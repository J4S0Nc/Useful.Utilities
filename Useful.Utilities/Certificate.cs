using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace Useful.Utilities
{

    /// <summary>
    /// Deals with windows x509 certificates
    /// </summary>
    public static class Certificate
    {
        //todo handle self signed certs http://blogs.msdn.com/b/dcook/archive/2008/11/25/creating-a-self-signed-certificate-in-c.aspx


        /// <summary>
        /// Selects the specified store using built-in windows UI
        /// </summary>
        /// <param name="store">The store to look in</param>
        /// <param name="location">The location to look in</param>
        /// <param name="remoteComputer">remote computer to run on</param>
        /// <param name="windowTitle">The window title.</param>
        /// <param name="windowMsg">The window message.</param>
        /// <returns></returns>
        public static X509Certificate2 Select(StoreName store = StoreName.My, StoreLocation location = StoreLocation.LocalMachine, string remoteComputer = "", string windowTitle = "Select Certificate", string windowMsg = "Select certificate to use")
        {
            X509Store x509Store = GetStore(store, location, remoteComputer);
            x509Store.Open(OpenFlags.ReadOnly);
            X509Certificate2Collection certs = X509Certificate2UI.SelectFromCollection(x509Store.Certificates, windowTitle, windowMsg, X509SelectionFlag.SingleSelection);
            x509Store.Close();
            return certs.Count > 0 ? certs[0] : null;
        }

        /// <summary>
        /// Gets a certificate by thumb print.
        /// </summary>
        /// <param name="thumbprint">the cert thumb print to find</param>
        /// <param name="store">The store to look in</param>
        /// <param name="location">The location to look in</param>
        /// <param name="remoteComputer">remote computer to run on</param>
        /// <returns></returns>
        public static X509Certificate2 GetByThumbprint(string thumbprint, StoreName store = StoreName.My, StoreLocation location = StoreLocation.LocalMachine, string remoteComputer = "")
        {
            thumbprint = thumbprint.Replace(" ", "");
            X509Store x509Store = GetStore(store, location, remoteComputer);
            x509Store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
            var certs = x509Store.Certificates.Find(X509FindType.FindByThumbprint, thumbprint, true);
            x509Store.Close();
            return certs.Count > 0 ? certs[0] : null;
        }

        /// <summary>
        /// Gets a list of Cert names and thumb prints in a tuple
        /// </summary>
        /// <param name="store">The store to look in</param>
        /// <param name="location">The location to look in</param>
        /// <param name="remoteComputer">remote computer to run on</param>
        /// <returns></returns>
        public static List<Tuple<string, string>> GetCerts(StoreName store = StoreName.My, StoreLocation location = StoreLocation.LocalMachine, string remoteComputer = "")
        {
            X509Store x509Store = GetStore(store, location, remoteComputer);
            x509Store.Open(OpenFlags.ReadOnly);
            var rtn = (from X509Certificate2 c in x509Store.Certificates select new Tuple<string, string>(string.IsNullOrWhiteSpace(c.FriendlyName) ? c.SubjectName.Name : c.FriendlyName, c.Thumbprint)).ToList();
            x509Store.Close();
            return rtn;
        }
        /// <summary>
        /// Install a PFX file to the cert store
        /// </summary>
        /// <param name="fileName">Name of the PFX file.</param>
        /// <param name="password">The password.</param>
        /// <param name="store">The store to look in</param>
        /// <param name="location">The location to look in</param>
        /// <param name="remoteComputer">remote computer to run on</param>
        /// <returns></returns>
        public static X509Certificate2 Setup(string fileName, string password, StoreName store = StoreName.My, StoreLocation location = StoreLocation.LocalMachine, string remoteComputer = "")
        {
            if (!FileUtility.FileExists(fileName, remoteComputer))
                throw new System.IO.FileNotFoundException("Could not find PFX file to setup", fileName);
            X509Certificate2 certificate = new X509Certificate2(fileName, password, X509KeyStorageFlags.PersistKeySet);
            X509Store x509Store = GetStore(store, location, remoteComputer);
            x509Store.Open(OpenFlags.ReadWrite);

            if (certificate.Thumbprint == null) throw new NullReferenceException("Thumb print is null");

            var existing = x509Store.Certificates.Find(X509FindType.FindByThumbprint, certificate.Thumbprint, true);
            if (existing.Count == 0)
                x509Store.Add(certificate);

            x509Store.Close();
            return certificate;
        }

        /// <summary>
        /// Helper function to connect to a cert store. Can be local or remote
        /// </summary>
        /// <param name="store">The store to look in</param>
        /// <param name="location">The location to look in</param>
        /// <param name="remoteComputer">remote computer to run on</param>
        /// <returns></returns>
        private static X509Store GetStore(StoreName store = StoreName.My, StoreLocation location = StoreLocation.LocalMachine, string remoteComputer = "")
        {
            var storeName = store.ToString();
            if (!ComputerManager.IsLocal(remoteComputer))
                storeName = @"\\" + remoteComputer + @"\" + store.ToString();
            return new X509Store(storeName, location);
        }
        //protected static void FetchCertificateDetails()
        //{
        //    try
        //    {
        //        //Create certificate store object and open the same
        //        X509Store store = new X509Store(StoreLocation.LocalMachine);
        //        store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);

        //        //Open certificate collection
        //        X509Certificate2Collection collection = store.Certificates;
        //        X509Certificate2Collection findCollection = collection.Find(X509FindType.FindByTimeValid, DateTime.Now, false);

        //        //Create a collection of certificates in a windows form object

        //        X509Certificate2Collection selectCollection = findCollection;
        //        //X509Certificate2Collection selectCollection = X509Certificate2UI.SelectFromCollection(findCollection
        //        //                                                    , "Test Certificate Select"
        //        //                                                    , "Select a particular certificate from the following list to get information on that certificate"
        //        //                                                    , X509SelectionFlag.MultiSelection);

        //        Console.WriteLine("Number of certificates: {0}{1}", selectCollection.Count, Environment.NewLine);

        //        //Iterate through all certificates in the collection
        //        foreach (X509Certificate2 x509 in selectCollection)
        //        {
        //            //Fetch the raw Data from certificate object
        //            byte[] rawData = x509.RawData;
        //            Console.WriteLine("Content Type: {0}", X509Certificate2.GetCertContentType(rawData));
        //            Console.WriteLine("Serial Number: {0}", x509.SerialNumber);
        //            Console.WriteLine("Friendly Name: {0}", x509.FriendlyName);
        //            Console.WriteLine("Simple Name: {0}", x509.GetNameInfo(X509NameType.SimpleName, true));
        //            Console.WriteLine("URL Name: {0}", x509.GetNameInfo(X509NameType.UrlName, true));
        //            Console.WriteLine("Hash: {0}", x509.GetCertHashString());
        //            Console.WriteLine("Thumb print: {0}", x509.Thumbprint);


        //            Console.WriteLine("");
        //            //Console.WriteLine("Certificate Verified?: {0}{1}", x509.Verify(), Environment.NewLine);
        //            //Console.WriteLine("Signature Algorithm Name: {0}{1}", x509.SignatureAlgorithm.FriendlyName, Environment.NewLine);
        //            //Console.WriteLine("Private Key: {0}{1}", x509.PrivateKey.ToXmlString(false), Environment.NewLine);
        //            //Console.WriteLine("Public Key: {0}{1}", x509.PublicKey.Key.ToXmlString(false), Environment.NewLine);
        //            //Console.WriteLine("Certificate Archived?: {0}{1}", x509.Archived, Environment.NewLine);
        //            //Console.WriteLine("Length of Raw Data: {0}{1}", x509.RawData.Length, Environment.NewLine);


        //            //Display the snapshot of certificate
        //            //  X509Certificate2UI.DisplayCertificate(x509);

        //            x509.Reset();
        //        }

        //        store.Close();
        //    }
        //    catch (CryptographicException)
        //    {
        //        Console.WriteLine("Information could not be written out for this certificate.");
        //    }
        //}
    }
}
