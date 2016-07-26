using System;
using System.Reflection;
using OpenQA.Selenium;
using Useful.WebAutomation.PageObjects.Controls;
using Useful.WebAutomation.Selenium;

namespace Useful.WebAutomation.PageObjects
{
    /// <summary>
    /// Object factory handles the creation of typed elements
    /// </summary>
    public static class ObjectFactory
    {
        /// <summary>
        /// Create a base element and wire its selector, parent, and type
        /// </summary>
        /// <param name="type">The type to create</param>
        /// <param name="driver">The web driver the element is attached to</param>
        /// <param name="by">The selector used to find the element</param>
        /// <param name="parent">The parent of the element</param>
        /// <param name="element">The element itself if it has already been created</param>
        /// <returns></returns>
        private static BaseElement CreateElement(Type type, WebDriver driver, By by, BaseElement parent, IWebElement element)
        {
            var constructor = type.GetConstructor(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.CreateInstance | BindingFlags.Instance, null, Type.EmptyTypes, null);
            if (constructor == null)
                throw new ArgumentException("No constructor for the specified class can be found");
            var objRtn = (BaseElement)constructor.Invoke(null);
            objRtn.Driver = driver;
            objRtn.Selector = by;
            objRtn.ParentElemant = parent;
            objRtn.Element = element;
            return objRtn;
        }
        /// <summary>
        /// Create a Typed element and wire its selector and parent. 
        /// If the type is abstract, attempt to find the type by attribute or tag name
        /// </summary>
        /// <typeparam name="T">The Type of element to create</typeparam>
        /// <param name="driver">The web driver the element is attached to</param>
        /// <param name="by">The selector used to find the element</param>
        /// <param name="parent">The parent of the element</param>
        /// <param name="element">The element itself if is has already been created</param>
        /// <returns></returns>
        public static T CreateElement<T>(WebDriver driver, By by, BaseElement parent = null, IWebElement element = null) where T : BaseElement
        {
            var t = typeof(T);
            if (t.IsAbstract) t = ElementType(element, t);
            return (T)CreateElement(t, driver, by, parent, element);
        }

        /// <summary>
        /// Find the type of an element. Checks type attribute and tag name
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <param name="defaultType">The default type to return if type not found</param>
        /// <returns></returns>
        public static Type ElementType(IWebElement element, Type defaultType = null)
        {
            if (defaultType == null) defaultType = typeof(WebControl);
            if (element == null) return defaultType;

            Type type = defaultType;
            type = CheckTagName(element) ?? type;
            type = CheckTypeAttribute(element) ?? type;
            return type;
        }

        /// <summary>
        /// Check the tag name of an element and derive the type
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <returns></returns>
        private static Type CheckTagName(IWebElement element)
        {
            var elementTag = TryIt(() => element.TagName);
            if (string.IsNullOrWhiteSpace(elementTag)) return null;
            switch (elementTag)
            {
                case "label": return typeof(Label);
                case "textarea": return typeof(TextArea);
                case "input": return typeof(InputField);
                case "button": return typeof(Button);
            }
            return null;
        }
        /// <summary>
        /// Check the HTML Type attribute and derive the object type
        /// </summary>
        /// <param name="element">The element to check</param>
        /// <returns></returns>
        private static Type CheckTypeAttribute(IWebElement element)
        {
            var elementType = TryIt(() => element.GetAttribute("type"));
            if (string.IsNullOrWhiteSpace(elementType)) return null;
            switch (elementType)
            {
                case "textarea": return typeof(TextArea);
                case "password": return typeof(InputField);
                case "checkbox": return typeof(Checkbox);
                case "button": return typeof(Button);
                case "submit": return typeof(Button);
            }
            return null;
        }
        
        /// <summary>
        /// Helper method to wrap exceptions. If/when errors, simply return the default of T
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="action">Action to try</param>
        /// <returns></returns>
        private static T TryIt<T>(Func<T> action)
        {
            try
            {
                return action.Invoke();
            }
            catch (Exception)
            {
                return default(T);
            }
        }
    }

    /// <summary>
    /// Web Driver extensions for navigating and creating page objects 
    /// </summary>
    public static class PageFactory
    {
        /// <summary>
        /// Creates a page object, ensures the driver has loaded the page then validates the DOM. the page object is returned
        /// </summary>
        /// <typeparam name="T">Type of Page object</typeparam>
        /// <param name="driver">the web driver</param>
        /// <param name="url">Optional URL to navigate to. If null, the page object URL property is used.</param>
        /// <param name="useAppRoot">Optional, Only takes effect if page object UseAppRoot property is null. Used when building URL. </param>
        /// <returns></returns>
        public static T GoTo<T>(this WebDriver driver, string url = null, bool useAppRoot = true) where T : BasePage
        {
            var page = ObjectFactory.CreateElement<T>(driver, By.TagName("body"), null, null);
            if (string.IsNullOrWhiteSpace(url)) url = page.Url;
            if (page.UseAppRoot != null) useAppRoot = page.UseAppRoot.Value;
            driver.EnsureUrl(url, useAppRoot);
            page.ValidatePage();
            return page;
        }

        public static BasePage CurrentPage(this WebDriver driver)
        {
            return CurrentPage<BasePage>(driver);
        }
        /// <summary>
        /// Validates the driver is at the current page and returns a page object of the given type
        /// </summary>
        /// <typeparam name="T">Type of Page object</typeparam>
        /// <param name="driver">the web driver</param>
        /// <returns></returns>
        public static T CurrentPage<T>(this WebDriver driver) where T : BasePage
        {
            var page = ObjectFactory.CreateElement<T>(driver, By.TagName("body"));
            page.ValidatePage();
            return page;
        }
        /// <summary>
        /// Clicks a given element and navigates to the Page object
        /// </summary>
        /// <typeparam name="T">Type of Page object</typeparam>
        /// <param name="driver">the web driver</param>
        /// <param name="element">Element to click</param>
        /// <returns></returns>
        public static T Click<T>(this WebDriver driver, IWebElement element) where T : BasePage
        {
            element.Click();
            driver.WaitforPage();
            return driver.GoTo<T>();
        }

    }
}