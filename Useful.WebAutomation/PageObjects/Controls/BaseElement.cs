using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Useful.WebAutomation.Selenium;

namespace Useful.WebAutomation.PageObjects.Controls
{
    /// <summary>
    /// Base Web Element class provides methods for dealing with controls, parent and child elements. 
    /// Implements OpenQA.Selenium.IWebElement interface
    /// </summary>
    public abstract class BaseElement : IWebElement
    {
        private IWebElement _elementCache;

        /// <summary>
        /// Can this element be null? Default is false
        /// </summary>
        public virtual bool Nullable
        {
            get { return false; }
        }
        /// <summary>
        /// Access base element
        /// </summary>
        public IWebElement Element
        {
            get { return GetElement(); }
            internal set { _elementCache = value; }
        }
        /// <summary>
        /// Access current Web Driver
        /// </summary>
        protected internal WebDriver Driver { get; internal set; }
        /// <summary>
        /// Access parent element as a search context. Driver is returned when ParentElement is null. 
        /// </summary>
        public ISearchContext Parent
        {
            get { return (ISearchContext)ParentElemant ?? Driver; }
        }
        /// <summary>
        /// Access parent element (up the tree)
        /// </summary>
        internal BaseElement ParentElemant { private get; set; }

        /// <summary>
        /// Selector used to find the current element from it's parent
        /// </summary>
        public By Selector { get; internal set; }

        /// <summary>
        /// Get the current element from cache or search parent by selector
        /// </summary>
        /// <returns></returns>
        public virtual IWebElement GetElement()
        {
            if (_elementCache != null) return _elementCache;
            return _elementCache = Parent.Find(Selector);
        }

        /// <summary>
        /// Get a typed control based on a selector. 
        /// </summary>
        /// <typeparam name="T">The type of control to create and return</typeparam>
        /// <param name="by">The selector used to find the control</param>
        /// <param name="parent">The parent control to start the search from. Current element is used when this is null</param>
        /// <param name="propertyName">Optional name defaulted from the calling member. Used as part of the cache key</param>
        /// <returns></returns>
        public T Control<T>(By by, BaseElement parent = null, [CallerMemberName] string propertyName = null)
            where T : BaseElement
        {
            if (parent == null) parent = this;
            return ControlCache(() => ObjectFactory.CreateElement<T>(Driver, by, parent), propertyName);
        }

        /// <summary>
        /// Get a typed control based on a selector. 
        /// </summary>
        /// <typeparam name="T">The type of control to create and return</typeparam>
        /// <param name="by">The selector used to find the control</param>
        /// <param name="parent">The web driver that will be searched. </param>
        /// <param name="propertyName">Optional name defaulted from the calling member. Used as part of the cache key</param>
        /// <returns></returns>
        public T Control<T>(By by, WebDriver parent, [CallerMemberName] string propertyName = null)
            where T : BaseElement
        {
            return ControlCache(() => ObjectFactory.CreateElement<T>(parent, by), propertyName);
        }
        /// <summary>
        /// Get a list of typed controls based on a selector. 
        /// </summary>
        /// <typeparam name="T">The type of control list to create and return</typeparam>
        /// <param name="by">The selector used to find the controls</param>
        /// <param name="parent">The parent control to start the search from. Current element is used when this is null</param>
        /// <param name="propertyName">Optional name defaulted from the calling member. Used as part of the cache key</param>
        /// <returns></returns>
        public ElementCollection<T> Controls<T>(By by, BaseElement parent = null,
            [CallerMemberName] string propertyName = null) where T : BaseElement
        {
            if (parent == null) parent = this;
            return ControlCache(() => ObjectFactory.CreateElement<ElementCollection<T>>(Driver, by, parent),
                propertyName);
        }
        /// <summary>
        /// Get a list of typed controls based on a function delegate. 
        /// </summary>
        /// <typeparam name="T">The type of control list to create and return</typeparam>
        /// <param name="fun">The function used to create and return the controls</param>
        /// <param name="propertyName">Optional name defaulted from the calling member. Used as part of the cache key</param>
        /// <returns></returns>
        public ElementCollection<T> Controls<T>(Func<ElementCollection<T>> fun,
            [CallerMemberName] string propertyName = null) where T : BaseElement
        {
            return ControlCache(fun, propertyName);
        }

        #region Control Cache

        private readonly Dictionary<string, BaseElement> _cache = new Dictionary<string, BaseElement>();

        /// <summary>
        /// Checks if the current property name has already been created and return it if it has. 
        /// If not in the cache, create it by calling the function delegate and then cache it for next time. 
        /// </summary>
        /// <typeparam name="T">The type of control to create and return</typeparam>
        /// <param name="fun">The function used to create and return the controls</param>
        /// <param name="propertyName">Name used as part of the cache key</param>
        /// <returns></returns>
        protected T ControlCache<T>(Func<T> fun, string propertyName) where T : BaseElement
        {
            var cached = ControlCache<T>(propertyName);
            if (cached == null)
            {
                var key = GetType().FullName + "." + propertyName;
                cached = fun.Invoke();
                if (!_cache.ContainsKey(key))
                    _cache.Add(key, cached);
            }
            return cached;
        }

        /// <summary>
        /// Checks if the current property name has already been created and return it if it has, else returns null 
        /// </summary>
        /// <typeparam name="T">The type of control to create and return</typeparam>
        /// <param name="propertyName">Name used as part of the cache key</param>
        /// <returns></returns>
        protected T ControlCache<T>(string propertyName) where T : BaseElement
        {
            var key = GetType().FullName + "." + propertyName;
            T cached = null;
            if (_cache.ContainsKey(key))
                cached = _cache[key] as T;

            return cached;
        }
        /// <summary>
        /// Clear all items from the control cache
        /// </summary>
        protected void ClearCache()
        {
            _cache.Clear();
        }

        /// <summary>
        /// remove an item from the cache by the property name
        /// </summary>
        /// <param name="propertyName">Name used as part of the cache key</param>
        /// <returns></returns>
        protected bool RemoveFromCache(string propertyName)
        {
            var key = GetType().FullName + "." + propertyName;
            return _cache.Remove(key);
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
        public virtual IWebElement FindElement(By @by)
        {
            return Element.FindElement(@by);
        }
        /// <summary>
        /// Finds all <see cref="T:OpenQA.Selenium.IWebElement">IWebElements</see> within the current context using the given mechanism. 
        /// </summary>
        /// <param name="by">The locating mechanism to use.</param>
        /// <returns>
        /// A <see cref="T:System.Collections.ObjectModel.ReadOnlyCollection`1"/> of all <see cref="T:OpenQA.Selenium.IWebElement">WebElements</see> matching the current criteria, or an empty list if nothing matches.
        /// </returns>
        public virtual ReadOnlyCollection<IWebElement> FindElements(By @by)
        {
            return Element.FindElements(@by);
        }

        /// <summary>
        /// Ensures the element is in a valid state then clears the content of this element. 
        /// </summary> 
        /// <remarks>
        /// If this element is a text entry element, the <see cref="M:OpenQA.Selenium.IWebElement.Clear"/> 
        /// method will clear the value. It has no effect on other elements. Text entry elements 
        /// are defined as elements with INPUT or TEXTAREA tags. 
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void Clear()
        {
            Element.ValidateState();
            Element.Clear();
        }
        /// <summary>
        /// Simulates typing text into the element. 
        /// </summary>
        /// <param name="text">The text to type into the element.</param>
        /// <remarks>
        /// The text to be typed may include special characters like arrow keys, 
        /// backspaces, function keys, and so on. Valid special keys are defined in <see cref="T:OpenQA.Selenium.Keys"/>.
        /// </remarks>
        /// <seealso cref="T:OpenQA.Selenium.Keys"/>
        /// <exception cref="T:OpenQA.Selenium.InvalidElementStateException">Thrown when the target element is not enabled.</exception>
        /// <exception cref="T:OpenQA.Selenium.ElementNotVisibleException">Thrown when the target element is not visible.</exception>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void SendKeys(string text)
        {
            Element.ValidateState();
            Element.SendKeys(text);
        }

        /// <summary>
        /// Submits this element to the web server. 
        /// </summary> 
        /// <remarks>
        /// If this current element is a form, or an element within a form,
        ///             then this will be submitted to the web server. If this causes the current
        ///             page to change, then this method will block until the new page is loaded.
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void Submit()
        {
            Element.ValidateState();
            Element.Submit();
        }

        /// <summary>
        /// Ensures the element is in a valid state then clicks this element. Once clicked the drive will be told to wait for the page to load. 
        /// </summary> 
        /// <remarks> 
        /// <para>
        /// Click this element. If the click causes a new page to load, the <see cref="M:OpenQA.Selenium.IWebElement.Click"/>
        ///             method will attempt to block until the page has loaded. After calling the
        ///             <see cref="M:OpenQA.Selenium.IWebElement.Click"/> method, you should discard all references to this
        ///             element unless you know that the element and the page will still be present.
        ///             Otherwise, any further operations performed on this element will have an undefined.
        ///             behavior.
        /// 
        /// </para> 
        /// <para>
        /// If this element is not clickable, then this operation is ignored. This allows you to
        ///             simulate a users to accidentally missing the target when clicking.
        /// 
        /// </para> 
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.ElementNotVisibleException">Thrown when the target element is not visible.</exception>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void Click()
        {
            Element.ValidateState();
            Element.Click();
            Driver.WaitforPage();
        }


        /// <summary>
        /// Ensures the element is in a valid state then clicks this element. 
        /// </summary> 
        /// <remarks> 
        /// <para>
        /// Click this element. If the click causes a new page to load, the <see cref="M:OpenQA.Selenium.IWebElement.Click"/>
        ///             method will attempt to block until the page has loaded. After calling the
        ///             <see cref="M:OpenQA.Selenium.IWebElement.Click"/> method, you should discard all references to this
        ///             element unless you know that the element and the page will still be present.
        ///             Otherwise, any further operations performed on this element will have an undefined.
        ///             behavior.
        /// 
        /// </para> 
        /// <para>
        /// If this element is not clickable, then this operation is ignored. This allows you to
        ///             simulate a users to accidentally missing the target when clicking.
        /// 
        /// </para> 
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.ElementNotVisibleException">Thrown when the target element is not visible.</exception>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual void ClickNoWait()
        {
            Element.ValidateState();
            Element.Click();
        }

        /// <summary>
        /// Click the element and wait the given number of seconds. Returns the wait object
        /// </summary>
        /// <param name="waitSeconds">Number of seconds to wait before timing out</param>
        /// <returns></returns>
        public virtual WebDriverWait ClickAndWait(int waitSeconds)
        {
            Element.ValidateState();
            Element.Click();
            return Driver.Wait(waitSeconds);
        }
        /// <summary>
        /// Gets the value of the specified attribute for this element. 
        /// </summary>
        /// <param name="attributeName">The name of the attribute.</param>
        /// <returns> The attribute's current value. Returns a <see langword="null"/> if the value is not set. </returns> 
        /// <remarks>
        /// The <see cref="M:OpenQA.Selenium.IWebElement.GetAttribute(System.String)"/> method will return the current value
        ///             of the attribute, even if the value has been modified after the page has been
        ///             loaded. Note that the value of the following attributes will be returned even if
        ///             there is no explicit attribute on the element:
        /// 
        /// <list type="table"> 
        /// <listheader>
        /// <term>Attribute name</term><term>Value returned if not explicitly specified</term><term>Valid element types</term>
        /// </listheader> 
        /// <item> <description>checked</description><description>checked</description><description>Check Box</description> </item> 
        /// <item> <description>selected</description><description>selected</description><description>Options in Select elements</description> </item> 
        /// <item> <description>disabled</description><description>disabled</description><description>Input and other UI elements</description> </item> 
        /// </list> 
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual string GetAttribute(string attributeName)
        {
            return Element.GetAttribute(attributeName);
        }

        /// <summary>
        /// Gets the value of a CSS property of this element. 
        /// </summary>
        /// <param name="propertyName">The name of the CSS property to get the value of.</param>
        /// <returns>
        /// The value of the specified CSS property.
        /// </returns> 
        /// <remarks> The value returned by the <see cref="M:OpenQA.Selenium.IWebElement.GetCssValue(System.String)"/>
        ///             method is likely to be unpredictable in a cross-browser environment.
        ///             Color values should be returned as hex strings. For example, a
        ///             "background-color" property set as "green" in the HTML source, will
        ///             return "#008000" for its value.
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual string GetCssValue(string propertyName)
        {
            return Element.GetCssValue(propertyName);
        }
        /// <summary>
        /// Gets the tag name of this element. 
        /// </summary> 
        /// <remarks> The <see cref="P:OpenQA.Selenium.IWebElement.TagName"/> property returns the tag name of the
        ///             element, not the value of the name attribute. For example, it will return
        ///             "input" for an element specified by the HTML markup &lt;input name="foo" /&gt;. 
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual string TagName
        {
            get { return Element.TagName; }
        }
        /// <summary>
        /// Gets the innerText of this element, without any leading or trailing whitespace, and with other whitespace collapsed. 
        /// </summary>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual string Text
        {
            get { return Element.Text; }
        }

        /// <summary>
        /// Gets a value indicating whether or not this element is enabled. 
        /// </summary> 
        /// <remarks> The <see cref="P:OpenQA.Selenium.IWebElement.Enabled"/> property will generally
        ///             return <see langword="true"/> for everything except explicitly disabled input elements.
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual bool Enabled
        {
            get { return Element.Enabled; }
        }
        /// <summary>
        /// Gets a value indicating whether or not this element is selected. 
        /// </summary> 
        /// <remarks> This operation only applies to input elements such as check boxes, options in a select element and radio buttons.
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual bool Selected
        {
            get { return Element.Selected; }
        }
        /// <summary>
        /// Gets a <see cref="T:System.Drawing.Point"/> object containing the coordinates of the upper-left corner 
        /// of this element relative to the upper-left corner of the page. 
        /// </summary>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual Point Location
        {
            get { return Element.Location; }
        }
        /// <summary>
        /// Gets a <see cref="P:System.Drawing.Size"/> object containing the height and width of this element. 
        /// </summary>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual Size Size
        {
            get { return Element.Size; }
        }
        /// <summary>
        /// Gets a value indicating whether or not this element is displayed. 
        /// </summary> 
        /// <remarks> The <see cref="P:OpenQA.Selenium.IWebElement.Displayed"/> property avoids the problem
        ///             of having to parse an element's "style" attribute to determine
        ///             visibility of an element.
        /// </remarks>
        /// <exception cref="T:OpenQA.Selenium.StaleElementReferenceException">Thrown when the target element is no longer valid in the document DOM.</exception>
        public virtual bool Displayed
        {
            get { return Element.Displayed; }
        }

        #endregion
    }

    /// <summary>
    /// Empty implementation of a base element control
    /// </summary>
    public class WebControl : BaseElement
    {
    }
}