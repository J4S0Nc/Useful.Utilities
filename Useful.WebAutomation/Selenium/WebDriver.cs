using System;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.PhantomJS;

namespace Useful.WebAutomation.Selenium
{
    /// <summary>
    /// Implements Selenium IWebDriver. 
    /// Handles setting up a new driver and providers methods for dealing with elements and page objects
    /// </summary>
    public class WebDriver : IWebDriver, IJavaScriptExecutor
    {
        /// <summary>
        /// Path to look for web drivers. Will check for AppSettings name "Drivers". Defaults to ".\Drivers\"
        /// </summary>
        public static string DriversPath => ConfigurationManager.AppSettings["Drivers"] ?? ".\\Drivers\\";

        /// <summary>
        /// Supported driver types
        /// </summary>
        public enum DriverTypes
        {
            Chrome,
            Firefox,
            Phantom,
            InternetExplorer
        }

        private IWebDriver _driver { get; set; }

        public WebDriver(DriverTypes driverType, string rootUrl, string appPath = "/")
        {
            DriverType = driverType;
            RootUrl = rootUrl;
            AppPath = appPath;
            SetupDriver();
        }
        /// <summary>
        /// The type of driver 
        /// </summary>
        public DriverTypes DriverType { get; }
        /// <summary>
        /// Root URL or server. Example "http://yourDomain.com"
        /// </summary>
        public string RootUrl { get; }
        /// <summary>
        /// Application root folder name. Example "/" or "/MyApp"
        /// </summary>
        public string AppPath { get; }

        /// <summary>
        /// Creates a driver if it has not been created yet. 
        /// </summary>
        public void SetupDriver()
        {
            if (_driver == null)
            {
                switch (DriverType)
                {
                    case DriverTypes.Phantom:
                        _driver = new PhantomJSDriver(DriversPath);
                        break;
                    case DriverTypes.Firefox:
                        _driver = new FirefoxDriver();
                        break;
                    case DriverTypes.InternetExplorer:
                        var options = new InternetExplorerOptions();
                        options.IgnoreZoomLevel = true;
                        _driver = new InternetExplorerDriver(DriversPath, options);

                        break;
                    case DriverTypes.Chrome:
                    default:
                        if (!File.Exists("chromedriver.exe"))
                        {
                            _driver = new ChromeDriver(DriversPath);
                        }
                        else
                            _driver = new ChromeDriver();
                        break;
                }
            }

        }

        /// <summary>
        /// Close, Quit and dispose of the current driver
        /// </summary>
        public void CleanUpDriver()
        {
            try
            {
                if (_driver == null) return;
                _driver.Close();
                _driver.Quit();
                _driver.Dispose();
            }
            catch (Exception e)
            {
                Trace.WriteLine(e);
            }
        }

        /// <summary>
        /// Clean up the current driver
        /// </summary>
        public void Dispose()
        {
            CleanUpDriver();
        }

        #region Navigation and pages

        /// <summary>
        /// Navigates to a page and waits for page to load
        /// </summary>
        /// <param name="page"></param>
        /// <param name="useAppRoot"></param>
        public void GoTo(string page = "", bool useAppRoot = true)
        {
            page = BuildUrl(page, useAppRoot);
            _driver.Navigate().GoToUrl(page);
            WaitforPage();
        }
        /// <summary>
        /// Check if the current drivers URL matches the URL passed in. 
        /// If the URL is different the driver will navigate to the given URL. 
        /// </summary>
        /// <param name="url">URL to ensure</param>
        /// <param name="useAppRoot"></param>
        public void EnsureUrl(string url, bool useAppRoot = true)
        {
            url = BuildUrl(url, useAppRoot);
            if (UrlChanged(url))
                GoTo(url);
        }
        /// <summary>
        /// Check if the given URL is different then the drivers current URL
        /// </summary>
        /// <param name="url">URL to check</param>
        /// <param name="useAppRoot"></param>
        /// <returns></returns>
        public bool UrlChanged(string url, bool useAppRoot = true)
        {
            return !_driver.Url.Equals(BuildUrl(url, useAppRoot), StringComparison.CurrentCultureIgnoreCase);
        }
        /// <summary>
        /// Helper method for building URLS. Handles checking for rooted URLs and prepending app root folder when needed
        /// </summary>
        /// <param name="page"></param>
        /// <param name="useAppRoot"></param>
        /// <returns></returns>
        private string BuildUrl(string page, bool useAppRoot)
        {
            if (page.StartsWith("http://", StringComparison.CurrentCultureIgnoreCase) ||
                page.StartsWith("https://", StringComparison.CurrentCultureIgnoreCase))
                return page;
            if (!page.StartsWith("/")) page = "/" + page;
            if (useAppRoot && !page.StartsWith(AppPath)) page = AppPath + page;
            return RootUrl + page;
        }

        /// <summary>
        /// Wait until a page is fully loaded and ensures no errors happened. 
        /// This function makes some assumptions that the site used JQuery. 
        /// JQuery animations will be turned off, it will attempt to wait for all JQuery AJAX calls to finish 
        /// and try to add a random element to the DOM and verify it appeared (using JQuery). 
        /// </summary>
        public virtual void WaitforPage()
        {
            //ensure JQuery animations are off (helps with timing issues)
            try
            {
                Execute("jQuery.fx.off = true;");
            }
            catch (Exception) { }

            EnsureNoErrors();

            try
            {
                _driver.WaitWhileVisible(By.ClassName("ui-widget-overlay"));
            }
            catch (NoSuchElementException) { }
            catch (Exception e)
            {
                Trace.WriteLine("Tried to wait for loading: " + e.Message);
            }

            try
            {

                _driver.Wait().Until((d) => (bool)((IJavaScriptExecutor)_driver).ExecuteScript("return jQuery.active == 0"));
                //add an element to the DOM after all other JS has ran (ensures bindings are loaded)
                string div = "Automation-" + new Random().Next(9999999).ToString(CultureInfo.InvariantCulture);
                //Execute("setTimeout(function() {$(function() {$('body').append('<div id=" + div + "></div>'); });},100)");
                //var exists = (bool)(((IJavaScriptExecutor)_driver).ExecuteScript("$('#" + div + "').length > 0") ?? false);
                _driver.Wait(10).Until((d) =>
                    {

                        ((IJavaScriptExecutor)d).ExecuteScript("setTimeout(function() {$(function() {$('body').append('<div id=" + div + "></div>'); });},100)");
                        var exists = (bool)(((IJavaScriptExecutor)d).ExecuteScript("$('#" + div + "').length > 0") ?? false);

                        return exists || d.TryFind(By.Id(div), false, false) != null;
                    });
            }
            catch (Exception e)
            {
                Trace.WriteLine("Tried to wait for ajax: " + e.Message);

            }

            EnsureNoErrors();
        }

        /// <summary>
        /// Take a screen shot and save as a PNG file. 
        /// </summary>
        /// <param name="name">Name of file to save</param>
        /// <param name="rootPath">Folder path to save to. If directory does not exists it will be created.</param>
        /// <param name="appendTicks">Add DateTime.Now.Ticks to file name</param>
        public void TakeScreenShot(string name, string rootPath = ".\\screen shots\\", bool appendTicks = true)
        {
            if (!Directory.Exists(rootPath)) Directory.CreateDirectory(rootPath);
            if (appendTicks) name += "-" + DateTime.Now.Ticks.ToString(CultureInfo.InvariantCulture);
            name = Path.Combine(rootPath, name + ".png");
            Trace.WriteLine("Saving Screen shot " + name);
            var ss = ((ITakesScreenshot)_driver).GetScreenshot();
            ss.SaveAsFile(name, ImageFormat.Png);
        }
        /// <summary>
        /// Execute a block of java script 
        /// </summary>
        /// <param name="script"></param>
        public object Execute(string script)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteScript(script);
        }

        /// <summary>
        /// Check page for errors or YSOD
        /// </summary>
        public virtual void EnsureNoErrors()
        {
            if (_driver.IsVisible("Server Error", By.TagName("h1"))) //ysod or iis error
            {
                var body = _driver.Find(By.TagName("body"));
                throw new InvalidElementStateException("Server Error! \n\n " + body.Text);
            }

        }
        #endregion

        #region click
        /// <summary>
        /// finds a button by text and clicks on it
        /// </summary>
        /// <param name="buttonText"></param>
        public void ClickButton(string buttonText)
        {
            //     Trace.WriteLine("ClickButton: " + buttonText);
            IWebElement btn = this.FindText(buttonText, By.TagName("button"));
            this.ScrollTo(btn);
            Click(btn);
        }
        /// <summary>
        /// Find a link by its text, scroll to it, then click it.
        /// </summary>
        /// <param name="linkText"></param>
        public void ClickLink(string linkText)
        {
            //    Trace.WriteLine("ClickLink: " + linkText);
            var lnk = this.FindWithWait(By.LinkText(linkText));
            this.ScrollTo(lnk);
            Click(lnk);
        }

        /// <summary>
        /// Find an element by its text and click it
        /// </summary>
        /// <param name="text">The text to find and click</param>
        /// <param name="by">The selector used to find the element</param>
        public void Click(string text, By by)
        {
            //      Trace.WriteLine("Click: " + text + " by: " + by);
            Click(this.FindText(text, by));
        }
        /// <summary>
        /// Click a Web Element. If the element is null, disabled or not visible an exception will be thrown
        /// </summary>
        /// <param name="e">The element to click</param>
        public void Click(IWebElement e)
        {
            e.ValidateState();
            e.Click();
            this.WaitforPage();
        }
        #endregion

        #region Interface methods
        /// <summary>
        /// Finds the first <see cref="T:OpenQA.Selenium.IWebElement"/> using the given method. 
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>
        /// The first matching <see cref="T:OpenQA.Selenium.IWebElement"/> on the current context.
        /// </returns>
        /// <exception cref="T:OpenQA.Selenium.NoSuchElementException">If no element matches the criteria.</exception>
        public IWebElement FindElement(By @by)
        {
            return _driver.FindElement(@by);
        }
        /// <summary>
        /// Finds all <see cref="T:OpenQA.Selenium.IWebElement">IWebElements</see> within the current context using the given mechanism. 
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>
        /// A <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1"/> of all <see cref="T:OpenQA.Selenium.IWebElement">WebElements</see> 
        /// matching the current criteria, or an empty list if nothing matches.
        /// </returns>
        public ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return _driver.FindElements(@by);
        }
        /// <summary>
        /// Close the current window, quitting the browser if it is the last window currently open. 
        /// </summary>
        public void Close()
        {
            _driver.Close();
        }
        /// <summary>
        /// Quits this driver, closing every associated window. 
        /// </summary>
        public void Quit()
        {
            _driver.Quit();
        }
        /// <summary>
        /// Instructs the driver to change its settings. 
        /// </summary> 
        /// <returns>
        /// An <see cref="T:OpenQA.Selenium.IOptions"/> object allowing the user to change
        ///             the settings of the driver.
        /// </returns>
        public IOptions Manage()
        {
            return _driver.Manage();
        }
        /// <summary>
        /// Instructs the driver to navigate the browser to another location. 
        /// </summary> 
        /// <returns>
        /// An <see cref="T:OpenQA.Selenium.INavigation"/> object allowing the user to access
        ///             the browser's history and to navigate to a given URL.
        /// </returns>
        public INavigation Navigate()
        {
            return _driver.Navigate();
        }
        /// <summary>
        /// Instructs the driver to send future commands to a different frame or window. 
        /// </summary> 
        /// <returns>
        /// An <see cref="T:OpenQA.Selenium.ITargetLocator"/> object which can be used to select a frame or window.
        /// </returns>
        public ITargetLocator SwitchTo()
        {
            return _driver.SwitchTo();
        }
        /// <summary>
        /// Get or set the current URL of the browser
        /// </summary> 
        /// <remarks>
        /// Setting the <see cref="P:OpenQA.Selenium.IWebDriver.Url"/> property will load a new web page in the current browser window.
        ///             This is done using an HTTP GET operation, and the method will block until the
        ///             load is complete. This will follow redirects issued either by the server or
        ///             as a meta-redirect from within the returned HTML. Should a meta-redirect "rest"
        ///             for any duration of time, it is best to wait until this timeout is over, since
        ///             should the underlying page change while your test is executing the results of
        ///             future calls against this interface will be against the freshly loaded page.
        /// 
        /// </remarks>
        /// <seealso cref="M:OpenQA.Selenium.INavigation.GoToUrl(System.String)"/><seealso cref="M:OpenQA.Selenium.INavigation.GoToUrl(System.Uri)"/>
        public string Url { get { return _driver.Url; } set { _driver.Url = value; } }
        /// <summary>
        /// Get the title of the current browser window. 
        /// </summary>
        public string Title { get { return _driver.Title; } }
        /// <summary>
        /// Gets the source of the page last loaded by the browser. 
        /// </summary> 
        /// <remarks>
        /// If the page has been modified after loading (for example, by JavaScript)
        ///             there is no guarantee that the returned text is that of the modified page.
        ///             Please consult the documentation of the particular driver being used to
        ///             determine whether the returned text reflects the current state of the page
        ///             or the text last sent by the web server. The page source returned is a
        ///             representation of the underlying DOM: do not expect it to be formatted
        ///             or escaped in the same way as the response sent from the web server.
        /// 
        /// </remarks>
        public string PageSource { get { return _driver.PageSource; } }
        /// <summary>
        /// Gets the current window handle, which is an opaque handle to this window that uniquely identifies it within this driver instance. 
        /// </summary>
        public string CurrentWindowHandle { get { return _driver.CurrentWindowHandle; } }
        /// <summary>
        /// Gets the window handles of open browser windows. 
        /// </summary>
        public ReadOnlyCollection<string> WindowHandles { get { return _driver.WindowHandles; } }
        #endregion
        /// <summary>
        /// Executes JavaScript in the context of the currently selected frame or window. 
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>
        /// The value returned by the script.
        /// </returns> 
        /// <remarks> 
        /// <para>
        /// The <see cref="M:OpenQA.Selenium.IJavaScriptExecutor.ExecuteScript(System.String,System.Object[])"/>method executes JavaScript in the context of
        ///             the currently selected frame or window. This means that "document" will refer
        ///             to the current document. If the script has a return value, then the following
        ///             steps will be taken: 
        /// </para> 
        /// <para>
        /// <list type="bullet"> 
        /// <item> <description>For an HTML element, this method returns a <see cref="T:OpenQA.Selenium.IWebElement"/></description> </item> 
        /// <item> <description>For a number, a <see cref="T:System.Int64"/> is returned</description> </item>
        ///  <item> <description>For a boolean, a <see cref="T:System.Boolean"/> is returned</description> </item>
        ///  <item> <description>For all other cases a <see cref="T:System.String"/> is returned.</description> </item>
        ///  <item> <description>For an array,we check the first element, and attempt to return a             <see cref="T:System.Collections.Generic.List`1"/> of that type, following the rules above. Nested lists are not             supported.</description> </item>
        ///  <item> <description>If the value is null or there is no return value,             <see langword="null"/> is returned.</description> </item>
        ///  </list> 
        /// </para> 
        /// <para>
        /// Arguments must be a number (which will be converted to a <see cref="T:System.Int64"/>),
        ///             a <see cref="T:System.Boolean"/>, a <see cref="T:System.String"/> or a <see cref="T:OpenQA.Selenium.IWebElement"/>.
        ///             An exception will be thrown if the arguments do not meet these criteria.
        ///             The arguments will be made available to the JavaScript via the "arguments" magic///             variable, as if the function were called via "Function.apply" 
        /// </para> 
        /// </remarks>
        public object ExecuteScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteScript(script, args);
        }
        /// <summary>
        /// Executes JavaScript asynchronously in the context of the currently selected frame or window. 
        /// </summary>
        /// <param name="script">The JavaScript code to execute.</param>
        /// <param name="args">The arguments to the script.</param>
        /// <returns>
        /// The value returned by the script.
        /// </returns>
        public object ExecuteAsyncScript(string script, params object[] args)
        {
            return ((IJavaScriptExecutor)_driver).ExecuteAsyncScript(script, args);
        }
    }
}
