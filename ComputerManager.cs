﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using Useful.Utilities.Models;

namespace Useful.Utilities
{
    namespace Models
    {
        public enum DomainRole : uint
        {
            StandaloneWorkstation = 0x0,
            MemberWorkstation = 0x1,
            StandaloneServer = 0x2,
            MemberServer = 0x3,
            BackupDomainController = 0x4,
            PrimaryDomainController = 0x5

        }
        #region Feature and roles enum
        /// <summary>
        /// List of Features and Roles that can be mapped to the FeatureInfo Id and Parent Id property
        /// </summary>
        public enum FeaturesAndRoles
        {
            NotSet = 0,
            [Description("Application Server")]
            ApplicationServer = 1,
            [Description("Web Server (IIS)")]
            WebServer_IIS = 2,
            [Description("Streaming Media Services")]
            StreamingMediaServices = 3,
            [Description("Fax Server")]
            FaxServer = 5,
            [Description("File Services")]
            FileServices = 6,
            [Description("Print and Document Services")]
            PrintandDocumentServices = 7,
            [Description("Active Directory Federation Services")]
            ActiveDirectoryFederationServices = 8,
            [Description("Active Directory Lightweight Directory Services")]
            ActiveDirectoryLightweightDirectoryServices = 9,
            [Description("Active Directory Domain Services")]
            ActiveDirectoryDomainServices = 10,
            [Description("UDDI Services")]
            UDDIServices = 11,
            [Description("DHCP Server")]
            DHCPServer = 12,
            [Description("DNS Server")]
            DNSServer = 13,
            [Description("Network Policy and Access Services")]
            NetworkPolicyandAccessServices = 14,
            [Description("Active Directory Certificate Services")]
            ActiveDirectoryCertificateServices = 16,
            [Description("Active Directory Rights Management Services")]
            ActiveDirectoryRightsManagementServices = 17,
            [Description("Remote Desktop Services")]
            RemoteDesktopServices = 18,
            [Description("Windows Deployment Services")]
            WindowsDeploymentServices = 19,
            [Description("Hyper-V")]
            HyperV = 20,
            [Description("Windows Server Update Services")]
            WindowsServerUpdateServices = 21,
            [Description("Failover Clustering")]
            FailoverClustering = 33,
            [Description("Network Load Balancing")]
            NetworkLoadBalancing = 34,
            [Description("Desktop Experience")]
            DesktopExperience = 35,
            [Description(".NET Framework 3.5.1 Features")]
            NETFramework351Features = 36,
            [Description("Windows System Resource Manager")]
            WindowsSystemResourceManager = 37,
            [Description("Wireless LAN Service")]
            WirelessLANService = 38,
            [Description("Windows Server Backup Features")]
            WindowsServerBackupFeatures = 39,
            [Description("WINS Server")]
            WINSServer = 40,
            [Description("Windows Process Activation Service")]
            WindowsProcessActivationService = 41,
            [Description("Remote Assistance")]
            RemoteAssistance = 42,
            [Description("Simple TCP/IP Services")]
            SimpleTCPIPServices = 43,
            [Description("Telnet Client")]
            TelnetClient = 44,
            [Description("Telnet Server")]
            TelnetServer = 45,
            [Description("Subsystem For Unix-based Applications")]
            SubsystemForUnixbasedApplications = 46,
            [Description("RPC Over HTTP Proxy")]
            RPCOverHTTPProxy = 47,
            [Description("SMTP Server")]
            SMTPServer = 48,
            [Description("Message Queuing")]
            MessageQueuing = 49,
            [Description("Windows Internal Database")]
            WindowsInternalDatabase = 51,
            [Description("Storage Manager For SANs")]
            StorageManagerForSANs = 52,
            [Description("LPR Port Monitor")]
            LPRPortMonitor = 53,
            [Description("Internet Storage Name Server")]
            InternetStorageNameServer = 55,
            [Description("Multipath I/O")]
            MultipathIO = 57,
            [Description("TFTP Client")]
            TFTPClient = 58,
            [Description("SNMP Services")]
            SNMPServices = 59,
            [Description("Removable Storage Manager")]
            RemovableStorageManager = 60,
            [Description("BitLocker Drive Encryption")]
            BitLockerDriveEncryption = 61,
            [Description("Services For Network File System")]
            ServicesForNetworkFileSystem = 62,
            [Description("Internet Printing Client")]
            InternetPrintingClient = 63,
            [Description("Peer Name Resolution Protocol")]
            PeerNameResolutionProtocol = 64,
            [Description("Connection Manager Administration Kit")]
            ConnectionManagerAdministrationKit = 65,
            [Description("Windows PowerShell")]
            WindowsPowerShell = 66,
            [Description("Remote Server Administration Tools")]
            RemoteServerAdministrationTools = 67,
            [Description("Quality Windows Audio Video Experience")]
            QualityWindowsAudioVideoExperience = 68,
            [Description("Group Policy Management")]
            GroupPolicyManagement = 69,
            [Description("Indexing Service")]
            IndexingService = 71,
            [Description("File Server Resource Manager (FSRM)")]
            FileServerResourceManager_FSRM = 72,
            [Description("Remote Differential Compression")]
            RemoteDifferentialCompression = 73,
            [Description("Ink and Handwriting Services")]
            InkandHandwritingServices = 310,
            [Description("Windows Server Migration Tools")]
            WindowsServerMigrationTools = 320,
            [Description("WinRM IIS Extension")]
            WinRMIISExtension = 321,
            [Description("BranchCache")]
            BranchCache = 324,
            [Description("DirectAccess Management Console")]
            DirectAccessManagementConsole = 334,
            [Description("Background Intelligent Transfer Service (BITS)")]
            BackgroundIntelligentTransferService_BITS = 335,
            [Description("XPS Viewer")]
            XPSViewer = 338,
            [Description("Windows Biometric Framework")]
            WindowsBiometricFramework = 339,
            [Description("WoW64 Support")]
            WoW64Support = 340,
            [Description("Windows PowerShell Integrated Scripting Environment (ISE)")]
            WindowsPowerShellIntegratedScriptingEnvironment_ISE = 351,
            [Description("Windows TIFF IFilter")]
            WindowsTIFFIFilter = 352,
            [Description("Distributed File System")]
            DistributedFileSystem = 100,
            [Description("DFS Namespace")]
            DFSNamespace = 101,
            [Description("DFS Replication")]
            DFSReplication = 102,
            [Description("File Replication Service")]
            FileReplicationService = 103,
            [Description("File Server Resource Manager")]
            FileServerResourceManager = 104,
            [Description("Services For Network File System")]
            ServicesForNetworkFileSystem_FileService = 105,
            [Description("Single Instance Storage")]
            SingleInstanceStorage = 106,
            [Description("Windows Search Service")]
            WindowsSearchService = 107,
            [Description("Indexing Service")]
            IndexingService_fileService = 108,
            [Description("Windows Server 2003 File Services")]
            WindowsServer2003FileServices = 226,
            [Description("File Server")]
            FileServer = 255,
            [Description("BranchCache for Network Files")]
            BranchCacheforNetworkFiles = 350,
            [Description("Active Directory Domain Controller")]
            ActiveDirectoryDomainController = 110,
            [Description("Identity Management For Unix")]
            IdentityManagementForUnix = 111,
            [Description("Server For Network Information Services")]
            ServerForNetworkInformationServices = 112,
            [Description("Password Synchronization")]
            PasswordSynchronization = 113,
            [Description("Administration Tools")]
            AdministrationTools = 294,
            [Description("Windows Media Server")]
            WindowsMediaServer = 120,
            [Description("Web-based Administration")]
            WebbasedAdministration = 121,
            [Description("Logging Agent")]
            LoggingAgent = 122,
            [Description("Federation Service")]
            FederationService = 125,
            [Description("Federation Service Policy")]
            FederationServicePolicy = 126,
            [Description("AD FS Web Agents")]
            ADFSWebAgents = 127,
            [Description("Claims-aware Agent")]
            ClaimsawareAgent = 128,
            [Description("Windows Token-based Agent")]
            WindowsTokenbasedAgent = 129,
            [Description("Remote Desktop Session Host")]
            RemoteDesktopSessionHost = 130,
            [Description("Remote Desktop Licensing")]
            RemoteDesktopLicensing = 131,
            [Description("Remote Desktop Gateway")]
            RemoteDesktopGateway = 132,
            [Description("Remote Desktop Connection Broker")]
            RemoteDesktopConnectionBroker = 133,
            [Description("Remote Desktop Web Access")]
            RemoteDesktopWebAccess = 134,
            [Description("Remote Desktop Virtualization Host")]
            RemoteDesktopVirtualizationHost = 322,
            [Description("Print Server")]
            PrintServer = 135,
            [Description("Internet Printing")]
            InternetPrinting = 136,
            [Description("LPD Print Service")]
            LPDPrintService = 137,
            [Description("Distributed Scan Server")]
            DistributedScanServer = 328,
            [Description("Web Server")]
            WebServer = 140,
            [Description("Common HTTP Features")]
            CommonHTTPFeatures = 141,
            [Description("Static Content")]
            StaticContent = 142,
            [Description("Default Document")]
            DefaultDocument = 143,
            [Description("Directory Browse")]
            DirectoryBrowse = 144,
            [Description("HTTP Errors")]
            HTTPErrors = 145,
            [Description("HTTP Redirection")]
            HTTPRedirection = 146,
            [Description("WebDAV Publishing")]
            WebDAVPublishing = 314,
            [Description("Application Development")]
            ApplicationDevelopment = 147,
            [Description("ASP.NET")]
            ASPNET = 148,
            [Description(".NET Extensibility")]
            NETExtensibility = 149,
            [Description("ASP")]
            ASP = 150,
            [Description("CGI")]
            CGI = 151,
            [Description("ISAPI Extensions")]
            ISAPIExtensions = 152,
            [Description("ISAPI Filters")]
            ISAPIFilters = 153,
            [Description("Server Side Includes")]
            ServerSideIncludes = 154,
            [Description("Health And Diagnostics")]
            HealthAndDiagnostics = 155,
            [Description("HTTP Logging")]
            HTTPLogging = 156,
            [Description("Logging Tools")]
            LoggingTools = 157,
            [Description("Request Monitor")]
            RequestMonitor = 158,
            [Description("Tracing")]
            Tracing = 159,
            [Description("Custom Logging")]
            CustomLogging = 160,
            [Description("ODBC Logging")]
            ODBCLogging = 161,
            [Description("Security")]
            Security = 162,
            [Description("Basic Authentication")]
            BasicAuthentication = 163,
            [Description("Windows Authentication")]
            WindowsAuthentication = 164,
            [Description("Digest Authentication")]
            DigestAuthentication = 165,
            [Description("Client Certificate Mapping Authentication")]
            ClientCertificateMappingAuthentication = 166,
            [Description("IIS Client Certificate Mapping Authentication")]
            IISClientCertificateMappingAuthentication = 167,
            [Description("URL Authorization")]
            URLAuthorization = 168,
            [Description("Request Filtering")]
            RequestFiltering = 169,
            [Description("IP And Domain Restrictions")]
            IPAndDomainRestrictions = 170,
            [Description("Performance")]
            Performance = 171,
            [Description("Static Content Compression")]
            StaticContentCompression = 172,
            [Description("Dynamic Content Compression")]
            DynamicContentCompression = 173,
            [Description("Management Tools")]
            ManagementTools = 174,
            [Description("IIS Management Console")]
            IISManagementConsole = 175,
            [Description("IIS Management Scripts And Tools")]
            IISManagementScriptsAndTools = 176,
            [Description("Management Service")]
            ManagementService = 177,
            [Description("IIS 6 Management Compatibility")]
            IIS6ManagementCompatibility = 178,
            [Description("IIS 6 Metabase Compatibility")]
            IIS6MetabaseCompatibility = 179,
            [Description("IIS 6 WMI Compatibility")]
            IIS6WMICompatibility = 180,
            [Description("IIS 6 Scripting Tools")]
            IIS6ScriptingTools = 181,
            [Description("IIS 6 Management Console")]
            IIS6ManagementConsole = 182,
            [Description("FTP Publishing Service")]
            FTPPublishingService = 183,
            [Description("FTP Server")]
            FTPServer = 184,
            [Description("FTP Management Console")]
            FTPManagementConsole = 185,
            [Description("FTP Service")]
            FTPService = 316,
            [Description("FTP Extensibility")]
            FTPExtensibility = 317,
            [Description("IIS Hostable Web Core")]
            IISHostableWebCore = 336,
            [Description("Message Queuing Services")]
            MessageQueuingServices = 190,
            [Description("Message Queuing Server")]
            MessageQueuingServer = 191,
            [Description("Directory Service Integration")]
            DirectoryServiceIntegration = 192,
            [Description("Message Queuing Triggers")]
            MessageQueuingTriggers = 193,
            [Description("HTTP Support")]
            HTTPSupport = 194,
            [Description("Routing Service")]
            RoutingService = 195,
            [Description("Windows 2000 Client Support")]
            Windows2000ClientSupport = 196,
            [Description("Message Queuing DCOM Proxy")]
            MessageQueuingDCOMProxy = 197,
            [Description("Multicasting Support")]
            MulticastingSupport = 228,
            [Description("Certification Authority")]
            CertificationAuthority = 200,
            [Description("Certification Authority Web Enrollment")]
            CertificationAuthorityWebEnrollment = 201,
            [Description("Online Responder")]
            OnlineResponder = 202,
            [Description("Network Device Enrollment Service")]
            NetworkDeviceEnrollmentService = 204,
            [Description("Certificate Enrollment Web Service")]
            CertificateEnrollmentWebService = 318,
            [Description("Certificate Enrollment Policy Web Service")]
            CertificateEnrollmentPolicyWebService = 319,
            [Description("Network Policy Server")]
            NetworkPolicyServer = 205,
            [Description("VPN")]
            VPN = 206,
            [Description("Remote Access Services")]
            RemoteAccessServices = 207,
            [Description("Routing")]
            Routing = 208,
            [Description("Health Registration Authority")]
            HealthRegistrationAuthority = 210,
            [Description("Host Credential Authorization Protocol")]
            HostCredentialAuthorizationProtocol = 250,
            [Description("UDDI Services Web Application")]
            UDDIServicesWebApplication = 215,
            [Description("UDDI Services Database")]
            UDDIServicesDatabase = 216,
            [Description("Configuration API")]
            ConfigurationAPI = 217,
            [Description(".NET Environment")]
            NETEnvironment = 218,
            [Description("Process Model")]
            ProcessModel = 219,
            [Description(".NET Framework 3.5.1")]
            NETFramework351 = 220,
            [Description("WCF Activation")]
            WCFActivation = 221,
            [Description("HTTP Activation")]
            HTTPActivation_Net35 = 222,
            [Description("Non-HTTP Activation")]
            NonHTTPActivation = 223,
            [Description("XPS Viewer")]
            XPSViewer_Net35 = 227,
            [Description("SNMP Service")]
            SNMPService = 224,
            [Description("SNMP WMI Provider")]
            SNMPWMIProvider = 225,
            [Description(".NET Framework 3.5.1")]
            NETFramework351_ApplicationCore = 230,
            [Description("Web Server (IIS) Support")]
            WebServer_IISSupport = 231,
            [Description("COM+ Network Access")]
            COMNetworkAccess = 232,
            [Description("TCP Port Sharing")]
            TCPPortSharing = 233,
            [Description("Windows Process Activation Service Support")]
            WindowsProcessActivationServiceSupport = 234,
            [Description("HTTP Activation")]
            HTTPActivation_ApplicationService = 235,
            [Description("Message Queuing Activation")]
            MessageQueuingActivation = 236,
            [Description("TCP Activation")]
            TCPActivation = 237,
            [Description("Named Pipes Activation")]
            NamedPipesActivation = 238,
            [Description("Distributed Transactions")]
            DistributedTransactions = 239,
            [Description("Incoming Remote Transactions")]
            IncomingRemoteTransactions = 240,
            [Description("Outgoing Remote Transactions")]
            OutgoingRemoteTransactions = 241,
            [Description("WS-Automatic Transactions")]
            WSAutomaticTransactions = 242,
            [Description("Application Server Extensions for .NET 4.0")]
            ApplicationServerExtensionsforNET40 = 353,
            [Description("Deployment Server")]
            DeploymentServer = 251,
            [Description("Transport Server")]
            TransportServer = 252,
            [Description("Active Directory Rights Management Server")]
            ActiveDirectoryRightsManagementServer = 253,
            [Description("Identity Federation Support")]
            IdentityFederationSupport = 254,
            [Description("Role Administration Tools")]
            RoleAdministrationTools = 256,
            [Description("AD DS Tools")]
            ADDSTools = 257,
            [Description("AD LDS Snap-Ins and Command-Line Tools")]
            ADLDSSnapInsandCommandLineTools = 258,
            [Description("Active Directory Certificate Services Tools")]
            ActiveDirectoryCertificateServicesTools = 259,
            [Description("Network Policy and Access Services")]
            NetworkPolicyandAccessServices_Remote = 260,
            [Description("Print and Document Services Tools")]
            PrintandDocumentServicesTools = 261,
            [Description("Active Directory Rights Management Services")]
            ActiveDirectoryRightsManagementServices_Remote = 262,
            [Description("Remote Desktop Services Tools")]
            RemoteDesktopServicesTools = 263,
            [Description("Windows Deployment Services Tools")]
            WindowsDeploymentServicesTools = 264,
            [Description("Feature Administration Tools")]
            FeatureAdministrationTools = 265,
            [Description("BitLocker Drive Encryption Tools")]
            BitLockerDriveEncryptionTools = 266,
            [Description("BITS Server Extensions Tools")]
            BITSServerExtensionsTools = 267,
            [Description("Failover Clustering Tools")]
            FailoverClusteringTools = 268,
            [Description("Network Load Balancing Tools")]
            NetworkLoadBalancingTools = 269,
            [Description("SMTP Server Tools")]
            SMTPServerTools = 270,
            [Description("DNS Server Tools")]
            DNSServerTools = 273,
            [Description("File Services Tools")]
            FileServicesTools = 277,
            [Description("Distributed File System Tools")]
            DistributedFileSystemTools = 278,
            [Description("File Server Resource Manager Tools")]
            FileServerResourceManagerTools = 279,
            [Description("Services For Network File System Tools")]
            ServicesForNetworkFileSystemTools = 280,
            [Description("Web Server (IIS) Tools")]
            WebServer_IISTools = 281,
            [Description("Remote Desktop Session Host Tools")]
            RemoteDesktopSessionHostTools = 284,
            [Description("Remote Desktop Gateway Tools")]
            RemoteDesktopGatewayTools = 285,
            [Description("Remote Desktop Licensing Tools")]
            RemoteDesktopLicensingTools = 286,
            [Description("Fax Server Tools")]
            FaxServerTools = 288,
            [Description("WINS Server Tools")]
            WINSServerTools = 290,
            [Description("UDDI Services Tools")]
            UDDIServicesTools = 291,
            [Description("Certification Authority Tools")]
            CertificationAuthorityTools = 292,
            [Description("Online Responder Tools")]
            OnlineResponderTools = 293,
            [Description("AD DS Snap-Ins and Command-Line Tools")]
            ADDSSnapInsandCommandLineTools = 299,
            [Description("BitLocker Recovery Password Viewer")]
            BitLockerRecoveryPasswordViewer = 323,
            [Description("BitLocker Drive Encryption Administration Utilities")]
            BitLockerDriveEncryptionAdministrationUtilities = 326,
            [Description("AD DS and AD LDS Tools")]
            ADDSandADLDSTools = 329,
            [Description("Active Directory Administrative Center")]
            ActiveDirectoryAdministrativeCenter = 330,
            [Description("Active Directory module for Windows PowerShell")]
            ActiveDirectorymoduleforWindowsPowerShell = 331,
            [Description("Remote Desktop Connection Broker Tools")]
            RemoteDesktopConnectionBrokerTools = 337,
            [Description("Windows Server Backup")]
            WindowsServerBackup = 296,
            [Description("Command Line Tools")]
            CommandLineTools = 297,
            [Description("Ink Support")]
            InkSupport = 311,
            [Description("Handwriting Recognition")]
            HandwritingRecognition = 312,
            [Description("IIS Server Extension")]
            IISServerExtension = 54,
            [Description("Compact Server")]
            CompactServer = 332,
            [Description("WoW64")]
            WoW64 = 341,
            [Description("WoW64 for .NET Framework 2.0 and Windows PowerShell")]
            WoW64forNETFramework20andWindowsPowerShell = 342,
            [Description("WoW64 for .NET Framework 2.0")]
            WoW64forNETFramework20 = 343,
            [Description("WoW64 for Windows PowerShell")]
            WoW64forWindowsPowerShell = 344,
            [Description("WoW64 for .NET Framework 3.0 and 3.5")]
            WoW64forNETFramework30and35 = 345,
            [Description("WoW64 for Print Services")]
            WoW64forPrintServices = 346,
            [Description("WoW64 for Failover Clustering")]
            WoW64forFailoverClustering = 347,
            [Description("WoW64 for Input Method Editor")]
            WoW64forInputMethodEditor = 348,
            [Description("WoW64 for Subsystem for UNIX-based Applications")]
            WoW64forSubsystemforUNIXbasedApplications = 349,

            //2012 
            [Description(".NET Framework 4.5")]
            NETFramework45 = 230,
            [Description("File And Storage Services")]
            FileAndStorageServices = 481,
            [Description("ASP.NET 4.5")]
            ASPNET45_Feature = 429,
            [Description(".NET Framework 4.5")]
            NETFramework45_Feature = 418,
            [Description(".NET Framework 4.5 Features")]
            NETFramework45Features = 466,
            [Description(".NET Framework 3.5 (includes .NET 2.0 and 3.0)")]
            NETFramework35_includesNET20and30 = 220,
            [Description(".NET Framework 3.5 Features")]
            NETFramework35Features = 475,
            [Description("HTTP Activation")]
            HTTPActivation = 421,
            [Description("WCF Services")]
            WCFServices = 420,
            [Description("TCP Activation")]
            TCPActivation_Feature = 424,
            [Description("TCP Port Sharing")]
            TCPPortSharing_Feature = 425,
            [Description("Windows PowerShell 3.0")]
            WindowsPowerShell30 = 412,
            [Description("Windows PowerShell ISE")]
            WindowsPowerShellISE = 351,
            [Description("Windows PowerShell 2.0 Engine")]
            WindowsPowerShell20Engine = 411,
            [Description("Windows PowerShell")]
            WindowsPowerShell_Feature = 417,
            [Description("Windows Search Service")]
            WindowsSearchService_Feature = 432,
            [Description("Graphical Management Tools and Infrastructure")]
            GraphicalManagementToolsandInfrastructure = 478,
            [Description("Server Graphical Shell")]
            ServerGraphicalShell = 99,
            [Description("Media Foundation")]
            MediaFoundation = 467,
            [Description("Storage Services")]
            StorageServices = 482,
            [Description("User Interfaces and Infrastructure")]
            UserInterfacesandInfrastructure = 477,
            [Description("Configuration APIs")]
            ConfigurationAPIs = 217,
            [Description(".NET Environment 3.5")]
            NETEnvironment35 = 218,
            [Description("Application Initialization")]
            ApplicationInitialization = 445,
            [Description("ASP.NET 4.5")]
            ASPNET45 = 413,
            [Description("Directory Browsing")]
            DirectoryBrowsing = 144,
            [Description(".NET Extensibility 3.5")]
            NETExtensibility35 = 149,
            [Description(".NET Extensibility 4.5")]
            NETExtensibility45 = 414,
            [Description("WebSocket Protocol")]
            WebSocketProtocol = 447,
            [Description("Windows Identity Foundation 3.5")]
            WindowsIdentityFoundation35 = 427,

        }
        #endregion

        /// <summary>
        /// Model for holding computer information. Also handles converting a <see cref="ManagementObject"/> to a model. 
        /// <see href="http://msdn.microsoft.com/en-us/library/aa394102(v=vs.85).aspx"/>
        /// </summary>
        [Serializable]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public class ComputerInfo
        {
            
            public string Caption { get; private set; }
            public string Description { get; private set; }
            /// <summary>
            /// Name of local computer according to the domain name server (DNS).
            /// </summary>
            public string DNSHostName { get; private set; }
            /// <summary>
            /// Name of the domain to which a computer belongs.
            /// </summary>
            public string Domain { get; private set; }
            public DomainRole DomainRole { get; private set; }
            /// <summary>
            /// Name of a computer manufacturer.
            /// </summary>
            public string Manufacturer { get; private set; }
            /// <summary>
            /// Product name that a manufacturer gives to a computer. This property must have a value.
            /// </summary>
            public string Model { get; private set; }
            /// <summary>
            /// Name of object
            /// </summary>
            public string Name { get; private set; }
            public string NameFormat { get; private set; }
            /// <summary>
            /// Number of logical processors available on the computer.
            /// </summary>
            public UInt32 NumberOfLogicalProcessors { get; private set; }
            /// <summary>
            /// Number of all processors available on the computer.
            /// </summary>
            public UInt32 NumberOfProcessors { get; private set; }
            /// <summary>
            /// Null if unknown
            /// </summary>
            public bool? PartOfDomain { get; private set; }
            /// <summary>
            /// Contact information for the primary system owner,
            /// </summary>
            public string PrimaryOwnerContact { get; private set; }
            /// <summary>
            /// Name of the primary system owner. 
            /// </summary>
            public string PrimaryOwnerName { get; private set; }
            public string Status { get; private set; }
            public string SystemType { get; private set; }
            /// <summary>
            /// Total size of physical memory. Be aware this property may not return an accurate value
            /// </summary>
            public UInt64 TotalPhysicalMemory { get; private set; }
            /// <summary>
            /// Name of a user that is logged on currently to the console (not remote desktop users)
            /// </summary>
            public string UserName { get; private set; }
            /// <summary>
            /// Name of the workgroup for this computer. Only if the value of the PartOfDomain property is False
            /// </summary>
            public string Workgroup { get; private set; }

            [NonSerialized]
            private ManagementObject _managementObject;
            protected internal ManagementObject ManagementObject(){return _managementObject; }

            protected internal static ComputerInfo CreateComputerInfo(ManagementObject managementObject)
            {
                if (managementObject == null)
                    return null;
                ComputerInfo comp = null;
                try
                {
                    comp = new ComputerInfo();
                    comp._managementObject = managementObject;
                    comp.Caption = (string)managementObject["Caption"];
                    comp.Description = (string)managementObject["Description"];
                    comp.DNSHostName = (string)managementObject["DNSHostName"];
                    comp.Domain = (string)managementObject["Domain"];

                    comp.Manufacturer = (string)managementObject["Manufacturer"];
                    comp.Model = (string)managementObject["Model"];
                    comp.Name = (string)managementObject["Name"];
                    comp.NameFormat = (string)managementObject["NameFormat"];
                    comp.NumberOfLogicalProcessors = (UInt32)managementObject["NumberOfLogicalProcessors"];
                    comp.NumberOfProcessors = (UInt32)managementObject["NumberOfProcessors"];

                    comp.PrimaryOwnerContact = (string)managementObject["PrimaryOwnerContact"];
                    comp.PrimaryOwnerName = (string)managementObject["PrimaryOwnerName"];
                    comp.Status = (string)managementObject["Status"];
                    comp.SystemType = (string)managementObject["SystemType"];
                    comp.TotalPhysicalMemory = (UInt64)managementObject["TotalPhysicalMemory"];
                    comp.UserName = (string)managementObject["UserName"];
                    comp.Workgroup = (string)managementObject["Workgroup"];
                    comp.DomainRole = (DomainRole)(ushort)(managementObject["DomainRole"]);
                    comp.PartOfDomain = (bool?)managementObject["PartOfDomain"];
                }
                catch (Exception ex)
                {
                    Trace.WriteLine("ERROR: " + ex.Message);
                    Trace.TraceError(ex.ToString());
                }
                return comp;
            }

        }

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


    /// <summary>
    /// Collection of computer, domain, and user name functions
    /// </summary>
    public class ComputerManager : WMI
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="ComputerManager"/> class.
        /// </summary>
        private ComputerManager() : base() { }
        /// <summary>
        /// Creates a new instance of Process Manager connected to a remote computer
        /// </summary>
        private ComputerManager(string server) : base(server) { }
        /// <summary>
        /// Creates a new instance of the Process Manager connected to a remote server as a different user
        /// </summary>
        private ComputerManager(string server, string username, string password) : base(server, username, password) { }

        private ComputerInfo _computer;
        /// <summary>
        /// Gets information about the computer currently connected to. 
        /// </summary>
        /// <returns></returns>
        public ComputerInfo Computer()
        {
            if (_computer != null) return _computer;
            var result = GetObjects("Win32_ComputerSystem");
            return _computer = result.Select(ComputerInfo.CreateComputerInfo).FirstOrDefault();
        }

        public List<FeatureInfo> Features()
        {
            var rtn = new List<string>();
            var result = GetObjects("Win32_ServerFeature");
            return result.Select(FeatureInfo.CreateFeatureInfo).ToList();
        }

        /// <summary>
        /// Connects to the computer name passed in, leave blank for local
        /// </summary>
        /// <param name="computerName">Name of the computer. Leave blank for local</param>
        /// <param name="username">The username to connect as. Leave blank for current user</param>
        /// <param name="password">The password for username if provided.</param>
        /// <returns></returns>
        public static ComputerManager Connect(string computerName = "", string username = "", string password = "")
        {
            return new ComputerManager(computerName, username, password);
        }



        #region local only function
        /// <summary>
        /// Gets the full domain name of the current computer (without the computer name). 
        /// Use <see cref="MachineFullName"/> to get FQN of current computer.
        /// </summary>
        public static string DomainNameFull
        {
            get
            {
                return System.Net.NetworkInformation.IPGlobalProperties.GetIPGlobalProperties().DomainName;
            }
        }

        /// <summary>
        /// Gets the Domain Net Bios of the current user. 
        /// </summary>
        public static string DomainNameBios { get { return Environment.UserDomainName; } }

        /// <summary>
        /// Gets the username of current user
        /// </summary>
        public static string UserName { get { return Environment.UserName; } }

        /// <summary>
        /// Gets the domain and username of current user. Domain\User
        /// </summary>
        public static string UserQualified
        {
            get
            {
                return Environment.UserDomainName + "\\" + Environment.UserName;
            }
        }

        /// <summary>
        /// Splits the username and domain into a Tuple. Domain is Item1, User is Item2.
        /// </summary>
        /// <param name="username">The Domain\Username or User@domain string to parse.</param>
        /// <returns>Domain is Item1, Username is Item2</returns>
        public static Tuple<string, string> SplitUserAndDomain(string username)
        {
            string[] parts;
            if (username.Contains("\\"))
            {
                parts = username.Split('\\');
                return new Tuple<string, string>(parts[0], parts[1]);
            }
            if (username.Contains("@"))
            {
                //todo should convert domain name to NetBIOS name of domain
                parts = username.Split('@');
                return new Tuple<string, string>(parts[1], parts[0]);
            }
            return new Tuple<string, string>(string.Empty, username);
        }


        /// <summary>
        /// Ensures the username as a domain prefix. If no prefix is given machine name is used.
        /// </summary>
        /// <param name="user">The username to check for domain.</param>
        /// <returns>domain\user or machine\user</returns>
        public static string EnsureDomain(string user)
        {
            var domainUser = SplitUserAndDomain(user);
            var domain = domainUser.Item1;
            user = domainUser.Item2;
            if (string.IsNullOrWhiteSpace(domain))
                domain = MachineName;
            return domain + "\\" + user;
        }

        /// <summary>
        /// Gets the Machine name of the current computer (without domain). 
        /// Use <see cref="MachineFullName"/> to get the FQN of the current computer.
        /// </summary>
        public static string MachineName { get { return Environment.MachineName; } }

        /// <summary>
        /// Gets the fully qualified name of the current computer. computer.domain.com
        /// </summary>
        public static string MachineFullName
        {
            get
            {
                return System.Net.Dns.GetHostEntry(Environment.MachineName).HostName;
            }
        }

        /// <summary>
        /// Checks if the name passed in is the current computer. 
        /// Returns true if the string is null/empty or the name matches the current <see cref="MachineName"/> or <see cref="MachineFullName"/>.
        /// </summary>
        /// <param name="serverName">Computer name to check</param>
        /// <returns></returns>
        public static bool IsLocal(string serverName)
        {
            if (string.IsNullOrWhiteSpace(serverName) || serverName == "." || serverName.Equals("localHost", StringComparison.InvariantCultureIgnoreCase)) 
                return true;
            if (serverName.Contains(".")
                && serverName.Equals(MachineFullName, StringComparison.InvariantCultureIgnoreCase))
                return true;
            if (serverName.Equals(MachineName, StringComparison.InvariantCultureIgnoreCase))
                return true;
            return false;
        }
        #endregion


    }
}
