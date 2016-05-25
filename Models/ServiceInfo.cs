using System;
using System.Management;

namespace Useful.Utilities.Models
{
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