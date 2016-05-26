<!-- http://varus.io/vsdoc-2-md/ -->
# Useful.Utilities

Collection of utility classes for dealing with Windows services, IIS, WMI, Registry, x509 certificates, Files, security, network shares, GAC files, and a few other things. Most utilities can be ran locally or remotely.

[NuGet Package Information](https://www.nuget.org/packages/Useful.Utilities/)                 


##Class Reference 

<!-- START doctoc generated TOC please keep comment here to allow auto update -->
<!-- DON'T EDIT THIS SECTION, INSTEAD RE-RUN doctoc TO UPDATE -->


- [Certificate](#certificate)
- [Compression](#compression)
- [ComputerManager](#computermanager)
- [CryptoManager](#cryptomanager)
- [Database](#database)
- [DynamicRow](#dynamicrow)
- [FileUtility](#fileutility)
- [WindowsShares](#windowsshares)
- [GacUtility](#gacutility)
- [Helpers](#helpers)
- [IAssemblyCache](#iassemblycache)
- [IisManager](#iismanager)
- [ApplicationSslFlags](#applicationsslflags)
- [ComputerInfo](#computerinfo)
- [FeatureInfo](#featureinfo)
- [FeaturesAndRoles](#featuresandroles)
- [OnError](#onerror)
- [ProcessInfo](#processinfo)
- [ServiceInfo](#serviceinfo)
- [ServiceState](#servicestate)
- [ServiceType](#servicetype)
- [StartMode](#startmode)
- [NetworkConnection](#networkconnection)
- [ObjectCopier](#objectcopier)
- [ProcessManager](#processmanager)
- [RegistryHelper](#registryhelper)
- [Security](#security)
- [ServicesManager](#servicesmanager)
- [SharedFolderConnection](#sharedfolderconnection)
- [TaskList](#tasklist)
- [WMI](#wmi)

<!-- END doctoc generated TOC please keep comment here to allow auto update -->


## Certificate

Deals with windows x509 certificates

#### GetByThumbprint(thumbprint, store, location, remoteComputer)

Gets a certificate by thumb print.

| Name | Description |
| ---- | ----------- |
| thumbprint | *System.String*<br>the cert thumbprint to find |
| store | *System.Security.Cryptography.X509Certificates.StoreName*<br>The store to look in |
| location | *System.Security.Cryptography.X509Certificates.StoreLocation*<br>The location to look in |
| remoteComputer | *System.String*<br>remote computer to run on |

#### GetCerts(store, location, remoteComputer)

Gets a list of Cert names and thumbprints in a tuple

| Name | Description |
| ---- | ----------- |
| store | *System.Security.Cryptography.X509Certificates.StoreName*<br>The store to look in |
| location | *System.Security.Cryptography.X509Certificates.StoreLocation*<br>The location to look in |
| remoteComputer | *System.String*<br>remote computer to run on |

#### GetStore(store, location, remoteComputer)

Helper function to connect to a cert store. Can be local or remote

| Name | Description |
| ---- | ----------- |
| store | *System.Security.Cryptography.X509Certificates.StoreName*<br>The store to look in |
| location | *System.Security.Cryptography.X509Certificates.StoreLocation*<br>The location to look in |
| remoteComputer | *System.String*<br>remote computer to run on |


#### Select(store, location, remoteComputer, windowTitle, windowMsg)

Selects the specified store using built-in windows UI

| Name | Description |
| ---- | ----------- |
| store | *System.Security.Cryptography.X509Certificates.StoreName*<br>The store to look in |
| location | *System.Security.Cryptography.X509Certificates.StoreLocation*<br>The location to look in |
| remoteComputer | *System.String*<br>remote computer to run on |
| windowTitle | *System.String*<br>The window title. |
| windowMsg | *System.String*<br>The window message. |


#### Setup(fileName, password, store, location, remoteComputer)

Install a PFX file to the cert store

| Name | Description |
| ---- | ----------- |
| fileName | *System.String*<br>Name of the PFX file. |
| password | *System.String*<br>The password. |
| store | *System.Security.Cryptography.X509Certificates.StoreName*<br>The store to look in |
| location | *System.Security.Cryptography.X509Certificates.StoreLocation*<br>The location to look in |
| remoteComputer | *System.String*<br>remote computer to run on |


## Compression

Unbuffered compression/decompression methods using GZip

#### Compress(data)

Use GZip Compression

| Name | Description |
| ---- | ----------- |
| data | *System.Byte[]*<br> |


#### Compress(text)

Compresses a string using GZip

| Name | Description |
| ---- | ----------- |
| text | *System.String*<br>The text to compress |


#### Decompress(compressed)

Use GZip Decompression

| Name | Description |
| ---- | ----------- |
| compressed | *System.Byte[]*<br> |


#### Decompress(compressedText)

Decompresses a string

| Name | Description |
| ---- | ----------- |
| compressedText | *System.String*<br>The compressed text |


## ComputerManager

Collection of computer, domain, and user name functions

#### Constructor(System.String,System.String,System.String)

Creates a new instance of the Process Manager connected to a remote server as a different user

#### Computer

Gets information about the computer currently connected to.


#### Connect(computerName, username, password)

Connects to the computer name passed in, leave blank for local

| Name | Description |
| ---- | ----------- |
| computerName | *System.String*<br>Name of the computer. Leave blank for local |
| username | *System.String*<br>The username to connect as. Leave blank for current user |
| password | *System.String*<br>The password for username if provided. |


#### DomainNameBios

Gets the Domain Net Bios of the current user.

#### DomainNameFull

Gets the full domain name of the current computer (without the computer name). Use <a href="#computermanager.machinefullname">ComputerManager.MachineFullName</a> to get FQN of current computer.

#### EnsureDomain(user)

Ensures the username as a domain prefix. If no prefix is given machine name is used.

| Name | Description |
| ---- | ----------- |
| user | *System.String*<br>The username to check for domain. |

Returns domain\user or machine\user

#### IsLocal(serverName)

Checks if the name passed in is the current computer. Returns true if the string is null/empty or the name matches the current <a href="#computermanager.machinename">ComputerManager.MachineName</a> or <a href="#computermanager.machinefullname">ComputerManager.MachineFullName</a>.

| Name | Description |
| ---- | ----------- |
| serverName | *System.String*<br>Computer name to check |


#### MachineFullName

Gets the fully qualified name of the current computer. computer.domain.com

#### MachineName

Gets the Machine name of the current computer (without domain). Use <a href="#computermanager.machinefullname">ComputerManager.MachineFullName</a> to get the FQN of the current computer.

#### SplitUserAndDomain(username)

Splits the username and domain into a Tuple. Domain is Item1, User is Item2.

| Name | Description |
| ---- | ----------- |
| username | *System.String*<br>The Domain\Username or User@domain string to parse. |

Returns Domain as Item1, Username as Item2

#### UserName

Gets the username of current user

#### UserQualified

Gets the domain and username of current user. Domain\User


## CryptoManager

Used to Encrypt / Decrypt strings and byte arrays

#### Decrypt(encryptedMessage, cryptKey, authKey, nonSecretPayloadLength)

Authentication (HMAC) then Decryption (AES) for a secret UTF8 Message.

| Name | Description |
| ---- | ----------- |
| encryptedMessage | *System.String*<br>The encrypted message. |
| cryptKey | *System.Byte[]*<br>The crypt key. |
| authKey | *System.Byte[]*<br>The auth key. |
| nonSecretPayloadLength | *System.Int32*<br>Length of the non secret payload. |

Returns Decrypted Message

#### DecryptWithPassword(encryptedMessage, password, nonSecretPayloadLength)

Authentication (HMAC) and then Descryption (AES) of a UTF8 Message using keys derived from a password (PBKDF2).

| Name | Description |
| ---- | ----------- |
| encryptedMessage | *System.String*<br>The encrypted message. |
| password | *System.String*<br>The password. |
| nonSecretPayloadLength | *System.Int32*<br>Length of the non secret payload. |

Returns Decrypted Message

##### Remarks

Significantly less secure than using random binary keys.

#### Encrypt(secretMessage, cryptKey, authKey, nonSecretPayload)

Encryption (AES) then Authentication (HMAC) for a UTF8 Message.

| Name | Description |
| ---- | ----------- |
| secretMessage | *System.String*<br>The secret message. |
| cryptKey | *System.Byte[]*<br>The crypt key. |
| authKey | *System.Byte[]*<br>The auth key. |
| nonSecretPayload | *System.Byte[]*<br>(Optional) Non-Secret Payload. |

Returns Encrypted Message

##### Remarks

Adds overhead of (Optional-Payload + BlockSize(16) + Message-Padded-To-Blocksize + HMac-Tag(32)) * 1.33 Base64

#### EncryptWithPassword(secretMessage, password, nonSecretPayload)

Encryption (AES) then Authentication (HMAC) of a UTF8 message using Keys derived from a Password (PBKDF2).

| Name | Description |
| ---- | ----------- |
| secretMessage | *System.String*<br>The secret message. |
| password | *System.String*<br>The password. |
| nonSecretPayload | *System.Byte[]*<br>The non secret payload. |

Returns Encrypted Message

##### Remarks

Significantly less secure than using random binary keys. Adds additional non secret payload for key generation parameters.

#### NewKey

Helper that generates a random key on each call.

#### Sha256(input)

Hash the string using SHA256 and return base64 encoded string

| Name | Description |
| ---- | ----------- |
| input | *System.String*<br> |


## Database

SQL Database functions

#### Constructor(connection)

Initializes a new instance of the <a href="#database">Database</a> class.

| Name | Description |
| ---- | ----------- |
| connection | *System.String*<br>The connection string. |

#### Connection

The database connection string.

#### ConnectionParts

Parses the connection string in to a <a href="#system.data.sqlclient.sqlconnectionstringbuilder">System.Data.SqlClient.SqlConnectionStringBuilder</a>


#### ConnectionParts(connection)

Parses the connection string in to a <a href="#system.data.sqlclient.sqlconnectionstringbuilder">System.Data.SqlClient.SqlConnectionStringBuilder</a>

| Name | Description |
| ---- | ----------- |
| connection | *System.String*<br>The connection string to parse |


#### Databases(server, username, password)

Gets a list of databases on a given server. To use NT Auth leave user/pass blank

| Name | Description |
| ---- | ----------- |
| server | *System.String*<br>Server to connect to |
| username | *System.String*<br>SQL Auth user. To use NT Auth leave blank |
| password | *System.String*<br>SQL Auth password |

Returns string array of database names

#### ExecuteCount(sqlCmd, connection)

Executes a scalar and attempts to parse the result to integer. If parse fails -1 is returned

| Name | Description |
| ---- | ----------- |
| sqlCmd | *System.Data.SqlClient.SqlCommand*<br>The command to execute |
| connection | *System.String*<br>SQL connection string |

Returns Scalar result as integer or -1

#### ExecuteNonQuery(sqlCmd, connection)

Executes a non query.

| Name | Description |
| ---- | ----------- |
| sqlCmd | *System.Data.SqlClient.SqlCommand*<br>The command to execute |
| connection | *System.String*<br>SQL connection string |

#### ExecuteScalar(sqlCmd, connection)

Executes a scalar

| Name | Description |
| ---- | ----------- |
| sqlCmd | *System.Data.SqlClient.SqlCommand*<br>The command to execute |
| connection | *System.String*<br>SQL connection string |

Returns Scalar result

#### ExecuteSql(sql, connection)

Executes a non query.

| Name | Description |
| ---- | ----------- |
| sql | *System.String*<br>SQL statement to execute |
| connection | *System.String*<br>SQL connection string |

#### ExecuteStoredProc(storedProcName, connection)

Executes a stored procedure as a non query

| Name | Description |
| ---- | ----------- |
| storedProcName | *System.String*<br> |
| connection | *System.String*<br>SQL connection string |

#### GetDataset(sqlCmd, connection)

Executes a Sql Adapter and fills a dataset

| Name | Description |
| ---- | ----------- |
| sqlCmd | *System.Data.SqlClient.SqlCommand*<br>The command to execute |
| connection | *System.String*<br>SQL connection string |

Returns A Filled DataSet

#### Run(sql)

Run a SQL command and return each row as a dynamic row

| Name | Description |
| ---- | ----------- |
| sql | *System.String*<br> |

Returns Enumeration of <a href="#dynamicrow">DynamicRow</a>

#### Servers

Gets a list of all available instances of SQL Server within the local network.

##### Value

string array of server names

#### TestConnection(throwOnError)

Tests the connection.

| Name | Description |
| ---- | ----------- |
| throwOnError | *System.Boolean*<br>Flag to throw or hide connection errors |

Returns True if successful

#### TestConnection(connection, throwOnError)

Tests the connection.

| Name | Description |
| ---- | ----------- |
| connection | *System.String*<br>The connection string. |
| throwOnError | *System.Boolean*<br>Flag to throw or hide connection errors |

Returns True if successful

*System.ArgumentNullException:* Connection string must have Data Source and Initial Catalog both set


## DynamicRow

Custom Dynamic Object for dealing with DataRow Objects

#### Constructor(row)

Initializes a new instance of the <a href="#dynamicrow">DynamicRow</a> class.

| Name | Description |
| ---- | ----------- |
| row | *System.Data.DataRow*<br>The data row object. |

#### Convert(table)

Converts the specified table to Enumeration of <a href="#dynamicrow">DynamicRow</a>.

| Name | Description |
| ---- | ----------- |
| table | *System.Data.DataTable*<br>The data table to convert. |

Returns Enumeration of <a href="#dynamicrow">DynamicRow</a>

#### DataRow

Gets the data row that created this DynamicRow object


## FileUtility

File Utility functions

#### ClearReadOnly(path)

Clears the read only flag on a file

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>Path to the file |

#### CopyFile(source, dest, overwrite)

Ensures the destination directory exists then copies a file.

| Name | Description |
| ---- | ----------- |
| source | *System.String*<br>The source file path. |
| dest | *System.String*<br>The destination file path. |
| overwrite | *System.Boolean*<br>allow destination file to be overwritten if it exists. |

#### FileExists(path, computer)

Checks if a file exists. If remote computer is passed in the path is converted to a UNC first

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>File path to check |
| computer | *System.String*<br>optional remote computer name to check for the file |


#### GetUniversalPath(path, computer)

Takes a local file path and translates it into a UNC file path where possible.

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>Path to convert to UNC. |
| computer | *System.String*<br>Machine name to use, if not set uses local machine |

Returns UNC path otherwise throws arg error.

#### IsFileLocked(file, mode, access, share)

Checks if a file is locked by attempting to open it.

| Name | Description |
| ---- | ----------- |
| file | *System.String*<br>File Path to open |
| mode | *System.IO.FileMode*<br> |
| access | *System.IO.FileAccess*<br> |
| share | *System.IO.FileShare*<br> |


#### WaitForFile(file, mode, access, share, retry, waitMs)

Tries to create a file stream. On error, the thread sleeps and retries until the max retry number is hit.

| Name | Description |
| ---- | ----------- |
| file | *System.String*<br>File path |
| mode | *System.IO.FileMode*<br>file mode |
| access | *System.IO.FileAccess*<br>file access |
| share | *System.IO.FileShare*<br>file share |
| retry | *System.Int32*<br>Number of retries to attempt on error |
| waitMs | *System.Int32*<br>number of milliseconds to sleep between retries |

Throws IOExecption if max retry is hit


## WindowsShares

Support class for listing windows shares


## GacUtility

A utility class for interacting with the Global Assembly Cache.

#### Add(assemblyName)

Adds an assembly to the GAC.

| Name | Description |
| ---- | ----------- |
| assemblyName | *System.String*<br>The name of the assembly to add. |

Returns A magic number.

#### AddAssembly(assemblyName)

Adds an assembly to the GAC.

| Name | Description |
| ---- | ----------- |
| assemblyName | *System.String*<br>The name of the assembly to add. |

Returns A magic number.

#### GetByKey(key)

Gets a list of paths to all files matching the given key

| Name | Description |
| ---- | ----------- |
| key | *System.String*<br>The key to find |

Returns list of file paths

#### Remove(assemblyName)

Removes an assembly from the GAC.

| Name | Description |
| ---- | ----------- |
| assemblyName | *System.String*<br>The name of the assembly to remove. |

Returns A magic number.

#### RemoveAssembly(assemblyName)

Removes an assembly from the GAC.

| Name | Description |
| ---- | ----------- |
| assemblyName | *System.String*<br>The name of the assembly to remove. |

Returns A magic number.

#### RemoveByKey(key)

Starts a background task that removes all assemblies from the GAC matching a given key

| Name | Description |
| ---- | ----------- |
| key | *System.String*<br>The key to remove |


## Helpers

Extensions and helper methods

#### Default\`\`1(obj, value)

If object is null <a href="#value">value</a> is returned. If object is empty string or min date time, <a href="#value">value</a> is returned. If object is a different type then value it may be casted or may throw an <a href="#system.invalidcastexception">System.InvalidCastException</a>

##### Type Parameters

- T - The default value type

| Name | Description |
| ---- | ----------- |
| obj | *System.Object*<br>the object |
| value | *\`\`0*<br>Default value to return when object is null or doesn't match rules |

*System.InvalidCastException:* When object is different type then default value InvalidCastException might be thrown


#### Description(enumeration)

Gets the description value from the <a href="#system.componentmodel.descriptionattribute">System.ComponentModel.DescriptionAttribute</a> of the enum. If enum doesn't have a description attribute, null is returned

| Name | Description |
| ---- | ----------- |
| enumeration | *System.Enum*<br>The enum value to look at |

Returns description value from the <a href="#system.componentmodel.descriptionattribute">System.ComponentModel.DescriptionAttribute</a> or null

#### GetAttribute\`\`2(enumeration, expression)

Gets attribute from an enumeration object

##### Type Parameters

- T - Input type
- TExpected - The return type

| Name | Description |
| ---- | ----------- |
| enumeration | *System.Enum*<br>The enum value |
| expression | *System.Func{\`\`0*<br> |


#### IsTrue(value)

If the nullable Boolean value is null or false, false is returned. if the nullable Boolean has a value and its true, true is returned.

| Name | Description |
| ---- | ----------- |
| value | *System.Nullable{System.Boolean}*<br>nullable Boolean |

Returns true or false

#### IsTrueOrNull(value)

If the nullable Boolean value is null or true, true is returned. if the nullable Boolean has a value and its false, false is returned.

| Name | Description |
| ---- | ----------- |
| value | *System.Nullable{System.Boolean}*<br>nullable Boolean |

Returns true or false

#### RoundDown(number, decimalPlaces)

Round a number down. Can set number of decimal places.

| Name | Description |
| ---- | ----------- |
| number | *System.Single*<br> |
| decimalPlaces | *System.Int32*<br> |


#### RoundUp(number, decimalPlaces)

Round a number up. Can set number of decimal places.

| Name | Description |
| ---- | ----------- |
| number | *System.Single*<br> |
| decimalPlaces | *System.Int32*<br> |


#### ToEnum\`\`1(value, spaceReplace)

Convert a string object to an Enum

##### Type Parameters

- T - The type of Enum to convert to

| Name | Description |
| ---- | ----------- |
| value | *System.Object*<br>The object to convert |
| spaceReplace | *System.String*<br>If value has spaces, They will be replaced |


#### ToEnum\`\`1(value, spaceReplace)

Convert a string to an Enum

##### Type Parameters

- T - The type of Enum to convert to

| Name | Description |
| ---- | ----------- |
| value | *System.String*<br>The object to convert |
| spaceReplace | *System.String*<br>If value has spaces, They will be replaced |


#### ToHex(bytes)

Convert a byte array to a hexadecimal string.

| Name | Description |
| ---- | ----------- |
| bytes | *System.Byte[]*<br>The bytes. |


#### ToLong(str)

Convert s string to a long, throws cast exception if it fails

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |

*System.InvalidCastException:* 


#### Traverse\`\`1(items, childSelector)

Recursively search a tree collection based on the child selector

##### Type Parameters

- T - 

| Name | Description |
| ---- | ----------- |
| items | *System.Collections.Generic.IEnumerable{\`\`0}*<br> |
| childSelector | *System.Func{\`\`0*<br> |


#### TryToLong(str)

Attempt to cast a string to a long, return null if unable to cast

| Name | Description |
| ---- | ----------- |
| str | *System.String*<br> |


## IAssemblyCache

Defines a contract for interacting with the Global Assembly Cache.

#### CreateAssemblyCacheItem(dwFlags, pvReserved, ppAsmItem, pszAssemblyName)

Creates the assembly cache item.

| Name | Description |
| ---- | ----------- |
| dwFlags | *System.UInt32*<br>The dw flags. |
| pvReserved | *System.IntPtr*<br>The pv reserved. |
| ppAsmItem | *System.IntPtr@*<br>The pp asm item. |
| pszAssemblyName | *System.String*<br>Name of the PSZ assembly. |


#### CreateAssemblyScavenger(ppAsmScavenger)

Creates the assembly scavenger.

| Name | Description |
| ---- | ----------- |
| ppAsmScavenger | *System.Object@*<br>The pp asm scavenger. |


#### InstallAssembly(dwFlags, pszManifestFilePath, pvReserved)

Installs the assembly.

| Name | Description |
| ---- | ----------- |
| dwFlags | *System.UInt32*<br>The dw flags. |
| pszManifestFilePath | *System.String*<br>The PSZ manifest file path. |
| pvReserved | *System.IntPtr*<br>The pv reserved. |


#### QueryAssemblyInfo(dwFlags, pszAssemblyName, pAsmInfo)

Queries the assembly information.

| Name | Description |
| ---- | ----------- |
| dwFlags | *System.UInt32*<br>The dw flags. |
| pszAssemblyName | *System.String*<br>Name of the PSZ assembly. |
| pAsmInfo | *System.IntPtr*<br>The p asm information. |


#### UninstallAssembly(dwFlags, pszAssemblyName, pvReserved, pulDisposition)

Uninstalls the assembly.

| Name | Description |
| ---- | ----------- |
| dwFlags | *System.UInt32*<br>The dw flags. |
| pszAssemblyName | *System.String*<br>Name of the PSZ assembly. |
| pvReserved | *System.IntPtr*<br>The pv reserved. |
| pulDisposition | *System.UInt32@*<br>The pul disposition. |


## IisManager

IIS Server Manager Wrapper. can be used for local and remote IIS settings

#### Constructor(remoateServer)

Initializes a new instance of the <a href="#iismanager">IisManager</a> class connected to a remote computer

| Name | Description |
| ---- | ----------- |
| remoateServer | *System.String*<br>The remote server. |


## ApplicationSslFlags

Application level Ssl Flags

#### Useful.Utilities.IisManager.CommitChanges

Commits the <a href="#servermanager">ServerManager</a> changes.

#### Useful.Utilities.IisManager.CreateSite(siteName, path, port, certHash)

Create a new web site

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>display name |
| path | *System.String*<br>Root directory |
| port | *System.Int32*<br>port |
| certHash | *System.String*<br>certificate thumbprint |


#### Useful.Utilities.IisManager.CreateSslSite(siteName, path, certHash, port)

Create a new web site on port 443

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>site name |
| path | *System.String*<br>root directory of site |
| certHash | *System.String*<br>certificate thumbprint |
| port | *System.Int32*<br>port |


#### Useful.Utilities.IisManager.DeleteApplication(siteName, appName)

Deletes an application under a site.

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |
| appName | *System.String*<br>Name of the application. |

#### Useful.Utilities.IisManager.DeletePool(poolName)

Deletes the application pool.

| Name | Description |
| ---- | ----------- |
| poolName | *System.String*<br>Name of the application pool. |

#### Useful.Utilities.IisManager.DeleteSite(siteName)

delete a site

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |

#### Useful.Utilities.IisManager.GetApplication(siteName, appName)

Get an application under the given site

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |
| appName | *System.String*<br>Name of the application. |


#### Useful.Utilities.IisManager.GetPool(poolName)

Gets the application pool by name.

| Name | Description |
| ---- | ----------- |
| poolName | *System.String*<br>Name of the application pool. |


#### Useful.Utilities.IisManager.GetSite(siteName)

Get single site by name

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |


#### Useful.Utilities.IisManager.IisVersion(remoteComputer)

IIS version number. 0 if not installed or error

| Name | Description |
| ---- | ----------- |
| remoteComputer | *System.String*<br>The remote computer. |


#### Useful.Utilities.IisManager.ListApplications(siteName)

Get list of applications for a site

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |


#### Useful.Utilities.IisManager.ListPools

Lists all the application pools.





#### Useful.Utilities.IisManager.ListSiteNames

List all IIS web sites


#### Useful.Utilities.IisManager.ListSites

List all IIS web sites





#### Useful.Utilities.IisManager.Processes

Get all worker process for all application pools


#### Useful.Utilities.IisManager.RecyclePool(poolName)

Recycles the pool.

| Name | Description |
| ---- | ----------- |
| poolName | *System.String*<br>Name of the application pool. |

#### Useful.Utilities.IisManager.Refresh

Refreshes this instance and restarts the <a href="#servermanager">ServerManager</a>

#### Useful.Utilities.IisManager.RemoteServer

The remote server currently connected to.

#### Useful.Utilities.IisManager.ResetIis(mode)

Resets IIS. Mode can be Restart, Stop, or Start

| Name | Description |
| ---- | ----------- |
| mode | *System.String*<br>The mode argument. Can be Restart, Stop, or Start |


#### Useful.Utilities.IisManager.ServerManager

Gets the server manager. Either local or remote based on <a href="#remoteserver">RemoteServer</a>

#### Useful.Utilities.IisManager.SetApplication(siteName, appName, path, poolName, allowAnonymousAccess, windowsAuth, sslFlags)

create or update an application under a site

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |
| appName | *System.String*<br>Name of the application. |
| path | *System.String*<br>The physical path. |
| poolName | *System.String*<br>Name of the application pool. |
| allowAnonymousAccess | *System.Boolean*<br>Flag to allow anonymous access. |
| windowsAuth | *System.Boolean*<br>Flag to enable windows authentication. |
| sslFlags | *Useful.Utilities.IisManager.ApplicationSslFlags*<br>The SSL flags. |


#### Useful.Utilities.IisManager.SetApplicationPool(siteName, appName, poolName)

Change the pool tied to an application

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |
| appName | *System.String*<br>Name of the application. |
| poolName | *System.String*<br>Name of the application pool. |

#### Useful.Utilities.IisManager.SetBinding(siteName, ip, port, hostheader, certThumb, removeAllOthers)

Create or update a binding on the given site.

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Site name |
| ip | *System.String*<br>Ip to apply binding to. Use * for all |
| port | *System.Int32*<br>Port to apply binding to |
| hostheader | *System.String*<br>Optional host header |
| certThumb | *System.String*<br>Optional Cert thumb print, if Set protocol will be https |
| removeAllOthers | *System.Boolean*<br>Flag to clear all other bindings on site |


#### Useful.Utilities.IisManager.SetPool(name, username, password, maxProcesses, version)

create or update an application pool

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The application pool name. |
| username | *System.String*<br>The username. |
| password | *System.String*<br>The password. |
| maxProcesses | *System.Int32*<br>The maximum processes. 0 for default |
| version | *System.String*<br>The version. |


#### Useful.Utilities.IisManager.SiteState(siteName)

Get site state (stopped, running, etc)

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |


#### Useful.Utilities.IisManager.StartSite(siteName)

Attempt to start a site by name

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |

#### Useful.Utilities.IisManager.StopSite(siteName)

Stop IIS site by name

| Name | Description |
| ---- | ----------- |
| siteName | *System.String*<br>Name of the site. |


## ComputerInfo

Model for holding computer information. Also handles converting a <a href="#computerinfo.managementobject">ComputerInfo.ManagementObject</a> to a model. <a href="http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx</a>

#### DNSHostName

Name of local computer according to the domain name server (DNS).

#### Domain

Name of the domain to which a computer belongs.

#### Manufacturer

Name of a computer manufacturer.

#### Model

Product name that a manufacturer gives to a computer. This property must have a value.

#### Name

Name of object

#### NumberOfLogicalProcessors

Number of logical processors available on the computer.

#### NumberOfProcessors

Number of all processors available on the computer.

#### PartOfDomain

Null if unknown

#### PrimaryOwnerContact

Contact information for the primary system owner,

#### PrimaryOwnerName

Name of the primary system owner.

#### TotalPhysicalMemory

Total size of physical memory. Be aware this property may not return an accurate value

#### UserName

Name of a user that is logged on currently to the console (not remote desktop users)

#### Workgroup

Name of the workgroup for this computer. Only if the value of the PartOfDomain property is False


## FeatureInfo

Model for holding feature information. Also handles converting a <a href="#featureinfo.managementobject">FeatureInfo.ManagementObject</a> to a model. <a href="http://msdn.microsoft.com/en-us/library/cc280268(v=vs.85).aspx">http://msdn.microsoft.com/en-us/library/cc280268(v=vs.85).aspx</a>


## FeaturesAndRoles

List of Features and Roles that can be mapped to the FeatureInfo Id and Parent Id property


## OnError

Windows Service Error reporting mode


## ProcessInfo

Model for holding process information. Also handles converting a <a href="#processinfo.managementobject">ProcessInfo.ManagementObject</a> to a model.


## ServiceInfo

Model for holding service information. Also handles converting a <a href="#serviceinfo.managementobject">ServiceInfo.ManagementObject</a> to a model.


## ServiceState

Windows Service state


## ServiceType

Type of Windows Service


## StartMode

Windows Service start mode


## NetworkConnection

Creates a connection to a network resource with a given set of credentials


## ObjectCopier

Perform a deep copy of an object. Binary Serialization is used to perform the copy.

#### Clone\`\`1(source)

Perform a deep Copy of the object.

##### Type Parameters

- T - The type of object being copied.

| Name | Description |
| ---- | ----------- |
| source | *\`\`0*<br>The object instance to copy. |

Returns The copied object.

#### FromBytes\`\`1(obj)

Takes a byte array and desterilizes it to a object.

##### Type Parameters

- T - The Type of the Object

| Name | Description |
| ---- | ----------- |
| obj | *System.Byte[]*<br>byte array of the object. |


#### FromXml\`\`1(xml)

Load an object from XML string.

##### Type Parameters

- T - The Type of the Object

| Name | Description |
| ---- | ----------- |
| xml | *System.String*<br>The XML. |


#### ToBytes\`\`1(source)

Takes a serializable object and returns it as a byte array.

##### Type Parameters

- T - The Type of the Object

| Name | Description |
| ---- | ----------- |
| source | *\`\`0*<br>The source object to serialize. |

#### ToXml\`\`1(obj)

Serialize an object to XML string.

##### Type Parameters

- T - The Type of Object

| Name | Description |
| ---- | ----------- |
| obj | *\`\`0*<br>The object. |

Returns XML String


## ProcessManager

Used to list, start and stop processes locally or remotely using WMI

#### Constructor(System.String,System.String,System.String)

Creates a new instance of the Process Manager connected to a remote server as a different user

#### Connect(computerName, username, password)

Connects to the computer name passed in, leave blank for local

| Name | Description |
| ---- | ----------- |
| computerName | *System.String*<br>Name of the computer. Leave blank for local |
| username | *System.String*<br>The username to connect as. Leave blank for current user |
| password | *System.String*<br>The password for username if provided. |


#### GetProcess(id)

Gets a single process by process id

| Name | Description |
| ---- | ----------- |
| id | *System.UInt32*<br>The process identifier |


#### GetProcesses(name)

Gets a list of running processes. Can be filtered by name

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>Null or blank to return all, otherwise returns all processes matching this name |


#### Run(filename, args, hideWindow)

Starts a local process

| Name | Description |
| ---- | ----------- |
| filename | *System.String*<br>The file to run |
| args | *System.String*<br>The optional arguments to pass to the file, if any |
| hideWindow | *System.Boolean*<br>`true` to hide the window. |


#### Start(command, timeoutSeconds)

Starts a command process.

| Name | Description |
| ---- | ----------- |
| command | *System.String*<br>The command to run. |
| timeoutSeconds | *System.String*<br>The number of seconds to wait before timing out (only applies to local processes). Pass 0 for no timeout |


#### Terminate(name, firstOnly)

Terminates a process with the specified name.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The name of the process |
| firstOnly | *System.Boolean*<br>Flag if all or only the first process matching the name will be terminated |


#### Terminate(id)

Terminates a process by the specified identifier.

| Name | Description |
| ---- | ----------- |
| id | *System.UInt32*<br>The process identifier |


## RegistryHelper

Windows registry wrapper. Used to read, write and delete keys and values. Handles picking 64bit or 32bit views. Can be used on local or remote registries.

#### DeleteKey(key, deleteTree)

Deletes a key and value. Will delete a full tree structure by default

| Name | Description |
| ---- | ----------- |
| key | *Microsoft.Win32.RegistryKey*<br>Sub key to select from deletion |
| deleteTree | *System.Boolean*<br>if true current key and all children will be deleted. if there are children and this is false and error is thrown. |

#### DeleteValue(key, keyName)

Deletes the value from a given key. To delete the key use <a href="#registryhelper.deletekey(microsoft.win32.registrykey,system.boolean)">RegistryHelper.DeleteKey(Microsoft.Win32.RegistryKey,System.Boolean)</a>

| Name | Description |
| ---- | ----------- |
| key | *Microsoft.Win32.RegistryKey*<br>The sub key name to select |
| keyName | *System.String*<br>the key to remove the value from |

#### GetKey(hive, subKeyName, computer)

Gets or Creates a registry Sub Key

| Name | Description |
| ---- | ----------- |
| hive | *Microsoft.Win32.RegistryHive*<br><a href="#microsoft.win32.registryhive">Microsoft.Win32.RegistryHive</a> |
| subKeyName | *System.String*<br>Path for sub key |
| computer | *System.String*<br>Remote computer name used for execution, null or blank for local host |

Returns <a href="#microsoft.win32.registrykey">Microsoft.Win32.RegistryKey</a>

#### GetValue\`\`1(key, keyName, defaultValue)

Get the value of a key or the default if the key has no value

##### Type Parameters

- T - The type of value to return

| Name | Description |
| ---- | ----------- |
| key | *Microsoft.Win32.RegistryKey*<br>The Sub Key to select |
| keyName | *System.String*<br>The key name to get |
| defaultValue | *\`\`0*<br>The default value to return if the key has no value |


#### ImportFile(regFile, computer)

Takes a .reg file and imports it to the registry

| Name | Description |
| ---- | ----------- |
| regFile | *System.String*<br>Full path and name of the .reg file |
| computer | *System.String*<br>Remote computer name used for execution, null or blank for local host |


#### SetValue\`\`1(key, keyName, value)

Sets the value of a given key

##### Type Parameters

- T - The Type of the value to be set

| Name | Description |
| ---- | ----------- |
| key | *Microsoft.Win32.RegistryKey*<br>The Sub Key to select |
| keyName | *System.String*<br>the key name to set |
| value | *\`\`0*<br>The value to apply to the key name |


#### View

Selects the 64 or 32 bit registry view based on architecture.


## Security

Security Utility Functions

#### Impersonation.Constructor

Initializes a new instance of the <a href="#security.impersonation">Security.Impersonation</a> class.

#### Impersonation.Constructor(System.String,System.String,System.String,Useful.Utilities.Security.LogonType,Useful.Utilities.Security.LogonProvider)

Begins impersonation with the given credentials, Logon type and Logon provider.

#### Impersonation.Dispose

Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.

#### Impersonation.Impersonate(System.String,System.String,System.String,Useful.Utilities.Security.LogonType,Useful.Utilities.Security.LogonProvider)

Impersonates the specified user account.

#### Impersonation.UndoImpersonation

Stops impersonation.

#### IsInRole(username, password, role, remoteComputer)

Determines whether the specified user is in a given role

| Name | Description |
| ---- | ----------- |
| username | *System.String*<br>The username. |
| password | *System.String*<br>The password. |
| role | *System.Security.Principal.WindowsBuiltInRole*<br>The role. |
| remoteComputer | *System.String*<br>Can be used to execute on a remote computer. |


#### IsValidLogin(user, password, domain, remoteComputer)

Determines whether the specified username and password are valid. Can be ran locally or remotely

| Name | Description |
| ---- | ----------- |
| user | *System.String*<br>The username: domain\user |
| password | *System.String*<br>The password. |
| domain | *System.String*<br>The domain. |
| remoteComputer | *Unknown type*<br>Can be used to execute on a remote computer. |


#### Login(user, password, remoteComputer)

Login as a given user and return the login token

| Name | Description |
| ---- | ----------- |
| user | *System.String*<br>The user: domain\user |
| password | *System.String*<br>The password. |
| remoteComputer | *System.String*<br>The remote computer. |

#### LogonProvider.Default

Use the standard logon provider for the system. The default security provider is negotiate, unless you pass NULL for the domain name and the user name is not in UPN format. In this case, the default provider is NTLM. NOTE: Windows 2000/NT: The default security provider is NTLM.

#### LogonProvider.WinNT35

Use this provider if you'll be authenticating against a Windows NT 3.51 domain controller (uses the NT 3.51 logon provider).

#### LogonProvider.WinNT40

Use the NTLM logon provider.

#### LogonProvider.WinNT50

Use the negotiate logon provider.

#### LogonType.Batch

This logon type is intended for batch servers, where processes may be executing on behalf of a user without their direct intervention. This type is also for higher performance servers that process many plaintext authentication attempts at a time, such as mail or Web servers. The LogonUser function does not cache credentials for this logon type.

#### LogonType.Interactive

This logon type is intended for users who will be interactively using the computer, such as a user being logged on by a terminal server, remote shell, or similar process. This logon type has the additional expense of caching logon information for disconnected operations; therefore, it is inappropriate for some client/server applications, such as a mail server.

#### LogonType.Network

This logon type is intended for high performance servers to authenticate plaintext passwords. The LogonUser function does not cache credentials for this logon type.

#### LogonType.NetworkCleartext

This logon type preserves the name and password in the authentication package, which allows the server to make connections to other network servers while impersonating the client. A server can accept plaintext credentials from a client, call LogonUser, verify that the user can access the system across the network, and still communicate with other servers. NOTE: Windows NT: This value is not supported.

#### LogonType.NewCredentials

This logon type allows the caller to clone its current token and specify new credentials for outbound connections. The new logon session has the same local identifier but uses different credentials for other network connections. NOTE: This logon type is supported only by the LOGON32_PROVIDER_WINNT50 logon provider. NOTE: Windows NT: This value is not supported.

#### LogonType.Service

Indicates a service-type logon. The account provided must have the service privilege enabled.

#### LogonType.Unlock

This logon type is for GINA DLLs that log on users who will be interactively using the computer. This logon type can generate a unique audit record that shows when the workstation was unlocked.

#### RunAs(username, password)

Runs an action as a different user.

| Name | Description |
| ---- | ----------- |
| username | *System.String*<br>The username. |
| password | *System.String*<br>The password. |

#### SetLogonAsAService(user, remoteComputer)

Set logon as a service rights for the user.

| Name | Description |
| ---- | ----------- |
| user | *System.String*<br>The username as domain\user. if domain is not provide machine name is used |
| remoteComputer | *System.String*<br>Can be used to execute on a remote computer. |

#### SetPrivilege(user, privilege, remoteComputer)

Sets a privilege for the user.

| Name | Description |
| ---- | ----------- |
| user | *System.String*<br>The username as domain\user. if domain is not provide machine name is used |
| privilege | *System.String*<br>The privilege to set. <a href="#security.lsawrapper">Security.LsaWrapper</a> |
| remoteComputer | *System.String*<br>Can be used to execute on a remote computer. |

#### ValidateLogin(username, password, domain, remoteComputer)

Validates the username and password. Throws error if its invalid

| Name | Description |
| ---- | ----------- |
| username | *System.String*<br>The username. |
| password | *System.String*<br>The password. |
| domain | *System.String*<br>The domain. |
| remoteComputer | *Unknown type*<br>Can be used to execute on a remote computer. |

*System.InvalidOperationException:* Thrown if Username and password is invalid!


## ServicesManager

Used to control windows services locally or remotely using WMI. Can find, list, install, update, uninstall, start, stop or restart services

#### Constructor(System.String,System.String,System.String)

Initializes a new instance of the <a href="#servicesmanager">ServicesManager</a> class connected to a remote server as a different user.

#### Change(service)

Changes the specified service username, password or path.

| Name | Description |
| ---- | ----------- |
| service | *Useful.Utilities.Models.ServiceInfo*<br>The service to update. |

#### ChangeCredentials(svcName, username, password)

Changes the credentials of a service.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |
| username | *System.String*<br>The new username. Can be a domain user by passing "Domain\Username" |
| password | *System.String*<br>The new password. |

#### Connect(computerName, username, password)

Connects to the computer name passed in, leave blank for local

| Name | Description |
| ---- | ----------- |
| computerName | *System.String*<br>Name of the computer. Leave blank for local |
| username | *System.String*<br>The username to connect as. Leave blank for current user |
| password | *System.String*<br>The password for username if provided. |

#### GetDescription(svcName)

Gets the description of the service from the registry.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |

#### GetPath(svcName)

Gets the path of the service in the registry.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |

#### GetService(name)

Gets a service by name.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The service name to find. |

#### GetServiceInfo(name)

Gets a service by name.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The service name to find. |

#### GetServiceInfo(svcInfo)

Gets a service by name.

| Name | Description |
| ---- | ----------- |
| svcInfo | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. The Name property is used |

#### GetServices

Gets a list of all services

#### GetServiceState(name)

Gets the state of the service.

| Name | Description |
| ---- | ----------- |
| name | *System.String*<br>The service name to find. |

#### GetServiceState(svcInfo)

Gets the state of the service.

| Name | Description |
| ---- | ----------- |
| svcInfo | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. The Name property is used. |

#### InstallService(svcName, svcDispName, svcPath, description, username, password, svcType, errHandle, svcStartMode, interactWithDesktop, loadOrderGroup, loadOrderGroupDependencies, svcDependencies)

Installs a windows service. Ensures user has Logon as a service right by calling <a href="#security.setlogonasaservice(system.string,system.string)">Security.SetLogonAsAService(System.String,System.String)</a>

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |
| svcDispName | *System.String*<br>Display name of the service |
| svcPath | *System.String*<br>The service file path. |
| description | *System.String*<br>The service description. |
| username | *System.String*<br>The username to run the service. |
| password | *System.String*<br>The password of the user running the service. |
| svcType | *Useful.Utilities.Models.ServiceType*<br>Type of the service. |
| errHandle | *Useful.Utilities.Models.OnError*<br>The error handle type. |
| svcStartMode | *Useful.Utilities.Models.StartMode*<br>The service start mode. |
| interactWithDesktop | *System.Boolean*<br>if set to `true` service can interact with desktop. |
| loadOrderGroup | *System.String*<br>The load order group. |
| loadOrderGroupDependencies | *System.String[]*<br>The load order group dependencies. |
| svcDependencies | *System.String[]*<br>Any service dependencies. |

#### InstallService(service)

Installs a windows service. Ensures user has Logon as a service right by calling <a href="#security.setlogonasaservice(system.string,system.string)">Security.SetLogonAsAService(System.String,System.String)</a>

| Name | Description |
| ---- | ----------- |
| service | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. <a href="#models.serviceinfo">Models.ServiceInfo</a> |

#### IsServiceInstalled(svcName)

Determines whether a service is installed by name.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |

Returns True if installed

#### IsServiceInstalled(svcInfo)

Determines whether a service is installed by name.

| Name | Description |
| ---- | ----------- |
| svcInfo | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. Name property is used |

Returns True if installed

#### SetDescription(svcName, description)

Sets the description of the service in the registry.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |
| description | *System.String*<br>The description text to set. |

#### SetPath(svcName, path)

Sets the path of the service in the registry.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |
| path | *System.String*<br>The path to set. |

#### StartService(svcName)

Starts the service.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |

#### StartService(service)

Starts the service.

| Name | Description |
| ---- | ----------- |
| service | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. Name property is used |

#### StopService(svcName)

Stops the service.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |

#### StopService(service)

Stops the service.

| Name | Description |
| ---- | ----------- |
| service | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. Name property is used |

#### UninstallService(svcName)

Uninstalls the service from the system.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>The service name. |

#### UninstallService(svcInfo)

Uninstalls the service from the system.

| Name | Description |
| ---- | ----------- |
| svcInfo | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. Name property is used |

#### WaitForState(svcName, state, timeoutMs)

Waits for the service to be in a given state.

| Name | Description |
| ---- | ----------- |
| svcName | *System.String*<br>Name of the service. |
| state | *Useful.Utilities.Models.ServiceState*<br>The state to wait for. |
| timeoutMs | *System.Int32*<br>The timeout in milliseconds. |

#### WaitForState(service, state, timeoutMs)

Waits for the service to be in a given state.

| Name | Description |
| ---- | ----------- |
| service | *Useful.Utilities.Models.ServiceInfo*<br>The service information object. |
| state | *Useful.Utilities.Models.ServiceState*<br>The state to wait for. |
| timeoutMs | *System.Int32*<br>The timeout in milliseconds. |

Returns True when service is in given state. False if service is not in given state by the end of the timeout period


## SharedFolderConnection

Create a connection to a shared folder with a different set of credentials

##### Example

Connect to a server share and copy a file as a different user: 
```

            using (new SharedFolderConnection(@"\\192.168.1.9", new NetworkCredential("user", "password", "domain")))
            {
                File.Copy(@"\\192.168.1.9\some share\some file.txt", @"c:\dest\some file.txt", true); 
            }
            
```


#### Constructor(unc, credentials)

Initializes a new instance of the <a href="#sharedfolderconnection">SharedFolderConnection</a> class.

| Name | Description |
| ---- | ----------- |
| unc | *System.String*<br>The unc. \\Server |
| credentials | *System.Net.NetworkCredential*<br>The <a href="#system.net.networkcredential">System.Net.NetworkCredential</a>. |


## TaskList

Provides functions for running async work.

#### Constructor

Initializes a new instance of the <a href="#tasklist">TaskList</a> class with a max thread count of 50.

#### Constructor(threads)

Initializes a new instance of the <a href="#tasklist">TaskList</a> class with a limited number of threads.

| Name | Description |
| ---- | ----------- |
| threads | *System.Int32*<br>The number of threads to limit. |

#### AddTask(work)

Adds the task to the list. If a thread is available work starts right away otherwise it waits for a thread then starts

| Name | Description |
| ---- | ----------- |
| work | *System.Action*<br>The action to run. |

#### Run(work, after, error)

Runs the specified work. If work action threw an error and error action is provided, it will be called before the after action. If after action is provided, it is ran once the work action is done. The after action is passed true if work completed successfully, false if work faulted. After and error actions are ran in the Current Synchronization Context (usually the UI thread)

| Name | Description |
| ---- | ----------- |
| work | *System.Action*<br>The work to the run. |
| after | *System.Action{System.Boolean}*<br>The action to run after work is complete. |
| error | *System.Action{System.Exception}*<br>The on error action if work faulted |

#### Run\`\`1(work, after, error)

Runs the specified work. If work action threw an error and error action is provided, it will be called before the after action. If after action is provided, it is ran once the work action is done. The after action is passed the result of work action if it was successful. If work action faulted, after action will be passed the default of <a href="#t">T</a>. After and error actions are ran in the Current Synchronization Context (usually the UI thread)

##### Type Parameters

- T - Type returned from work function and input to after action

| Name | Description |
| ---- | ----------- |
| work | *System.Func{\`\`0}*<br>The work function to run |
| after | *System.Action{\`\`0}*<br>The after action to run |
| error | *System.Action{System.Exception}*<br>The on error action if work faulted |

#### Tasks

Gets all the tasks in the list.

#### WaitForAll

Waits for all tasks in the list to finish. Then clears the lists


## WMI

Windows Management Interface Wrapper class. Handles scoping WMI calls for local or remote computers

#### Constructor

Creates a new instance of the wrapper

#### Constructor(System.String,System.String,System.String)

Creates a new instance of the wrapper connected to a remote server as a different user

#### Constructor(System.String)

Creates a new instance of the wrapper connected to a remote server

#### ConnectionOptions

Gets or sets the management scope

#### Dispose

Managed dispose

#### Dispose(disposing)

Dispose of managed and unmanaged objects

| Name | Description |
| ---- | ----------- |
| disposing | *System.Boolean*<br> |

#### Finalize

Clean up unmanaged references

#### GetObjects(wmiClass, where)

Get an instance of the specified class filtered by a where clause

| Name | Description |
| ---- | ----------- |
| wmiClass | *System.String*<br>Type of the class |
| where | *System.String*<br>The where clause filter to apply |

#### GetObjects(wmiClass)

Get an instance of the specified class

| Name | Description |
| ---- | ----------- |
| wmiClass | *System.String*<br>Type of the class |

Returns Array of management objects

#### GetObjectsByName(wmiClass, name)

Get an instance of the specified class filtered by name

| Name | Description |
| ---- | ----------- |
| wmiClass | *System.String*<br>Type of the class |
| name | *System.String*<br>The name to filter by |

#### GetProperties(mo)

Convert the property data collection to a string object dictionary

| Name | Description |
| ---- | ----------- |
| mo | *System.Management.ManagementBaseObject*<br>ManagementBaseObject |

Returns Dictionary{string,object}

#### Initialize(username, password, server)

Initializes the WMI connection

| Name | Description |
| ---- | ----------- |
| username | *System.String*<br>Username to connect to server with |
| password | *System.String*<br>Password to connect to server with |
| server | *System.String*<br>Server to connect to |

#### Password

Gets the password used to connect


## WMI ReturnValue

WMI Common Return Values

#### Useful.Utilities.WMI.Scope

Creates a <a href="#system.management.managementscope">System.Management.ManagementScope</a> scoped to the current connection

#### Useful.Utilities.WMI.ScopedClass(path, options)

Creates a <a href="#system.management.managementclass">System.Management.ManagementClass</a> scoped to the current connection

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>The WMI path |
| options | *System.Management.ObjectGetOptions*<br>Additional options, if needed |

#### Useful.Utilities.WMI.ScopedObject(path, options)

Creates a <a href="#system.management.managementobject">System.Management.ManagementObject</a> scoped to the current connection

| Name | Description |
| ---- | ----------- |
| path | *System.String*<br>The WMI path |
| options | *System.Management.ObjectGetOptions*<br>Additional options, if needed |

#### Useful.Utilities.WMI.Server

Gets the server connected to

#### Useful.Utilities.WMI.Username

Gets the username used to connect

#### Useful.Utilities.WMI.WmiNameSpace

Gets or sets the WMI namespace. default is CimV2
