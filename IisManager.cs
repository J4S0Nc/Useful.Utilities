using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Web.Administration;
using Microsoft.Win32;

namespace Useful.Utilities
{
    /// <summary>
    /// IIS Server Manager Wrapper. can be used for local and remote IIS settings
    /// </summary>
    public class IisManager : IDisposable
    {
        //http://blogs.msdn.com/b/carlosag/archive/2006/04/17/microsoftwebadministration.aspx

        /// <summary>
        /// Application level Ssl Flags
        /// </summary>
        public enum ApplicationSslFlags
        {
            None, Ssl, SslNegotiateCert, SslRequireCert
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="IisManager"/> class.
        /// </summary>
        private IisManager() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="IisManager"/> class connected to a remote computer
        /// </summary>
        /// <param name="remoateServer">The remote server.</param>
        private IisManager(string remoteServer)
        {
            RemoteServer = remoteServer;
        }

        public static IisManager Connect(string remoateServer = null)
        {
            return new IisManager(remoateServer);
        }
        /// <summary>
        /// The remote server currently connected to.
        /// </summary>
        public string RemoteServer { get; private set; }

        private ServerManager _svcMan;

        /// <summary>
        /// Gets the server manager. Either local or remote based on <see cref="RemoteServer"/>
        /// </summary>
        protected internal ServerManager serverManager
        {
            get
            {
                return _svcMan ?? (_svcMan = ComputerManager.IsLocal(RemoteServer)
                            ? new ServerManager()
                            : ServerManager.OpenRemote(RemoteServer));
            }
        }

        #region Sites
        /// <summary>
        /// List all IIS web sites
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Site> ListSites()
        {
            return serverManager.Sites;
        }

        /// <summary>
        /// List all IIS web sites
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> ListSiteNames()
        {
            return serverManager.Sites.Select(s=> s.Name);
        }

        /// <summary>
        /// Get single site by name
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <returns></returns>
        public Site GetSite(string siteName)
        {
            return serverManager.Sites[siteName];
        }

        /// <summary>
        /// Get site state (stopped, running, etc)
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <returns></returns>
        public ObjectState SiteState(string siteName)
        {
            return serverManager.Sites[siteName].State;
        }

        /// <summary>
        /// Stop IIS site by name
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        public void StopSite(string siteName)
        {
            serverManager.Sites[siteName].Stop(); serverManager.CommitChanges();
        }

        /// <summary>
        /// Attempt to start a site by name
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        public void StartSite(string siteName)
        {
            serverManager.Sites[siteName].Start(); serverManager.CommitChanges();
        }

        /// <summary>
        /// Get all worker process for all application pools
        /// </summary>
        /// <returns></returns>
        public IEnumerable<WorkerProcess> Processes()
        {
            return serverManager.WorkerProcesses;
        }

        /// <summary>
        /// Create a new web site on port 443 
        /// </summary>
        /// <param name="siteName">site name</param>
        /// <param name="path">root directory of site</param>
        /// <param name="certHash">certificate thumbprint</param>
        /// <param name="port">port</param>
        /// <returns></returns>
        public Site CreateSslSite(string siteName, string path, string certHash = null, int port = 443)
        {
            return CreateSite(siteName, path, port, certHash);
        }

        /// <summary>
        /// Create a new web site
        /// </summary>
        /// <param name="siteName">display name</param>
        /// <param name="path">Root directory</param>
        /// <param name="port">port</param>
        /// <param name="certHash">certificate thumbprint</param>
        /// <returns></returns>
        public Site CreateSite(string siteName, string path, int port = 80, string certHash = null)
        {
            if (!System.IO.Directory.Exists(path))
                System.IO.Directory.CreateDirectory(path);

            var newSite = serverManager.Sites.Add(siteName, path, port);

            if (!string.IsNullOrWhiteSpace(certHash))
                SetBinding(siteName, "*", port, "", certHash, true);

            serverManager.CommitChanges();
            return newSite;
        }
        
        /// <summary>
        /// delete a site
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        public void DeleteSite(string siteName)
        {
            serverManager.Sites[siteName].Delete();
            serverManager.CommitChanges();
        }
        #endregion

        #region Bindings
        public IEnumerable<Binding> Bindings(string siteName)
        {
            var site = serverManager.Sites[siteName];
            return site.Bindings;
        }
        public void DeleteBinding(string siteName, int index)
        {
            serverManager.Sites[siteName].Bindings.RemoveAt(index);
            serverManager.CommitChanges();
        }

        public void DeleteAllBindings(string siteName)
        {
            serverManager.Sites[siteName].Bindings.Clear();
            serverManager.CommitChanges();
        }
       
        /// <summary>
        /// Create or update a binding on the given site. 
        /// </summary>
        /// <param name="siteName">Site name</param>
        /// <param name="ip">Ip to apply binding to. Use * for all</param>
        /// <param name="port">Port to apply binding to</param>
        /// <param name="hostheader">Optional host header</param>
        /// <param name="certThumb">Optional Cert thumb print, if Set protocol will be https</param>
        /// <param name="removeAllOthers">Flag to clear all other bindings on site</param>
        /// <returns></returns>
        public Binding SetBinding(string siteName, string ip = "*", int port = 80, string hostheader = "", string certThumb = "", bool removeAllOthers = false)
        {
            Binding binding = null;
            if (removeAllOthers) serverManager.Sites[siteName].Bindings.Clear();

            string bindingInfo = string.Format("{0}:{1}:{2}", ip, port, hostheader);

            var existing = serverManager.Sites[siteName].Bindings.FirstOrDefault(b => b.BindingInformation.StartsWith(bindingInfo));
            if (existing != null)
                serverManager.Sites[siteName].Bindings.Remove(existing);

            if (string.IsNullOrWhiteSpace(certThumb))
                binding = serverManager.Sites[siteName].Bindings.Add(bindingInfo, "http");
            else
            {
                var cert = Certificate.GetByThumbprint(certThumb);
                binding = serverManager.Sites[siteName].Bindings.Add(bindingInfo, cert.GetCertHash(), "My");
                binding.Protocol = "https";
            }
            serverManager.CommitChanges();
            return binding;
        }
        #endregion

        #region Applications
        /// <summary>
        /// Get list of applications for a site
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <returns></returns>
        public IEnumerable<Application> ListApplications(string siteName)
        {
            return serverManager.Sites[siteName].Applications;

        }
        /// <summary>
        /// Get an application under the given site
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <param name="appName">Name of the application.</param>
        /// <returns></returns>
        public Application GetApplication(string siteName, string appName)
        {
            if (!appName.StartsWith("/")) appName = "/" + appName;
            return serverManager.Sites[siteName].Applications.FirstOrDefault(
                    a => a.Path.Equals(appName, StringComparison.CurrentCultureIgnoreCase));
        }

        /// <summary>
        /// create or update an application under a site
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <param name="appName">Name of the application.</param>
        /// <param name="path">The physical path.</param>
        /// <param name="poolName">Name of the application pool.</param>
        /// <param name="allowAnonymousAccess">Flag to allow anonymous access.</param>
        /// <param name="windowsAuth">Flag to enable windows authentication.</param>
        /// <param name="sslFlags">The SSL flags.</param>
        /// <returns></returns>
        public Application SetApplication(string siteName, string appName, string path, string poolName, bool allowAnonymousAccess = true, bool windowsAuth = false, ApplicationSslFlags sslFlags = ApplicationSslFlags.None)
        {
            if (!appName.StartsWith("/")) appName = "/" + appName;
            var app = serverManager.Sites[siteName].Applications.FirstOrDefault(a => a.Path.Equals(appName, StringComparison.CurrentCultureIgnoreCase)) ??
                              serverManager.Sites[siteName].Applications.Add(appName, path);

            var configuration = serverManager.GetApplicationHostConfiguration();
            
            var winAuth = configuration.GetSection("system.webServer/security/authentication/windowsAuthentication", siteName + appName);
            winAuth["enabled"] = windowsAuth;


            var anonymousAuth = configuration.GetSection("system.webServer/security/authentication/anonymousAuthentication", siteName + appName);
            anonymousAuth["enabled"] = allowAnonymousAccess;

            var sslFlag = configuration.GetSection("system.webServer/security/access", siteName + appName);
            sslFlag["sslFlags"] = sslFlags.ToString();

            app.Path = appName; //Virtual path
            var v = app.VirtualDirectories["/"] ?? app.VirtualDirectories.Add(appName, app.Path);
            v.PhysicalPath = path;
            app.ApplicationPoolName = poolName;
            serverManager.CommitChanges();
            return app;
        }



        /// <summary>
        /// Deletes an application under a site.
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <param name="appName">Name of the application.</param>
        public void DeleteApplication(string siteName, string appName)
        {
            if (!appName.StartsWith("/")) appName = "/" + appName;
            serverManager.Sites[siteName].Applications[appName].Delete();
            serverManager.CommitChanges();
        }

        /// <summary>
        /// Change the pool tied to an application
        /// </summary>
        /// <param name="siteName">Name of the site.</param>
        /// <param name="appName">Name of the application.</param>
        /// <param name="poolName">Name of the application pool.</param>
        public void SetApplicationPool(string siteName, string appName, string poolName)
        {
            if (!appName.StartsWith("/")) appName = "/" + appName;
            serverManager.Sites[siteName].Applications[appName].ApplicationPoolName = poolName;
            serverManager.CommitChanges();
        }
        #endregion

        #region Application Pools

        /// <summary>
        /// Lists all the application pools.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ApplicationPool> ListPools()
        {
            return serverManager.ApplicationPools;
        }

        /// <summary>
        /// Gets the application pool by name.
        /// </summary>
        /// <param name="poolName">Name of the application pool.</param>
        /// <returns></returns>
        public ApplicationPool GetPool(string poolName)
        {
            return serverManager.ApplicationPools.FirstOrDefault(a => a.Name.Equals(poolName, StringComparison.CurrentCultureIgnoreCase));
        }


        /// <summary>
        /// Recycles the pool.
        /// </summary>
        /// <param name="poolName">Name of the application pool.</param>
        public void RecyclePool(string poolName)
        {
            var pool = serverManager.ApplicationPools.FirstOrDefault(a => a.Name.Equals(poolName, StringComparison.CurrentCultureIgnoreCase));
            if (pool == null) return;
            pool.Recycle();
            serverManager.CommitChanges();
        }

        /// <summary>
        /// Deletes the application pool.
        /// </summary>
        /// <param name="poolName">Name of the application pool.</param>
        public void DeletePool(string poolName)
        {
            var pool = serverManager.ApplicationPools.FirstOrDefault(a => a.Name.Equals(poolName, StringComparison.CurrentCultureIgnoreCase));
            if (pool == null) return;
            pool.Delete();
            serverManager.CommitChanges();
        }

        /// <summary>
        /// create or update an application pool
        /// </summary>
        /// <param name="name">The application pool name.</param>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="maxProcesses">The maximum processes. 0 for default</param>
        /// <param name="version">The version.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception"></exception>
        public ApplicationPool SetPool(string name, string username = "", string password = "", int maxProcesses = 0, string version = "v4.0")
        {
            try
            {
                ApplicationPool pool;
                pool = GetPool(name) == null ? serverManager.ApplicationPools.Add(name) : serverManager.ApplicationPools[name];

                if (string.IsNullOrWhiteSpace(version)) version = "v4.0";
                pool.ManagedRuntimeVersion = version;

                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    pool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                    pool.ProcessModel.UserName = username;
                    pool.ProcessModel.Password = password;
                }

                if (maxProcesses > 0)
                    pool.ProcessModel.MaxProcesses = maxProcesses;

                serverManager.CommitChanges();
                return pool;
            }
            catch (Exception ex)
            {
                throw new Exception(string.Format("Error setting application pool! Name: {0}", name), ex);
            }
        }

        #endregion

        public void Dispose()
        {
            if (_svcMan != null)
                _svcMan.Dispose();
        }
        /// <summary>
        /// Refreshes this instance and restarts the <see cref="serverManager"/>
        /// </summary>
        public void Refresh()
        {
            _svcMan.Dispose();
            _svcMan = null;
        }

        /// <summary>
        /// Commits the <see cref="serverManager"/> changes.
        /// </summary>
        public void CommitChanges() { serverManager.CommitChanges(); }

        /// <summary>
        /// Resets IIS. Mode can be Restart, Stop, or Start
        /// </summary>
        /// <param name="mode">The mode argument. Can be Restart, Stop, or Start</param>
        /// <returns></returns>
        public static bool ResetIis(string mode = "restart")
        {
            return ProcessManager.Run("iisreset.exe", "/" + mode, true) == 0;
        }

        /// <summary>
        /// IIS version number. 0 if not installed or error
        /// </summary>
        /// <param name="remoteComputer">The remote computer.</param>
        /// <returns></returns>
        public static float IisVersion(string remoteComputer = "")
        {
            try
            {
                var key = RegistryHelper.GetKey(RegistryHive.LocalMachine, @"Software\Microsoft\InetStp", remoteComputer);
                var majorVersion = RegistryHelper.GetValue(key, "MajorVersion", 0);
                var minorVersion = RegistryHelper.GetValue(key, "MinorVersion", 0);
                return float.Parse(majorVersion + "." + minorVersion);
            }
            catch
            {
                return 0;
            }
        }

    }
}
