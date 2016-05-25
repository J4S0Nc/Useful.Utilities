using System;
using System.Diagnostics;
using System.Management;

namespace Useful.Utilities.Models
{
    /// <summary>
    /// Model for holding process information. Also handles converting a <see cref="ManagementObject"/> to a model.
    /// </summary>
    public class ProcessInfo
    {
        public uint Priority { get; set; }
        public uint ProcessId { get; set; }
        public string Status { get; set; }
        public string CreationDate { get; set; }
        public string Caption { get; set; }
        public string Description { get; set; }
        public string CommandLine { get; set; }
        public string ExecutablePath { get; set; }
        public string ExecutionState { get; set; }
        public UInt32? MaximumWorkingSetSize { get; set; }
        public UInt32? MinimumWorkingSetSize { get; set; }
        public UInt64 KernelModeTime { get; set; }
        public UInt32 ThreadCount { get; set; }
        public UInt64 UserModeTime { get; set; }
        public UInt64 VirtualSize { get; set; }
        public UInt64 WorkingSetSize { get; set; }

        [NonSerialized]
        private ManagementObject _managementObject;
        protected internal ManagementObject ManagementObject() { return _managementObject; }

        protected internal static ProcessInfo CreateProcessInfo(ManagementObject managementObject)
        {

            if (managementObject == null)
                return null;
            ProcessInfo process = null;
            try
            {
                process = new ProcessInfo
                {
                    _managementObject = managementObject,
                    Priority = (uint)managementObject["Priority"],
                    ProcessId = (uint)managementObject["ProcessId"],
                    Status = (string)managementObject["Status"],
                    CreationDate = (string)managementObject["CreationDate"],
                    Caption = (string)managementObject["Caption"],
                    CommandLine = (string)managementObject["CommandLine"],
                    Description = (string)managementObject["Description"],
                    ExecutablePath = (string)managementObject["ExecutablePath"],
                    ExecutionState = (string)managementObject["ExecutionState"],
                    MaximumWorkingSetSize = (UInt32?)managementObject["MaximumWorkingSetSize"],
                    MinimumWorkingSetSize = (UInt32?)managementObject["MinimumWorkingSetSize"],
                    KernelModeTime = (UInt64)managementObject["KernelModeTime"],
                    ThreadCount = (UInt32)managementObject["ThreadCount"],
                    UserModeTime = (UInt64)managementObject["UserModeTime"],
                    VirtualSize = (UInt64)managementObject["VirtualSize"],
                    WorkingSetSize = (UInt64)managementObject["WorkingSetSize"]
                };
            }
            catch (Exception ex)
            {
                Trace.WriteLine("ERROR: " + ex.Message);
                Trace.TraceError(ex.ToString());
            }
            return process;
        }
    }
}