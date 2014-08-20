using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Useful.Utilities
{


    public static class Network
    {
        public static string IpAddress(string computer)
        {
            if (!string.IsNullOrWhiteSpace(computer))
            {
                try
                {
                    IPAddress ip = Dns.GetHostAddresses(computer).FirstOrDefault(i => i.AddressFamily == AddressFamily.InterNetwork);
                    if (ip != null)
                        return ip.ToString();
                }
                catch (Exception ex)
                {
                    throw new Exception("Invalid Computer Name", ex);
                }
            }
            return "127.0.0.1";
        }
        
    }

    /// <summary>
    /// Create a connection to a shared folder with a different set of credentials 
    /// </summary>
    /// <example>
    /// Connect to a server share and copy a file as a different user:
    /// <code lang="c#">
    /// using (new SharedFolderConnection(@"\\192.168.1.9", new NetworkCredential("user", "password", "domain")))
    /// {
    ///     File.Copy(@"\\192.168.1.9\some share\some file.txt", @"c:\dest\some file.txt", true); 
    /// }
    /// </code>
    /// </example>
    public class SharedFolderConnection : NetworkConnection
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SharedFolderConnection"/> class.
        /// </summary>
        /// <param name="unc">The unc. \\Server</param>
        /// <param name="credentials">The <see cref="NetworkCredential"/>.</param>
        public SharedFolderConnection(string unc, NetworkCredential credentials)
            : base(new NetResource()
            {
                Scope = ResourceScope.GlobalNetwork,
                ResourceType = ResourceType.Disk,
                DisplayType = ResourceDisplaytype.Share,
                RemoteName = unc

            }, credentials)
        { }

    }

    /// <summary>
    /// Creates a connection to a network resource with a given set of credentials
    /// </summary>
    public class NetworkConnection : IDisposable
    {
        readonly string _networkName;

        internal NetworkConnection(NetResource resource, NetworkCredential credentials)
        {
            _networkName = resource.RemoteName;
            var userName = string.IsNullOrEmpty(credentials.Domain)
                ? credentials.UserName
                : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

            var result = WNetAddConnection2(resource, credentials.Password, userName, 0);

            if (result != 0)
            {
                throw new Win32Exception(result, "Error connecting to remote share " + result);
            }
        }

        ~NetworkConnection()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            WNetCancelConnection2(_networkName, 0, true);
        }

        [DllImport("mpr.dll")]
        private static extern int WNetAddConnection2(NetResource netResource, string password, string username, int flags);

        [DllImport("mpr.dll")]
        private static extern int WNetCancelConnection2(string name, int flags, bool force);

        [StructLayout(LayoutKind.Sequential)]
        public class NetResource
        {
            public ResourceScope Scope;
            public ResourceType ResourceType;
            public ResourceDisplaytype DisplayType;
            public int Usage;
            public string LocalName;
            public string RemoteName;
            public string Comment;
            public string Provider;
        }

        public enum ResourceScope : int
        {
            Connected = 1,
            GlobalNetwork,
            Remembered,
            Recent,
            Context
        };

        public enum ResourceType : int
        {
            Any = 0,
            Disk = 1,
            Print = 2,
            Reserved = 8,
        }

        public enum ResourceDisplaytype : int
        {
            Generic = 0x0,
            Domain = 0x01,
            Server = 0x02,
            Share = 0x03,
            File = 0x04,
            Group = 0x05,
            Network = 0x06,
            Root = 0x07,
            Shareadmin = 0x08,
            Directory = 0x09,
            Tree = 0x0a,
            Ndscontainer = 0x0b
        }
    }


}
