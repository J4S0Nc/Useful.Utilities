using System.Net;

namespace Useful.Utilities
{
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
}