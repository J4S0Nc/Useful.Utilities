using System;
using System.Diagnostics;
using System.Management;

namespace Useful.Utilities.Models
{
    /// <summary>
    /// Model for holding feature information. Also handles converting a <see cref="ManagementObject"/> to a model. 
    /// <see href="http://msdn.microsoft.com/en-us/library/cc280268(v=vs.85).aspx"/>
    /// </summary>
    [Serializable]
        
    public class FeatureInfo
    {
        public uint Id { get; set; }
        public uint ParentId { get; set; }
        public string Name { get; set; }
        [NonSerialized]
        private ManagementObject _managementObject;
        protected internal ManagementObject ManagementObject() { return _managementObject; }

        protected internal static FeatureInfo CreateFeatureInfo(ManagementObject managementObject)
        {
            if (managementObject == null)
                return null;
            FeatureInfo comp = null;
            try
            {
                comp = new FeatureInfo();
                comp._managementObject = managementObject;
                comp.Name = (string)managementObject["Name"];
                comp.Id = (UInt32)managementObject["ID"];
                comp.ParentId = (UInt32)managementObject["ParentId"];
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