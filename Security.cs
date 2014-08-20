using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading;
using Microsoft.Win32.SafeHandles;
using LSA_HANDLE = System.IntPtr;

namespace Useful.Utilities
{
    /// <summary>
    /// Security Utility Functions
    /// </summary>
    public class Security
    {
        public static class Privileges
        {
            public const string LogonAsASerivce = "SeServiceLogonRight";
        }

        /// <summary>
        /// Set logon as a service rights for the user.
        /// </summary>
        /// <param name="user">The username as domain\user. if domain is not provide machine name is used</param>
        /// <param name="remoteComputer">Can be used to execute on a remote computer.</param>
        public static void SetLogonAsAService(string user, string remoteComputer = null)
        {
            SetPrivilege(user, Privileges.LogonAsASerivce, remoteComputer);
        }

        /// <summary>
        /// Sets a privilege for the user.
        /// </summary>
        /// <param name="user">The username as domain\user. if domain is not provide machine name is used</param>
        /// <param name="privilege">The privilege to set. <see cref="LsaWrapper"/></param>
        /// <param name="remoteComputer">Can be used to execute on a remote computer.</param>
        public static void SetPrivilege(string user, string privilege, string remoteComputer = null)
        {
            user = ComputerManager.EnsureDomain(user);
            using (LsaWrapper lsa = new LsaWrapper(remoteComputer))
            {
                Trace.WriteLine(string.Format("Setting Privilege {0} for user {1}", privilege, user));
                lsa.AddPrivileges(user, privilege);
            }

        }

        /// <summary>
        /// Login as a given user and return the login token
        /// </summary>
        /// <param name="user">The user: domain\user</param>
        /// <param name="password">The password.</param>
        /// <param name="remoteComputer">The remote computer.</param>
        /// <returns></returns>
        internal static IntPtr Login(string user, string password, string remoteComputer = null)
        {
            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
                return IntPtr.Zero;
            user = ComputerManager.EnsureDomain(user);
            var domainUser = ComputerManager.SplitUserAndDomain(user);
            Trace.WriteLine(string.Format("Attempting Logon as {0}\\{1}", domainUser.Item1, domainUser.Item2));
            using (LsaWrapper lsa = new LsaWrapper(remoteComputer))
            {
                IntPtr token;
                if (lsa.Logon(domainUser.Item1, domainUser.Item2, password, out token))
                    return token;
            }
            return IntPtr.Zero;
        }

        /// <summary>
        /// Determines whether the specified username and password are valid. Can be ran locally or remotely
        /// </summary>
        /// <param name="user">The username: domain\user</param>
        /// <param name="password">The password.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="remoteComputer">Can be used to execute on a remote computer.</param>
        /// <returns></returns>
        public static bool IsValidLogin(string user, string password, string remoteComputer = null)
        {
            return Login(user, password, remoteComputer) != IntPtr.Zero;
            //if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(password))
            //    return false;
            //user = ComputerManger.EnsureDomain(user);
            //var domainUser = ComputerManger.SplitUserAndDomain(user);
            //Trace.WriteLine(string.Format("Attempting Logon as {0}\\{1}", domainUser.Item1, domainUser.Item2));
            //using (LsaWrapper lsa = new LsaWrapper(remoteComputer))
            //{
            //    return lsa.Logon(domainUser.Item1, domainUser.Item2, password);
            //}

        }

        /// <summary>
        /// Validates the username and password. Throws error if its invalid
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="domain">The domain.</param>
        /// <param name="remoteComputer">Can be used to execute on a remote computer.</param>
        /// <exception cref="System.InvalidOperationException">Thrown if Username and password is invalid!</exception>
        public static void ValidateLogin(string username, string password, string remoteComputer = null)
        {
            if (!IsValidLogin(username, password, remoteComputer))
                throw new InvalidOperationException("Username and password invalid!");
        }


        /// <summary>
        /// Determines whether the specified user is in a given role
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="role">The role.</param>
        /// <param name="remoteComputer">Can be used to execute on a remote computer.</param>
        /// <returns></returns>
        public static bool IsInRole(string username = null, string password = null, WindowsBuiltInRole role = WindowsBuiltInRole.Administrator, string remoteComputer = null)
        {
            WindowsIdentity identity;
            if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
            {
                var token = Login(username, password, remoteComputer);
                if (token == IntPtr.Zero) return false; //login failed
                identity = new WindowsIdentity(token);
                using (identity.Impersonate())
                {
                    var p = new WindowsPrincipal(identity);
                    return p.IsInRole(role);
                }

            }

            identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(role);

        }

        /// <summary>
        /// Runs an action as a different user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public static Impersonation RunAs(string username, string password)
        {
            username = ComputerManager.EnsureDomain(username);
            var domainUser = ComputerManager.SplitUserAndDomain(username);
            return new Impersonation(domainUser.Item1, domainUser.Item2, password);
        }

        #region lsawrapper
        [StructLayout(LayoutKind.Sequential)]
        internal struct LSA_OBJECT_ATTRIBUTES
        {
            internal int Length;
            internal IntPtr RootDirectory;
            internal IntPtr ObjectName;
            internal int Attributes;
            internal IntPtr SecurityDescriptor;
            internal IntPtr SecurityQualityOfService;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        internal struct LSA_UNICODE_STRING
        {
            internal ushort Length;
            internal ushort MaximumLength;
            [MarshalAs(UnmanagedType.LPWStr)]
            internal string Buffer;
        }

        public enum LogonType
        {
            /// <summary>
            /// This logon type is intended for users who will be interactively
            /// using the computer, such as a user being logged on by a
            /// terminal server, remote shell, or similar process.
            /// This logon type has the additional expense of caching logon
            /// information for disconnected operations; therefore, it is
            /// inappropriate for some client/server applications, such as a
            /// mail server.
            /// </summary>
            Interactive = 2,

            /// <summary>
            /// This logon type is intended for high performance servers to
            /// authenticate plaintext passwords.
            /// The LogonUser function does not cache credentials for this
            /// logon type.
            /// </summary>
            Network = 3,

            /// <summary>
            /// This logon type is intended for batch servers, where processes
            /// may be executing on behalf of a user without their direct
            /// intervention.  This type is also for higher performance servers
            /// that process many plaintext authentication attempts at a time,
            /// such as mail or Web servers.
            /// The LogonUser function does not cache credentials for this
            /// logon type.
            /// </summary>
            Batch = 4,

            /// <summary>
            /// Indicates a service-type logon.  The account provided must have
            /// the service privilege enabled.
            /// </summary>
            Service = 5,

            /// <summary>
            /// This logon type is for GINA DLLs that log on users who will be
            /// interactively using the computer.
            /// This logon type can generate a unique audit record that shows
            /// when the workstation was unlocked.
            /// </summary>
            Unlock = 7,

            /// <summary>
            /// This logon type preserves the name and password in the
            /// authentication package, which allows the server to make
            /// connections to other network servers while impersonating the
            /// client.  A server can accept plaintext credentials from a
            /// client, call LogonUser, verify that the user can access the
            /// system across the network, and still communicate with other
            /// servers.
            /// NOTE: Windows NT:  This value is not supported.
            /// </summary>
            NetworkCleartext = 8,

            /// <summary>
            /// This logon type allows the caller to clone its current token
            /// and specify new credentials for outbound connections.  The new
            /// logon session has the same local identifier but uses different
            /// credentials for other network connections.
            /// NOTE: This logon type is supported only by the
            /// LOGON32_PROVIDER_WINNT50 logon provider.
            /// NOTE: Windows NT:  This value is not supported.
            /// </summary>
            NewCredentials = 9

        }

        public enum LogonProvider
        {
            /// <summary>
            /// Use the standard logon provider for the system.
            /// The default security provider is negotiate, unless you pass
            /// NULL for the domain name and the user name is not in UPN format.
            /// In this case, the default provider is NTLM.
            /// NOTE: Windows 2000/NT:   The default security provider is NTLM.
            /// </summary>
            Default = 0,

            /// <summary>
            /// Use this provider if you'll be authenticating against a Windows
            /// NT 3.51 domain controller (uses the NT 3.51 logon provider).
            /// </summary>
            WinNT35 = 1,

            /// <summary>
            /// Use the NTLM logon provider.
            /// </summary>
            WinNT40 = 2,

            /// <summary>
            /// Use the negotiate logon provider.
            /// </summary>
            WinNT50 = 3
        }

        public enum ImpersonationLevel
        {
            SecurityAnonymous = 0,
            SecurityIdentification = 1,
            SecurityImpersonation = 2,
            SecurityDelegation = 3
        }
        internal sealed class Win32Sec
        {
            [DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
            internal static extern uint LsaOpenPolicy(
               LSA_UNICODE_STRING[] SystemName,
               ref LSA_OBJECT_ATTRIBUTES ObjectAttributes,
               int AccessMask,
               out IntPtr PolicyHandle
            );

            [DllImport("advapi32", CharSet = CharSet.Unicode, SetLastError = true), SuppressUnmanagedCodeSecurityAttribute]
            internal static extern uint LsaAddAccountRights(
               LSA_HANDLE PolicyHandle,
               IntPtr pSID,
               LSA_UNICODE_STRING[] UserRights,
               int CountOfRights
            );

            [DllImport("advapi32", SetLastError = true)]
            internal static extern int LsaNtStatusToWinError(int NTSTATUS);

            [DllImport("advapi32")]
            internal static extern int LsaClose(IntPtr PolicyHandle);

            [DllImport("advapi32", SetLastError = true)]
            internal static extern bool LogonUser(String lpszUsername,
                String lpszDomain, String lpszPassword, int dwLogonType,
                int dwLogonProvider, ref IntPtr phToken);

            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern int DuplicateToken(IntPtr hToken,
                  int impersonationLevel,
                  ref IntPtr hNewToken);

            [DllImport("advapi32.dll", SetLastError = true)]
            public static extern bool RevertToSelf();

            [DllImport("kernel32.dll")]
            public static extern bool CloseHandle(IntPtr handle);


        }

        sealed class Sid : IDisposable
        {
            public IntPtr pSid = IntPtr.Zero;
            public SecurityIdentifier sid = null;

            public Sid(string account)
            {
                try
                {
                    sid = (SecurityIdentifier)(new NTAccount(account)).Translate(typeof(SecurityIdentifier));
                    Byte[] buffer = new Byte[sid.BinaryLength];
                    sid.GetBinaryForm(buffer, 0);

                    pSid = Marshal.AllocHGlobal(sid.BinaryLength);
                    Marshal.Copy(buffer, 0, pSid, sid.BinaryLength);
                }
                catch (Exception e)
                {
                    Trace.WriteLine("Error getting Sid for account " + account + " " + e.Message);
                    throw;
                }
            }

            public void Dispose()
            {
                if (pSid != IntPtr.Zero)
                {
                    Marshal.FreeHGlobal(pSid);
                    pSid = IntPtr.Zero;
                }
                GC.SuppressFinalize(this);
            }
            ~Sid()
            {
                Dispose();
            }
        }

        public sealed class LsaWrapper : IDisposable
        {
            enum Access : int
            {
                POLICY_READ = 0x20006,
                POLICY_ALL_ACCESS = 0x00F0FFF,
                POLICY_EXECUTE = 0X20801,
                POLICY_WRITE = 0X207F8
            }
            const uint STATUS_ACCESS_DENIED = 0xc0000022;
            const uint STATUS_INSUFFICIENT_RESOURCES = 0xc000009a;
            const uint STATUS_NO_MEMORY = 0xc0000017;

            IntPtr lsaHandle;

            public LsaWrapper() : this(null) { }
            // local system if systemName is null
            public LsaWrapper(string systemName)
            {
                LSA_OBJECT_ATTRIBUTES lsaAttr;
                lsaAttr.RootDirectory = IntPtr.Zero;
                lsaAttr.ObjectName = IntPtr.Zero;
                lsaAttr.Attributes = 0;
                lsaAttr.SecurityDescriptor = IntPtr.Zero;
                lsaAttr.SecurityQualityOfService = IntPtr.Zero;
                lsaAttr.Length = Marshal.SizeOf(typeof(LSA_OBJECT_ATTRIBUTES));
                lsaHandle = IntPtr.Zero;
                LSA_UNICODE_STRING[] system = null;
                if (!ComputerManager.IsLocal(systemName))
                {
                    system = new LSA_UNICODE_STRING[1];
                    system[0] = InitLsaString(systemName);
                }

                uint ret = Win32Sec.LsaOpenPolicy(system, ref lsaAttr, (int)Access.POLICY_ALL_ACCESS, out lsaHandle);
                if (ret == 0)
                    return;
                if (ret == STATUS_ACCESS_DENIED)
                {
                    throw new UnauthorizedAccessException();
                }
                if ((ret == STATUS_INSUFFICIENT_RESOURCES) || (ret == STATUS_NO_MEMORY))
                {
                    throw new OutOfMemoryException();
                }
                throw new Win32Exception(Win32Sec.LsaNtStatusToWinError((int)ret));
            }

            public void AddPrivileges(string account, string privilege)
            {
                uint ret = 0;
                using (Sid sid = new Sid(account))
                {
                    LSA_UNICODE_STRING[] privileges = new LSA_UNICODE_STRING[1];
                    privileges[0] = InitLsaString(privilege);
                    ret = Win32Sec.LsaAddAccountRights(lsaHandle, sid.pSid, privileges, 1);
                }
                if (ret == 0)
                    return;
                if (ret == STATUS_ACCESS_DENIED)
                {
                    throw new UnauthorizedAccessException();
                }
                if ((ret == STATUS_INSUFFICIENT_RESOURCES) || (ret == STATUS_NO_MEMORY))
                {
                    throw new OutOfMemoryException();
                }
                throw new Win32Exception(Win32Sec.LsaNtStatusToWinError((int)ret));
            }
            public bool Logon(String sDomain, String sUser, String sPassword)
            {
                IntPtr t;
                return Logon(sDomain, sUser, sPassword, out t);
            }
            public bool Logon(String sDomain, String sUser, String sPassword, out IntPtr token)
            {
                return Logon(sDomain, sUser, sPassword, out token, LogonType.Network);
            }
            private bool Logon(String sDomain, String sUser, String sPassword, out IntPtr token, LogonType type)
            {
                token = IntPtr.Zero;
                try
                {
                    var succees = Win32Sec.LogonUser(sUser, sDomain, sPassword, (int)type, (int)LogonProvider.Default, ref token);
                    // did impersonation fail?
                    if (!succees)
                    {
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                        //int nErrorCode = Marshal.GetLastWin32Error();
                        //throw new UnauthorizedAccessException("LogonUser() failed with error code: " + nErrorCode);
                    }
                    return true;
                }
                catch (Exception e)
                {
                    Trace.WriteLine("SECURITY ERROR: " + e.Message);
                    Trace.TraceError(e.ToString());
                }
                return false;
            }


            public void Dispose()
            {
                if (lsaHandle != IntPtr.Zero)
                {
                    Win32Sec.LsaClose(lsaHandle);
                    lsaHandle = IntPtr.Zero;
                }
                GC.SuppressFinalize(this);
            }
            ~LsaWrapper()
            {
                Dispose();
            }
            // helper functions

            static LSA_UNICODE_STRING InitLsaString(string s)
            {
                // Unicode strings max. 32KB
                if (s.Length > 0x7ffe)
                    throw new ArgumentException("String too long");
                LSA_UNICODE_STRING lus = new LSA_UNICODE_STRING();
                lus.Buffer = s;
                lus.Length = (ushort)(s.Length * sizeof(char));
                lus.MaximumLength = (ushort)(lus.Length + sizeof(char));
                return lus;
            }
        }

        #endregion

        #region Impersonator
        public class Impersonation : IDisposable
        {
            private WindowsImpersonationContext _wic;

            /// <summary>
            /// Begins impersonation with the given credentials, Logon type and Logon provider.
            /// </summary>
            public Impersonation(string domainName, string userName, string password, LogonType logonType = LogonType.Interactive, LogonProvider logonProvider = LogonProvider.Default)
            {
                Impersonate(domainName, userName, password, logonType, logonProvider);
            }

            ///// <summary>
            ///// Begins impersonation with the given credentials.
            ///// </summary>
            //public Impersonation(string domainName, string userName, string password)
            //{
            //    Impersonate(domainName, userName, password, LogonType.Interactive, LogonProvider.Default);
            //}

            /// <summary>
            /// Initializes a new instance of the <see cref="Impersonation"/> class.
            /// </summary>
            public Impersonation()
            { }

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
                UndoImpersonation();
            }

            ///// <summary>
            ///// Impersonates the specified user account.
            ///// </summary>
            //public void Impersonate(string domainName, string userName, string password)
            //{
            //    Impersonate(domainName, userName, password, LogonType.Interactive, LogonProvider.Default);
            //}

            /// <summary>
            /// Impersonates the specified user account.
            /// </summary>
            public void Impersonate(string domainName, string userName, string password, LogonType logonType = LogonType.Interactive, LogonProvider logonProvider = LogonProvider.Default)
            {
                UndoImpersonation();

                IntPtr logonToken = IntPtr.Zero;
                IntPtr logonTokenDuplicate = IntPtr.Zero;
                try
                {
                    // revert to the application identity, saving the identity of the current requestor
                    _wic = WindowsIdentity.Impersonate(IntPtr.Zero);

                    // do logon & impersonate
                    if (Win32Sec.LogonUser(userName, domainName, password, (int)logonType, (int)logonProvider, ref logonToken))
                    {
                        if (Win32Sec.DuplicateToken(logonToken, (int)ImpersonationLevel.SecurityImpersonation, ref logonTokenDuplicate) != 0)
                        {
                            var wi = new WindowsIdentity(logonTokenDuplicate);
                            wi.Impersonate(); // discard the returned identity context (which is the context of the application pool)
                        }
                        else
                            throw new Win32Exception(Marshal.GetLastWin32Error());
                    }
                    else
                        throw new Win32Exception(Marshal.GetLastWin32Error());
                }
                finally
                {
                    if (logonToken != IntPtr.Zero)
                        Win32Sec.CloseHandle(logonToken);

                    if (logonTokenDuplicate != IntPtr.Zero)
                        Win32Sec.CloseHandle(logonTokenDuplicate);
                }
            }

            /// <summary>
            /// Stops impersonation.
            /// </summary>
            private void UndoImpersonation()
            {
                // restore saved requestor identity
                if (_wic != null)
                    _wic.Undo();
                _wic = null;
            }
        }
    }
        #endregion


}

