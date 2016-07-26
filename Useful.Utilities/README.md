# Useful.Utilities

Collection of utility classes for dealing with Windows services, IIS, WMI, Registry, x509 certificates, Files, security, network shares, GAC files, and a few other things. Most utilities can be ran locally or remotely.

### [Documentation](./Useful.Utilities.md)

### [NuGet Package](https://www.nuget.org/packages/Useful.Utilities/)

### [Project Site](http://xiopod.net/Useful.Utilities)


## Change Log
#### v1.0.6
Added extension methods for recursively iterating over XML documents and XML nodes
Added extension method for name value collections to get items by name and default values
Added extension method string.Contains that takes a comparison parameter and can ignore case

#### v1.0.5
Added WebBase class for building typed web clients
Added XML to Markdown logic for documentation generation (See [Build Toolds](./buildTools/XmlToMarkdown.cs))

#### v1.0.4
Enhanced Default extension method, Support for more types including nullables
Added Traverse<T> extension method for recursively searching an enumerable tree
Added ToLong and TryToLong extension methods for converting strings to longs
Added Compression class for basic zip/unzip using GZip (unbuffered)
Added SHA256 hashing function to CryptoManager

#### v1.0.3
Renamed ComputerManger to ComputerManager (fixed typo)
Renamed IISServer to IisManager, replaced public constructors with connect method
Added Impersonation class to security manager
Added RunAs function to wrap impersonation
Added IisVersion function to IisManger
Added ExecuteScalarAsInt to Database class
Added FeatureInfo class and FeaturesAndRoles enum (maps to Win32_ServerFeature objects / ids)
Added ToBytes/FromBytes methods to ObjectCopier class
Added CryptoManager 