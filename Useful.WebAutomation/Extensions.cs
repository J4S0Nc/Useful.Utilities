using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Useful.WebAutomation
{

    /// <summary>
    /// Extension method for web driver and elements 
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// default wait time
        /// </summary>
        private const int WaitTime = 30;

        #region IWebDriver ext


        /// <summary>
        /// Wait class wrapper. Takes number of seconds to wait or uses default when not passed in
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="seconds">The seconds.</param>
        /// <returns></returns>
        public static WebDriverWait Wait(this IWebDriver driver, float seconds = -1)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(seconds <= 0 ? WaitTime : seconds));
        }
        /// <summary>
        /// Wait Until the given function delegate returns true or a timeout exception is thrown. 
        /// If the logic function returns true this executes the return logic delegate and sends back the value
        /// </summary>
        /// <typeparam name="T">Type to return</typeparam>
        /// <param name="wait">The wait object</param>
        /// <param name="untilLogic">Logic to repetitively run until it returns true or times out</param>
        /// <param name="returnLogic">Logic to execute after untilLogic returns true</param>
        /// <returns>result of returnLogic delegate</returns>
        public static T Until<T>(this WebDriverWait wait, Func<IWebDriver, bool> untilLogic, Func<T> returnLogic)
        {
            wait?.Until(untilLogic);
            return returnLogic.Invoke();
        }
        /// <summary>
        /// Wait extension that will try to find a element by selector in the given parent context
        /// </summary>
        /// <param name="wait">The wait object</param>
        /// <param name="selector">the select to find</param>
        /// <param name="parent">The context to search in</param>
        /// <returns></returns>
        public static IWebElement Find(this WebDriverWait wait, By selector, ISearchContext parent)
        {
            IWebElement e = null;

            wait.Until(d =>
            {
                e = parent.TryFind(selector);
                return e != null;
            });
            return e;
        }

        /// <summary>
        /// Wait for all elements matching selector to not be displayed.
        /// throws timeout exception if still visible
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="wait">The wait.</param>
        public static void WaitWhileVisible(this IWebDriver driver, By selector, ISearchContext parent = null, WebDriverWait wait = null)
        {
            if (parent == null) parent = driver;
            bool isVisiable = parent.IsVisible(selector);
            // Trace.WriteLine("WaitWhileVisible by: " + selector + " " + isVisiable);
            if (!isVisiable) return;
            if (wait == null) wait = driver.Wait();
            wait.Until((d) => !parent.FindAll(selector, excludeDisabled: false).Any());
        }

        /// <summary>
        /// Driver extension that will wait until the selector is found or it times out. 
        /// </summary>
        /// <param name="driver">The driver.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="parent">The parent.</param>
        /// <param name="wait">The wait.</param>
        /// <returns></returns>
        public static IWebElement FindWithWait(this IWebDriver driver, By selector, ISearchContext parent = null, WebDriverWait wait = null)
        {
            if (parent == null) parent = driver;
            IWebElement e = null;
            if (wait == null) wait = driver.Wait();
            wait.Until(d =>
            {
                e = parent.TryFind(selector);
                return e != null;
            });
            return e;
        }

        ///// <summary>
        ///// finds the first element containing the text passed in
        ///// </summary>
        ///// <param name="text"></param>
        ///// <param name="selector"></param>
        ///// <param name="parent"></param>
        ///// <returns></returns>
        //public static IWebElement FindTextWithWait(this IWebDriver driver, string text, By selector = null, ISearchContext parent = null, WebDriverWait wait = null)
        //{
        //    if (selector == null) selector = By.TagName("body");
        //    if (parent == null) parent = driver;
        //    if (wait == null) wait = driver.Wait();
        //    return wait.Until(
        //        (d) => parent.FindElements(selector).Any(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed),
        //        () => parent.FindElements(selector).FirstOrDefault(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed));
        //    //driver.Wait().Until((d) => parent.FindElements(selector).Any(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed));
        //    //return parent.FindElements(selector).FirstOrDefault(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed);
        //}
        //public static void Execute(this IWebDriver driver, string script)
        //{
        //    ((IJavaScriptExecutor)driver).ExecuteScript(script);
        //}

        /// <summary>
        /// Scroll to an element using javascript. Can accept positive or negative x and y offsets 
        /// </summary>
        /// <param name="driver">the driver</param>
        /// <param name="e">The element</param>
        /// <param name="yOffset">Y vertical offset. default it -75 to try to ensure element is viewable</param>
        /// <param name="xOffset">X horizontal offset</param>
        public static void ScrollTo(this IWebDriver driver, IWebElement e, int yOffset = -75, int xOffset = 0)
        {
            var s = string.Format("javascript:window.scroll({0},{1})", e.Location.X + xOffset, e.Location.Y + yOffset);
            ((IJavaScriptExecutor)driver).ExecuteScript(s);
        }

        /*
function visible(element) {
  if (element.offsetWidth === 0 || element.offsetHeight === 0) return false;
  var height = document.documentElement.clientHeight,
      rects = element.getClientRects(),
     on_top = function(r) {
      for (var x = Math.floor(r.left), x_max = Math.ceil(r.right); x <= x_max; x++)
      for (var y = Math.floor(r.top), y_max = Math.ceil(r.bottom); y <= y_max; y++) {
        if (document.elementFromPoint(x, y) === element) return true;
      }
      return false;
    };
  for (var i = 0, l = rects.length; i < l; i++) {
    var r = rects[i],
        in_viewport = r.top > 0 ? r.top <= height : (r.bottom > 0 && r.bottom <= height);
    if (in_viewport && on_top(r)) return true;
  }
  return false;
}
         */
        #endregion

        #region ISearchContext ext

        /// <summary>
        /// Check if an element is visible by a selector and optionally verify it contains the given text. 
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="text">optional text to verify is found on selector. text is case insensitive</param>
        /// <param name="selector">Optional selector, defaults to body tag if not given</param>
        /// <returns></returns>
        public static bool IsVisible(this ISearchContext parent, string text = null, By selector = null)
        {
            if (parent == null) return false;
            if (selector == null) selector = By.TagName("body");
            bool elementVisable = false;
            //  Trace.WriteLine("IsVisible: \"" + text + "\" by: " + selector);
            try
            {
                var elements = parent.FindElements(selector);
                elementVisable = elements.Any(e => e.Displayed);
            }
            catch (Exception )
            {
            }

            if (!string.IsNullOrWhiteSpace(text) && elementVisable)
                elementVisable = (parent.FindElements(selector).Any(e => e.Text.ToLower().Contains(text.ToLower())));

            return elementVisable;
        }
        /// <summary>
        /// Check if an element is visible by a selector.
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="selector"></param>
        /// <returns></returns>
        public static bool IsVisible(this ISearchContext parent, By selector = null)
        {
            return parent != null && parent.IsVisible(null, selector);
        }

        /// <summary>
        /// Find an element using the default timeout 
        /// </summary>
        /// <param name="selector"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static IWebElement Find(this ISearchContext parent, By selector, bool excludeHidden = true, bool excludeDisabled = true)
        {
            try
            {
                return parent.FindAll(selector, excludeHidden, excludeDisabled).First();
            }
            catch (NoSuchElementException e)
            {
                throw new NoSuchElementException("Element Not Found: " + selector.ToString(), e);
            }
        }


        /// <summary>
        /// Try to find element, returns null if not found
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="excludeHidden">if set to <c>true</c> exclude hidden.</param>
        /// <param name="excludeDisabled">if set to <c>true</c> exclude disabled.</param>
        /// <returns></returns>
        public static IWebElement TryFind(this ISearchContext parent, By selector, bool excludeHidden = true, bool excludeDisabled = true)
        {
            bool found;
            return parent.TryFind(selector, excludeHidden, excludeDisabled, out found);
        }

        /// <summary>
        /// Try to find element, returns null if not found
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="selector">The selector.</param>
        /// <param name="excludeHidden">if set to <c>true</c> exclude hidden.</param>
        /// <param name="excludeDisabled">if set to <c>true</c> exclude disabled.</param>
        /// <param name="found">if set to <c>true</c> found.</param>
        /// <returns></returns>
        public static IWebElement TryFind(this ISearchContext parent, By selector, bool excludeHidden, bool excludeDisabled, out bool found)
        {
            found = true;
            IWebElement e = null;
            try
            {
                e = parent.FindAll(selector, excludeHidden, excludeDisabled).FirstOrDefault();
            }
            catch (Exception)
            {
            }
            found = e != null;
            return e;
        }



        /// <summary>
        /// finds all elements match the selector (can include invisible and disabled elements)
        /// </summary>
        /// <param name="context">The search context to look under</param>
        /// <param name="selector">The selector used to find the elements</param>
        /// <param name="excludeHidden">if set to <c>true</c> exclude hidden.</param>
        /// <param name="excludeDisabled">if set to <c>true</c> exclude disabled.</param>
        /// <returns></returns>
        /// <exception cref="OpenQA.Selenium.NoSuchElementException">Find All Failed:  + selector.ToString()</exception>
        public static IWebElement[] FindAll(this ISearchContext context, By selector, bool excludeHidden = true, bool excludeDisabled = true)
        {
            if (selector == null) return new IWebElement[] { };
            try
            {
                //   Trace.WriteLine("Find by: " + selector);
                var els = context.FindElements(selector).ToArray();
                if (!els.Any()) return new IWebElement[] { };
                if (excludeDisabled) els = els.Where(e => e.Enabled).ToArray();
                if (excludeHidden) els = els.Where(e => e.Displayed).ToArray();

                return els;
            }
            catch (Exception e)
            {
                throw new NoSuchElementException("Find All Failed: " + selector.ToString(), e);
            }

        }
        /// <summary>
        /// Find all the visible elements that contain the given text.
        /// </summary>
        /// <param name="context">The search context to look under</param>
        /// <param name="text">The text to search for</param>
        /// <param name="selector">The selector used to find the elements. if none is given the body tag is used</param>
        /// <param name="wait">Optional wait object to hold until any element matching the text is displayed.</param>
        /// <returns></returns>
        public static ReadOnlyCollection<IWebElement> FindAllText(this ISearchContext context, string text, By selector = null, WebDriverWait wait = null)
        {
            if (selector == null) selector = By.TagName("body");
            //   Trace.WriteLine("Find Text: " + text + " by: " + selector);
            wait?.Until((d) => d.FindElements(selector).Any(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed));
            return new ReadOnlyObservableCollection<IWebElement>(new ObservableCollection<IWebElement>(context.FindElements(selector).Where(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed)));
        }
        /// <summary>
        /// Find the first visible element that contains the given text.
        /// </summary>
        /// <param name="context">The search context to look under</param>
        /// <param name="text">The text to search for</param>
        /// <param name="selector">The selector used to find the elements. if none is given the body tag is used</param>
        /// <param name="wait">Optional wait object to hold until any element matching the text is displayed.</param>
        /// <returns></returns>
        public static IWebElement FindText(this ISearchContext context, string text, By selector = null, WebDriverWait wait = null)
        {

            if (selector == null) selector = By.TagName("body");
            //  Trace.WriteLine("Find Text: " + text + " by: " + selector);
            wait?.Until((d) => context.FindElements(selector).Any(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed));
            return context.FindElements(selector).FirstOrDefault(e => e.Text.ToLower().Contains(text.ToLower()) && e.Displayed);
        }
        #endregion

        #region IWebElement ext
        /// <summary>
        /// Throws exceptions if the element is null, disabled or hidden.  
        /// </summary>
        /// <param name="e">Element to validate</param>
        public static void ValidateState(this IWebElement e)
        {
            if (e == null) throw new NullReferenceException("Element is null.");
            if (!e.Enabled) throw new InvalidElementStateException(e.TagName + " is disabled: " + e.Text);
            if (!e.Displayed) throw new ElementNotVisibleException(e.TagName + " is hidden: " + e.Text);

        }

        /// <summary>
        /// Check if an element has the given class name in its class attribute. 
        /// </summary>
        /// <param name="e">Element to check</param>
        /// <param name="className">class name to look for</param>
        /// <returns></returns>
        public static bool HasClass(this IWebElement e, string className)
        {
            if (e == null) return false;
            var c = e.GetAttribute("class");
            return !string.IsNullOrWhiteSpace(c) && c.Contains(className);
        }

        /// <summary>
        /// Get parent relative to current element using XPath "./parent::*"
        /// </summary>
        /// <param name="element">The current element</param>
        /// <returns></returns>
        public static IWebElement Parent(this IWebElement element)
        {
            return element?.Find(By.XPath("./parent::*"));
        }
        #endregion




    }
}
