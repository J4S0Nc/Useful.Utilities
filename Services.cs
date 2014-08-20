using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Win32;
using Useful.Utilities.Models;

namespace Useful.Utilities
{


    #region Support objects

    namespace Models
    {
        /// <summary>
        /// Type of Windows Service
        /// </summary>
        public enum ServiceType : uint
        {
            KernelDriver = 0x1,
            FileSystemDriver = 0x2,
            Adapter = 0x4,
            RecognizerDriver = 0x8,
            OwnProcess = 0x10,
            ShareProcess = 0x20,
            Interactive = 0x100
        }

        /// <summary>
        /// Windows Service Error reporting mode
        /// </summary>
        public enum OnError
        {
            UserIsNotNotified = 0,
            UserIsNotified = 1,
            SystemRestartedLastGoodConfiguraion = 2,
            SystemAttemptStartWithGoodConfiguration = 3
        }

        /// <summary>
        /// Windows Service start mode
        /// </summary>
        public enum StartMode
        {
            Boot = 0,
            System = 1,
            Auto = 2,
            Manual = 3,
            Disabled = 4
        }

        /// <summary>
        /// Windows Service  state
        /// </summary>
        public enum ServiceState
        {
            Running,
            Stopped,
            Paused,
            StartPending,
            StopPending,
            PausePending,
            ContinuePending
        }


        /// <summary>
        /// Model for holding service information. Also handles converting a <see cref="ManagementObject"/> to a model.
        /// </summary>
        public class ServiceInfo
        {
            public string Name { get; set; }
            public string Status { get; set; }
            public string DisplayName { get; set; }
            public string PathName { get; set; }
            public uint ProcessId { get; set; }
            public bool Started { get; set; }
            public string InstallDate { get; set; }
            public string Description { get; set; }
            public string Caption { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public ServiceType ServiceType { get; set; }
            public OnError ErrorHandle { get; set; }
            public StartMode StartMode { get; set; }
            public ServiceState State { get; set; }
            public bool InteractWithDesktop { get; set; }
            public string LoadOrderGroup { get; set; }
            public string[] LoadOrderGroupDependencies { get; set; }
            public string[] Dependencies { get; set; }

            [NonSerialized]
            private ManagementObject _managementObject;
            protected internal ManagementObject ManagementObject() { return _managementObject; }

            protected internal static ServiceInfo CreateServiceInfo(ManagementObject managementObject)
            {

                if (managementObject == null)
                    return null;
                ServiceInfo rtn = null;
                try
                {
                    rtn = new ServiceInfo
                    {
                        _managementObject = managementObject,
                        InteractWithDesktop = false,
                        State = Helpers.ToEnum<ServiceState>(managementObject["State"]),
                        Status = (string)managementObject["Status"],
                        Name = (string)managementObject["Name"],
                        DisplayName = (string)managementObject["DisplayName"],
                        PathName = (string)managementObject["PathName"],
                        ProcessId = (uint)managementObject["ProcessId"],
                        Started = (bool)managementObject["Started"],
                        StartMode = Helpers.ToEnum<StartMode>(managementObject["StartMode"]),
                        ServiceType = Helpers.ToEnum<ServiceType>(managementObject["ServiceType"]),
                        InstallDate = (string)managementObject["InstallDate"],
                        Description = (string)managementObject["Description"],
                        Caption = (string)managementObject["Caption"],
                        Username = (string)managementObject["StartName"]
                    };
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
                return rtn;
            }
            public ServiceInfo()
            {
                InteractWithDesktop = false;
                StartMode = StartMode.Auto;
                ServiceType = ServiceType.OwnProcess;
            }

        }
    }

    #endregion Enum


    /// <summary>
    /// Used to control windows services locally or remotely using WMI.
    /// Can find, list, install, update, uninstall, start, stop or restart services
    /// </summary>
    public class ServicesManager : WMI
    {

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesManager"/> class.
        /// </summary>
        private ServicesManager() : base() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesManager"/> class connected to a remote server.
        /// </summary>
        /// <param name="server"></param>
        private ServicesManager(string server) : base(server) { }
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicesManager"/> class connected to a remote server as a different user.
        /// </summary>
        private ServicesManager(string server, string username, string password) : base(server, username, password) { }

        /// <summary>
        /// Connects to the computer name passed in, leave blank for local
        /// </summary>
        /// <param name="computerName">Name of the computer. Leave blank for local</param>
        /// <param name="username">The username to connect as. Leave blank for current user</param>
        /// <param name="password">The password for username if provided.</param>
        /// <returns></returns>
        public static ServicesManager Connect(string computerName = "", string username = "", string password = "")
        {
            return new ServicesManager(computerName, username, password);
        }
        #endregion
        #region services
        /// <summary>
        /// Gets a list of all services
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ServiceInfo> GetServices()
        {
            var services = GetObjects("Win32_Service");
            return services.Select(ServiceInfo.CreateServiceInfo);
        }

        /// <summary>
        /// Gets a service by name.
        /// </summary>
        /// <param name="name">The service name to find.</param>
        /// <returns></returns>
        private ManagementObject GetService(string name) { return ScopedObject(string.Format("Win32_Service.Name='{0}'", name)); }

        /// <summary>
        /// Gets a service by name.
        /// </summary>
        /// <param name="svcInfo">The service information object. The Name property is used</param>
        /// <returns></returns>
        public ServiceInfo GetServiceInfo(ServiceInfo svcInfo) { return GetServiceInfo(svcInfo.Name); }

        /// <summary>
        /// Gets a service by name.
        /// </summary>
        /// <param name="name">The service name to find.</param>
        /// <returns></returns>
        public ServiceInfo GetServiceInfo(string name) { return ServiceInfo.CreateServiceInfo(GetService(name)); }

        /// <summary>
        /// Gets the state of the service.
        /// </summary>
        /// <param name="svcInfo">The service information object. The Name property is used.</param>
        /// <returns></returns>
        public ServiceState GetServiceState(ServiceInfo svcInfo) { return GetServiceInfo(svcInfo).State; }

        /// <summary>
        /// Gets the state of the service.
        /// </summary>
        /// <param name="name">The service name to find.</param>
        /// <returns></returns>
        public ServiceState GetServiceState(string svcName) { return GetServiceInfo(svcName).State; }


        /// <summary>
        /// Installs a windows service. Ensures user has Logon as a service right by calling <see cref="Security.SetLogonAsAService"/>
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <param name="svcDispName">Display name of the service</param>
        /// <param name="svcPath">The service file path.</param>
        /// <param name="description">The service description.</param>
        /// <param name="username">The username to run the service.</param>
        /// <param name="password">The password of the user running the service.</param>
        /// <param name="svcType">Type of the service.</param>
        /// <param name="errHandle">The error handle type.</param>
        /// <param name="svcStartMode">The service start mode.</param>
        /// <param name="interactWithDesktop">if set to <c>true</c> service can interact with desktop.</param>
        /// <param name="loadOrderGroup">The load order group.</param>
        /// <param name="loadOrderGroupDependencies">The load order group dependencies.</param>
        /// <param name="svcDependencies">Any service dependencies.</param>
        /// <returns><see cref="WMI.ReturnValue"/></returns>
        public ReturnValue InstallService(string svcName,
                                            string svcDispName,
                                            string svcPath,
                                            string description,
                                            string username = null,
                                            string password = null,
                                            ServiceType svcType = ServiceType.OwnProcess,
                                            OnError errHandle = OnError.UserIsNotified,
                                            StartMode svcStartMode = StartMode.Auto,
                                            bool interactWithDesktop = false,
                                            string loadOrderGroup = null,
                                            string[] loadOrderGroupDependencies = null,
                                            string[] svcDependencies = null)
        {
            var service = new ServiceInfo
                {
                    Name = svcName,
                    DisplayName = svcDispName,
                    Description = description,
                    PathName = svcPath,
                    ServiceType = svcType,
                    ErrorHandle = errHandle,
                    StartMode = svcStartMode,
                    InteractWithDesktop = interactWithDesktop,
                    LoadOrderGroup = loadOrderGroup,
                    LoadOrderGroupDependencies = loadOrderGroupDependencies,
                    Dependencies = svcDependencies,
                    Username = ComputerManager.EnsureDomain(username),
                    Password = password
                };
            return InstallService(service);

        }

        /// <summary>
        /// Installs a windows service. Ensures user has Logon as a service right by calling <see cref="Security.SetLogonAsAService"/>
        /// </summary>
        /// <param name="service">The service information object. <see cref="ServiceInfo"/></param>
        /// <returns></returns>
        public ReturnValue InstallService(ServiceInfo service)
        {
            if (!Security.IsValidLogin(service.Username, service.Password, Server))
                return ReturnValue.ServiceLogonFailure;
            //ensure user account has logon as service rights
            Security.SetLogonAsAService(service.Username, Server);

            ManagementClass mc = ScopedClass("Win32_Service");

            ManagementBaseObject inParams = mc.GetMethodParameters("create");

            inParams["Name"] = service.Name;
            inParams["DisplayName"] = string.IsNullOrWhiteSpace(service.DisplayName) ? service.Name : service.DisplayName;
            inParams["PathName"] = service.PathName;
            inParams["ServiceType"] = service.ServiceType;
            inParams["ErrorControl"] = service.ErrorHandle;
            inParams["StartMode"] = service.StartMode == StartMode.Auto ? "Automatic" : service.StartMode.ToString();
            inParams["DesktopInteract"] = service.InteractWithDesktop;
            inParams["StartName"] = service.Username;
            inParams["StartPassword"] = service.Password;
            inParams["LoadOrderGroup"] = service.LoadOrderGroup;
            inParams["LoadOrderGroupDependencies"] = service.LoadOrderGroupDependencies;
            inParams["ServiceDependencies"] = service.Dependencies;

            var rtn = InvokeMethod(mc, "Create", inParams);
            SetDescription(service.Name, service.Description);
            return rtn;
        }

        /// <summary>
        /// Determines whether a service is installed by name.
        /// </summary>
        /// <param name="svcInfo">The service information object. Name property is used</param>
        /// <returns>True if installed</returns>
        public bool IsServiceInstalled(ServiceInfo svcInfo) { return IsServiceInstalled(svcInfo.Name); }

        /// <summary>
        /// Determines whether a service is installed by name.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <returns>True if installed</returns>
        public bool IsServiceInstalled(string svcName)
        {
            try
            {
                ManagementObject svc = GetService(svcName);
                var r = InvokeMethod(svc, "InterrogateService");
                return r != ReturnValue.ServiceNotFound;
            }
            catch (Exception ex)
            {
                if (ex.Message.ToLower().Trim() == "not found" || ex.GetHashCode() == 41149443)
                    return false;
                throw;
            }
        }

        /// <summary>
        /// Changes the credentials of a service.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <param name="username">The new username. Can be a domain user by passing "Domain\Username"</param>
        /// <param name="password">The new password.</param>
        /// <returns></returns>
        public ReturnValue ChangeCredentials(string svcName, string username, string password)
        {
            var service = GetServiceInfo(svcName);
            service.Username = ComputerManager.EnsureDomain(username);
            service.Password = password;
            return Change(service);
        }


        /// <summary>
        /// Changes the specified service username, password or path.
        /// </summary>
        /// <param name="service">The service to update.</param>
        /// <returns></returns>
        public ReturnValue Change(ServiceInfo service)
        {
            if (!string.IsNullOrWhiteSpace(service.Password) && !Security.IsValidLogin(service.Username, service.Password, Server))
                return ReturnValue.ServiceLogonFailure;
            //ensure user account has logon as service rights
            Security.SetLogonAsAService(service.Username, Server);
            ManagementObject svc = service.ManagementObject() ?? GetService(service.Name);
            ManagementClass mc = ScopedClass("Win32_Service");
            mc.Scope = Scope();

            ManagementBaseObject inParams = mc.GetMethodParameters("Change");
            if (!string.IsNullOrWhiteSpace(service.Password))
            {
                inParams["StartName"] = service.Username;
                inParams["StartPassword"] = service.Password;
            }
            inParams["PathName"] = service.PathName;

            return InvokeMethod(svc, "Change", inParams);

        }

        /// <summary>
        /// Gets the description of the service from the registry.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <returns></returns>
        public string GetDescription(string svcName)
        {
            var key = RegistryHelper.GetKey(RegistryHive.LocalMachine, @"System\CurrentControlSet\Services\" + svcName, Server);
            return RegistryHelper.GetValue(key, "Description", "");
        }

        /// <summary>
        /// Sets the description of the service in the registry.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <param name="description">The description text to set.</param>
        public void SetDescription(string svcName, string description)
        {
            var key = RegistryHelper.GetKey(RegistryHive.LocalMachine, @"System\CurrentControlSet\Services\" + svcName, Server);
            RegistryHelper.SetValue(key, "Description", description);
        }

        /// <summary>
        /// Gets the path of the service in the registry.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <returns></returns>
        public string GetPath(string svcName)
        {
            var key = RegistryHelper.GetKey(RegistryHive.LocalMachine, @"System\CurrentControlSet\Services\" + svcName, Server);
            return RegistryHelper.GetValue(key, "ImagePath", "");
        }
        /// <summary>
        /// Sets the path of the service in the registry.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <param name="path">The path to set.</param>
        /// <returns></returns>
        public bool SetPath(string svcName, string path)
        {
            var key = RegistryHelper.GetKey(RegistryHive.LocalMachine, @"System\CurrentControlSet\Services\" + svcName, Server);
            return RegistryHelper.SetValue(key, "ImagePath", path);
        }

        /// <summary>
        /// Uninstalls the service from the system.
        /// </summary>
        /// <param name="svcName">The service name.</param>
        /// <returns></returns>
        public ReturnValue UninstallService(string svcName) { return UninstallService(GetServiceInfo(svcName)); }

        /// <summary>
        /// Uninstalls the service from the system.
        /// </summary>
        /// <param name="svcInfo">The service information object. Name property is used</param>
        /// <returns></returns>
        public ReturnValue UninstallService(ServiceInfo service)
        {
            ManagementObject svc = service.ManagementObject() ?? GetService(service.Name);
            return InvokeMethod(svc, "delete");
        }

        /// <summary>
        /// Starts the service.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <returns></returns>
        public ReturnValue StartService(string svcName) { return StartService(GetServiceInfo(svcName)); }

        /// <summary>
        /// Starts the service.
        /// </summary>
        /// <param name="service">The service information object. Name property is used</param>
        /// <returns></returns>
        public ReturnValue StartService(ServiceInfo service)
        {
            ManagementObject svc = service.ManagementObject() ?? GetService(service.Name);
            return InvokeMethod(svc, "StartService");
        }

        /// <summary>
        /// Stops the service.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <returns></returns>
        public ReturnValue StopService(string svcName) { return StopService(GetServiceInfo(svcName)); }

        /// <summary>
        /// Stops the service.
        /// </summary>
        /// <param name="service">The service information object. Name property is used</param>
        /// <returns></returns>
        public ReturnValue StopService(ServiceInfo service)
        {
            ManagementObject svc = service.ManagementObject() ?? GetService(service.Name);
            return InvokeMethod(svc, "StopService");
        }

        /// <summary>
        /// Waits for the service to be in a given state.
        /// </summary>
        /// <param name="svcName">Name of the service.</param>
        /// <param name="state">The state to wait for.</param>
        /// <param name="timeoutMs">The timeout in milliseconds.</param>
        /// <returns></returns>
        public ReturnValue WaitForState(string svcName, ServiceState state, int timeoutMs = 5000) { return WaitForState(GetServiceInfo(svcName), state, timeoutMs); }

        /// <summary>
        /// Waits for the service to be in a given state.
        /// </summary>
        /// <param name="service">The service information object.</param>
        /// <param name="state">The state to wait for.</param>
        /// <param name="timeoutMs">The timeout in milliseconds.</param>
        /// <returns>True when service is in given state. 
        /// False if service is not in given state by the end of the  timeout period</returns>
        public ReturnValue WaitForState(ServiceInfo service, ServiceState state, int timeoutMs = 5000)
        {
            DateTime endDate = DateTime.Now.AddMilliseconds(timeoutMs);
            do
            {
                service = GetServiceInfo(service);
                if (service.State == state)
                    return ReturnValue.Success;
                Thread.Sleep(500);
            } while (endDate > DateTime.Now);

            return ReturnValue.ServiceRequestTimeout;
        }
        #endregion
    }


}
