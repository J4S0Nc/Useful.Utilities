## Useful.Utilities ##
- [Certificate](#useful.utilities.certificate)
- [Compression](#useful.utilities.compression)
- [Models.ComputerInfo](#useful.utilities.models.computerinfo)
- [Models.FeatureInfo](#useful.utilities.models.featureinfo)
- [Models.FeaturesAndRoles](#useful.utilities.models.featuresandroles)
- [Models.ServiceType](#useful.utilities.models.servicetype)
- [Models.OnError](#useful.utilities.models.onerror)
- [Models.ProcessInfo](#useful.utilities.models.processinfo)
- [Models.ServiceInfo](#useful.utilities.models.serviceinfo)
- [Models.ServiceState](#useful.utilities.models.servicestate)
- [Models.StartMode](#useful.utilities.models.startmode)
- [CryptoManager](#useful.utilities.cryptomanager)
- [Database](#useful.utilities.database)
- [DynamicRow](#useful.utilities.dynamicrow)
- [FileUtility](#useful.utilities.fileutility)
- [FileUtility.WindowsShares](#useful.utilities.fileutility.windowsshares)
- [GacUtility](#useful.utilities.gacutility)
- [Helpers](#useful.utilities.helpers)
- [IAssemblyCache](#useful.utilities.iassemblycache)
- [IisManager](#useful.utilities.iismanager)
- [IisManager.ApplicationSslFlags](#useful.utilities.iismanager.applicationsslflags)
- [ComputerManager](#useful.utilities.computermanager)
- [NetworkConnection](#useful.utilities.networkconnection)
- [ObjectCopier](#useful.utilities.objectcopier)
- [ProcessManager](#useful.utilities.processmanager)
- [RandomExtensions](#useful.utilities.randomextensions)
- [RegistryHelper](#useful.utilities.registryhelper)
- [Security](#useful.utilities.security)
- [ServicesManager](#useful.utilities.servicesmanager)
- [SharedFolderConnection](#useful.utilities.sharedfolderconnection)
- [TaskList](#useful.utilities.tasklist)
- [WMI](#useful.utilities.wmi)
- [WMI.ReturnValue](#useful.utilities.wmi.returnvalue)

---
# Certificate

 Deals with windows x509 certificates

#### Certificate.Select(System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String,System.String,System.String)

 Selects the specified store using built-in windows UI 

| Parameter | Description |
|-----------|-------------|
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |
|windowTitle |The window title. |
| windowMsg |The window message. |


#### Certificate.GetByThumbprint(System.String,System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

 Gets a certificate by thumb print. 

| Parameter | Description |
|-----------|-------------|
|thumbprint |the cert thumbprint to find |
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


#### Certificate.GetCerts(System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

 Gets a list of Cert names and thumbprints in a tuple 

| Parameter | Description |
|-----------|-------------|
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


#### Certificate.Setup(System.String,System.String,System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

 Install a PFX file to the cert store 

| Parameter | Description |
|-----------|-------------|
|  fileName |Name of the PFX file. |
|  password |The password. |
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


#### Certificate.GetStore(System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

 Helper function to connect to a cert store. Can be local or remote 

| Parameter | Description |
|-----------|-------------|
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


---
# Compression

 Unbuffered compression/decompression methods using GZip

#### Compression.Compress(System.String)

 Compresses a string using GZip 

| Parameter | Description |
|-----------|-------------|
|      text |The text to compress |


#### Compression.Compress(System.Byte[])

 Use GZip Compression 

| Parameter | Description |
|-----------|-------------|
|      data |             |


#### Compression.Decompress(System.String)

 Decompresses a string 

| Parameter | Description |
|-----------|-------------|
|compressedText |The compressed text |


#### Compression.Decompress(System.Byte[])

 Use GZip Decompression 

| Parameter | Description |
|-----------|-------------|
|compressed |             |


---
# Models.ComputerInfo

 Model for holding computer information. Also handles converting a [[|Models.ComputerInfo.ManagementObject]] to a model. [[|http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx]]
|  Property | Description |
|-----------|-------------|
|Models.ComputerInfo.DNSHostName | Name of local computer according to the domain name server (DNS). |
|Models.ComputerInfo.Domain | Name of the domain to which a computer belongs. |
|Models.ComputerInfo.Manufacturer | Name of a computer manufacturer. |
|Models.ComputerInfo.Model | Product name that a manufacturer gives to a computer. This property must have a value. |
|Models.ComputerInfo.Name | Name of object |
|Models.ComputerInfo.NumberOfLogicalProcessors | Number of logical processors available on the computer. |
|Models.ComputerInfo.NumberOfProcessors | Number of all processors available on the computer. |
|Models.ComputerInfo.PartOfDomain | Null if unknown |
|Models.ComputerInfo.PrimaryOwnerContact | Contact information for the primary system owner, |
|Models.ComputerInfo.PrimaryOwnerName | Name of the primary system owner. |
|Models.ComputerInfo.TotalPhysicalMemory | Total size of physical memory. Be aware this property may not return an accurate value |
|Models.ComputerInfo.UserName | Name of a user that is logged on currently to the console (not remote desktop users) |
|Models.ComputerInfo.Workgroup | Name of the workgroup for this computer. Only if the value of the PartOfDomain property is False |

---
# Models.FeatureInfo

 Model for holding feature information. Also handles converting a [[|Models.FeatureInfo.ManagementObject]] to a model. [[|http://msdn.microsoft.com/en-us/library/cc280268(v=vs.85).aspx]]

---
# Models.FeaturesAndRoles

 List of Features and Roles that can be mapped to the FeatureInfo Id and Parent Id property

---
# Models.ServiceType

 Type of Windows Service

---
# Models.OnError

 Windows Service Error reporting mode

---
# Models.ProcessInfo

 Model for holding process information. Also handles converting a [[|Models.ProcessInfo.ManagementObject]] to a model.

---
# Models.ServiceInfo

 Model for holding service information. Also handles converting a [[|Models.ServiceInfo.ManagementObject]] to a model.

---
# Models.ServiceState

 Windows Service state

---
# Models.StartMode

 Windows Service start mode

---
# CryptoManager

 Used to Encrypt / Decrypt strings and byte arrays

#### CryptoManager.NewKey

 Helper that generates a random key on each call.


#### CryptoManager.Sha256(System.String)

 Hash the string using SHA256 and return base64 encoded string 

| Parameter | Description |
|-----------|-------------|
|     input |             |


#### CryptoManager.Encrypt(System.String,System.Byte[],System.Byte[],System.Byte[])

 Encryption (AES) then Authentication (HMAC) for a UTF8 Message. 

| Parameter | Description |
|-----------|-------------|
|secretMessage |The secret message. |
|  cryptKey |The crypt key. |
|   authKey |The auth key. |
|nonSecretPayload |(Optional) Non-Secret Payload. |
Returns:  Encrypted Message 

Throws: [[System.ArgumentException|System.ArgumentException]]: Secret Message Required!;secretMessage



> Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Blocksize + HMac-Tag(32)) * 1.33 Base64


#### CryptoManager.Decrypt(System.String,System.Byte[],System.Byte[],System.Int32)

 Authentication (HMAC) then Decryption (AES) for a secret UTF8 Message. 

| Parameter | Description |
|-----------|-------------|
|encryptedMessage |The encrypted message. |
|  cryptKey |The crypt key. |
|   authKey |The auth key. |
|nonSecretPayloadLength |Length of the non secret payload. |
Returns:  Decrypted Message 

Throws: [[System.ArgumentException|System.ArgumentException]]: Encrypted Message Required!;encryptedMessage


#### CryptoManager.EncryptWithPassword(System.String,System.String,System.Byte[])

 Encryption (AES) then Authentication (HMAC) of a UTF8 message using Keys derived from a Password (PBKDF2). 

| Parameter | Description |
|-----------|-------------|
|secretMessage |The secret message. |
|  password |The password. |
|nonSecretPayload |The non secret payload. |
Returns:  Encrypted Message 

Throws: [[System.ArgumentException|System.ArgumentException]]: password



> Significantly less secure than using random binary keys. Adds additional non secret payload for key generation parameters.


#### CryptoManager.DecryptWithPassword(System.String,System.String,System.Int32)

 Authentication (HMAC) and then Descryption (AES) of a UTF8 Message using keys derived from a password (PBKDF2). 

| Parameter | Description |
|-----------|-------------|
|encryptedMessage |The encrypted message. |
|  password |The password. |
|nonSecretPayloadLength |Length of the non secret payload. |
Returns:  Decrypted Message 

Throws: [[System.ArgumentException|System.ArgumentException]]: Encrypted Message Required!;encryptedMessage



> Significantly less secure than using random binary keys.


---
# Database

 SQL Database functions

#### Database.#ctor(System.String)

 Initializes a new instance of the [[|Database]] class. 

| Parameter | Description |
|-----------|-------------|
|connection |The connection string. |

|  Property | Description |
|-----------|-------------|
|Database.Connection | The database connection string. |

#### Database.ConnectionParts

 Parses the connection string in to a [[|System.Data.SqlClient.SqlConnectionStringBuilder]]


#### Database.ConnectionParts(System.String)

 Parses the connection string in to a [[|System.Data.SqlClient.SqlConnectionStringBuilder]]

| Parameter | Description |
|-----------|-------------|
|connection |The connection string to parse |


#### Database.TestConnection(System.Boolean)

 Tests the connection. 

| Parameter | Description |
|-----------|-------------|
|throwOnError |Flag to throw or hide connection errors |
Returns: True if successful


#### Database.TestConnection(System.String,System.Boolean)

 Tests the connection. 

| Parameter | Description |
|-----------|-------------|
|connection |The connection string. |
|throwOnError |Flag to throw or hide connection errors |
Returns:  True if successful 

Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Connection string must have Data Source and Initial Catalog both set

|  Property | Description |
|-----------|-------------|
|Database.Servers | Gets a list of all available instances of SQL Server within the local network. 

Returns: string array of server names |

#### Database.Databases(System.String,System.String,System.String)

 Gets a list of databases on a given server. To use NT Auth leave user/pass blank 

|    server |Server to connect to |
|  username |SQL Auth user. To use NT Auth leave blank |
|  password |SQL Auth password |
Returns: string array of database names


#### Database.ExecuteSql(System.String,System.String)

 Executes a non query. 

| Parameter | Description |
|-----------|-------------|
|       sql |SQL statement to execute |
|connection |SQL connection string |


#### Database.ExecuteScalar(System.Data.SqlClient.SqlCommand,System.String)

 Executes a scalar 

| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |
Returns: Scalar result


#### Database.ExecuteNonQuery(System.Data.SqlClient.SqlCommand,System.String)

 Executes a non query. 

| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |


#### Database.ExecuteCount(System.Data.SqlClient.SqlCommand,System.String)

 Executes a scalar and attempts to parse the result to integer. If parse fails -1 is returned 

| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |
Returns: Scalar result as integer or -1


#### Database.ExecuteStoredProc(System.String,System.String)

 Executes a stored procedure as a non query 

| Parameter | Description |
|-----------|-------------|
|storedProcName |             |
|connection |SQL connection string |


#### Database.GetDataset(System.Data.SqlClient.SqlCommand,System.String)

 Executes a Sql Adapter and fills a dataset 

| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |
Returns: A Filled DataSet


#### Database.Run(System.String,System.String)

 Run a SQL command and return each row as a dynamic row 

| Parameter | Description |
|-----------|-------------|
|       sql |             |
Returns: Enumeration of [[|DynamicRow]]


---
# DynamicRow

 Custom Dynamic Object for dealing with DataRow Objects

#### DynamicRow.#ctor(System.Data.DataRow)

 Initializes a new instance of the [[|DynamicRow]] class. 

| Parameter | Description |
|-----------|-------------|
|       row |The data row object. |

|  Property | Description |
|-----------|-------------|
|DynamicRow.DataRow | Gets the data row that created this DynamicRow object |

#### DynamicRow.Convert(System.Data.DataTable)

 Converts the specified table to Enumeration of [[|DynamicRow]]. 

|     table |The data table to convert. |
Returns: Enumeration of [[|DynamicRow]]


---
# FileUtility

 File Utility functions

#### FileUtility.WaitForFile(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare,System.Int32,System.Int32)

 Tries to create a file stream. On error, the thread sleeps and retries until the max retry number is hit. 

| Parameter | Description |
|-----------|-------------|
|      file |File path    |
|      mode |file mode    |
|    access |file access  |
|     share |file share   |
|     retry |Number of retries to attempt on error |
|    waitMs |number of milliseconds to sleep between retries |
Throws: [[System.IO.IOException|System.IO.IOException]]: Throws IOExecption if max retry is hit


#### FileUtility.IsFileLocked(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare)

 Checks if a file is locked by attempting to open it. 

| Parameter | Description |
|-----------|-------------|
|      file |File Path to open |
|      mode |             |
|    access |             |
|     share |             |


#### FileUtility.FileExists(System.String,System.String)

 Checks if a file exists. If remote computer is passed in the path is converted to a UNC first 

| Parameter | Description |
|-----------|-------------|
|      path |File path to check |
|  computer |optional remote computer name to check for the file |


#### FileUtility.CopyFile(System.String,System.String,System.Boolean)

 Ensures the destination directory exists then copies a file. 

| Parameter | Description |
|-----------|-------------|
|    source |The source file path. |
|      dest |The destination file path. |
| overwrite |allow destination file to be overwritten if it exists. |


#### FileUtility.GetUniversalPath(System.String,System.String)

 Takes a local file path and translates it into a UNC file path where possible. 

| Parameter | Description |
|-----------|-------------|
|      path |Path to convert to UNC. |
|  computer |Machine name to use, if not set uses local machine |
Returns: UNC path otherwise throws arg error.


#### FileUtility.ClearReadOnly(System.String)

 Clears the read only flag on a file 

| Parameter | Description |
|-----------|-------------|
|      path |Path to the file |


---
# FileUtility.WindowsShares

 Support class for listing windows shares

---
# GacUtility

 A utility class for interacting with the Global Assembly Cache.

#### GacUtility.Remove(System.String)

 Removes an assembly from the GAC. 

| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to remove. |
Returns: A magic number.


#### GacUtility.Add(System.String)

 Adds an assembly to the GAC. 

| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to add. |
Returns: A magic number.


#### GacUtility.AddAssembly(System.String)

 Adds an assembly to the GAC. 

| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to add. |
Returns: A magic number.


#### GacUtility.RemoveAssembly(System.String)

 Removes an assembly from the GAC. 

| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to remove. |
Returns: A magic number.


#### GacUtility.RemoveByKey(System.String)

 Starts a background task that removes all assemblies from the GAC matching a given key 

| Parameter | Description |
|-----------|-------------|
|       key |The key to remove |


#### GacUtility.GetByKey(System.String)

 Gets a list of paths to all files matching the given key 

| Parameter | Description |
|-----------|-------------|
|       key |The key to find |
Returns: list of file paths


---
# Helpers

 Extensions and helper methods

#### Helpers.ToEnum&lt;T&gt;(System.Object,System.String)

 Convert a string object to an Enum 

| Parameter | Description |
|-----------|-------------|
|         T |The type of Enum to convert to |
|     value |The object to convert |
|spaceReplace |If value has spaces, They will be replaced |


#### Helpers.ToEnum&lt;T&gt;(System.String,System.String)

 Convert a string to an Enum 

| Parameter | Description |
|-----------|-------------|
|         T |The type of Enum to convert to |
|     value |The object to convert |
|spaceReplace |If value has spaces, They will be replaced |


#### Helpers.ToHex(System.Byte[])

 Convert a byte array to a hexadecimal string. 

| Parameter | Description |
|-----------|-------------|
|     bytes |The bytes.   |


#### Helpers.GetAttribute&lt;T2&gt;(System.Enum,System.Func{&lt;T&gt;,&lt;T&gt;})

 Gets attribute from an enumeration object 

| Parameter | Description |
|-----------|-------------|
|         T |Input type   |
| TExpected |The return type |
|enumeration |The enum value |
|expression |             |


#### Helpers.Description(System.Enum)

 Gets the description value from the [[|System.ComponentModel.DescriptionAttribute]] of the enum. If enum doesn't have a description attribute, null is returned 

| Parameter | Description |
|-----------|-------------|
|enumeration |The enum value to look at |
Returns: description value from the [[|System.ComponentModel.DescriptionAttribute]] or null


#### Helpers.IsTrue(System.Nullable{System.Boolean})

 If the nullable Boolean value is null or false, false is returned. if the nullable Boolean has a value and its true, true is returned. 

| Parameter | Description |
|-----------|-------------|
|     value |nullable Boolean |
Returns: true or false


#### Helpers.IsTrueOrNull(System.Nullable{System.Boolean})

 If the nullable Boolean value is null or true, true is returned. if the nullable Boolean has a value and its false, false is returned. 

| Parameter | Description |
|-----------|-------------|
|     value |nullable Boolean |
Returns: true or false


#### Helpers.Default&lt;T&gt;(System.Object,&lt;T&gt;)

 If object is null [[|value]] is returned. If object is empty string or min date time, [[|value]] is returned. If object is a different type then value it may be casted or may throw an [[|System.InvalidCastException]]

| Parameter | Description |
|-----------|-------------|
|         T |The default value type |
|       obj |the object   |
|     value |Default value to return when object is null or doesn't match rules |
Throws: [[System.InvalidCastException|System.InvalidCastException]]: When object is different type then default value InvalidCastException might be thrown


#### Helpers.RoundDown(System.Single,System.Int32)

 Round a number down. Can set number of decimal places. 

| Parameter | Description |
|-----------|-------------|
|    number |             |
|decimalPlaces |             |


#### Helpers.RoundUp(System.Single,System.Int32)

 Round a number up. Can set number of decimal places. 

| Parameter | Description |
|-----------|-------------|
|    number |             |
|decimalPlaces |             |


#### Helpers.ToLong(System.String)

 Convert s string to a long, throws cast exception if it fails 

| Parameter | Description |
|-----------|-------------|
|       str |             |
Throws: [[System.InvalidCastException|System.InvalidCastException]]:


#### Helpers.TryToLong(System.String)

 Attempt to cast a string to a long, return null if unable to cast 

| Parameter | Description |
|-----------|-------------|
|       str |             |


#### Helpers.Traverse&lt;T&gt;(System.Collections.Generic.IEnumerable{&lt;T&gt;},System.Func{&lt;T&gt;,System.Collections.Generic.IEnumerable{&lt;T&gt;}})

 Recursively search a tree collection based on the child selector 

| Parameter | Description |
|-----------|-------------|
|         T |             |
|     items |             |
|childSelector |             |


---
# IAssemblyCache

 Defines a contract for interacting with the Global Assembly Cache.

#### IAssemblyCache.UninstallAssembly(System.UInt32,System.String,System.IntPtr,System.UInt32@)

 Uninstalls the assembly. 

| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pszAssemblyName |Name of the PSZ assembly. |
|pvReserved |The pv reserved. |
|pulDisposition |The pul disposition. |


#### IAssemblyCache.QueryAssemblyInfo(System.UInt32,System.String,System.IntPtr)

 Queries the assembly information. 

| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pszAssemblyName |Name of the PSZ assembly. |
|  pAsmInfo |The p asm information. |


#### IAssemblyCache.CreateAssemblyCacheItem(System.UInt32,System.IntPtr,System.IntPtr@,System.String)

 Creates the assembly cache item. 

| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pvReserved |The pv reserved. |
| ppAsmItem |The pp asm item. |
|pszAssemblyName |Name of the PSZ assembly. |


#### IAssemblyCache.CreateAssemblyScavenger(System.Object@)

 Creates the assembly scavenger. 

| Parameter | Description |
|-----------|-------------|
|ppAsmScavenger |The pp asm scavenger. |


#### IAssemblyCache.InstallAssembly(System.UInt32,System.String,System.IntPtr)

 Installs the assembly. 

| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pszManifestFilePath |The PSZ manifest file path. |
|pvReserved |The pv reserved. |


---
# IisManager

 IIS Server Manager Wrapper. can be used for local and remote IIS settings

---
# IisManager.ApplicationSslFlags

 Application level Ssl Flags

#### IisManager.#ctor(System.String)

 Initializes a new instance of the [[|IisManager]] class connected to a remote computer 

| Parameter | Description |
|-----------|-------------|
|remoateServer |The remote server. |

|  Property | Description |
|-----------|-------------|
|IisManager.RemoteServer | The remote server currently connected to. |
|IisManager.ServerManager | Gets the server manager. Either local or remote based on [[|IisManager.RemoteServer]] |

#### IisManager.ListSites

 List all IIS web sites


#### IisManager.ListSiteNames

 List all IIS web sites


#### IisManager.GetSite(System.String)

 Get single site by name 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### IisManager.SiteState(System.String)

 Get site state (stopped, running, etc) 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### IisManager.StopSite(System.String)

 Stop IIS site by name 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### IisManager.StartSite(System.String)

 Attempt to start a site by name 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### IisManager.Processes

 Get all worker process for all application pools


#### IisManager.CreateSslSite(System.String,System.String,System.String,System.Int32)

 Create a new web site on port 443 

| Parameter | Description |
|-----------|-------------|
|  siteName |site name    |
|      path |root directory of site |
|  certHash |certificate thumbprint |
|      port |port         |


#### IisManager.CreateSite(System.String,System.String,System.Int32,System.String)

 Create a new web site 

| Parameter | Description |
|-----------|-------------|
|  siteName |display name |
|      path |Root directory |
|      port |port         |
|  certHash |certificate thumbprint |


#### IisManager.DeleteSite(System.String)

 delete a site 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### IisManager.SetBinding(System.String,System.String,System.Int32,System.String,System.String,System.Boolean)

 Create or update a binding on the given site. 

| Parameter | Description |
|-----------|-------------|
|  siteName |Site name    |
|        ip |Ip to apply binding to. Use * for all |
|      port |Port to apply binding to |
|hostheader |Optional host header |
| certThumb |Optional Cert thumb print, if Set protocol will be https |
|removeAllOthers |Flag to clear all other bindings on site |


#### IisManager.ListApplications(System.String)

 Get list of applications for a site 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### IisManager.GetApplication(System.String,System.String)

 Get an application under the given site 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |


#### IisManager.SetApplication(System.String,System.String,System.String,System.String,System.Boolean,System.Boolean,IisManager.ApplicationSslFlags)

 create or update an application under a site 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |
|      path |The physical path. |
|  poolName |Name of the application pool. |
|allowAnonymousAccess |Flag to allow anonymous access. |
|windowsAuth |Flag to enable windows authentication. |
|  sslFlags |The SSL flags. |


#### IisManager.DeleteApplication(System.String,System.String)

 Deletes an application under a site. 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |


#### IisManager.SetApplicationPool(System.String,System.String,System.String)

 Change the pool tied to an application 

| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |
|  poolName |Name of the application pool. |


#### IisManager.ListPools

 Lists all the application pools.


#### IisManager.GetPool(System.String)

 Gets the application pool by name. 

| Parameter | Description |
|-----------|-------------|
|  poolName |Name of the application pool. |


#### IisManager.RecyclePool(System.String)

 Recycles the pool. 

| Parameter | Description |
|-----------|-------------|
|  poolName |Name of the application pool. |


#### IisManager.DeletePool(System.String)

 Deletes the application pool. 

| Parameter | Description |
|-----------|-------------|
|  poolName |Name of the application pool. |


#### IisManager.SetPool(System.String,System.String,System.String,System.Int32,System.String)

 create or update an application pool 

| Parameter | Description |
|-----------|-------------|
|      name |The application pool name. |
|  username |The username. |
|  password |The password. |
|maxProcesses |The maximum processes. 0 for default |
|   version |The version. |
Throws: [[System.Exception|System.Exception]]:


#### IisManager.Refresh

 Refreshes this instance and restarts the [[|IisManager.ServerManager]]


#### IisManager.CommitChanges

 Commits the [[|IisManager.ServerManager]] changes.


#### IisManager.ResetIis(System.String)

 Resets IIS. Mode can be Restart, Stop, or Start 

| Parameter | Description |
|-----------|-------------|
|      mode |The mode argument. Can be Restart, Stop, or Start |


#### IisManager.IisVersion(System.String)

 IIS version number. 0 if not installed or error 

| Parameter | Description |
|-----------|-------------|
|remoteComputer |The remote computer. |


---
# ComputerManager

 Collection of computer, domain, and user name functions

#### ComputerManager.#ctor(System.String,System.String,System.String)

 Creates a new instance of the Computer Manager connected to a remote server as a different user


#### ComputerManager.Computer

 Gets information about the computer currently connected to.


#### ComputerManager.Connect(System.String,System.String,System.String)

 Connects to the computer name passed in, leave blank for local 

| Parameter | Description |
|-----------|-------------|
|computerName |Name of the computer. Leave blank for local |
|  username |The username to connect as. Leave blank for current user |
|  password |The password for username if provided. |

|  Property | Description |
|-----------|-------------|
|ComputerManager.DomainNameFull | Gets the full domain name of the current computer (without the computer name). Use [[|ComputerManager.MachineFullName]] to get FQN of current computer. |
|ComputerManager.DomainNameBios | Gets the Domain Net Bios of the current user. |
|ComputerManager.UserName | Gets the username of current user |
|ComputerManager.UserQualified | Gets the domain and username of current user. Domain\User |

#### ComputerManager.SplitUserAndDomain(System.String)

 Splits the username and domain into a Tuple. Domain is Item1, User is Item2. 

|  username |The Domain\Username or User@domain string to parse. |
Returns: Domain is Item1, Username is Item2


#### ComputerManager.EnsureDomain(System.String)

 Ensures the username as a domain prefix. If no prefix is given machine name is used. 

| Parameter | Description |
|-----------|-------------|
|      user |The username to check for domain. |
Returns: domain\user or machine\user

|  Property | Description |
|-----------|-------------|
|ComputerManager.MachineName | Gets the Machine name of the current computer (without domain). Use [[|ComputerManager.MachineFullName]] to get the FQN of the current computer. |
|ComputerManager.MachineFullName | Gets the fully qualified name of the current computer. computer.domain.com |

#### ComputerManager.IsLocal(System.String)

 Checks if the name passed in is the current computer. Returns true if the string is null/empty or the name matches the current [[|ComputerManager.MachineName]] or [[|ComputerManager.MachineFullName]]. 

|serverName |Computer name to check |


---
# NetworkConnection

 Creates a connection to a network resource with a given set of credentials

---
# ObjectCopier

 Perform a deep copy of an object. Binary Serialization is used to perform the copy.

#### ObjectCopier.Clone&lt;T&gt;(&lt;T&gt;)

 Perform a deep Copy of the object. 

| Parameter | Description |
|-----------|-------------|
|         T |The type of object being copied. |
|    source |The object instance to copy. |
Returns: The copied object.


#### ObjectCopier.ToBytes&lt;T&gt;(&lt;T&gt;)

 Takes a serializable object and returns it as a byte array. 

| Parameter | Description |
|-----------|-------------|
|         T |The Type of the Object |
|    source |The source object to serialize. |
Throws: [[System.ArgumentException|System.ArgumentException]]: The type must be serializable.;source


#### ObjectCopier.FromBytes&lt;T&gt;(System.Byte[])

 Takes a byte array and desterilizes it to a object. 

| Parameter | Description |
|-----------|-------------|
|         T |The Type of the Object |
|       obj |byte array of the object. |
Throws: [[System.ArgumentException|System.ArgumentException]]: The type must be serializable.;source


#### ObjectCopier.FromXml&lt;T&gt;(System.String)

 Load an object from XML string. 

| Parameter | Description |
|-----------|-------------|
|         T |The Type of the Object |
|       xml |The XML.     |


#### ObjectCopier.ToXml&lt;T&gt;(&lt;T&gt;)

 Serialize an object to XML string. 

| Parameter | Description |
|-----------|-------------|
|         T |The Type of Object |
|       obj |The object.  |
Returns: XML String


---
# ProcessManager

 Used to list, start and stop processes locally or remotely using WMI

#### ProcessManager.#ctor(System.String,System.String,System.String)

 Creates a new instance of the Process Manager connected to a remote server as a different user


#### ProcessManager.Connect(System.String,System.String,System.String)

 Connects to the computer name passed in, leave blank for local 

| Parameter | Description |
|-----------|-------------|
|computerName |Name of the computer. Leave blank for local |
|  username |The username to connect as. Leave blank for current user |
|  password |The password for username if provided. |


#### ProcessManager.GetProcesses(System.String)

 Gets a list of running processes. Can be filtered by name 

| Parameter | Description |
|-----------|-------------|
|      name |Null or blank to return all, otherwise returns all processes matching this name |


#### ProcessManager.GetProcess(System.UInt32)

 Gets a single process by process id 

| Parameter | Description |
|-----------|-------------|
|        id |The process identifier |


#### ProcessManager.Terminate(System.String,System.Boolean)

 Terminates a process with the specified name. 

| Parameter | Description |
|-----------|-------------|
|      name |The name of the process |
| firstOnly |Flag if all or only the first process matching the name will be terminated |


#### ProcessManager.Terminate(System.UInt32)

 Terminates a process by the specified identifier. 

| Parameter | Description |
|-----------|-------------|
|        id |The process identifier |


#### ProcessManager.Start(System.String,System.String,System.Int32)

 Starts a command process. 

| Parameter | Description |
|-----------|-------------|
|   command |The command to run. |
|timeoutSeconds |The number of seconds to wait before timing out (only applies to local processes). Pass 0 for no timeout |


#### ProcessManager.Run(System.String,System.String,System.Boolean)

 Starts a local process 

| Parameter | Description |
|-----------|-------------|
|  filename |The file to run |
|      args |The optional arguments to pass to the file, if any |
|hideWindow |true to hide the window. |


---
# RandomExtensions

 Extension methods for System.Random objects. IEnumerable extension to get a random item.
|  Property | Description |
|-----------|-------------|
|RandomExtensions.Random | Static access to random object |

#### RandomExtensions.PhoneNumber(System.Random)

 Generate a random phone number (10 random digits formatted as ###-###-####) 

|    random |             |


#### RandomExtensions.Bool(System.Random,System.Double)

 Generate a random Boolean 

| Parameter | Description |
|-----------|-------------|
|    random |             |
|    weight | Percent of weight toward true results. 0 = all false, 1 = all true |


#### RandomExtensions.RandomItem&lt;T&gt;(System.Collections.Generic.IEnumerable{&lt;T&gt;})

 Randomly sort the items and pick one. If the collection is null, null is returned. 

| Parameter | Description |
|-----------|-------------|
|         T |             |
|      list |             |


---
# RegistryHelper

 Windows registry wrapper. Used to read, write and delete keys and values. Handles picking 64bit or 32bit views. Can be used on local or remote registries.

#### RegistryHelper.GetValue&lt;T&gt;(Microsoft.Win32.RegistryKey,System.String,&lt;T&gt;)

 Get the value of a key or the default if the key has no value 

| Parameter | Description |
|-----------|-------------|
|         T |The type of value to return |
|       key |The Sub Key to select |
|   keyName |The key name to get |
|defaultValue |The default value to return if the key has no value |


#### RegistryHelper.SetValue&lt;T&gt;(Microsoft.Win32.RegistryKey,System.String,&lt;T&gt;)

 Sets the value of a given key 

| Parameter | Description |
|-----------|-------------|
|         T |The Type of the value to be set |
|       key |The Sub Key to select |
|   keyName |the key name to set |
|     value |The value to apply to the key name |


#### RegistryHelper.DeleteKey(Microsoft.Win32.RegistryKey,System.Boolean)

 Deletes a key and value. Will delete a full tree structure by default 

| Parameter | Description |
|-----------|-------------|
|       key |Sub key to select from deletion |
|deleteTree |if true current key and all children will be deleted. if there are children and this is false and error is thrown. |


#### RegistryHelper.DeleteValue(Microsoft.Win32.RegistryKey,System.String)

 Deletes the value from a given key. To delete the key use [[|RegistryHelper.DeleteKey(Microsoft.Win32.RegistryKey,System.Boolean)]]

| Parameter | Description |
|-----------|-------------|
|       key |The sub key name to select |
|   keyName |the key to remove the value from |


#### RegistryHelper.GetKey(Microsoft.Win32.RegistryHive,System.String,System.String)

 Gets or Creates a registry Sub Key 

| Parameter | Description |
|-----------|-------------|
|      hive |[[|Microsoft.Win32.RegistryHive]] |
|subKeyName |Path for sub key |
|  computer |Remote computer name used for execution, null or blank for local host |
Returns: [[|Microsoft.Win32.RegistryKey]]

|  Property | Description |
|-----------|-------------|
|RegistryHelper.View | Selects the 64 or 32 bit registry view based on architecture. |

#### RegistryHelper.ImportFile(System.String,System.String)

 Takes a .reg file and imports it to the registry 

|   regFile |Full path and name of the .reg file |
|  computer |Remote computer name used for execution, null or blank for local host |


---
# Security

 Security Utility Functions

#### Security.SetLogonAsAService(System.String,System.String)

 Set logon as a service rights for the user. 

| Parameter | Description |
|-----------|-------------|
|      user |The username as domain\user. if domain is not provide machine name is used |
|remoteComputer |Can be used to execute on a remote computer. |


#### Security.SetPrivilege(System.String,System.String,System.String)

 Sets a privilege for the user. 

| Parameter | Description |
|-----------|-------------|
|      user |The username as domain\user. if domain is not provide machine name is used |
| privilege |The privilege to set. [[|Security.LsaWrapper]] |
|remoteComputer |Can be used to execute on a remote computer. |


#### Security.Login(System.String,System.String,System.String)

 Login as a given user and return the login token 

| Parameter | Description |
|-----------|-------------|
|      user |The user: domain\user |
|  password |The password. |
|remoteComputer |The remote computer. |


#### Security.IsValidLogin(System.String,System.String,System.String)

 Determines whether the specified username and password are valid. Can be ran locally or remotely 

| Parameter | Description |
|-----------|-------------|
|      user |The username: domain\user |
|  password |The password. |
|    domain |The domain.  |
|remoteComputer |Can be used to execute on a remote computer. |


#### Security.ValidateLogin(System.String,System.String,System.String)

 Validates the username and password. Throws error if its invalid 

| Parameter | Description |
|-----------|-------------|
|  username |The username. |
|  password |The password. |
|    domain |The domain.  |
|remoteComputer |Can be used to execute on a remote computer. |
Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: Thrown if Username and password is invalid!


#### Security.IsInRole(System.String,System.String,System.Security.Principal.WindowsBuiltInRole,System.String)

 Determines whether the specified user is in a given role 

| Parameter | Description |
|-----------|-------------|
|  username |The username. |
|  password |The password. |
|      role |The role.    |
|remoteComputer |Can be used to execute on a remote computer. |


#### Security.RunAs(System.String,System.String)

 Runs an action as a different user. 

| Parameter | Description |
|-----------|-------------|
|  username |The username. |
|  password |The password. |

|  Property | Description |
|-----------|-------------|
|Security.LogonType.Interactive | This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, remote shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore, it is inappropriate for some client/server applications, such as a mail server. |
|Security.LogonType.Network | This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not cache credentials for this logon type. |
|Security.LogonType.Batch | This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention. This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or Web servers. The LogonUser function does not cache credentials for this logon type. |
|Security.LogonType.Service | Indicates a service-type logon. The account provided must have the service privilege enabled. |
|Security.LogonType.Unlock | This logon type is for GINA DLLs that log on users who will be interactively using the computer. This logon type can generate a unique audit record that shows when the workstation was unlocked. |
|Security.LogonType.NetworkCleartext | This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network servers while impersonating the client. A server can accept plaintext credentials from a client, call LogonUser, verify that the user can access the system across the network, and still communicate with other servers. NOTE: Windows NT: This value is not supported. |
|Security.LogonType.NewCredentials | This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has the same local identifier but uses different credentials for other network connections. NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider. NOTE: Windows NT: This value is not supported. |
|Security.LogonProvider.Default | Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the domain name and the user name is not in UPN format. In this case, the default provider is NTLM. NOTE: Windows 2000/NT: The default security provider is NTLM. |
|Security.LogonProvider.WinNT35 | Use this provider if you'll be authenticating against a Windows NT 3.51 domain controller (uses the NT 3.51 logon provider). |
|Security.LogonProvider.WinNT40 | Use the NTLM logon provider. |
|Security.LogonProvider.WinNT50 | Use the negotiate logon provider. |

#### Security.Impersonation.#ctor(System.String,System.String,System.String,Security.LogonType,Security.LogonProvider)

 Begins impersonation with the given credentials, Logon type and Logon provider.


#### Security.Impersonation.#ctor

 Initializes a new instance of the [[|Security.Impersonation]] class.


#### Security.Impersonation.Dispose

 Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.


#### Security.Impersonation.Impersonate(System.String,System.String,System.String,Security.LogonType,Security.LogonProvider)

 Impersonates the specified user account.


#### Security.Impersonation.UndoImpersonation

 Stops impersonation.


---
# ServicesManager

 Used to control windows services locally or remotely using WMI. Can find, list, install, update, uninstall, start, stop or restart services

#### ServicesManager.#ctor(System.String,System.String,System.String)

 Initializes a new instance of the [[|ServicesManager]] class connected to a remote server as a different user.


#### ServicesManager.Connect(System.String,System.String,System.String)

 Connects to the computer name passed in, leave blank for local 

| Parameter | Description |
|-----------|-------------|
|computerName |Name of the computer. Leave blank for local |
|  username |The username to connect as. Leave blank for current user |
|  password |The password for username if provided. |


#### ServicesManager.GetServices

 Gets a list of all services


#### ServicesManager.GetService(System.String)

 Gets a service by name. 

| Parameter | Description |
|-----------|-------------|
|      name |The service name to find. |


#### ServicesManager.GetServiceInfo(Models.ServiceInfo)

 Gets a service by name. 

| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. The Name property is used |


#### ServicesManager.GetServiceInfo(System.String)

 Gets a service by name. 

| Parameter | Description |
|-----------|-------------|
|      name |The service name to find. |


#### ServicesManager.GetServiceState(Models.ServiceInfo)

 Gets the state of the service. 

| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. The Name property is used. |


#### ServicesManager.GetServiceState(System.String)

 Gets the state of the service. 

| Parameter | Description |
|-----------|-------------|
|      name |The service name to find. |


#### ServicesManager.InstallService(System.String,System.String,System.String,System.String,System.String,System.String,Models.ServiceType,Models.OnError,Models.StartMode,System.Boolean,System.String,System.String[],System.String[])

 Installs a windows service. Ensures user has Logon as a service right by calling [[|Security.SetLogonAsAService(System.String,System.String)]]

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|svcDispName |Display name of the service |
|   svcPath |The service file path. |
|description |The service description. |
|  username |The username to run the service. |
|  password |The password of the user running the service. |
|   svcType |Type of the service. |
| errHandle |The error handle type. |
|svcStartMode |The service start mode. |
|interactWithDesktop |if set to true service can interact with desktop. |
|loadOrderGroup |The load order group. |
|loadOrderGroupDependencies |The load order group dependencies. |
|svcDependencies |Any service dependencies. |
Returns: [[|WMI.ReturnValue]]


#### ServicesManager.InstallService(Models.ServiceInfo)

 Installs a windows service. Ensures user has Logon as a service right by calling [[|Security.SetLogonAsAService(System.String,System.String)]]

| Parameter | Description |
|-----------|-------------|
|   service |The service information object. [[|Models.ServiceInfo]] |


#### ServicesManager.IsServiceInstalled(Models.ServiceInfo)

 Determines whether a service is installed by name. 

| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. Name property is used |
Returns: True if installed


#### ServicesManager.IsServiceInstalled(System.String)

 Determines whether a service is installed by name. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
Returns: True if installed


#### ServicesManager.ChangeCredentials(System.String,System.String,System.String)

 Changes the credentials of a service. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|  username |The new username. Can be a domain user by passing "Domain\Username" |
|  password |The new password. |


#### ServicesManager.Change(Models.ServiceInfo)

 Changes the specified service username, password or path. 

| Parameter | Description |
|-----------|-------------|
|   service |The service to update. |


#### ServicesManager.GetDescription(System.String)

 Gets the description of the service from the registry. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### ServicesManager.SetDescription(System.String,System.String)

 Sets the description of the service in the registry. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|description |The description text to set. |


#### ServicesManager.GetPath(System.String)

 Gets the path of the service in the registry. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### ServicesManager.SetPath(System.String,System.String)

 Sets the path of the service in the registry. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|      path |The path to set. |


#### ServicesManager.UninstallService(System.String)

 Uninstalls the service from the system. 

| Parameter | Description |
|-----------|-------------|
|   svcName |The service name. |


#### ServicesManager.UninstallService(Models.ServiceInfo)

 Uninstalls the service from the system. 

| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. Name property is used |


#### ServicesManager.StartService(System.String)

 Starts the service. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### ServicesManager.StartService(Models.ServiceInfo)

 Starts the service. 

| Parameter | Description |
|-----------|-------------|
|   service |The service information object. Name property is used |


#### ServicesManager.StopService(System.String)

 Stops the service. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### ServicesManager.StopService(Models.ServiceInfo)

 Stops the service. 

| Parameter | Description |
|-----------|-------------|
|   service |The service information object. Name property is used |


#### ServicesManager.WaitForState(System.String,Models.ServiceState,System.Int32)

 Waits for the service to be in a given state. 

| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|     state |The state to wait for. |
| timeoutMs |The timeout in milliseconds. |


#### ServicesManager.WaitForState(Models.ServiceInfo,Models.ServiceState,System.Int32)

 Waits for the service to be in a given state. 

| Parameter | Description |
|-----------|-------------|
|   service |The service information object. |
|     state |The state to wait for. |
| timeoutMs |The timeout in milliseconds. |
Returns: True when service is in given state. False if service is not in given state by the end of the timeout period


---
# SharedFolderConnection

 Create a connection to a shared folder with a different set of credentials 

_C# code_

```c#
    Connect to a server share and copy a file as a different user:
    
    using (new SharedFolderConnection(@"\\192.168.1.9", new NetworkCredential("user", "password", "domain")))
    {
        File.Copy(@"\\192.168.1.9\some share\some file.txt", @"c:\dest\some file.txt", true); 
    }
    
```

#### SharedFolderConnection.#ctor(System.String,System.Net.NetworkCredential)

 Initializes a new instance of the [[|SharedFolderConnection]] class. 

| Parameter | Description |
|-----------|-------------|
|       unc |The unc. \\Server |
|credentials |The [[|System.Net.NetworkCredential]]. |


---
# TaskList

 Provides functions for running async work.

#### TaskList.#ctor

 Initializes a new instance of the [[|TaskList]] class with a max thread count of 50.


#### TaskList.#ctor(System.Int32)

 Initializes a new instance of the [[|TaskList]] class with a limited number of threads. 

| Parameter | Description |
|-----------|-------------|
|   threads |The number of threads to limit. |


#### TaskList.AddTask(System.Action)

 Adds the task to the list. If a thread is available work starts right away otherwise it waits for a thread then starts 

| Parameter | Description |
|-----------|-------------|
|      work |The action to run. |


#### TaskList.WaitForAll

 Waits for all tasks in the list to finish. Then clears the lists

|  Property | Description |
|-----------|-------------|
|TaskList.Tasks | Gets all the tasks in the list. |

#### TaskList.Run(System.Action,System.Action{System.Boolean},System.Action{System.Exception})

 Runs the specified work. If work action threw an error and error action is provided, it will be called before the after action. If after action is provided, it is ran once the work action is done. The after action is passed true if work completed successfully, false if work faulted. After and error actions are ran in the Current Synchronization Context (usually the UI thread) 

|      work |The work to the run. |
|     after |The action to run after work is complete. |
|     error |The on error action if work faulted |


#### TaskList.Run&lt;T&gt;(System.Func{&lt;T&gt;},System.Action{&lt;T&gt;},System.Action{System.Exception})

 Runs the specified work. If work action threw an error and error action is provided, it will be called before the after action. If after action is provided, it is ran once the work action is done. The after action is passed the result of work action if it was successful. If work action faulted, after action will be passed the default of [[|T]]. After and error actions are ran in the Current Synchronization Context (usually the UI thread) 

| Parameter | Description |
|-----------|-------------|
|         T |Type returned from work function and input to after action |
|      work |The work function to run |
|     after |The after action to run |
|     error |The on error action if work faulted |


---
# WMI

 Windows Management Interface Wrapper class. Handles scoping WMI calls for local or remote computers

#### WMI.GetProperties(System.Management.ManagementBaseObject)

 Convert the property data collection to a string object dictionary 

| Parameter | Description |
|-----------|-------------|
|        mo |ManagementBaseObject |
Returns: Dictionary{string,object}


#### WMI.#ctor

 Creates a new instance of the wrapper


#### WMI.#ctor(System.String)

 Creates a new instance of the wrapper connected to a remote server


#### WMI.#ctor(System.String,System.String,System.String)

 Creates a new instance of the wrapper connected to a remote server as a different user


#### WMI.Finalize

 Clean up unmanaged references


#### WMI.Initialize(System.String,System.String,System.String)

 Initializes the WMI connection 

| Parameter | Description |
|-----------|-------------|
|  username |Username to connect to server with |
|  password |Password to connect to server with |
|    server |Server to connect to |


#### WMI.Scope

 Creates a [[|System.Management.ManagementScope]] scoped to the current connection


#### WMI.ScopedObject(System.String,System.Management.ObjectGetOptions)

 Creates a [[|System.Management.ManagementObject]] scoped to the current connection 

| Parameter | Description |
|-----------|-------------|
|      path |The WMI path |
|   options |Additional options, if needed |


#### WMI.ScopedClass(System.String,System.Management.ObjectGetOptions)

 Creates a [[|System.Management.ManagementClass]] scoped to the current connection 

| Parameter | Description |
|-----------|-------------|
|      path |The WMI path |
|   options |Additional options, if needed |


#### WMI.GetObjects(System.String)

 Get an instance of the specified class 

| Parameter | Description |
|-----------|-------------|
|  wmiClass |Type of the class |
Returns: Array of management objects


#### WMI.GetObjects(System.String,System.String)

 Get an instance of the specified class filtered by a where clause 

| Parameter | Description |
|-----------|-------------|
|  wmiClass |Type of the class |
|     where |The where clause filter to apply |


#### WMI.GetObjectsByName(System.String,System.String)

 Get an instance of the specified class filtered by name 

| Parameter | Description |
|-----------|-------------|
|  wmiClass |Type of the class |
|      name |The name to filter by |


#### WMI.Dispose

 Managed dispose


#### WMI.Dispose(System.Boolean)

 Dispose of managed and unmanaged objects 

| Parameter | Description |
|-----------|-------------|
| disposing |             |

|  Property | Description |
|-----------|-------------|
|WMI.ConnectionOptions | Gets or sets the management scope |
|WMI.Server | Gets the server connected to |
|WMI.Username | Gets the username used to connect |
|WMI.Password | Gets the password used to connect |
|WMI.WmiNameSpace | Gets or sets the WMI namespace. default is CimV2 |

---
# WMI.ReturnValue

 WMI Common Return Values


