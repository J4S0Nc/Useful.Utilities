using System;
using System.Linq;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OpenQA.Selenium;
using Useful.WebAutomation.PageObjects.Controls;
using Useful.WebAutomation.Selenium;

namespace Useful.WebAutomation.PageObjects.Farmers
{

    public abstract class SelfServiceBasePage : BasePage
    {
        public override void ValidatePage()
        {
            var source = this.Driver.PageSource;
            var matches = Regex.Matches(source, "<!-- Page (ID|Name): (.*) -->").Cast<Match>().ToList();
            Assert.True(matches.Any(), "No Page ID or Name found!");
            Assert.True(matches.Any(match => match.Groups[2].Value.Equals(this.PageId, StringComparison.CurrentCultureIgnoreCase)
                ), "Invalid Page ID! Looked for: {0}; Found: {1}", this.PageId, matches.Last().Groups[2].Value);
        }
    }

    public class SelfServiceGreeting : SelfServiceBasePage
    {
        public override string Url
        {
            get
            {
                return "V1/Default.aspx?id=CE33D256-A4DA-4A2D-B613-A6B0BAA23436&smakey=QWERTY";// "/Logins/SelfService/Default.aspx?id=CE33D256-A4DA-4A2D-B613-A6B0BAA23436&Phone=1234567890&mm_key=QWERTY"; 
            }
        }
        public override string PageId { get { return "SELFSERVICE GREETING"; } }
        public InputField PolicyNumber { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","PlcyNum")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class LossDetails : SelfServiceBasePage
    {
        public override string PageId { get { return "SELFSERVICE DATE OF LOSS"; } }
        public InputField LossDate { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","LossDt")); } }
        public SelectField LossState { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","LossLocState")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class VehicleCovageLookup : SelfServiceBasePage
    {
        public override string PageId { get { return "CoverageExt.aspx"; } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public WebControl NotFoundLink { get { return Control<WebControl>(By.LinkText("Vehicle Not Found")); } }
        public ElementCollection<Button> Choices { get { return Controls<Button>(CustomBy.CssAttr("data-FriendlyId","vehicle")); } }
    }

    public class PersonDetails : SelfServiceBasePage
    {
        public override string PageId { get { return "SELFSERVICE INSURED INFO"; } }
        public InputField FirstName { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","InsuredFirstName")); } }
        public InputField LastName { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","InsuredLastName")); } }
        public InputField HomePhone { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","InsuredHomePhone")); } }
        public InputField WorkPhone { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","InsuredWorkPhone")); } }
        public InputField EmailAddress { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","InsuredEmailAddress")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class PersonAddressDetails : AddressPage
    {
        public override string PageId { get { return "HomeAddressInfoExt.aspx"; } }

    }

    public abstract class AddressPage : SelfServiceBasePage
    {
        public InputField Address1 { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","address1")); } }
        public InputField Address2 { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","address2")); } }
        public InputField City { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","city")); } }
        public SelectField State { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","state")); } }
        public InputField Zip { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","zipCode")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
        public AddressDialog AddressValidationDialog { get { return Control<AddressDialog>(By.ClassName("ui-dialog")); } }
    }

    public class AddressDialog : WebControl
    {
        public ElementCollection<RadioButton> Choices { get { return Controls<RadioButton>(By.Name("pickZipRadio")); } }
        public Button ChooseButton { get { return Control<Button>(By.Name("chooseNewZip")); } }

    }

    public class SelectVehicle : SelfServiceBasePage
    {
        public override string PageId { get { return "VehicleSelectionExt.aspx"; } }
        public SelectField Year { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","vehYear")); } }
        public SelectField Make { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","vehMake")); } }
        public SelectField Model { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","vehModel")); } }
        public SelectField Style { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","vehStyle")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class GlassSelection : SelfServiceBasePage
    {
        public override string PageId { get { return "GlassSelectionCommonExt.aspx"; } }
        public Checkbox Windshield { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","Windshield")); } }
        public Checkbox SideGlass { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","SideGlass")); } }
        public Checkbox BackGlass { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","BackGlass")); } }
        public Checkbox OtherGlass { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","unknown")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class GlassSelectionSideType : SelfServiceBasePage
    {
        public override string PageId { get { return "GlassSelectionSideExt.aspx"; } }
        //Driver/Passenger/Both
        public ElementCollection<RadioButton> GlassTypes { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","glassType")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class UnderDollarBill : SelfServiceBasePage
    {
        public override string PageId { get { return "RepairQualificationDollarBillExt.aspx"; } }
        //smaller/larger
        public ElementCollection<RadioButton> UnderDollar { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","data")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class NumberOfChips : SelfServiceBasePage
    {
        public override string PageId { get { return "RepairQualificationNumberOfChipsExt.aspx"; } }
        //1/2/3/4Plus
        public ElementCollection<RadioButton> Chips { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","data")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class GlassSelectionSideDetails : SelfServiceBasePage
    {
        public override string PageId { get { return "GlassSelectionSideDetailExt.aspx"; } }
        public Checkbox FrontDoor { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","FrontDoor")); } }
        public Checkbox RearDoor { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","RearDoor")); } }
        public Checkbox SideDoor { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","SideDoor")); } }
        public Checkbox Vent { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","Vent")); } }
        public Checkbox RearQuarter { get { return Control<Checkbox>(CustomBy.CssAttr("data-FriendlyId","RearQuarter")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }
    public class GlassSelectionPartDetails : SelfServiceBasePage
    {
        public override string PageId { get { return "PartSelectionExt.aspx"; } }
        // parts are by car and glass type
        public ElementCollection<RadioButton> Parts { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","data")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class RepairReplaceMessage : SelfServiceBasePage
    {
        public override string PageId { get { return "SELFSERVICE REPAIR INFO"; } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class Provider : SelfServiceBasePage
    {
        public override string PageId { get { return "SELFSERVICE FBSTMT"; } }
        // NO PREFERENCE/PREFERENCE
        public ElementCollection<RadioButton> Preferences { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","InsuredProviderPreference")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class LocationType : SelfServiceBasePage
    {
        public override string PageId { get { return "ScheduleLocationExt.aspx"; } }
        // InShop/Work/Home/Other
        public new ElementCollection<RadioButton> Location { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","schedLocGroup")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class ChooseShop : SelfServiceBasePage
    {
        public override string PageId { get { return "ScheduleInshopSelectionExt.aspx"; } }
        // InShop/Work/Home/Other
        public ElementCollection<Button> Shops { get { return Controls<Button>(CustomBy.CssAttr("data-FriendlyId","data")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        //todo add map next button, change zip link and radius drop down options
    }

    public class ServiceAddressDetails : AddressPage
    {
        public override string PageId { get { return "ServiceAddressInfoExt.aspx"; } }
        public InputField Company { get { return Control<InputField>(CustomBy.CssAttr("data-FriendlyId","company")); } }
    }

    public class ScheduleMobileTime : SelfServiceBasePage
    {
        public override string PageId { get { return "ScheduleMobileTimeExt.aspx"; } }
        //todo how to deal with calendar? 

        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class ScheduleInShop : SelfServiceBasePage
    {
        public override string PageId { get { return "ScheduleAvailableInshopExt.aspx"; } }
        public WebControl Calendar { get { return Control<WebControl>(By.ClassName("ui-datepicker-inline")); } }
        public SelectField Morning { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","morningTimes")); } }
        public SelectField Afternoon { get { return Control<SelectField>(CustomBy.CssAttr("data-FriendlyId","afternoonTimes")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }

    public class Bailout : SelfServiceBasePage
    {
        public override string PageId { get { return "SELFSERVICE BAILOUT"; } }
        // Y/N
        public ElementCollection<RadioButton> CallBackOptions { get { return Controls<RadioButton>(CustomBy.CssAttr("data-FriendlyId","CreateCallBack")); } }
        public Button BackButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","previousButton")); } }
        public Button NextButton { get { return Control<Button>(CustomBy.CssAttr("data-FriendlyId","nextButton")); } }
    }
}
