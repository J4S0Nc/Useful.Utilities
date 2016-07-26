using System.Collections;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace Useful.WebAutomation.PageObjects.Controls
{
    /// <summary>
    /// Collection of elements. The collection it's self can also be an element. 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ElementCollection<T> : BaseElement, IReadOnlyCollection<T> where T : BaseElement
    {
        private IEnumerable<T> _elementsCache;

        public ElementCollection() { }
        public ElementCollection(IEnumerable<T> fields)
        {
            _elementsCache = new List<T>(fields);
        }
        /// <summary>
        /// Get all the visible elements by the collections selector. Items are cached internally after first call
        /// </summary>
        /// <returns></returns>
        public virtual IEnumerable<T> GetElements()
        {
            if (_elementsCache != null && _elementsCache.Any()) return _elementsCache;
            var els = Parent.FindAll(Selector,false,false);
            return _elementsCache = els.Select(e => ObjectFactory.CreateElement<T>(Driver, Selector, this, e)).ToList();
        }

        /// <summary>
        /// Allow the collection element to be null. 
        /// </summary>
        public override bool Nullable { get { return true; } }
        /// <summary>
        /// Gets the root element of the collection (not an item of the collection)
        /// </summary>
        /// <returns></returns>
        public override IWebElement GetElement() { return null; }

        /// <summary>
        /// Enumerator of elements in the collection
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator() { return GetElements().GetEnumerator(); }
        /// <summary>
        /// Enumerator of elements in the collection
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
        /// <summary>
        /// Numbers of items in the collection
        /// </summary>
        public int Count { get { return GetElements().Count(); } }

    }

}