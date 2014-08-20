using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Management;
using System.Net;
using System.Threading;


namespace Useful.Utilities
{
    /// <summary>
    /// Windows Management Interface Wrapper class. Handles scoping WMI calls for local or remote computers
    /// </summary>
    public class WMI : IDisposable
    {

        /// <summary>
        /// Convert the property data collection to a string object dictionary
        /// </summary>
        /// <param name="mo">ManagementBaseObject</param>
        /// <returns>Dictionary{string,object}</returns>
        public static Dictionary<string, object> GetProperties(ManagementBaseObject mo)
        {
            return mo.Properties.Cast<PropertyData>().ToDictionary(prop => prop.Name, prop => prop.Value);
        }


        #region Constructor

        /// <summary>
        /// Creates a new instance of the wrapper
        /// </summary>
        public WMI()
        {
            Initialise(null, null, null);
        }

        /// <summary>
        /// Creates a new instance of the wrapper connected to a remote server
        /// </summary>
        public WMI(string server)
        {
            Initialise(server, null, null);
        }
        /// <summary>
        /// Creates a new instance of the wrapper connected to a remote server as a different user
        /// </summary>
        public WMI(string server, string username, string password)
        {
            Initialise(server, username, password);
        }

        #endregion

        #region Destructor

        /// <summary>
        /// Clean up unmanaged references
        /// </summary>
        ~WMI()
        {
            Dispose(false);
        }

        #endregion

        #region Initialise

        /// <summary>
        /// Initializes the WMI connection
        /// </summary>
        /// <param name="username">Username to connect to server with</param>
        /// <param name="password">Password to connect to server with</param>
        /// <param name="server">Server to connect to</param>
        private void Initialise(string server, string username, string password)
        {
            if (ComputerManager.IsLocal(server))
                server = Dns.GetHostEntry(Environment.MachineName).HostName;

            Server = server;
            Username = username;
            Password = password;

            // set connection options
            ConnectionOptions = new ConnectionOptions();
            
            if (ComputerManager.IsLocal(server) || string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return;

            ConnectionOptions.Username = username;
            ConnectionOptions.Password = password;
            ConnectionOptions.Impersonation = ImpersonationLevel.Impersonate;
            ConnectionOptions.EnablePrivileges = true;
        }

        #endregion

        #region wmi objects

        /// <summary>
        /// Creates a <see cref="ManagementScope"/> scoped to the current connection
        /// </summary>
        /// <returns></returns>
        internal protected ManagementScope Scope()
        {
            return new ManagementScope(String.Format("\\\\{0}\\root\\{1}", Server, WmiNameSpace), ConnectionOptions);
        }
        /// <summary>
        /// Creates a <see cref="ManagementObject"/> scoped to the current connection
        /// </summary>
        /// <param name="path">The WMI path</param>
        /// <param name="options">Additional options, if needed</param>
        /// <returns></returns>
        internal protected ManagementObject ScopedObject(string path, ObjectGetOptions options = null)
        {
            return new ManagementObject(Scope(), new ManagementPath(path), options);
        }
        /// <summary>
        /// Creates a <see cref="ManagementClass"/> scoped to the current connection
        /// </summary>
        /// <param name="path">The WMI path</param>
        /// <param name="options">Additional options, if needed</param>
        /// <returns></returns>
        internal protected ManagementClass ScopedClass(string path, ObjectGetOptions options = null)
        {
            return new ManagementClass(Scope(), new ManagementPath(path), options);
        }

        /// <summary>
        /// Get an instance of the specified class
        /// </summary>
        /// <param name="wmiClass">Type of the class</param>
        /// <returns>Array of management objects</returns>
        internal protected ManagementObject[] GetObjects(string wmiClass)
        {
            var wmiSearcher = new ManagementObjectSearcher(Scope(),
                    new WqlObjectQuery(string.Format("SELECT * FROM {0}", wmiClass)), null);

            return wmiSearcher.Get().Cast<ManagementObject>().ToArray();
        }

        /// <summary>
        /// Get an instance of the specified class filtered by a where clause
        /// </summary>
        /// <param name="wmiClass">Type of the class</param>
        /// <param name="where">The where clause filter to apply</param>
        /// <returns></returns>
        internal protected ManagementObject[] GetObjects(string wmiClass, string where)
        {
            var wmiSearcher = new ManagementObjectSearcher(Scope(),
                    new WqlObjectQuery(string.Format("SELECT * FROM {0} where {1}", wmiClass, where)), null);

            return wmiSearcher.Get().Cast<ManagementObject>().ToArray();
        }

        /// <summary>
        /// Get an instance of the specified class filtered by name
        /// </summary>
        /// <param name="wmiClass">Type of the class</param>
        /// <param name="name">The name to filter by</param>
        /// <returns></returns>
        internal protected ManagementObject[] GetObjectsByName(string wmiClass, string name)
        {
            return GetObjects(wmiClass, "name = '" + name + "'");
        }

        internal protected ReturnValue InvokeMethod(ManagementObject obj, string method, ManagementBaseObject inParams = null, InvokeMethodOptions methodOptions = null)
        {
            try
            {
                var rtn = (obj.InvokeMethod(method, inParams, methodOptions));
                return Helpers.ToEnum<ReturnValue>(rtn["ReturnValue"].ToString());
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Trim() == "not found" || ex.GetHashCode() == 41149443)
                    return ReturnValue.ServiceNotFound;
                throw;
            }
        }

        #endregion

        #region additional WMI functions not being used
        // /// <summary>
        ///// Return a list of available wmi namespaces
        ///// </summary>
        ///// <returns></returns>
        //public List<String> GetWMINamespaces()
        //{
        //    ManagementScope wmiScope = new ManagementScope(String.Format("\\\\{0}\\root", this.Server),
        //                                                   this.ConnectionOptions);
        //    List<String> wmiNamespaceList = new List<String>();

        //    ManagementClass wmiNamespaces = new ManagementClass(wmiScope, new ManagementPath("__namespace"), null);
        //    ;

        //    foreach (ManagementObject ns in wmiNamespaces.GetInstances())
        //        wmiNamespaceList.Add(ns["Name"].ToString());

        //    return wmiNamespaceList;
        //}

        ///// <summary>
        ///// Return a list of available classes in a namespace
        ///// </summary>
        ///// <param name="wmiNameSpace">Namespace to get wmi classes for</param>
        ///// <returns>List of classes in the requested namespace</returns>
        //public List<String> GetWMIClassList(string wmiNameSpace)
        //{
        //    ManagementScope wmiScope =
        //        new ManagementScope(String.Format("\\\\{0}\\root\\{1}", this.Server, wmiNameSpace),
        //                            this.ConnectionOptions);
        //    List<String> wmiClasses = new List<String>();

        //    ManagementObjectSearcher wmiSearcher = new ManagementObjectSearcher(wmiScope,
        //                                                                        new WqlObjectQuery(
        //                                                                            "SELECT * FROM meta_Class"), null);

        //    foreach (ManagementClass wmiClass in wmiSearcher.Get())
        //        wmiClasses.Add(wmiClass["__CLASS"].ToString());

        //    return wmiClasses;
        //}

        ///// <summary>
        ///// Get a list of wmi properties for the specified class
        ///// </summary>
        ///// <param name="wmiNameSpace">WMI Namespace</param>
        ///// <param name="wmiClass">WMI Class</param>
        ///// <returns>List of properties for the class</returns>
        //public List<String> GetWMIClassPropertyList(string wmiNameSpace, string wmiClass)
        //{
        //    List<String> wmiClassProperties = new List<string>();

        //    ManagementClass managementClass = GetWMIClass(wmiNameSpace, wmiClass);

        //    foreach (PropertyData property in managementClass.Properties)
        //        wmiClassProperties.Add(property.Name);

        //    return wmiClassProperties;
        //}

        ///// <summary>
        ///// Returns a list of methods for the class
        ///// </summary>
        ///// <param name="wmiNameSpace"></param>
        ///// <param name="wmiClass"></param>
        ///// <returns></returns>
        //public List<String> GetWMIClassMethodList(string wmiNameSpace, string wmiClass)
        //{
        //    List<String> wmiClassMethods = new List<string>();


        //    ManagementClass managementClass = GetWMIClass(wmiNameSpace, wmiClass);

        //    foreach (MethodData method in managementClass.Methods)
        //        wmiClassMethods.Add(method.Name);

        //    return wmiClassMethods;
        //}

        ///// <summary>
        ///// Retrieve the specified management class
        ///// </summary>
        ///// <param name="wmiNameSpace">Namespace of the class</param>
        ///// <param name="wmiClass">Type of the class</param>
        ///// <returns></returns>
        //public ManagementClass GetWMIClass(string wmiNameSpace, string wmiClass)
        //{
        //    ManagementScope wmiScope =
        //        new ManagementScope(String.Format("\\\\{0}\\root\\{1}", this.Server, wmiNameSpace),
        //                            this.ConnectionOptions);
        //    ManagementClass managementClass = null;

        //    ManagementObjectSearcher wmiSearcher = new ManagementObjectSearcher(wmiScope,
        //                                                                        new WqlObjectQuery(
        //                                                                            String.Format(
        //                                                                                "SELECT * FROM meta_Class WHERE __CLASS = '{0}'",
        //                                                                                wmiClass)), null);

        //    foreach (ManagementClass wmiObject in wmiSearcher.Get())
        //        managementClass = wmiObject;

        //    return managementClass;
        //}







        ///// <summary>
        ///// Returns the current time on the remote server
        ///// </summary>
        ///// <returns></returns>
        //public DateTime Now()
        //{
        //    ManagementScope wmiScope = new ManagementScope(String.Format("\\\\{0}\\root\\{1}", this.Server, "CIMV2"),
        //                                                   this.ConnectionOptions);
        //    ManagementClass managementClass = null;

        //    ManagementObjectSearcher wmiSearcher = new ManagementObjectSearcher(wmiScope,
        //                                                                        new WqlObjectQuery(
        //                                                                            String.Format(
        //                                                                                "SELECT * FROM Win32_LocalTime")),
        //                                                                        null);

        //    DateTime localTime = DateTime.MinValue;

        //    foreach (ManagementObject time in wmiSearcher.Get())
        //    {
        //        UInt32 day = (UInt32)time["Day"];
        //        UInt32 month = (UInt32)time["Month"];
        //        UInt32 year = (UInt32)time["Year"];
        //        UInt32 hour = (UInt32)time["Hour"];
        //        UInt32 minute = (UInt32)time["Minute"];
        //        UInt32 second = (UInt32)time["Second"];
        //        localTime = new DateTime((int)year, (int)month, (int)day, (int)hour, (int)minute, (int)second);
        //    }
        //    ;



        //    return localTime;
        //}

        ///// <summary>
        ///// Converts a wmi date into a proper date
        ///// </summary>
        ///// <param name="wmiDate">Wmi formatted date</param>
        ///// <returns>Date time object</returns>
        //private static bool ConvertFromWmiDate(string wmiDate, out DateTime properDate)
        //{
        //    properDate = DateTime.MinValue;

        //    string properDateString;

        //    // check if string is populated
        //    if (String.IsNullOrEmpty(wmiDate))
        //        return false;

        //    wmiDate = wmiDate.Trim().ToLower().Replace("*", "0");

        //    string[] months = new string[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        //    try
        //    {
        //        properDateString = String.Format("{0}-{1}-{2} {3}:{4}:{5}.{6}",
        //                                         wmiDate.Substring(6, 2),
        //                                         months[int.Parse(wmiDate.Substring(4, 2)) - 1],
        //                                         wmiDate.Substring(0, 4), wmiDate.Substring(8, 2),
        //                                         wmiDate.Substring(10, 2), wmiDate.Substring(12, 2),
        //                                         wmiDate.Substring(15, 6));
        //    }
        //    catch (InvalidCastException)
        //    {
        //        return false;
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        return false;
        //    }

        //    // try and parse the new date
        //    if (!DateTime.TryParse(properDateString, out properDate))
        //        return false;

        //    // true if conversion successful
        //    return true;
        //}

        #endregion

        #region IDisposable Members

        /// <summary>
        /// Managed dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Dispose of managed and unmanaged objects
        /// </summary>
        /// <param name="disposing"></param>
        public void Dispose(bool disposing)
        {
            if (disposing)
            {
                ConnectionOptions = null;
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the management scope
        /// </summary>
        private ConnectionOptions ConnectionOptions { get; set; }

        /// <summary>
        /// Gets the server connected to
        /// </summary>
        public string Server { get; private set; }
        /// <summary>
        /// Gets the username used to connect
        /// </summary>
        internal string Username { get; private set; }
        /// <summary>
        /// Gets the password used to connect
        /// </summary>
        internal string Password { get; private set; }
        /// <summary>
        /// Gets or sets the WMI namespace. default is CimV2
        /// </summary>
        protected internal string WmiNameSpace { get { return _wmiNameSpace; } set { _wmiNameSpace = value; } }
        private string _wmiNameSpace = "CIMV2";

        #endregion

        /// <summary>
        /// WMI Common Return Values
        /// </summary>
        public enum ReturnValue
        {
            Success = 0,
            NotSupported = 1,
            AccessDenied = 2,
            InsufficientPrivilege = 3,
            InvalidServiceControl = 4,
            ServiceCannotAcceptControl = 5,
            ServiceNotActive = 6,
            ServiceRequestTimeout = 7,
            UnknownFailure = 8,
            PathNotFound = 9,
            ServiceAlreadyRunning = 10,
            ServiceDatabaseLocked = 11,
            ServiceDependencyDeleted = 12,
            ServiceDependencyFailure = 13,
            ServiceDisabled = 14,
            ServiceLogonFailure = 15,
            ServiceMarkedForDeletion = 16,
            ServiceNoThread = 17,
            StatusCircularDependency = 18,
            StatusDuplicateName = 19,
            StatusInvalidName = 20,
            StatusInvalidParameter = 21,
            StatusInvalidServiceAccount = 22,
            StatusServiceExists = 23,
            ServiceAlreadyPaused = 24,
            ServiceNotFound = 25
        }
    }

}
