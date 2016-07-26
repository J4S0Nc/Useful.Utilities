using OpenQA.Selenium.Support.UI;

namespace Useful.WebAutomation.PageObjects.Controls
{
    /// <summary>
    /// Button control
    /// </summary>
    public class Button : BaseElement { }

    /// <summary>
    /// Helper class for linking labels to form fields 
    /// </summary>
    public abstract class FormFields : BaseElement
    {
        public Label Label { get; set; }
    }
    /// <summary>
    /// Label control, can be null
    /// </summary>
    public class Label : BaseElement
    {
        public override bool Nullable { get { return true; } }
    }
    /// <summary>
    /// base input control. If Text attribute is null or empty falls back and checks value attribute
    /// </summary>
    public class InputField : FormFields
    {
        public override string Text { get { return string.IsNullOrWhiteSpace(base.Text) ? GetAttribute("value") : base.Text; } }
    }

    /// <summary>
    /// Text area control inherits from <see cref="InputField"/>
    /// </summary>
    public class TextArea : InputField { }

    /// <summary>
    /// Check box control inherits from <see cref="InputField"/>
    /// </summary>
    public class Checkbox : InputField { }

    /// <summary>
    /// Radio button control inherits from <see cref="InputField"/>
    /// </summary>
    public class RadioButton : InputField { }

    /// <summary>
    /// Select (drop down) control inherits from <see cref="InputField"/>
    /// </summary>
    public class SelectField : InputField
    {
        private SelectElement _aSelectElement;
        /// <summary>
        /// Convert Element to <see cref="SelectElement"/> SelectElement
        /// </summary>
        /// <returns></returns>
        public SelectElement AsSelectElement()
        {
            return _aSelectElement ?? (_aSelectElement = new SelectElement(Element));
        }

    }

}
