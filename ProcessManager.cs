using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using Useful.Utilities.Models;

namespace Useful.Utilities
{
    /// <summary>
    /// Used to list, start and stop processes locally or remotely using WMI
    /// </summary>
    public class ProcessManager : WMI
    {
        ///// <summary>
        ///// Creates a new instance of Process Manager
        ///// </summary>
        //private ProcessManager() : base() { }
        ///// <summary>
        ///// Creates a new instance of Process Manager connected to a remote computer
        ///// </summary>
        //private ProcessManager(string server) : base(server) { }

        /// <summary>
        /// Creates a new instance of the Process Manager connected to a remote server as a different user
        /// </summary>
        private ProcessManager(string server, string username, string password) : base(server, username, password) { }

        /// <summary>
        /// Connects to the computer name passed in, leave blank for local
        /// </summary>
        /// <param name="computerName">Name of the computer. Leave blank for local</param>
        /// <param name="username">The username to connect as. Leave blank for current user</param>
        /// <param name="password">The password for username if provided.</param>
        /// <returns></returns>
        public static ProcessManager Connect(string computerName = "", string username = "", string password = "")
        {
            return new ProcessManager(computerName, username, password);
        }

        /// <summary>
        /// Gets a list of running processes. Can be filtered by name
        /// </summary>
        /// <param name="name">Null or blank to return all, otherwise returns all processes matching this name</param>
        /// <returns></returns>
        public IEnumerable<ProcessInfo> GetProcesses(string name = null)
        {
            string where = null;
            if (!string.IsNullOrWhiteSpace(name))
                where = "name = '" + name + "'";
            var procs = GetObjects("WIN32_Process", where);
            return procs.Select(ProcessInfo.CreateProcessInfo);
        }


        /// <summary>
        /// Gets a single process by process id
        /// </summary>
        /// <param name="id">The process identifier</param>
        /// <returns></returns>
        public ProcessInfo GetProcess(uint id)
        {
            var procs = GetObjects("WIN32_Process", "ProcessId = " + id);
            return ProcessInfo.CreateProcessInfo(procs.FirstOrDefault());
        }

        /// <summary>
        /// Terminates a process with the specified name.
        /// </summary>
        /// <param name="name">The name of the process</param>
        /// <param name="firstOnly">Flag if all or only the first process matching the name will be terminated</param>
        /// <returns></returns>
        public bool Terminate(string name, bool firstOnly = false)
        {
            var last = false;
            var procs = GetProcesses(name);
            foreach (var proc in procs)
            {
                var r = Helpers.ToEnum<ReturnValue>(proc.ManagementObject().InvokeMethod("Terminate", null));
                last = r == ReturnValue.Success;
                if (firstOnly) return last;
            }
            return last;
        }

        /// <summary>
        /// Terminates a process by the specified identifier.
        /// </summary>
        /// <param name="id">The process identifier</param>
        /// <returns></returns>
        public bool Terminate(uint id)
        {
            var proc = GetProcess(id);
            return Helpers.ToEnum<ReturnValue>(proc.ManagementObject().InvokeMethod("Terminate", null)) == ReturnValue.Success;
        }

        /// <summary>
        /// Starts a command process.
        /// </summary>
        /// <param name="command">The command to run.</param>
        /// <param name="timeoutSeconds">The number of seconds to wait before timing out (only applies to local processes). 
        /// Pass 0 for no timeout</param>
        /// <returns></returns>
        public int Start(string command, string args = "", int timeoutSeconds = 60)
        {
            if (ComputerManager.IsLocal(Server))
            {
                Trace.WriteLine("Running Local Command: " + command);
                using (var process = new Process())
                {
                    var dir = Path.GetDirectoryName(command) ?? string.Empty;
                    process.StartInfo.WorkingDirectory = dir;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = false;
                    process.StartInfo.FileName = command;
                    if (!string.IsNullOrWhiteSpace(args))
                        process.StartInfo.Arguments = args;
                    process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                    if (!string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password))
                    {
                        process.StartInfo.Domain = ComputerManager.SplitUserAndDomain(Username).Item1;
                        process.StartInfo.UserName = ComputerManager.SplitUserAndDomain(Username).Item2;
                        process.StartInfo.Password = new SecureString();
                        Password.ToList().ForEach(c => process.StartInfo.Password.AppendChar(c));
                        process.StartInfo.LoadUserProfile = false;
                    }

                    process.Start();
                    if (timeoutSeconds <= 0 || timeoutSeconds > int.MaxValue / 1000)
                        timeoutSeconds = int.MaxValue / 1000;
                    process.WaitForExit(timeoutSeconds * 1000);

                    return process.ExitCode;
                }
            }

            if (!string.IsNullOrWhiteSpace(args)) command += " " + args;
            Trace.WriteLine("Running " + Server + " Command: " + command);

            var p = ScopedClass("WIN32_Process");
            var input = p.GetMethodParameters("Create");
            input["CommandLine"] = command;

            var result = InvokeMethod(p, "create", input);
            return (int)result;
        }

        /// <summary>
        /// Starts a local process
        /// </summary>
        /// <param name="filename">The file to run</param>
        /// <param name="args">The optional arguments to pass to the file, if any</param>
        /// <param name="hideWindow">true to hide the window.</param>
        /// <returns></returns>
        public static int Run(string filename, string args = "", bool hideWindow = true)
        {
            Trace.WriteLine("Running Local Command: " + filename);
            using (var p = new Process())
            {
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = false;
                p.StartInfo.FileName = filename;
                if (!string.IsNullOrWhiteSpace(args))
                    p.StartInfo.Arguments = args;
                if (hideWindow)
                    p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                p.Start();
                p.WaitForExit();
                return p.ExitCode;
            }
        }

        ///// <summary>
        ///// Get a list of processes
        ///// </summary>
        ///// <returns></returns>
        //public List<ProcessInfo> GetProcesses()
        //{
        //    return GetProcess(null);
        //}

        ///// <summary>
        ///// Get a list of processes
        ///// </summary>
        ///// <returns></returns>
        //public List<ProcessInfo> GetProcess(uint? processId)
        //{
        //    ManagementObject[] processes = GetWMIClassObjects("CIMV2", "WIN32_Process");
        //    List<ProcessInfo> processList = new List<ProcessInfo>();

        //    for (int i = 0; i < processes.Length; i++)
        //    {
        //        ManagementObject managementObject = processes[i];
        //        ProcessInfo process = new ProcessInfo(managementObject);
        //        process.Priority = (uint)managementObject["Priority"];
        //        process.ProcessId = (uint)managementObject["ProcessId"];
        //        process.Status = (string)managementObject["Status"];

        //        DateTime createDate;

        //        if (ConvertFromWmiDate((string)managementObject["CreationDate"], out createDate))
        //            process.CreationDate = createDate.ToString("dd-MMM-yyyy HH:mm:ss");


        //        process.Caption = (string)managementObject["Caption"];
        //        process.CommandLine = (string)managementObject["CommandLine"];
        //        process.Description = (string)managementObject["Description"];
        //        process.ExecutablePath = (string)managementObject["ExecutablePath"];
        //        process.ExecutionState = (string)managementObject["ExecutionState"];
        //        process.MaximumWorkingSetSize = (UInt32?)managementObject["MaximumWorkingSetSize"];
        //        process.MinimumWorkingSetSize = (UInt32?)managementObject["MinimumWorkingSetSize"];
        //        process.KernelModeTime = (UInt64)managementObject["KernelModeTime"];
        //        process.ThreadCount = (UInt32)managementObject["ThreadCount"];
        //        process.UserModeTime = (UInt64)managementObject["UserModeTime"];
        //        process.VirtualSize = (UInt64)managementObject["VirtualSize"];
        //        process.WorkingSetSize = (UInt64)managementObject["WorkingSetSize"];

        //        if (processId == null || process.ProcessId == processId.Value)
        //            processList.Add(process);
        //    }

        //    return processList;
        //}



        ///// <summary>
        ///// Schedule a process on the remote machine
        ///// </summary>
        ///// <param name="command"></param>
        ///// <param name="scheduleTime"></param>
        ///// <param name="jobName"></param>
        ///// <returns></returns>
        //public bool ScheduleProcess(string command, DateTime scheduleTime, out string jobName)
        //{
        //    jobName = String.Empty;

        //    ManagementClass scheduleClass = GetWMIClass("CIMV2", "Win32_ScheduledJob");

        //    object[] objectsIn = new object[7];

        //    objectsIn[0] = command;

        //    objectsIn[1] = String.Format("********{0:00}{1:00}{2:00}.000000+060", scheduleTime.Hour,
        //                                 scheduleTime.Minute, scheduleTime.Second);
        //    objectsIn[5] = true;

        //    scheduleClass.InvokeMethod("Create", objectsIn);

        //    if (objectsIn[6] == null)
        //        return false;

        //    UInt32 scheduleid = (uint)objectsIn[6];

        //    jobName = scheduleid.ToString();

        //    return true;
        //}
    }
}
