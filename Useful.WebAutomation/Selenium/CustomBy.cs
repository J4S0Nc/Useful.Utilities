using System;
using System.Collections.ObjectModel;
using System.Linq;
using OpenQA.Selenium;

namespace Useful.WebAutomation.Selenium
{
    /// <summary>
    /// Custom selectors for find elements in a document or context
    /// </summary>
    public class CustomBy : By
    {
        private CustomBy(Func<ISearchContext, IWebElement> single, Func<ISearchContext, ReadOnlyCollection<IWebElement>> many, string description)
            : base(single, many)
        {
            Description = description;
        }

        /// <summary>
        /// Find elements by a CSS attribute. 
        /// </summary>
        /// <param name="attr">Attribute to check</param>
        /// <param name="value">value to match</param>
        /// <returns></returns>
        public static By CssAttr(string attr, string value)
        {
            return new CustomBy(
                (context => (context).FindElements(By.CssSelector("[\""+ attr + "\"=" + value + "]")).FirstOrDefault()),
                (context => (context).FindElements(By.CssSelector("[\"" + attr + "\"=" + value + "]"))),
                "By.CssAttr: " +attr + "=" + value
                );
        }

        /// <summary>
        /// Find elements by text. Text is case insensitive  
        /// </summary>
        /// <param name="text">The text to search for</param>
        /// <param name="parent">The element to search under, default is document body</param>
        /// <returns></returns>
        public static By Text(string text, By parent = null)
        {
            if (string.IsNullOrWhiteSpace(text))
                throw new ArgumentNullException("text", "Cannot find elements when text is null.");
            return new CustomBy(
                (context => (context).FindText(text, parent)),
                (context => (context).FindAllText(text, parent)),
                "By.Text: " + text
                );
        }

        //public static By List(params By[] selectors)
        //{
        //    if (selectors == null || !selectors.Any())
        //        throw new ArgumentNullException("selectors", "Cannot find elements when selectors is null.");
        //    var desc = "";
        //    desc = selectors.Aggregate(desc, (c, n) => c += n);

        //    return new CustomBy(
        //        (context => (IWebElement)selectors.Aggregate(context, (current, s) => s.FindElement(current))),
        //        (context =>
        //            {
        //                for (var index = 0; index < selectors.Length - 1; index++)
        //                    context = selectors[index].FindElement(context);
        //                return selectors.Last().FindElements(context);

        //            }),
        //        "By.Array: " + desc
        //        );
        //}
    }
}