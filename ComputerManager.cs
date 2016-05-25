using System;
using System.Collections.Generic;
using System.Linq;
using Useful.Utilities.Models;

namespace Useful.Utilities
{
 
    /// <summary>
    /// Collection of computer, domain, and user name functions
    /// </summary>
    public class ComputerManager : WMI
    {

        ///// <summary>
        ///// Initializes a new instance of the <see cref="ComputerManager"/> class.
        ///// </summary>
        //private ComputerManager() : base() { }
        ///// <summary>
        ///// Creates a new instance of Process Manager connected to a remote computer
        ///// </summary>
        //private ComputerManager(string server) : base(server) { }
        /// <summary>
        /// Creates a new instance of the Process Manager connected to a remote server as a different user
        /// </summary>
        private ComputerManager(string server, string username, string password) : base(server, username, password) { }

        private ComputerInfo _computer;
        /// <summary>
        /// Gets information about the computer currently connected to. 
        /// </summary>
        /// <returns></returns>
        public ComputerInfo Computer()
        {
            if (_computer != null) return _computer;
            var result = GetObjects("Win32_ComputerSystem");
            return _computer = result.Select(ComputerInfo.CreateComputerInfo).FirstOrDefault();
        }

        public List<FeatureInfo> Features()
        {
            var result = GetObjects("Win32_ServerFeature");
            return result.Select(FeatureInfo.CreateFeatureInfo).ToList();
        }

        /// <summary>
        /// Connects to the computer name passed in, leave blank for local
        /// </summary>
        /// <param name="computerName">Name of the computer. Leave blank for local</param>
        /// <param name="username">The username to connect as. Leave blank for current user</param>
        /// <param name="password">The password for username if provided.</param>
        /// <returns></returns>
        public static ComputerManager Connect(string computerName = "", string username = "", string password = "")
        {
            return new ComputerManager(computerName, username, password);
        }



        #region local only function
        /// <summary>
        /// Gets the full domain name of the current computer (without the computer name). 
        /// Use <see cref="MachineFullName"/> to get FQN of current computer.
        /// </summary>
        public static string DomainNameFull
        {
            get
            {
                return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
        }

        /// <summary>
        /// Gets the Domain Net Bios of the current user. 
        /// </summary>
        public static string DomainNameBios { get { return Environment.UserDomainName; } }

        /// <summary>
        /// Gets the username of current user
        /// </summary>
        public static string UserName { get { return Environment.UserName; } }

        /// <summary>
        /// Gets the domain and username of current user. Domain\User
        /// </summary>
        public static string UserQualified
        {
            get
            {
                return Environment.UserDomainName + "\\" + Environment.UserName;
            }
        }

        /// <summary>
        /// Splits the username and domain into a Tuple. Domain is Item1, User is Item2.
        /// </summary>
        /// <param name="username">The Domain\Username or User@domain string to parse.</param>
        /// <returns>Domain is Item1, Username is Item2</returns>
        public static Tuple<string, string> SplitUserAndDomain(string username)
        {
            string[] parts;
            if (username.Contains("\\"))
            {
                parts = username.Split('\\');
                return new Tuple<string, string>(parts[0], parts[1]);
            }
            if (username.Contains("@"))
            {
                //todo should convert domain name to NetBIOS name of domain
                parts = username.Split('@');
                return new Tuple<string, string>(parts[1], parts[0]);
            }
            return new Tuple<string, string>(string.Empty, username);
        }


        /// <summary>
        /// Ensures the username as a domain prefix. If no prefix is given machine name is used.
        /// </summary>
        /// <param name="user">The username to check for domain.</param>
        /// <returns>domain\user or machine\user</returns>
        public static string EnsureDomain(string user)
        {
            var domainUser = SplitUserAndDomain(user);
            var domain = domainUser.Item1;
            user = domainUser.Item2;
            if (string.IsNullOrWhiteSpace(domain))
                domain = MachineName;
            return domain + "\\" + user;
        }

        /// <summary>
        /// Gets the Machine name of the current computer (without domain). 
        /// Use <see cref="MachineFullName"/> to get the FQN of the current computer.
        /// </summary>
        public static string MachineName { get { return Environment.MachineName; } }

        /// <summary>
        /// Gets the fully qualified name of the current computer. computer.domain.com
        /// </summary>
        public static string MachineFullName
        {
            get
            {
                return System.Net.Dns.GetHostEntry(Environment.MachineName).HostName;
            }
        }

        /// <summary>
        /// Checks if the name passed in is the current computer. 
        /// Returns true if the string is null/empty or the name matches the current <see cref="MachineName"/> or <see cref="MachineFullName"/>.
        /// </summary>
        /// <param name="serverName">Computer name to check</param>
        /// <returns></returns>
        public static bool IsLocal(string serverName)
        {
            if (string.IsNullOrWhiteSpace(serverName) || serverName == "." || serverName.Equals("localHost", StringComparison.InvariantCultureIgnoreCase)) 
                return true;
            if (serverName.Contains(".")
                && serverName.Equals(MachineFullName, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (serverName.Equals(MachineName, StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }
        #endregion


    }
}
