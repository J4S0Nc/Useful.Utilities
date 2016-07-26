namespace Useful.WebAutomation.PageObjects.Controls
{
    //public class BaseForm : BasePage
    //{
        
    //    public ElementCollection<Label> Labels { get { return Controls<Label>(By.TagName("label")); } }
    //    public ElementCollection<FormFields> Fields { get { return Controls(GetFields); } }

    //    public T Field<T>(string labelText) where T : FormFields
    //    {
    //        return (from f in Fields.OfType<T>() where f.Label.Text.Equals(labelText) select f).FirstOrDefault();
    //    }
        

    //    public ElementCollection<FormFields> GetFields()
    //    {
    //        var fields = new List<FormFields>();
    //        foreach (var label in Labels)
    //        {
    //            IWebElement input = null;
    //            var forId = label.GetAttribute("for");
    //            if (forId != null && Parent.IsVisible(By.Id(forId)))
    //                input = Parent.Find(By.Id(label.GetAttribute("for")));
    //            else
    //                input = label.TryFind(By.TagName("input"));

    //            var f = ObjectFactory.CreateElement<FormFields>(Driver, Selector, this, input);
    //            f.Label = label;

    //            fields.Add(f);
    //        }

    //        return new ElementCollection<FormFields>(fields);
    //    }
    //}
}