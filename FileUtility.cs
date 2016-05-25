using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

namespace Useful.Utilities
{
    /// <summary>
    /// File Utility functions
    /// </summary>
    public static class FileUtility
    {

        /// <summary>
        /// Tries to create a file stream. On error, the thread sleeps and retries until the max retry number is hit.
        /// </summary>
        /// <param name="file">File path</param>
        /// <param name="mode">file mode</param>
        /// <param name="access">file access</param>
        /// <param name="share">file share</param>
        /// <param name="retry">Number of retries to attempt on error</param>
        /// <param name="waitMs">number of milliseconds to sleep between retries</param>
        /// <returns></returns>
        /// <exception cref="IOException">Throws IOExecption if max retry is hit</exception>
        public static FileStream WaitForFile(string file, FileMode mode = FileMode.Create, FileAccess access = FileAccess.Write, FileShare share = FileShare.ReadWrite, int retry = 5, int waitMs = 1000)
        {
            if (!File.Exists(file))
                return new FileStream(file, mode, access, share);

            try
            {
                return File.Open(file, mode, access, share);
            }
            catch (IOException)
            {
                if (retry > 0)
                {
                    Thread.Sleep(waitMs);
                    return WaitForFile(file, mode, access, share, --retry, waitMs);
                }
                throw;
            }

        }

        /// <summary>
        /// Checks if a file is locked by attempting to open it. 
        /// </summary>
        /// <param name="file">File Path to open</param>
        /// <param name="mode"></param>
        /// <param name="access"></param>
        /// <param name="share"></param>
        /// <returns></returns>
        public static bool IsFileLocked(string file, FileMode mode = FileMode.Create, FileAccess access = FileAccess.Write, FileShare share = FileShare.ReadWrite)
        {
            if (!File.Exists(file)) return false;
            FileStream stream = null;
            try
            {
                stream = File.Open(file, mode, access, share);
            }
            catch (IOException)
            {
                return true;
            }
            finally
            {
                if (stream != null)
                    stream.Close();
            }
            return false;
        }

        /// <summary>
        /// Checks if a file exists. If remote computer is passed in the path is converted to a UNC first
        /// </summary>
        /// <param name="path">File path to check</param>
        /// <param name="computer">optional remote computer name to check for the file</param>
        /// <returns></returns>
        public static bool FileExists(string path, string computer = "")
        {
            return File.Exists(ComputerManager.IsLocal(computer) ? path : GetUniversalPath(path, computer));
        }

        /// <summary>
        /// Ensures the destination directory exists then copies a file.
        /// </summary>
        /// <param name="source">The source file path.</param>
        /// <param name="dest">The destination file path.</param>
        /// <param name="overwrite">allow destination file to be overwritten if it exists.</param>
        public static void CopyFile(string source, string dest, bool overwrite = true)
        {
            var dPath = Path.GetDirectoryName(dest);
            if (dPath != null && !Directory.Exists(dPath))
                Directory.CreateDirectory(dPath);
             File.Copy(source,dest, overwrite);
        }


        /// <summary>
        /// Takes a local file path and translates it into a UNC file path where possible.
        /// </summary>
        /// <param name="path">Path to convert to UNC.</param>
        /// <param name="computer">Machine name to use, if not set uses local machine</param>
        /// <returns>UNC path otherwise throws arg error.</returns>
        public static string GetUniversalPath(string path, string computer = "")
        {
            if (ComputerManager.IsLocal(computer)) computer = Environment.MachineName;

            var shares = new WindowsShares().EnumNetShares(computer);
            if (shares == null || shares.Count == 0)
                throw new ArgumentException(computer + " has no accessible shares!");
            foreach (WindowsShares.ShareInfo shareInfo in shares)
            {
                if (shareInfo.Path.Length > 0
                 && path.StartsWith(shareInfo.Path, StringComparison.OrdinalIgnoreCase))
                {
                    string pathRemainder = path.Substring(shareInfo.Path.Length);
                    return Path.Combine(@"\\", computer, shareInfo.ShareName, pathRemainder);
                }
            }
            throw new ArgumentException(computer + " has no share found matching path: " + path);
        }


        /// <summary>
        /// Clears the read only flag on a file
        /// </summary>
        /// <param name="path">Path to the file</param>
        public static void ClearReadOnly(string path)
        {
            var file = new FileInfo(path) { IsReadOnly = false };
            file.Refresh();

        }

        /// <summary>
        /// Support class for listing windows shares
        /// </summary>
        public class WindowsShares
        {
            //todo might move to network class
            #region External Calls
            [DllImport("Netapi32.dll", SetLastError = true)]
            static extern int NetApiBufferFree(IntPtr Buffer);
            [DllImport("Netapi32.dll", CharSet = CharSet.Unicode)]
            private static extern int NetShareEnum(
                 StringBuilder ServerName,
                 int level,
                 ref IntPtr bufPtr,
                 uint prefmaxlen,
                 ref int entriesread,
                 ref int totalentries,
                 ref int resume_handle
                 );
            #endregion
            #region External Structures
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            public struct ShareInfo
            {
                public string ShareName;
                public uint ShareType;
                public string Remark;
                public uint Permissions;
                public uint MaxUses;
                public uint CurrentUses;
                public string Path;
                public string Password;

                public ShareInfo(string netname, uint type, string remark, uint permissions,
                        uint max_uses, uint current_uses, string path, string password)
                {
                    ShareName = netname;
                    ShareType = type;
                    Remark = remark;
                    Permissions = permissions;
                    MaxUses = max_uses;
                    CurrentUses = current_uses;
                    Path = path;
                    Password = password;
                }
            }
            #endregion
            const uint MAX_PREFERRED_LENGTH = 0xFFFFFFFF;
            const int SuccessCode = 0;

            public List<ShareInfo> EnumNetShares(string server)
            {
                List<ShareInfo> shareInfos = new List<ShareInfo>();
                int entriesread = 0;
                int totalentries = 0;
                int resumeHandle = 0;
                int nStructSize = Marshal.SizeOf(typeof(ShareInfo));
                IntPtr bufPtr = IntPtr.Zero;
                StringBuilder srvr = new StringBuilder(server);
                int ret = NetShareEnum(srvr, 2, ref bufPtr, MAX_PREFERRED_LENGTH,
                               ref entriesread, ref totalentries, ref resumeHandle);
                if (ret == SuccessCode)
                {
                    IntPtr currentPtr = bufPtr;
                    for (int i = 0; i < entriesread; i++)
                    {
                        ShareInfo shi1 =
                            (ShareInfo)Marshal.PtrToStructure(currentPtr, typeof(ShareInfo));
                        shareInfos.Add(shi1);
                        currentPtr = new IntPtr(currentPtr.ToInt32() + nStructSize);
                    }
                    NetApiBufferFree(bufPtr);
                    return shareInfos;
                }
                return null;
            }
        }
    }
}
