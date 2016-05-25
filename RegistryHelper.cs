using System;
using Microsoft.Win32;

namespace Useful.Utilities
{
    /// <summary>
    /// Windows registry wrapper. Used to read, write and delete keys and values. Handles picking 64bit or 32bit views. 
    /// Can be used on local or remote registries.
    /// </summary>
    public class RegistryHelper
    {
        /// <summary>
        /// Get the value of a key or the default if the key has no value
        /// </summary>
        /// <typeparam name="T">The type of value to return</typeparam>
        /// <param name="key">The Sub Key to select</param>
        /// <param name="keyName">The key name to get</param>
        /// <param name="defaultValue">The default value to return if the key has no value</param>
        /// <returns></returns>
        public static T GetValue<T>(RegistryKey key, string keyName, T defaultValue = default(T))
        {
            var v = key.GetValue(keyName);
            return v != null ? (T)v : defaultValue;
        }

        /// <summary>
        /// Sets the value of a given key
        /// </summary>
        /// <typeparam name="T">The Type of the value to be set</typeparam>
        /// <param name="key">The Sub Key to select</param>
        /// <param name="keyName">the key name to set </param>
        /// <param name="value">The value to apply to the key name</param>
        /// <returns></returns>
        public static bool SetValue<T>(RegistryKey key, string keyName, T value)
        {
            if (key == null || value == null || value.Equals(default(T)))
                return false;
            key = key.OpenSubKey("", true);
            if(key == null) throw new NullReferenceException("Key is null");
            key.SetValue(keyName, value);
            return true;
        }

        /// <summary>
        /// Deletes a key and value. Will delete a full tree structure by default
        /// </summary>
        /// <param name="key">Sub key to select from deletion </param>
        /// <param name="deleteTree">if true current key and all children will be deleted. 
        ///     if there are children and this is false and error is thrown.
        /// </param>
        public static void DeleteKey(RegistryKey key, bool deleteTree = true)
        {
            if (deleteTree)
                key.DeleteSubKeyTree("");
            else
                key.DeleteSubKey("");
        }

        /// <summary>
        /// Deletes the value from a given key. To delete the key use <see cref="DeleteKey"/>
        /// </summary>
        /// <param name="key">The sub key name to select</param>
        /// <param name="keyName">the key to remove the value from </param>
        public static void DeleteValue(RegistryKey key, string keyName) { key.DeleteValue(keyName); }

        /// <summary>
        /// Gets or Creates a registry Sub Key
        /// </summary>
        /// <param name="hive"><see cref="RegistryHive" /></param>
        /// <param name="subKeyName">Path for sub key</param>
        /// <param name="computer">Remote computer name used for execution, null or blank for local host</param>
        /// <returns>
        ///   <see cref="RegistryKey" />
        /// </returns>
        public static RegistryKey GetKey(RegistryHive hive, string subKeyName, string computer = "")
        {
            RegistryKey registryKey = ComputerManager.IsLocal(computer)
                                                  ? RegistryKey.OpenBaseKey(hive, View)
                                                  : RegistryKey.OpenRemoteBaseKey(hive, computer, View);

            return registryKey.OpenSubKey(subKeyName) ?? registryKey.CreateSubKey(subKeyName);

        }

        /// <summary>
        /// Selects the 64 or 32 bit registry view based on architecture. 
        /// </summary>
        protected static RegistryView View { get { return Environment.Is64BitOperatingSystem ? RegistryView.Registry64 : RegistryView.Registry32; } }

        /// <summary>
        /// Takes a .reg file and imports it to the registry
        /// </summary>
        /// <param name="regFile">Full path and name of the .reg file</param>
        /// <param name="computer">Remote computer name used for execution, null or blank for local host</param>
        /// <returns></returns>
        public static bool ImportFile(string regFile, string computer = "")
        {
            var args = "/s ";
            args += regFile.Contains(" ") ? "\"" + regFile + "\"" : regFile;
            return ProcessManager.Connect(computer).Start("regedit.exe" , args)==0;
        }
    }
}
