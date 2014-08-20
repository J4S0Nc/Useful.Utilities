using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Useful.Utilities
{


    /// <summary>
    /// A utility class for interacting with the Global Assembly Cache.
    /// </summary>
    public class GacUtility
    {
        private readonly IAssemblyCache _assemblyCache;
        public GacUtility()
        {
            CreateAssemblyCache(out _assemblyCache, 0);
        }

        /// <summary>
        /// Removes an assembly from the GAC.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to remove.</param>
        /// <returns>A magic number.</returns>
        public int Remove(string assemblyName)
        {
            uint n;
            return _assemblyCache.UninstallAssembly(0, assemblyName, (IntPtr)0, out n);
        }

        /// <summary>
        /// Adds an assembly to the GAC.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to add.</param>
        /// <returns>A magic number.</returns>
        public int Add(string assemblyName)
        {
            return _assemblyCache.InstallAssembly(0, assemblyName, (IntPtr)0);
        }

        /// <summary>
        /// Adds an assembly to the GAC.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to add.</param>
        /// <returns>A magic number.</returns>
        public static int AddAssembly(string assemblyName)
        {
            IAssemblyCache assemblyCache;
            var hr = CreateAssemblyCache(out assemblyCache, 0);

            return hr != 0 ? hr : assemblyCache.InstallAssembly(0, assemblyName, (IntPtr)0);
        }

        /// <summary>
        /// Removes an assembly from the GAC.
        /// </summary>
        /// <param name="assemblyName">The name of the assembly to remove.</param>
        /// <returns>A magic number.</returns>
        public static int RemoveAssembly(string assemblyName)
        {
            IAssemblyCache assemblyCache;
            uint n;
            var hr = CreateAssemblyCache(out assemblyCache, 0);

            return hr != 0 ? hr : assemblyCache.UninstallAssembly(0, assemblyName, (IntPtr)0, out n);
        }

        /// <summary>
        /// Starts a background task that removes all assemblies from the GAC matching a given key
        /// </summary>
        /// <param name="key">The key to remove</param>
        /// <returns></returns>
        public static Task RemoveByKey(string key)
        {
            return Task.Factory.StartNew(() =>
                {
                    var t1 = Task.Factory.StartNew(() => RemoveByKey(key, Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "Microsoft.NET\\assembly"))); //clr 4.0
                    var t2 = Task.Factory.StartNew(() => RemoveByKey(key, Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "assembly\\GAC_MSIL"))); //clr 2.0
                    Task.WaitAll(t1, t2);
                });

        }
        private static void RemoveByKey(string key, string searchPath)
        {
            var folderPaths = Directory.GetDirectories(searchPath, "*_" + key, SearchOption.AllDirectories);
            foreach (var folderPath in folderPaths)
            {
                var path = Path.Combine(folderPath, "..\\");
                if (!Directory.Exists(path))
                    continue;
                // Trace.WriteLine("deleting " + path);
                try
                {
                    Directory.Delete(path, true);
                }
                catch (Exception e)
                {
                    Trace.WriteLine("error: " + e.Message);
                }
            }
            // find any left over files by key and delete them
            var assNames = GetByKey(key, searchPath);
            var t = new TaskList();
            var gac = new GacUtility();
            foreach (var s in assNames)
            {
                string a = s;
                t.AddTask(() => gac.Remove(a));
            }
            t.WaitForAll();

        }
        /// <summary>
        /// Gets a list of paths to all files matching the given key
        /// </summary>
        /// <param name="key">The key to find</param>
        /// <returns>list of file paths</returns>
        public static List<string> GetByKey(string key)
        {
            var rtn = GetByKey(key, Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "assembly\\GAC_MSIL"));
            rtn.AddRange(GetByKey(key, Path.Combine(Environment.ExpandEnvironmentVariables("%windir%"), "Microsoft.NET\\assembly")));
            return rtn;
        }


        private static List<string> GetByKey(string key, string searchPath)
        {
            var folderPaths = Directory.GetDirectories(searchPath, "*_" + key, SearchOption.AllDirectories);
            var assNames = new List<string>();
            foreach (var folderPath in folderPaths)
            {
                if (!Directory.Exists(folderPath))
                    continue;

                var fileName = Directory.GetFiles(folderPath, "*.dll").FirstOrDefault();

                if (fileName == null)
                {
                    Directory.Delete(folderPath); //delete empty folders
                    continue;
                }

                var assemblyName = Path.GetFileNameWithoutExtension(fileName);
                if (!assNames.Contains(assemblyName))
                    assNames.Add(assemblyName);
            }
            return assNames;
        }

        [DllImport("Fusion.dll", CharSet = CharSet.Auto)]
        private static extern int CreateAssemblyCache(out IAssemblyCache ppAsmCache, uint dwReserved);
    }

    /// <summary>
    /// Defines a contract for interacting with the Global Assembly Cache.
    /// </summary>
    [ComImport, InterfaceType(ComInterfaceType.InterfaceIsIUnknown), Guid("e707dcde-d1cd-11d2-bab9-00c04f8eceae")]
    internal interface IAssemblyCache
    {

        /// <summary>
        /// Uninstalls the assembly.
        /// </summary>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="pszAssemblyName">Name of the PSZ assembly.</param>
        /// <param name="pvReserved">The pv reserved.</param>
        /// <param name="pulDisposition">The pul disposition.</param>
        /// <returns></returns>
        [PreserveSig]
        int UninstallAssembly(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName, IntPtr pvReserved, out uint pulDisposition);


        /// <summary>
        /// Queries the assembly information.
        /// </summary>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="pszAssemblyName">Name of the PSZ assembly.</param>
        /// <param name="pAsmInfo">The p asm information.</param>
        /// <returns></returns>
        [PreserveSig]
        int QueryAssemblyInfo(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszAssemblyName, IntPtr pAsmInfo);


        /// <summary>
        /// Creates the assembly cache item.
        /// </summary>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="pvReserved">The pv reserved.</param>
        /// <param name="ppAsmItem">The pp asm item.</param>
        /// <param name="pszAssemblyName">Name of the PSZ assembly.</param>
        /// <returns></returns>
        [PreserveSig]
        int CreateAssemblyCacheItem(uint dwFlags, IntPtr pvReserved, out /*IAssemblyCacheItem*/IntPtr ppAsmItem, [MarshalAs(UnmanagedType.LPWStr)] String pszAssemblyName);


        /// <summary>
        /// Creates the assembly scavenger.
        /// </summary>
        /// <param name="ppAsmScavenger">The pp asm scavenger.</param>
        /// <returns></returns>
        [PreserveSig]
        int CreateAssemblyScavenger(out object ppAsmScavenger);


        /// <summary>
        /// Installs the assembly.
        /// </summary>
        /// <param name="dwFlags">The dw flags.</param>
        /// <param name="pszManifestFilePath">The PSZ manifest file path.</param>
        /// <param name="pvReserved">The pv reserved.</param>
        /// <returns></returns>
        [PreserveSig]
        int InstallAssembly(uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] string pszManifestFilePath, IntPtr pvReserved);
    }


}
