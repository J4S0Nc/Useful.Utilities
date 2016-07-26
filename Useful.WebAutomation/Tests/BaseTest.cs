using System;
using System.Configuration;
using System.Diagnostics;
using NUnit.Framework;
using Useful.Utilities;
using Useful.WebAutomation.Selenium;

namespace Useful.WebAutomation.Tests
{
    public class BaseTest
    {
        public WebDriver Driver => TestSession.Driver;


        [TestFixtureSetUp]
        public void FixtureSetUp()
        {
            //Trace.WriteLine("Base Fixture setup");
        }


        [TestFixtureTearDown]
        public void FixtureTearDown()
        {
            //Trace.WriteLine("Base Fixture Tear Down");
        }

    }

    [SetUpFixture]
    public class TestSession
    {
        private static WebDriver _driver;
        /// <summary>
        /// Static Web driver property to be used in tests.
        /// </summary>
        public static WebDriver Driver => GetDriver();
        /// <summary>
        /// Root URL for this site. This is read from the appSettings config section key name is "RootUrl" value should be something like: "http://yourSite.com" 
        /// </summary>
        public static string RootUrl
        {
            get
            {
                var url = ConfigurationManager.AppSettings.Item();
                if(string.IsNullOrWhiteSpace(url))
                    throw new ArgumentNullException("RootUrl", "RootUrl appSetting was not found. Please ensure you configuration file is setup correctly. AppSettings add name=\"RootUrl\" value=\"http://yourSite.com\"");
                return url;
            }
        }
        /// <summary>
        /// Application folder name/structure to be appended to RootUrl. default is "/". 
        /// If you are hosting in IIS as a virtual directory place that name in the appSettings config section 
        /// with a key name of "AppPath" and the value of the directory name like "/MyApp"
        /// </summary>
        public static string AppPath => ConfigurationManager.AppSettings.Item("/");
        /// <summary>
        /// The type of driver to load. <see cref="WebDriver.DriverTypes"/>
        /// </summary>
        public static WebDriver.DriverTypes DriverType => ConfigurationManager.AppSettings.Item("Chrome").ToEnum<WebDriver.DriverTypes>();

        /// <summary>
        /// Build and return a web driver. If a driver has already been built it is simply returned.
        /// This is called from the Driver property.
        /// </summary>
        /// <returns></returns>
        internal static WebDriver GetDriver()
        {
            if (_driver != null) return _driver;
            Trace.WriteLine("Setting up driver");
            _driver = new WebDriver(DriverType, RootUrl, AppPath);
            return _driver;
        }

        /// <summary>
        /// Dispose of the current web driver
        /// </summary>
        public static void TearDownDriver()
        {
            Trace.WriteLine("Disposing Driver");
            Driver?.Dispose();
        }



        [SetUp]
        public static void FirstSetup()
        {
            GetDriver();
        }

        [TearDown]
        public static void LastTearDown()
        {
            TearDownDriver();
        }
    }
}
