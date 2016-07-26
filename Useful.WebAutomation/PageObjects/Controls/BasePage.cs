namespace Useful.WebAutomation.PageObjects.Controls
{
    /// <summary>
    /// Base page container used by page factory 
    /// </summary>
    public abstract class BasePage : BaseElement
    {
        /// <summary>
        /// The URL of the page
        /// </summary>
        public virtual string Url { get { return Driver.Url; } }
        /// <summary>
        /// Does this page URL have the same application root URL as other pages?
        /// </summary>
        public virtual bool? UseAppRoot { get { return null; } }
        /// <summary>
        /// Unique ID string that identifies a page to its type. Typically checked in the validatePage method.
        /// </summary>
        public virtual string PageId { get { return Driver.Title; } }
        /// <summary>
        /// Called when a page is created by the page factory. Used to validate the DOM matches the type being created.
        /// </summary>
        public abstract void ValidatePage();
    }



}
