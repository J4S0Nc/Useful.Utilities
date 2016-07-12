## Useful.Utilities ##
- [Useful.Utilities.Certificate](#usefulutilitiescertificate) Deals with windows x509 certificates
- [Useful.Utilities.Compression](#usefulutilitiescompression) Unbuffered compression/decompression methods using GZip
- [Useful.Utilities.Models.ComputerInfo](#usefulutilitiesmodelscomputerinfo) Model for holding computer information. Also handles converting a[Useful.Utilities.Models.ComputerInfo.ManagementObject]to a model.[http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx]
- [Useful.Utilities.Models.FeatureInfo](#usefulutilitiesmodelsfeatureinfo) Model for holding feature information. Also handles converting a[Useful.Utilities.Models.FeatureInfo.ManagementObject]to a model.[http://msdn.microsoft.com/en-us/library/cc280268(v=vs.85).aspx]
- [Useful.Utilities.Models.FeaturesAndRoles](#usefulutilitiesmodelsfeaturesandroles) List of Features and Roles that can be mapped to the FeatureInfo Id and Parent Id property
- [Useful.Utilities.Models.ServiceType](#usefulutilitiesmodelsservicetype) Type of Windows Service
- [Useful.Utilities.Models.OnError](#usefulutilitiesmodelsonerror) Windows Service Error reporting mode
- [Useful.Utilities.Models.ProcessInfo](#usefulutilitiesmodelsprocessinfo) Model for holding process information. Also handles converting a[Useful.Utilities.Models.ProcessInfo.ManagementObject]to a model.
- [Useful.Utilities.Models.ServiceInfo](#usefulutilitiesmodelsserviceinfo) Model for holding service information. Also handles converting a[Useful.Utilities.Models.ServiceInfo.ManagementObject]to a model.
- [Useful.Utilities.Models.ServiceState](#usefulutilitiesmodelsservicestate) Windows Service state
- [Useful.Utilities.Models.StartMode](#usefulutilitiesmodelsstartmode) Windows Service start mode
- [Useful.Utilities.CryptoManager](#usefulutilitiescryptomanager) Used to Encrypt / Decrypt strings and byte arrays
- [Useful.Utilities.Database](#usefulutilitiesdatabase) SQL Database functions
- [Useful.Utilities.DynamicRow](#usefulutilitiesdynamicrow) Custom Dynamic Object for dealing with DataRow Objects
- [Useful.Utilities.FileUtility](#usefulutilitiesfileutility) File Utility functions
- [Useful.Utilities.FileUtility.WindowsShares](#usefulutilitiesfileutilitywindowsshares) Support class for listing windows shares
- [Useful.Utilities.GacUtility](#usefulutilitiesgacutility) A utility class for interacting with the Global Assembly Cache.
- [Useful.Utilities.Helpers](#usefulutilitieshelpers) Extensions and helper methods
- [Useful.Utilities.IAssemblyCache](#usefulutilitiesiassemblycache) Defines a contract for interacting with the Global Assembly Cache.
- [Useful.Utilities.IisManager](#usefulutilitiesiismanager) IIS Server Manager Wrapper. can be used for local and remote IIS settings
- [Useful.Utilities.IisManager.ApplicationSslFlags](#usefulutilitiesiismanagerapplicationsslflags) Application level SSL Flags
- [Useful.Utilities.ComputerManager](#usefulutilitiescomputermanager) Collection of computer, domain, and user name functions
- [Useful.Utilities.NetworkConnection](#usefulutilitiesnetworkconnection) Creates a connection to a network resource with a given set of credentials
- [Useful.Utilities.ObjectCopier](#usefulutilitiesobjectcopier) Perform a deep copy of an object. Binary Serialization is used to perform the copy.
- [Useful.Utilities.ProcessManager](#usefulutilitiesprocessmanager) Used to list, start and stop processes locally or remotely using WMI
- [Useful.Utilities.RandomExtensions](#usefulutilitiesrandomextensions) Extension methods for System.Random objects. IEnumerable extension to get a random item.
- [Useful.Utilities.RegistryHelper](#usefulutilitiesregistryhelper) Windows registry wrapper. Used to read, write and delete keys and values. Handles picking 64bit or 32bit views. Can be used on local or remote registries.
- [Useful.Utilities.Security](#usefulutilitiessecurity) Security Utility Functions
- [Useful.Utilities.ServicesManager](#usefulutilitiesservicesmanager) Used to control windows services locally or remotely using WMI. Can find, list, install, update, uninstall, start, stop or restart services
- [Useful.Utilities.SharedFolderConnection](#usefulutilitiessharedfolderconnection) Create a connection to a shared folder with a different set of credentials
- [Useful.Utilities.TaskList](#usefulutilitiestasklist) Provides functions for running async work.
- [Useful.Utilities.WebBase](#usefulutilitieswebbase) Base class for building Web Clients that take and return typed objects.
- [Useful.Utilities.JsonContent](#usefulutilitiesjsoncontent) Provides HTTP content based on JSON string. Sets media type to "application/json"
- [Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse](#usefulutilitiesusefulutilitieswebmodelshttpresponse) Model for storing raw HTTP responses.
- [Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse&lt;T&gt;](#usefulutilitiesusefulutilitieswebmodelshttpresponse&lt;T&gt;) Model for storing typed HTTP responses.
- [Useful.Utilities.Useful.Utilities.Web.Models.Method](#usefulutilitiesusefulutilitieswebmodelsmethod) Supported HTTP Methods: GET, POST, PUT, DELETE
- [Useful.Utilities.Useful.Utilities.Web.Ext.WebRequestExt](#usefulutilitiesusefulutilitieswebextwebrequestext) Web Request Extension methods
- [Useful.Utilities.WMI](#usefulutilitieswmi) Windows Management Interface Wrapper class. Handles scoping WMI calls for local or remote computers
- [Useful.Utilities.WMI.ReturnValue](#usefulutilitieswmireturnvalue) WMI Common Return Values

---
# Useful.Utilities.Certificate

Deals with windows x509 certificates

#### Useful.Utilities.Certificate.Select(System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String,System.String,System.String)

Selects the specified store using built-in windows UI


| Parameter | Description |
|-----------|-------------|
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |
|windowTitle |The window title. |
| windowMsg |The window message. |


#### Useful.Utilities.Certificate.GetByThumbprint(System.String,System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

Gets a certificate by thumb print.


| Parameter | Description |
|-----------|-------------|
|thumbprint |the cert thumb print to find |
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


#### Useful.Utilities.Certificate.GetCerts(System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

Gets a list of Cert names and thumb prints in a tuple


| Parameter | Description |
|-----------|-------------|
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


#### Useful.Utilities.Certificate.Setup(System.String,System.String,System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

Install a PFX file to the cert store


| Parameter | Description |
|-----------|-------------|
|  fileName |Name of the PFX file. |
|  password |The password. |
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


#### Useful.Utilities.Certificate.GetStore(System.Security.Cryptography.X509Certificates.StoreName,System.Security.Cryptography.X509Certificates.StoreLocation,System.String)

Helper function to connect to a cert store. Can be local or remote


| Parameter | Description |
|-----------|-------------|
|     store |The store to look in |
|  location |The location to look in |
|remoteComputer |remote computer to run on |


---
# Useful.Utilities.Compression

Unbuffered compression/decompression methods using GZip

#### Useful.Utilities.Compression.Compress(System.String)

Compresses a string using GZip


| Parameter | Description |
|-----------|-------------|
|      text |The text to compress |


#### Useful.Utilities.Compression.Compress(System.Byte[])

Use GZip Compression


| Parameter | Description |
|-----------|-------------|
|      data |             |


#### Useful.Utilities.Compression.Decompress(System.String)

Decompresses a string


| Parameter | Description |
|-----------|-------------|
|compressedText |The compressed text |


#### Useful.Utilities.Compression.Decompress(System.Byte[])

Use GZip Decompression


| Parameter | Description |
|-----------|-------------|
|compressed |             |


---
# Useful.Utilities.Models.ComputerInfo

Model for holding computer information. Also handles converting a[Useful.Utilities.Models.ComputerInfo.ManagementObject]to a model.[http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx]

|  Property | Description |
|-----------|-------------|
|Useful.Utilities.Models.ComputerInfo.DNSHostName |Name of local computer according to the domain name server (DNS). |
|Useful.Utilities.Models.ComputerInfo.Domain |Name of the domain to which a computer belongs. |
|Useful.Utilities.Models.ComputerInfo.Manufacturer |Name of a computer manufacturer. |
|Useful.Utilities.Models.ComputerInfo.Model |Product name that a manufacturer gives to a computer. This property must have a value. |
|Useful.Utilities.Models.ComputerInfo.Name |Name of object |
|Useful.Utilities.Models.ComputerInfo.NumberOfLogicalProcessors |Number of logical processors available on the computer. |
|Useful.Utilities.Models.ComputerInfo.NumberOfProcessors |Number of all processors available on the computer. |
|Useful.Utilities.Models.ComputerInfo.PartOfDomain |Null if unknown |
|Useful.Utilities.Models.ComputerInfo.PrimaryOwnerContact |Contact information for the primary system owner, |
|Useful.Utilities.Models.ComputerInfo.PrimaryOwnerName |Name of the primary system owner. |
|Useful.Utilities.Models.ComputerInfo.TotalPhysicalMemory |Total size of physical memory. Be aware this property may not return an accurate value |
|Useful.Utilities.Models.ComputerInfo.UserName |Name of a user that is logged on currently to the console (not remote desktop users) |
|Useful.Utilities.Models.ComputerInfo.Workgroup |Name of the work group for this computer. Only if the value of the PartOfDomain property is False |

---
# Useful.Utilities.Models.FeatureInfo

Model for holding feature information. Also handles converting a[Useful.Utilities.Models.FeatureInfo.ManagementObject]to a model.[http://msdn.microsoft.com/en-us/library/cc280268(v=vs.85).aspx]

---
# Useful.Utilities.Models.FeaturesAndRoles

List of Features and Roles that can be mapped to the FeatureInfo Id and Parent Id property

---
# Useful.Utilities.Models.ServiceType

Type of Windows Service

---
# Useful.Utilities.Models.OnError

Windows Service Error reporting mode

---
# Useful.Utilities.Models.ProcessInfo

Model for holding process information. Also handles converting a[Useful.Utilities.Models.ProcessInfo.ManagementObject]to a model.

---
# Useful.Utilities.Models.ServiceInfo

Model for holding service information. Also handles converting a[Useful.Utilities.Models.ServiceInfo.ManagementObject]to a model.

---
# Useful.Utilities.Models.ServiceState

Windows Service state

---
# Useful.Utilities.Models.StartMode

Windows Service start mode

---
# Useful.Utilities.CryptoManager

Used to Encrypt / Decrypt strings and byte arrays

#### Useful.Utilities.CryptoManager.NewKey

Helper that generates a random key on each call.


#### Useful.Utilities.CryptoManager.Sha256(System.String)

Hash the string using SHA256 and return base64 encoded string


| Parameter | Description |
|-----------|-------------|
|     input |             |


#### Useful.Utilities.CryptoManager.Encrypt(System.String,System.Byte[],System.Byte[],System.Byte[])

Encryption (AES) then Authentication (HMAC) for a UTF8 Message.


| Parameter | Description |
|-----------|-------------|
|secretMessage |The secret message. |
|  cryptKey |The crypt key. |
|   authKey |The auth key. |
|nonSecretPayload |(Optional) Non-Secret Payload. |

Returns: Encrypted Message


Throws: [[System.ArgumentException|System.ArgumentException]]: Secret Message Required!;secretMessage



>Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Block-size + HMac-Tag(32)) * 1.33 Base64


#### Useful.Utilities.CryptoManager.Decrypt(System.String,System.Byte[],System.Byte[],System.Int32)

Authentication (HMAC) then Decryption (AES) for a secret UTF8 Message.


| Parameter | Description |
|-----------|-------------|
|encryptedMessage |The encrypted message. |
|  cryptKey |The crypt key. |
|   authKey |The auth key. |
|nonSecretPayloadLength |Length of the non secret payload. |

Returns: Decrypted Message


Throws: [[System.ArgumentException|System.ArgumentException]]: Encrypted Message Required!;encryptedMessage


#### Useful.Utilities.CryptoManager.EncryptWithPassword(System.String,System.String,System.Byte[])

Encryption (AES) then Authentication (HMAC) of a UTF8 message using Keys derived from a Password (PBKDF2).


| Parameter | Description |
|-----------|-------------|
|secretMessage |The secret message. |
|  password |The password. |
|nonSecretPayload |The non secret payload. |

Returns: Encrypted Message


Throws: [[System.ArgumentException|System.ArgumentException]]: password



>Significantly less secure than using random binary keys. Adds additional non secret payload for key generation parameters.


#### Useful.Utilities.CryptoManager.DecryptWithPassword(System.String,System.String,System.Int32)

Authentication (HMAC) and then Decryption (AES) of a UTF8 Message using keys derived from a password (PBKDF2).


| Parameter | Description |
|-----------|-------------|
|encryptedMessage |The encrypted message. |
|  password |The password. |
|nonSecretPayloadLength |Length of the non secret payload. |

Returns: Decrypted Message


Throws: [[System.ArgumentException|System.ArgumentException]]: Encrypted Message Required!;encryptedMessage



>Significantly less secure than using random binary keys.


---
# Useful.Utilities.Database

SQL Database functions

#### Useful.Utilities.Database.#ctor(System.String)

Initializes a new instance of the[Useful.Utilities.Database]class.


| Parameter | Description |
|-----------|-------------|
|connection |The connection string. |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.Database.Connection |The database connection string. |

#### Useful.Utilities.Database.ConnectionParts

Parses the connection string in to a[System.Data.SqlClient.SqlConnectionStringBuilder]


#### Useful.Utilities.Database.ConnectionParts(System.String)

Parses the connection string in to a[System.Data.SqlClient.SqlConnectionStringBuilder]


| Parameter | Description |
|-----------|-------------|
|connection |The connection string to parse |


#### Useful.Utilities.Database.TestConnection(System.Boolean)

Tests the connection.


| Parameter | Description |
|-----------|-------------|
|throwOnError |Flag to throw or hide connection errors |

Returns: True if successful


#### Useful.Utilities.Database.TestConnection(System.String,System.Boolean)

Tests the connection.


| Parameter | Description |
|-----------|-------------|
|connection |The connection string. |
|throwOnError |Flag to throw or hide connection errors |

Returns: True if successful


Throws: [[System.ArgumentNullException|System.ArgumentNullException]]: Connection string must have Data Source and Initial Catalog both set


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.Database.Servers |Gets a list of all available instances of SQL Server within the local network.


Returns: string array of server names |

#### Useful.Utilities.Database.Databases(System.String,System.String,System.String)

Gets a list of databases on a given server. To use NT Auth leave user/pass blank


| Parameter | Description |
|-----------|-------------|
|    server |Server to connect to |
|  username |SQL Auth user. To use NT Auth leave blank |
|  password |SQL Auth password |

Returns: string array of database names


#### Useful.Utilities.Database.ExecuteSql(System.String,System.String)

Executes a non query.


| Parameter | Description |
|-----------|-------------|
|       sql |SQL statement to execute |
|connection |SQL connection string |


#### Useful.Utilities.Database.ExecuteScalar(System.Data.SqlClient.SqlCommand,System.String)

Executes a scalar


| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |

Returns: Scalar result


#### Useful.Utilities.Database.ExecuteNonQuery(System.Data.SqlClient.SqlCommand,System.String)

Executes a non query.


| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |


#### Useful.Utilities.Database.ExecuteCount(System.Data.SqlClient.SqlCommand,System.String)

Executes a scalar and attempts to parse the result to integer. If parse fails -1 is returned


| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |

Returns: Scalar result as integer or -1


#### Useful.Utilities.Database.ExecuteStoredProc(System.String,System.String)

Executes a stored procedure as a non query


| Parameter | Description |
|-----------|-------------|
|storedProcName |             |
|connection |SQL connection string |


#### Useful.Utilities.Database.GetDataset(System.Data.SqlClient.SqlCommand,System.String)

Executes a Sql Adapter and fills a dataset


| Parameter | Description |
|-----------|-------------|
|    sqlCmd |The command to execute |
|connection |SQL connection string |

Returns: A Filled DataSet


#### Useful.Utilities.Database.Run(System.String,System.String)

Run a SQL command and return each row as a dynamic row


| Parameter | Description |
|-----------|-------------|
|       sql |             |

Returns: Enumeration of[Useful.Utilities.DynamicRow]


---
# Useful.Utilities.DynamicRow

Custom Dynamic Object for dealing with DataRow Objects

#### Useful.Utilities.DynamicRow.#ctor(System.Data.DataRow)

Initializes a new instance of the[Useful.Utilities.DynamicRow]class.


| Parameter | Description |
|-----------|-------------|
|       row |The data row object. |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.DynamicRow.DataRow |Gets the data row that created this DynamicRow object |

#### Useful.Utilities.DynamicRow.Convert(System.Data.DataTable)

Converts the specified table to Enumeration of[Useful.Utilities.DynamicRow].


| Parameter | Description |
|-----------|-------------|
|     table |The data table to convert. |

Returns: Enumeration of[Useful.Utilities.DynamicRow]


---
# Useful.Utilities.FileUtility

File Utility functions

#### Useful.Utilities.FileUtility.WaitForFile(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare,System.Int32,System.Int32)

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


#### Useful.Utilities.FileUtility.IsFileLocked(System.String,System.IO.FileMode,System.IO.FileAccess,System.IO.FileShare)

Checks if a file is locked by attempting to open it.


| Parameter | Description |
|-----------|-------------|
|      file |File Path to open |
|      mode |             |
|    access |             |
|     share |             |


#### Useful.Utilities.FileUtility.FileExists(System.String,System.String)

Checks if a file exists. If remote computer is passed in the path is converted to a UNC first


| Parameter | Description |
|-----------|-------------|
|      path |File path to check |
|  computer |optional remote computer name to check for the file |


#### Useful.Utilities.FileUtility.CopyFile(System.String,System.String,System.Boolean)

Ensures the destination directory exists then copies a file.


| Parameter | Description |
|-----------|-------------|
|    source |The source file path. |
|      dest |The destination file path. |
| overwrite |allow destination file to be overwritten if it exists. |


#### Useful.Utilities.FileUtility.GetUniversalPath(System.String,System.String)

Takes a local file path and translates it into a UNC file path where possible.


| Parameter | Description |
|-----------|-------------|
|      path |Path to convert to UNC. |
|  computer |Machine name to use, if not set uses local machine |

Throws: [[System.ArgumentException|System.ArgumentException]]: 


Returns: UNC path otherwise throws Argument Exception.


#### Useful.Utilities.FileUtility.ClearReadOnly(System.String)

Clears the read only flag on a file


| Parameter | Description |
|-----------|-------------|
|      path |Path to the file |


---
# Useful.Utilities.FileUtility.WindowsShares

Support class for listing windows shares

---
# Useful.Utilities.GacUtility

A utility class for interacting with the Global Assembly Cache.

#### Useful.Utilities.GacUtility.Remove(System.String)

Removes an assembly from the GAC.


| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to remove. |

Returns: A magic number.


#### Useful.Utilities.GacUtility.Add(System.String)

Adds an assembly to the GAC.


| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to add. |

Returns: A magic number.


#### Useful.Utilities.GacUtility.AddAssembly(System.String)

Adds an assembly to the GAC.


| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to add. |

Returns: A magic number.


#### Useful.Utilities.GacUtility.RemoveAssembly(System.String)

Removes an assembly from the GAC.


| Parameter | Description |
|-----------|-------------|
|assemblyName |The name of the assembly to remove. |

Returns: A magic number.


#### Useful.Utilities.GacUtility.RemoveByKey(System.String)

Starts a background task that removes all assemblies from the GAC matching a given key


| Parameter | Description |
|-----------|-------------|
|       key |The key to remove |


#### Useful.Utilities.GacUtility.GetByKey(System.String)

Gets a list of paths to all files matching the given key


| Parameter | Description |
|-----------|-------------|
|       key |The key to find |

Returns: list of file paths


---
# Useful.Utilities.Helpers

Extensions and helper methods

#### Useful.Utilities.Helpers.ToEnum&lt;T&gt;(System.Object,System.String)

Convert a string object to an Enum

_c# Example_

```c#
    //define some example enums
    enum SomeEnum { Yes, No, File_Not_Found }
    enum AnotherEnum { No, Maybe, Yes }
    
    //turn a string into an enum
    SomeEnum yes = "Yes".ToEnum<SomeEnum>();
    // replace spaces with _
    SomeEnum fileNotFound = "File not found".ToEnum<SomeEnum>("_");
    
    //convert one enum to another enum with matching name (not value)
    SomeEnum someEnumYes = SomeEnum.Yes; //value of 0
    AnotherEnum anotherEnumYes = someEnumYes.ToEnum<AnotherEnum>(); //value of 2
    
```


| Parameter | Description |
|-----------|-------------|
|         T |The type of Enum to convert to |

| Parameter | Description |
|-----------|-------------|
|     value |The object to convert |
|spaceReplace |If value has spaces, They will be replaced |


#### Useful.Utilities.Helpers.ToEnum&lt;T&gt;(System.String,System.String)

Convert a string to an Enum


| Parameter | Description |
|-----------|-------------|
|         T |The type of Enum to convert to |

| Parameter | Description |
|-----------|-------------|
|     value |The object to convert |
|spaceReplace |If value has spaces, They will be replaced |


#### Useful.Utilities.Helpers.ToHex(System.Byte[])

Convert a byte array to a hexadecimal string.


| Parameter | Description |
|-----------|-------------|
|     bytes |The bytes.   |


#### Useful.Utilities.Helpers.GetAttribute&lt;T2&gt;(System.Enum,System.Func{&lt;T&gt;,&lt;T&gt;})

Gets attribute from an enumeration object


| Parameter | Description |
|-----------|-------------|
|         T |Input type   |
| TExpected |The return type |

| Parameter | Description |
|-----------|-------------|
|enumeration |The enum value |
|expression |             |


#### Useful.Utilities.Helpers.Description(System.Enum)

Gets the description value from the[System.ComponentModel.DescriptionAttribute]of the enum. If enum doesn't have a description attribute, null is returned


| Parameter | Description |
|-----------|-------------|
|enumeration |The enum value to look at |

Returns: description value from the[System.ComponentModel.DescriptionAttribute]or null


#### Useful.Utilities.Helpers.IsTrue(System.Nullable{System.Boolean})

If the nullable Boolean value is null or false, false is returned. if the nullable Boolean has a value and its true, true is returned.


| Parameter | Description |
|-----------|-------------|
|     value |nullable Boolean |

Returns: true or false


#### Useful.Utilities.Helpers.IsTrueOrNull(System.Nullable{System.Boolean})

If the nullable Boolean value is null or true, true is returned. if the nullable Boolean has a value and its false, false is returned.


| Parameter | Description |
|-----------|-------------|
|     value |nullable Boolean |

Returns: true or false


#### Useful.Utilities.Helpers.Default&lt;T&gt;(System.Object,&lt;T&gt;)

If object is null[value]is returned. If object is empty string or min date time,[value]is returned. If object is a different type then value it may be casted or may throw an[System.InvalidCastException]


| Parameter | Description |
|-----------|-------------|
|         T |The default value type |

| Parameter | Description |
|-----------|-------------|
|       obj |the object   |
|     value |Default value to return when object is null or doesn't match rules |

Throws: [[System.InvalidCastException|System.InvalidCastException]]: When object is different type then default value InvalidCastException might be thrown


#### Useful.Utilities.Helpers.RoundDown(System.Single,System.Int32)

Round a number down. Can set number of decimal places.


| Parameter | Description |
|-----------|-------------|
|    number |             |
|decimalPlaces |             |


#### Useful.Utilities.Helpers.RoundUp(System.Single,System.Int32)

Round a number up. Can set number of decimal places.


| Parameter | Description |
|-----------|-------------|
|    number |             |
|decimalPlaces |             |


#### Useful.Utilities.Helpers.ToLong(System.String)

Convert s string to a long, throws cast exception if it fails


| Parameter | Description |
|-----------|-------------|
|       str |             |

Throws: [[System.InvalidCastException|System.InvalidCastException]]:


#### Useful.Utilities.Helpers.TryToLong(System.String)

Attempt to cast a string to a long, return null if unable to cast


| Parameter | Description |
|-----------|-------------|
|       str |             |


#### Useful.Utilities.Helpers.Traverse&lt;T&gt;(System.Collections.Generic.IEnumerable{&lt;T&gt;},System.Func{&lt;T&gt;,System.Collections.Generic.IEnumerable{&lt;T&gt;}})

Recursively search a tree collection based on the child selector


| Parameter | Description |
|-----------|-------------|
|         T |             |

| Parameter | Description |
|-----------|-------------|
|     items |             |
|childSelector |             |


---
# Useful.Utilities.IAssemblyCache

Defines a contract for interacting with the Global Assembly Cache.

#### Useful.Utilities.IAssemblyCache.UninstallAssembly(System.UInt32,System.String,System.IntPtr,System.UInt32@)

Uninstalls the assembly.


| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pszAssemblyName |Name of the PSZ assembly. |
|pvReserved |The pv reserved. |
|pulDisposition |The pul disposition. |


#### Useful.Utilities.IAssemblyCache.QueryAssemblyInfo(System.UInt32,System.String,System.IntPtr)

Queries the assembly information.


| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pszAssemblyName |Name of the PSZ assembly. |
|  pAsmInfo |The p asm information. |


#### Useful.Utilities.IAssemblyCache.CreateAssemblyCacheItem(System.UInt32,System.IntPtr,System.IntPtr@,System.String)

Creates the assembly cache item.


| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pvReserved |The pv reserved. |
| ppAsmItem |The pp asm item. |
|pszAssemblyName |Name of the PSZ assembly. |


#### Useful.Utilities.IAssemblyCache.CreateAssemblyScavenger(System.Object@)

Creates the assembly scavenger.


| Parameter | Description |
|-----------|-------------|
|ppAsmScavenger |The pp asm scavenger. |


#### Useful.Utilities.IAssemblyCache.InstallAssembly(System.UInt32,System.String,System.IntPtr)

Installs the assembly.


| Parameter | Description |
|-----------|-------------|
|   dwFlags |The dw flags. |
|pszManifestFilePath |The PSZ manifest file path. |
|pvReserved |The pv reserved. |


---
# Useful.Utilities.IisManager

IIS Server Manager Wrapper. can be used for local and remote IIS settings

---
# Useful.Utilities.IisManager.ApplicationSslFlags

Application level SSL Flags

#### Useful.Utilities.IisManager.#ctor(System.String)

Initializes a new instance of the[Useful.Utilities.IisManager]class connected to a remote computer


| Parameter | Description |
|-----------|-------------|
|remoateServer |The remote server. |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.IisManager.RemoteServer |The remote server currently connected to. |
|Useful.Utilities.IisManager.ServerManager |Gets the server manager. Either local or remote based on[Useful.Utilities.IisManager.RemoteServer] |

#### Useful.Utilities.IisManager.ListSites

List all IIS web sites


#### Useful.Utilities.IisManager.ListSiteNames

List all IIS web sites


#### Useful.Utilities.IisManager.GetSite(System.String)

Get single site by name


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### Useful.Utilities.IisManager.SiteState(System.String)

Get site state (stopped, running, etc)


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### Useful.Utilities.IisManager.StopSite(System.String)

Stop IIS site by name


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### Useful.Utilities.IisManager.StartSite(System.String)

Attempt to start a site by name


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### Useful.Utilities.IisManager.Processes

Get all worker process for all application pools


#### Useful.Utilities.IisManager.CreateSslSite(System.String,System.String,System.String,System.Int32)

Create a new web site on port 443


| Parameter | Description |
|-----------|-------------|
|  siteName |site name    |
|      path |root directory of site |
|  certHash |certificate thumb print |
|      port |port         |


#### Useful.Utilities.IisManager.CreateSite(System.String,System.String,System.Int32,System.String)

Create a new web site


| Parameter | Description |
|-----------|-------------|
|  siteName |display name |
|      path |Root directory |
|      port |port         |
|  certHash |certificate thumb print |


#### Useful.Utilities.IisManager.DeleteSite(System.String)

delete a site


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### Useful.Utilities.IisManager.SetBinding(System.String,System.String,System.Int32,System.String,System.String,System.Boolean)

Create or update a binding on the given site.


| Parameter | Description |
|-----------|-------------|
|  siteName |Site name    |
|        ip |IP address to apply binding to. Use * for all |
|      port |Port to apply binding to |
|hostheader |Optional host header |
| certThumb |Optional Cert thumb print, if Set protocol will be https |
|removeAllOthers |Flag to clear all other bindings on site |


#### Useful.Utilities.IisManager.ListApplications(System.String)

Get list of applications for a site


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |


#### Useful.Utilities.IisManager.GetApplication(System.String,System.String)

Get an application under the given site


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |


#### Useful.Utilities.IisManager.SetApplication(System.String,System.String,System.String,System.String,System.Boolean,System.Boolean,Useful.Utilities.IisManager.ApplicationSslFlags)

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


#### Useful.Utilities.IisManager.DeleteApplication(System.String,System.String)

Deletes an application under a site.


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |


#### Useful.Utilities.IisManager.SetApplicationPool(System.String,System.String,System.String)

Change the pool tied to an application


| Parameter | Description |
|-----------|-------------|
|  siteName |Name of the site. |
|   appName |Name of the application. |
|  poolName |Name of the application pool. |


#### Useful.Utilities.IisManager.ListPools

Lists all the application pools.


#### Useful.Utilities.IisManager.GetPool(System.String)

Gets the application pool by name.


| Parameter | Description |
|-----------|-------------|
|  poolName |Name of the application pool. |


#### Useful.Utilities.IisManager.RecyclePool(System.String)

Recycles the pool.


| Parameter | Description |
|-----------|-------------|
|  poolName |Name of the application pool. |


#### Useful.Utilities.IisManager.DeletePool(System.String)

Deletes the application pool.


| Parameter | Description |
|-----------|-------------|
|  poolName |Name of the application pool. |


#### Useful.Utilities.IisManager.SetPool(System.String,System.String,System.String,System.Int32,System.String)

create or update an application pool


| Parameter | Description |
|-----------|-------------|
|      name |The application pool name. |
|  username |The username. |
|  password |The password. |
|maxProcesses |The maximum processes. 0 for default |
|   version |The version. |

Throws: [[System.Exception|System.Exception]]:


#### Useful.Utilities.IisManager.Refresh

Refreshes this instance and restarts the[Useful.Utilities.IisManager.ServerManager]


#### Useful.Utilities.IisManager.CommitChanges

Commits the[Useful.Utilities.IisManager.ServerManager]changes.


#### Useful.Utilities.IisManager.ResetIis(System.String)

Resets IIS. Mode can be Restart, Stop, or Start


| Parameter | Description |
|-----------|-------------|
|      mode |The mode argument. Can be Restart, Stop, or Start |


#### Useful.Utilities.IisManager.IisVersion(System.String)

IIS version number. 0 if not installed or error


| Parameter | Description |
|-----------|-------------|
|remoteComputer |The remote computer. |


---
# Useful.Utilities.ComputerManager

Collection of computer, domain, and user name functions

#### Useful.Utilities.ComputerManager.#ctor(System.String,System.String,System.String)

Creates a new instance of the Computer Manager connected to a remote server as a different user


#### Useful.Utilities.ComputerManager.Computer

Gets information about the computer currently connected to.


#### Useful.Utilities.ComputerManager.Connect(System.String,System.String,System.String)

Connects to the computer name passed in, leave blank for local


| Parameter | Description |
|-----------|-------------|
|computerName |Name of the computer. Leave blank for local |
|  username |The username to connect as. Leave blank for current user |
|  password |The password for username if provided. |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.ComputerManager.DomainNameFull |Gets the full domain name of the current computer (without the computer name). Use[Useful.Utilities.ComputerManager.MachineFullName]to get FQN of current computer. |
|Useful.Utilities.ComputerManager.DomainNameBios |Gets the Domain Net BIOS of the current user. |
|Useful.Utilities.ComputerManager.UserName |Gets the username of current user |
|Useful.Utilities.ComputerManager.UserQualified |Gets the domain and username of current user. Domain\User |

#### Useful.Utilities.ComputerManager.SplitUserAndDomain(System.String)

Splits the username and domain into a Tuple. Domain is Item1, User is Item2.


| Parameter | Description |
|-----------|-------------|
|  username |The Domain\Username or User@domain string to parse. |

Returns: Domain is Item1, Username is Item2


#### Useful.Utilities.ComputerManager.EnsureDomain(System.String)

Ensures the username as a domain prefix. If no prefix is given machine name is used.


| Parameter | Description |
|-----------|-------------|
|      user |The username to check for domain. |

Returns: domain\user or machine\user


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.ComputerManager.MachineName |Gets the Machine name of the current computer (without domain). Use[Useful.Utilities.ComputerManager.MachineFullName]to get the FQN of the current computer. |
|Useful.Utilities.ComputerManager.MachineFullName |Gets the fully qualified name of the current computer. computer.domain.com |

#### Useful.Utilities.ComputerManager.IsLocal(System.String)

Checks if the name passed in is the current computer. Returns true if the string is null/empty or the name matches the current[Useful.Utilities.ComputerManager.MachineName]or[Useful.Utilities.ComputerManager.MachineFullName].


| Parameter | Description |
|-----------|-------------|
|serverName |Computer name to check |


---
# Useful.Utilities.NetworkConnection

Creates a connection to a network resource with a given set of credentials

---
# Useful.Utilities.ObjectCopier

Perform a deep copy of an object. Binary Serialization is used to perform the copy.

#### Useful.Utilities.ObjectCopier.Clone&lt;T&gt;(&lt;T&gt;)

Perform a deep Copy of the object.


| Parameter | Description |
|-----------|-------------|
|         T |The type of object being copied. |

| Parameter | Description |
|-----------|-------------|
|    source |The object instance to copy. |

Returns: The copied object.


#### Useful.Utilities.ObjectCopier.ToBytes&lt;T&gt;(&lt;T&gt;)

Takes a serializable object and returns it as a byte array.


| Parameter | Description |
|-----------|-------------|
|         T |The Type of the Object |

| Parameter | Description |
|-----------|-------------|
|    source |The source object to serialize. |

Throws: [[System.ArgumentException|System.ArgumentException]]: The type must be serializable.;source


#### Useful.Utilities.ObjectCopier.FromBytes&lt;T&gt;(System.Byte[])

Takes a byte array and desterilizes it to a object.


| Parameter | Description |
|-----------|-------------|
|         T |The Type of the Object |

| Parameter | Description |
|-----------|-------------|
|       obj |byte array of the object. |

Throws: [[System.ArgumentException|System.ArgumentException]]: The type must be serializable.;source


#### Useful.Utilities.ObjectCopier.FromXml&lt;T&gt;(System.String)

Load an object from XML string.


| Parameter | Description |
|-----------|-------------|
|         T |The Type of the Object |

| Parameter | Description |
|-----------|-------------|
|       xml |The XML.     |


#### Useful.Utilities.ObjectCopier.ToXml&lt;T&gt;(&lt;T&gt;)

Serialize an object to XML string.


| Parameter | Description |
|-----------|-------------|
|         T |The Type of Object |

| Parameter | Description |
|-----------|-------------|
|       obj |The object.  |

Returns: XML String


---
# Useful.Utilities.ProcessManager

Used to list, start and stop processes locally or remotely using WMI

#### Useful.Utilities.ProcessManager.#ctor(System.String,System.String,System.String)

Creates a new instance of the Process Manager connected to a remote server as a different user


#### Useful.Utilities.ProcessManager.Connect(System.String,System.String,System.String)

Connects to the computer name passed in, leave blank for local


| Parameter | Description |
|-----------|-------------|
|computerName |Name of the computer. Leave blank for local |
|  username |The username to connect as. Leave blank for current user |
|  password |The password for username if provided. |


#### Useful.Utilities.ProcessManager.GetProcesses(System.String)

Gets a list of running processes. Can be filtered by name


| Parameter | Description |
|-----------|-------------|
|      name |Null or blank to return all, otherwise returns all processes matching this name |


#### Useful.Utilities.ProcessManager.GetProcess(System.UInt32)

Gets a single process by process id


| Parameter | Description |
|-----------|-------------|
|        id |The process identifier |


#### Useful.Utilities.ProcessManager.Terminate(System.String,System.Boolean)

Terminates a process with the specified name.


| Parameter | Description |
|-----------|-------------|
|      name |The name of the process |
| firstOnly |Flag if all or only the first process matching the name will be terminated |


#### Useful.Utilities.ProcessManager.Terminate(System.UInt32)

Terminates a process by the specified identifier.


| Parameter | Description |
|-----------|-------------|
|        id |The process identifier |


#### Useful.Utilities.ProcessManager.Start(System.String,System.String,System.Int32)

Starts a command process.


| Parameter | Description |
|-----------|-------------|
|   command |The command to run. |
|timeoutSeconds |The number of seconds to wait before timing out (only applies to local processes). Pass 0 for no timeout |


#### Useful.Utilities.ProcessManager.Run(System.String,System.String,System.Boolean)

Starts a local process


| Parameter | Description |
|-----------|-------------|
|  filename |The file to run |
|      args |The optional arguments to pass to the file, if any |
|hideWindow |true to hide the window. |


---
# Useful.Utilities.RandomExtensions

Extension methods for System.Random objects. IEnumerable extension to get a random item.

|  Property | Description |
|-----------|-------------|
|Useful.Utilities.RandomExtensions.Random |Static access to random object |

#### Useful.Utilities.RandomExtensions.String(System.Random,System.Int32,System.String)

Generate a random string. Can take a string of characters to randomly pick from.


| Parameter | Description |
|-----------|-------------|
|    random |             |
|    length |The total length of the new string to return |
|     chars |string of characters to pick randomly from |


#### Useful.Utilities.RandomExtensions.Number(System.Random,System.Int32,System.String)

Generate a random string of numbers (may have leading zeros)


| Parameter | Description |
|-----------|-------------|
|    random |             |
|    length |             |
|     chars |string of numbers to pick randomly from |


#### Useful.Utilities.RandomExtensions.PhoneNumber(System.Random)

Generate a random phone number (10 random digits formatted as ###-###-####)


| Parameter | Description |
|-----------|-------------|
|    random |             |


#### Useful.Utilities.RandomExtensions.Bool(System.Random,System.Double)

Generate a random Boolean


| Parameter | Description |
|-----------|-------------|
|    random |             |
|    weight |Percent of weight toward true results. 0 = all false, 1 = all true |


#### Useful.Utilities.RandomExtensions.RandomItem&lt;T&gt;(System.Collections.Generic.IEnumerable{&lt;T&gt;})

Randomly sort the items and pick one. If the collection is null, null is returned.


| Parameter | Description |
|-----------|-------------|
|         T |             |

| Parameter | Description |
|-----------|-------------|
|      list |             |


---
# Useful.Utilities.RegistryHelper

Windows registry wrapper. Used to read, write and delete keys and values. Handles picking 64bit or 32bit views. Can be used on local or remote registries.

#### Useful.Utilities.RegistryHelper.GetValue&lt;T&gt;(Microsoft.Win32.RegistryKey,System.String,&lt;T&gt;)

Get the value of a key or the default if the key has no value


| Parameter | Description |
|-----------|-------------|
|         T |The type of value to return |

| Parameter | Description |
|-----------|-------------|
|       key |The Sub Key to select |
|   keyName |The key name to get |
|defaultValue |The default value to return if the key has no value |


#### Useful.Utilities.RegistryHelper.SetValue&lt;T&gt;(Microsoft.Win32.RegistryKey,System.String,&lt;T&gt;)

Sets the value of a given key


| Parameter | Description |
|-----------|-------------|
|         T |The Type of the value to be set |

| Parameter | Description |
|-----------|-------------|
|       key |The Sub Key to select |
|   keyName |the key name to set |
|     value |The value to apply to the key name |


#### Useful.Utilities.RegistryHelper.DeleteKey(Microsoft.Win32.RegistryKey,System.Boolean)

Deletes a key and value. Will delete a full tree structure by default


| Parameter | Description |
|-----------|-------------|
|       key |Sub key to select from deletion |
|deleteTree |if true current key and all children will be deleted. if there are children and this is false and error is thrown. |


#### Useful.Utilities.RegistryHelper.DeleteValue(Microsoft.Win32.RegistryKey,System.String)

Deletes the value from a given key. To delete the key use[Useful.Utilities.RegistryHelper.DeleteKey(Microsoft.Win32.RegistryKey,System.Boolean)]


| Parameter | Description |
|-----------|-------------|
|       key |The sub key name to select |
|   keyName |the key to remove the value from |


#### Useful.Utilities.RegistryHelper.GetKey(Microsoft.Win32.RegistryHive,System.String,System.String)

Gets or Creates a registry Sub Key


| Parameter | Description |
|-----------|-------------|
|      hive |[Microsoft.Win32.RegistryHive] |
|subKeyName |Path for sub key |
|  computer |Remote computer name used for execution, null or blank for local host |

Returns: [Microsoft.Win32.RegistryKey]


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.RegistryHelper.View |Selects the 64 or 32 bit registry view based on architecture. |

#### Useful.Utilities.RegistryHelper.ImportFile(System.String,System.String)

Takes a .reg file and imports it to the registry


| Parameter | Description |
|-----------|-------------|
|   regFile |Full path and name of the .reg file |
|  computer |Remote computer name used for execution, null or blank for local host |


---
# Useful.Utilities.Security

Security Utility Functions

#### Useful.Utilities.Security.SetLogonAsAService(System.String,System.String)

Set logon as a service rights for the user.


| Parameter | Description |
|-----------|-------------|
|      user |The username as domain\user. if domain is not provide machine name is used |
|remoteComputer |Can be used to execute on a remote computer. |


#### Useful.Utilities.Security.SetPrivilege(System.String,System.String,System.String)

Sets a privilege for the user.


| Parameter | Description |
|-----------|-------------|
|      user |The username as domain\user. if domain is not provide machine name is used |
| privilege |The privilege to set.[Useful.Utilities.Security.LsaWrapper] |
|remoteComputer |Can be used to execute on a remote computer. |


#### Useful.Utilities.Security.Login(System.String,System.String,System.String)

Login as a given user and return the login token


| Parameter | Description |
|-----------|-------------|
|      user |The user: domain\user |
|  password |The password. |
|remoteComputer |The remote computer. |


#### Useful.Utilities.Security.IsValidLogin(System.String,System.String,System.String)

Determines whether the specified username and password are valid. Can be ran locally or remotely


| Parameter | Description |
|-----------|-------------|
|      user |The username: domain\user |
|  password |The password. |
|    domain |The domain.  |
|remoteComputer |Can be used to execute on a remote computer. |


#### Useful.Utilities.Security.ValidateLogin(System.String,System.String,System.String)

Validates the username and password. Throws error if its invalid


| Parameter | Description |
|-----------|-------------|
|  username |The username. |
|  password |The password. |
|    domain |The domain.  |
|remoteComputer |Can be used to execute on a remote computer. |

Throws: [[System.InvalidOperationException|System.InvalidOperationException]]: Thrown if Username and password is invalid!


#### Useful.Utilities.Security.IsInRole(System.String,System.String,System.Security.Principal.WindowsBuiltInRole,System.String)

Determines whether the specified user is in a given role


| Parameter | Description |
|-----------|-------------|
|  username |The username. |
|  password |The password. |
|      role |The role.    |
|remoteComputer |Can be used to execute on a remote computer. |


#### Useful.Utilities.Security.RunAs(System.String,System.String)

Runs an action as a different user.


| Parameter | Description |
|-----------|-------------|
|  username |The username. |
|  password |The password. |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.Security.LogonType.Interactive |This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, remote shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore, it is inappropriate for some client/server applications, such as a mail server. |
|Useful.Utilities.Security.LogonType.Network |This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not cache credentials for this logon type. |
|Useful.Utilities.Security.LogonType.Batch |This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention. This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or Web servers. The LogonUser function does not cache credentials for this logon type. |
|Useful.Utilities.Security.LogonType.Service |Indicates a service-type logon. The account provided must have the service privilege enabled. |
|Useful.Utilities.Security.LogonType.Unlock |This logon type is for GINA DLLs that log on users who will be interactively using the computer. This logon type can generate a unique audit record that shows when the workstation was unlocked. |
|Useful.Utilities.Security.LogonType.NetworkCleartext |This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network servers while impersonating the client. A server can accept plaintext credentials from a client, call LogonUser, verify that the user can access the system across the network, and still communicate with other servers. NOTE: Windows NT: This value is not supported. |
|Useful.Utilities.Security.LogonType.NewCredentials |This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has the same local identifier but uses different credentials for other network connections. NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider. NOTE: Windows NT: This value is not supported. |
|Useful.Utilities.Security.LogonProvider.Default |Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the domain name and the user name is not in UPN format. In this case, the default provider is NTLM. NOTE: Windows 2000/NT: The default security provider is NTLM. |
|Useful.Utilities.Security.LogonProvider.WinNT35 |Use this provider if you'll be authenticating against a Windows NT 3.51 domain controller (uses the NT 3.51 logon provider). |
|Useful.Utilities.Security.LogonProvider.WinNT40 |Use the NTLM logon provider. |
|Useful.Utilities.Security.LogonProvider.WinNT50 |Use the negotiate logon provider. |

#### Useful.Utilities.Security.Impersonation.#ctor(System.String,System.String,System.String,Useful.Utilities.Security.LogonType,Useful.Utilities.Security.LogonProvider)

Begins impersonation with the given credentials, Logon type and Logon provider.


#### Useful.Utilities.Security.Impersonation.#ctor

Initializes a new instance of the[Useful.Utilities.Security.Impersonation]class.


#### Useful.Utilities.Security.Impersonation.Dispose

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.


#### Useful.Utilities.Security.Impersonation.Impersonate(System.String,System.String,System.String,Useful.Utilities.Security.LogonType,Useful.Utilities.Security.LogonProvider)

Impersonates the specified user account.


#### Useful.Utilities.Security.Impersonation.UndoImpersonation

Stops impersonation.


---
# Useful.Utilities.ServicesManager

Used to control windows services locally or remotely using WMI. Can find, list, install, update, uninstall, start, stop or restart services

#### Useful.Utilities.ServicesManager.#ctor(System.String,System.String,System.String)

Initializes a new instance of the[Useful.Utilities.ServicesManager]class connected to a remote server as a different user.


#### Useful.Utilities.ServicesManager.Connect(System.String,System.String,System.String)

Connects to the computer name passed in, leave blank for local


| Parameter | Description |
|-----------|-------------|
|computerName |Name of the computer. Leave blank for local |
|  username |The username to connect as. Leave blank for current user |
|  password |The password for username if provided. |


#### Useful.Utilities.ServicesManager.GetServices

Gets a list of all services


#### Useful.Utilities.ServicesManager.GetService(System.String)

Gets a service by name.


| Parameter | Description |
|-----------|-------------|
|      name |The service name to find. |


#### Useful.Utilities.ServicesManager.GetServiceInfo(Useful.Utilities.Models.ServiceInfo)

Gets a service by name.


| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. The Name property is used |


#### Useful.Utilities.ServicesManager.GetServiceInfo(System.String)

Gets a service by name.


| Parameter | Description |
|-----------|-------------|
|      name |The service name to find. |


#### Useful.Utilities.ServicesManager.GetServiceState(Useful.Utilities.Models.ServiceInfo)

Gets the state of the service.


| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. The Name property is used. |


#### Useful.Utilities.ServicesManager.GetServiceState(System.String)

Gets the state of the service.


| Parameter | Description |
|-----------|-------------|
|      name |The service name to find. |


#### Useful.Utilities.ServicesManager.InstallService(System.String,System.String,System.String,System.String,System.String,System.String,Useful.Utilities.Models.ServiceType,Useful.Utilities.Models.OnError,Useful.Utilities.Models.StartMode,System.Boolean,System.String,System.String[],System.String[])

Installs a windows service. Ensures user has Logon as a service right by calling[Useful.Utilities.Security.SetLogonAsAService(System.String,System.String)]


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

Returns: [Useful.Utilities.WMI.ReturnValue]


#### Useful.Utilities.ServicesManager.InstallService(Useful.Utilities.Models.ServiceInfo)

Installs a windows service. Ensures user has Logon as a service right by calling[Useful.Utilities.Security.SetLogonAsAService(System.String,System.String)]


| Parameter | Description |
|-----------|-------------|
|   service |The service information object.[Useful.Utilities.Models.ServiceInfo] |


#### Useful.Utilities.ServicesManager.IsServiceInstalled(Useful.Utilities.Models.ServiceInfo)

Determines whether a service is installed by name.


| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. Name property is used |

Returns: True if installed


#### Useful.Utilities.ServicesManager.IsServiceInstalled(System.String)

Determines whether a service is installed by name.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |

Returns: True if installed


#### Useful.Utilities.ServicesManager.ChangeCredentials(System.String,System.String,System.String)

Changes the credentials of a service.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|  username |The new username. Can be a domain user by passing "Domain\Username" |
|  password |The new password. |


#### Useful.Utilities.ServicesManager.Change(Useful.Utilities.Models.ServiceInfo)

Changes the specified service username, password or path.


| Parameter | Description |
|-----------|-------------|
|   service |The service to update. |


#### Useful.Utilities.ServicesManager.GetDescription(System.String)

Gets the description of the service from the registry.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### Useful.Utilities.ServicesManager.SetDescription(System.String,System.String)

Sets the description of the service in the registry.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|description |The description text to set. |


#### Useful.Utilities.ServicesManager.GetPath(System.String)

Gets the path of the service in the registry.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### Useful.Utilities.ServicesManager.SetPath(System.String,System.String)

Sets the path of the service in the registry.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|      path |The path to set. |


#### Useful.Utilities.ServicesManager.UninstallService(System.String)

Uninstalls the service from the system.


| Parameter | Description |
|-----------|-------------|
|   svcName |The service name. |


#### Useful.Utilities.ServicesManager.UninstallService(Useful.Utilities.Models.ServiceInfo)

Uninstalls the service from the system.


| Parameter | Description |
|-----------|-------------|
|   svcInfo |The service information object. Name property is used |


#### Useful.Utilities.ServicesManager.StartService(System.String)

Starts the service.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### Useful.Utilities.ServicesManager.StartService(Useful.Utilities.Models.ServiceInfo)

Starts the service.


| Parameter | Description |
|-----------|-------------|
|   service |The service information object. Name property is used |


#### Useful.Utilities.ServicesManager.StopService(System.String)

Stops the service.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |


#### Useful.Utilities.ServicesManager.StopService(Useful.Utilities.Models.ServiceInfo)

Stops the service.


| Parameter | Description |
|-----------|-------------|
|   service |The service information object. Name property is used |


#### Useful.Utilities.ServicesManager.WaitForState(System.String,Useful.Utilities.Models.ServiceState,System.Int32)

Waits for the service to be in a given state.


| Parameter | Description |
|-----------|-------------|
|   svcName |Name of the service. |
|     state |The state to wait for. |
| timeoutMs |The timeout in milliseconds. |


#### Useful.Utilities.ServicesManager.WaitForState(Useful.Utilities.Models.ServiceInfo,Useful.Utilities.Models.ServiceState,System.Int32)

Waits for the service to be in a given state.


| Parameter | Description |
|-----------|-------------|
|   service |The service information object. |
|     state |The state to wait for. |
| timeoutMs |The timeout in milliseconds. |

Returns: True when service is in given state. False if service is not in given state by the end of the timeout period


---
# Useful.Utilities.SharedFolderConnection

Create a connection to a shared folder with a different set of credentials

_c# Example_

```c#
    //Connect to a server share and copy a file as a different user:
    using (new SharedFolderConnection(@"\\192.168.1.9", new NetworkCredential("user", "password", "domain")))
    {
        File.Copy(@"\\192.168.1.9\some share\some file.txt", @"c:\dest\some file.txt", true); 
    }
    
```

#### Useful.Utilities.SharedFolderConnection.#ctor(System.String,System.Net.NetworkCredential)

Initializes a new instance of the[Useful.Utilities.SharedFolderConnection]class.


| Parameter | Description |
|-----------|-------------|
|       unc |The unc. \\Server |
|credentials |The[System.Net.NetworkCredential]. |


---
# Useful.Utilities.TaskList

Provides functions for running async work.

#### Useful.Utilities.TaskList.#ctor

Initializes a new instance of the[Useful.Utilities.TaskList]class with a max thread count of 50.


#### Useful.Utilities.TaskList.#ctor(System.Int32)

Initializes a new instance of the[Useful.Utilities.TaskList]class with a limited number of threads.


| Parameter | Description |
|-----------|-------------|
|   threads |The number of threads to limit. |


#### Useful.Utilities.TaskList.AddTask(System.Action)

Adds the task to the list. If a thread is available work starts right away otherwise it waits for a thread then starts


| Parameter | Description |
|-----------|-------------|
|      work |The action to run. |


#### Useful.Utilities.TaskList.WaitForAll

Waits for all tasks in the list to finish. Then clears the lists


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.TaskList.Tasks |Gets all the tasks in the list. |

#### Useful.Utilities.TaskList.Run(System.Action,System.Action{System.Boolean},System.Action{System.Exception})

Runs the specified work. If work action threw an error and error action is provided, it will be called before the after action. If after action is provided, it is ran once the work action is done. The after action is passed true if work completed successfully, false if work faulted. After and error actions are ran in the Current Synchronization Context (usually the UI thread)


| Parameter | Description |
|-----------|-------------|
|      work |The work to the run. |
|     after |The action to run after work is complete. |
|     error |The on error action if work faulted |


#### Useful.Utilities.TaskList.Run&lt;T&gt;(System.Func{&lt;T&gt;},System.Action{&lt;T&gt;},System.Action{System.Exception})

Runs the specified work. If work action threw an error and error action is provided, it will be called before the after action. If after action is provided, it is ran once the work action is done. The after action is passed the result of work action if it was successful. If work action faulted, after action will be passed the default of[T]. After and error actions are ran in the Current Synchronization Context (usually the UI thread)


| Parameter | Description |
|-----------|-------------|
|         T |Type returned from work function and input to after action |

| Parameter | Description |
|-----------|-------------|
|      work |The work function to run |
|     after |The after action to run |
|     error |The on error action if work faulted |


---
# Useful.Utilities.WebBase

Base class for building Web Clients that take and return typed objects.

_C# Example_

```C#
    //Example client class using JSON.Net 
    public class JsonWebClient : WebBase
    {
       protected override T DeserializeObject<T>(string content)
       {
           return JsonConvert.DeserializeObject<T>(content);
       }
       public override HttpContent SerializeObject(object content)
       {
           return new JsonContent(JsonConvert.SerializeObject(content));
       }
       public override string BaseUrl { get { return "http://SomeUrl/MyApp/"; } }
    }
    
```

#### Useful.Utilities.WebBase.DeserializeObject&lt;T&gt;(System.String)

Abstract hook for wiring object deserialization

_C# Example_

```C#
    //Using Json.Net
    return JsonConvert.DeserializeObject<T>(content)
    
```


| Parameter | Description |
|-----------|-------------|
|         T |The Type to deserialize the string in to |

| Parameter | Description |
|-----------|-------------|
|   content |Body of the request |


#### Useful.Utilities.WebBase.SerializeObject(System.Object)

Abstract hook for wiring object serialization

_C# Example_

```C#
    //Using Json.Net
    return new JsonContent(JsonConvert.SerializeObject(content));
    
```


| Parameter | Description |
|-----------|-------------|
|   content |Body of the request |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.WebBase.BaseUrl |Base URL that can be prepended to requests |

#### Useful.Utilities.WebBase.Go(System.Uri,System.Net.Http.HttpContent,System.Net.HttpStatusCode,Useful.Utilities.Useful.Utilities.Web.Models.Method,System.Action{System.Net.Http.HttpRequestMessage})

Build an HTTP Client and sent a request to the given URL. The resulting status will be validated to match the expected status parameter


| Parameter | Description |
|-----------|-------------|
|       uri |The URI to send the request to |
|   content |Body of the request, This is not valid on GET requests |
|expectedStatus |Expected status will be checked against the response status code |
|    method |HTTP Method of the request: GET, POST, PUT, DELETE |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Go&lt;T2&gt;(System.Uri,&lt;T&gt;,System.Net.HttpStatusCode,Useful.Utilities.Useful.Utilities.Web.Models.Method,System.Action{System.Net.Http.HttpRequestMessage})

Build an HTTP Client and sent a typed request to the given URL. The response will be deserialized into a typed response object. The requested type and response type can be different types. The resulting status will be validated to match the expected status parameter.


| Parameter | Description |
|-----------|-------------|
|        TO |Type of HTTP response content object |
|         T |Type of the request content object |

| Parameter | Description |
|-----------|-------------|
|       uri |The URI to send the request to |
|   content |Body of the request, This is not valid on GET requests |
|expectedStatus |Expected status will be checked against the response status code |
|    method |HTTP Method of the request: GET, POST, PUT, DELETE |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Go&lt;T&gt;(System.Uri,&lt;T&gt;,System.Net.HttpStatusCode,Useful.Utilities.Useful.Utilities.Web.Models.Method,System.Action{System.Net.Http.HttpRequestMessage})

Build an HTTP Client and sent a typed request to the given URL. The response will be deserialized into a typed response object. The request type and response type will be the same. The resulting status will be validated to match the expected status parameter.


| Parameter | Description |
|-----------|-------------|
|         T |The type of the request and response objects |

| Parameter | Description |
|-----------|-------------|
|       uri |The URI to send the request to |
|   content |Body of the request, This is not valid on GET requests |
|expectedStatus |Expected status will be checked against the response status code |
|    method |HTTP Method of the request: GET, POST, PUT, DELETE |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.MakeUri(System.String)

Takes a string URL and converts it to a URI object. If the string starts with http:// or https:// it is simply returned. Else the BaseUrl property is prepended to the URL.


| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |


#### Useful.Utilities.WebBase.Get(System.String,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a GET Request and return a generic response object


| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Get&lt;T&gt;(System.String,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a GET Request and return a typed response object


| Parameter | Description |
|-----------|-------------|
|         T |Type of HTTP response content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Post&lt;T&gt;(System.String,&lt;T&gt;,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a POST Request and return a typed response object


| Parameter | Description |
|-----------|-------------|
|         T |Type of HTTP response content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|   content |Body of the request |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Post&lt;T2&gt;(System.String,&lt;T&gt;,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a POST Request with a different type and return a typed response object


| Parameter | Description |
|-----------|-------------|
|      TOut |Type of HTTP response content object |
|       TIn |Type of request content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|   content |Body of the request |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Put&lt;T&gt;(System.String,&lt;T&gt;,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a PUT Request and return a typed response object


| Parameter | Description |
|-----------|-------------|
|         T |Type of HTTP response content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|   content |Body of the request |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Put&lt;T2&gt;(System.String,&lt;T&gt;,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a PUT Request and return a typed response object


| Parameter | Description |
|-----------|-------------|
|      TOut |Type of HTTP response content object |
|       TIn |Type of request content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|   content |Body of the request |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Delete&lt;T&gt;(System.String,&lt;T&gt;,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a DELETE Request and return a typed response object


| Parameter | Description |
|-----------|-------------|
|         T |Type of HTTP response content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|   content |Body of the request |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


#### Useful.Utilities.WebBase.Delete&lt;T2&gt;(System.String,&lt;T&gt;,System.Net.HttpStatusCode,System.Action{System.Net.Http.HttpRequestMessage})

Preform a DELETE Request and return a typed response object


| Parameter | Description |
|-----------|-------------|
|      TOut |Type of HTTP response content object |
|       TIn |Type of request content object |

| Parameter | Description |
|-----------|-------------|
|       url |The URL to send the request to |
|   content |Body of the request |
|expectedStatus |Expected status will be checked against the response status code |
|preRequest |Optional action that can modify the request object before it is sent |


---
# Useful.Utilities.JsonContent

Provides HTTP content based on JSON string. Sets media type to "application/json"

---
# Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse

Model for storing raw HTTP responses.

|  Property | Description |
|-----------|-------------|
|Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse.RawContent |Response content as a raw string |
|Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse.Response |Full response message |

---
# Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse&lt;T&gt;

Model for storing typed HTTP responses.


| Parameter | Description |
|-----------|-------------|
|         T |The Type of content in the response |

|  Property | Description |
|-----------|-------------|
|Useful.Utilities.Useful.Utilities.Web.Models.HttpResponse&lt;T&gt;.Content |Typed content from the response |

---
# Useful.Utilities.Useful.Utilities.Web.Models.Method

Supported HTTP Methods: GET, POST, PUT, DELETE

---
# Useful.Utilities.Useful.Utilities.Web.Ext.WebRequestExt

Web Request Extension methods

#### Useful.Utilities.Useful.Utilities.Web.Ext.WebRequestExt.AddBearer(System.Net.Http.HttpRequestMessage,System.String)

Add a Bearer Token authorization header to the request object


| Parameter | Description |
|-----------|-------------|
|   request |             |
|     token |             |


#### Useful.Utilities.Useful.Utilities.Web.Ext.WebRequestExt.AddHeader(System.Net.Http.HttpRequestMessage,System.String,System.String)

Add an unvalidated header and value to the request object


| Parameter | Description |
|-----------|-------------|
|   request |             |
|      name |Header name  |
|     value |Header value |


---
# Useful.Utilities.WMI

Windows Management Interface Wrapper class. Handles scoping WMI calls for local or remote computers

#### Useful.Utilities.WMI.GetProperties(System.Management.ManagementBaseObject)

Convert the property data collection to a string object dictionary


| Parameter | Description |
|-----------|-------------|
|        mo |ManagementBaseObject |

Returns: Dictionary{string,object}


#### Useful.Utilities.WMI.#ctor

Creates a new instance of the wrapper


#### Useful.Utilities.WMI.#ctor(System.String)

Creates a new instance of the wrapper connected to a remote server


#### Useful.Utilities.WMI.#ctor(System.String,System.String,System.String)

Creates a new instance of the wrapper connected to a remote server as a different user


#### Useful.Utilities.WMI.Finalize

Clean up unmanaged references


#### Useful.Utilities.WMI.Initialize(System.String,System.String,System.String)

Initializes the WMI connection


| Parameter | Description |
|-----------|-------------|
|  username |Username to connect to server with |
|  password |Password to connect to server with |
|    server |Server to connect to |


#### Useful.Utilities.WMI.Scope

Creates a[System.Management.ManagementScope]scoped to the current connection


#### Useful.Utilities.WMI.ScopedObject(System.String,System.Management.ObjectGetOptions)

Creates a[System.Management.ManagementObject]scoped to the current connection


| Parameter | Description |
|-----------|-------------|
|      path |The WMI path |
|   options |Additional options, if needed |


#### Useful.Utilities.WMI.ScopedClass(System.String,System.Management.ObjectGetOptions)

Creates a[System.Management.ManagementClass]scoped to the current connection


| Parameter | Description |
|-----------|-------------|
|      path |The WMI path |
|   options |Additional options, if needed |


#### Useful.Utilities.WMI.GetObjects(System.String)

Get an instance of the specified class


| Parameter | Description |
|-----------|-------------|
|  wmiClass |Type of the class |

Returns: Array of management objects


#### Useful.Utilities.WMI.GetObjects(System.String,System.String)

Get an instance of the specified class filtered by a where clause


| Parameter | Description |
|-----------|-------------|
|  wmiClass |Type of the class |
|     where |The where clause filter to apply |


#### Useful.Utilities.WMI.GetObjectsByName(System.String,System.String)

Get an instance of the specified class filtered by name


| Parameter | Description |
|-----------|-------------|
|  wmiClass |Type of the class |
|      name |The name to filter by |


#### Useful.Utilities.WMI.Dispose

Managed dispose


#### Useful.Utilities.WMI.Dispose(System.Boolean)

Dispose of managed and unmanaged objects


| Parameter | Description |
|-----------|-------------|
| disposing |             |


|  Property | Description |
|-----------|-------------|
|Useful.Utilities.WMI.ConnectionOptions |Gets or sets the management scope |
|Useful.Utilities.WMI.Server |Gets the server connected to |
|Useful.Utilities.WMI.Username |Gets the username used to connect |
|Useful.Utilities.WMI.Password |Gets the password used to connect |
|Useful.Utilities.WMI.WmiNameSpace |Gets or sets the WMI namespace. default is CimV2 |

---
# Useful.Utilities.WMI.ReturnValue

WMI Common Return Values


