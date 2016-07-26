using System;
using System.Runtime.InteropServices;

namespace Useful.Utilities
{
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