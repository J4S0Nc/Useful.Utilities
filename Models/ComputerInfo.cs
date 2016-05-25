using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Management;

namespace Useful.Utilities.Models
{
    /// <summary>
    /// Model for holding computer information. Also handles converting a <see cref="ManagementObject"/> to a model. 
    /// <see href="http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx"/>
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class ComputerInfo
    {
            
        public string Caption { get; private set; }
        public string Description { get; private set; }
        /// <summary>
        /// Name of local computer according to the domain name server (DNS).
        /// </summary>
        public string DNSHostName { get; private set; }
        /// <summary>
        /// Name of the domain to which a computer belongs.
        /// </summary>
        public string Domain { get; private set; }
        public DomainRole DomainRole { get; private set; }
        /// <summary>
        /// Name of a computer manufacturer.
        /// </summary>
        public string Manufacturer { get; private set; }
        /// <summary>
        /// Product name that a manufacturer gives to a computer. This property must have a value.
        /// </summary>
        public string Model { get; private set; }
        /// <summary>
        /// Name of object
        /// </summary>
        public string Name { get; private set; }
        public string NameFormat { get; private set; }
        /// <summary>
        /// Number of logical processors available on the computer.
        /// </summary>
        public UInt32 NumberOfLogicalProcessors { get; private set; }
        /// <summary>
        /// Number of all processors available on the computer.
        /// </summary>
        public UInt32 NumberOfProcessors { get; private set; }
        /// <summary>
        /// Null if unknown
        /// </summary>
        public bool? PartOfDomain { get; private set; }
        /// <summary>
        /// Contact information for the primary system owner,
        /// </summary>
        public string PrimaryOwnerContact { get; private set; }
        /// <summary>
        /// Name of the primary system owner. 
        /// </summary>
        public string PrimaryOwnerName { get; private set; }
        public string Status { get; private set; }
        public string SystemType { get; private set; }
        /// <summary>
        /// Total size of physical memory. Be aware this property may not return an accurate value
        /// </summary>
        public UInt64 TotalPhysicalMemory { get; private set; }
        /// <summary>
        /// Name of a user that is logged on currently to the console (not remote desktop users)
        /// </summary>
        public string UserName { get; private set; }
        /// <summary>
        /// Name of the workgroup for this computer. Only if the value of the PartOfDomain property is False
        /// </summary>
        public string Workgroup { get; private set; }

        [NonSerialized]
        private ManagementObject _managementObject;
        protected internal ManagementObject ManagementObject(){return _managementObject; }

        protected internal static ComputerInfo CreateComputerInfo(ManagementObject managementObject)
        {
            if (managementObject == null)
                return null;
            ComputerInfo comp = null;
            try
            {
                comp = new ComputerInfo();
                comp._managementObject = managementObject;
                comp.Caption = (string)managementObject["Caption"];
                comp.Description = (string)managementObject["Description"];
                comp.DNSHostName = (string)managementObject["DNSHostName"];
                comp.Domain = (string)managementObject["Domain"];

                comp.Manufacturer = (string)managementObject["Manufacturer"];
                comp.Model = (string)managementObject["Model"];
                comp.Name = (string)managementObject["Name"];
                comp.NameFormat = (string)managementObject["NameFormat"];
                comp.NumberOfLogicalProcessors = (UInt32)managementObject["NumberOfLogicalProcessors"];
                comp.NumberOfProcessors = (UInt32)managementObject["NumberOfProcessors"];

                comp.PrimaryOwnerContact = (string)managementObject["PrimaryOwnerContact"];
                comp.PrimaryOwnerName = (string)managementObject["PrimaryOwnerName"];
                comp.Status = (string)managementObject["Status"];
                comp.SystemType = (string)managementObject["SystemType"];
                comp.TotalPhysicalMemory = (UInt64)managementObject["TotalPhysicalMemory"];
                comp.UserName = (string)managementObject["UserName"];
                comp.Workgroup = (string)managementObject["Workgroup"];
                comp.DomainRole = (DomainRole)(ushort)(managementObject["DomainRole"]);
                comp.PartOfDomain = (bool?)managementObject["PartOfDomain"];
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
                Trace.TraceError(ex.ToString());
            }
            return comp;
        }

    }
}