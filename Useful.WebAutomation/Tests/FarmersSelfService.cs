using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using Useful.WebAutomation.PageObjects;
using Useful.WebAutomation.PageObjects.Farmers;

namespace Useful.WebAutomation.Tests
{
    class FarmersSelfService : BaseTest
    {


        [Test]
        public void Testing()
        {

            Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(10));
            var page = Driver.GoTo<SelfServiceGreeting>();
            page.PolicyNumber.SendKeys("0165811640");
            page.NextButton.Click();

            var lossPage = Driver.CurrentPage<LossDetails>();
            lossPage.LossDate.SendKeys("6/4/2015");
            lossPage.LossState.AsSelectElement().SelectByValue("OH");
            lossPage.NextButton.Click();

            var vehiclePage = Driver.CurrentPage<VehicleCovageLookup>();

            Assert.True(vehiclePage.Choices.Any(), "no vehicles found");
            vehiclePage.Choices.First().Click();

            var personDetsPage = Driver.CurrentPage<PersonDetails>();
            personDetsPage.NextButton.Click();

            var addressPage = Driver.CurrentPage<PersonAddressDetails>();
            var w = addressPage.NextButton.ClickAndWait(2);
            //var hasDialog = w.Find(By.ClassName("ui-dialog"), Driver) != null;

            //if (hasDialog)
            //{
            //    if (addressPage.AddressValidationDialog.Choices.Any())
            //        addressPage.AddressValidationDialog.Choices.First().ClickNoWait();
            //    addressPage.AddressValidationDialog.ChooseButton.Click();
            //    addressPage.NextButton.Click();
            //}

            var vehicleDetails = Driver.CurrentPage<SelectVehicle>();
            vehicleDetails.NextButton.Click();

            var glassSelection = Driver.CurrentPage<GlassSelection>();
            glassSelection.Windshield.Click();
            glassSelection.BackGlass.Click();
            glassSelection.SideGlass.Click();
            glassSelection.NextButton.Click();

            var sideSelection = Driver.CurrentPage<GlassSelectionSideType>();
            Assert.AreEqual(3, sideSelection.GlassTypes.Count, "Side glass type count");
            sideSelection.GlassTypes.First().Click();
            sideSelection.NextButton.Click();

            var sideDetails = Driver.CurrentPage<GlassSelectionSideDetails>();
            sideDetails.FrontDoor.Click();
            sideDetails.NextButton.Click();

            //windshield 
            var partSelection = Driver.CurrentPage<GlassSelectionPartDetails>();
            partSelection.NextButton.Click();

            //back glass
            partSelection = Driver.CurrentPage<GlassSelectionPartDetails>();
            partSelection.NextButton.Click();

            //side glass
            partSelection = Driver.CurrentPage<GlassSelectionPartDetails>();
            partSelection.NextButton.Click();

            var provider = Driver.CurrentPage<Provider>();
            provider.Preferences.First().Click();
            provider.NextButton.Click();

            var locationType = Driver.CurrentPage<LocationType>();
            locationType.NextButton.Click();

            var shops = Driver.CurrentPage<ChooseShop>();
            shops.Shops.First().Click();

            var appointment = Driver.CurrentPage<ScheduleInShop>();
            //todo this will not if today is last day of month or Saturday!
            appointment.Find(By.PartialLinkText(DateTime.Today.AddDays(1).Day.ToString())).Click();
            appointment.Afternoon.AsSelectElement().SelectByText("2:00 PM");
            appointment.NextButton.Click();

        }


        private void LossDetails(string policyNumber, string lossDate, string lossState)
        {
            var page = Driver.GoTo<SelfServiceGreeting>();
            page.PolicyNumber.SendKeys(policyNumber);
            page.NextButton.Click();

            var lossPage = Driver.CurrentPage<LossDetails>();
            lossPage.LossDate.SendKeys(lossDate);
            lossPage.LossState.AsSelectElement().SelectByValue(lossState);
            lossPage.NextButton.Click();

        }
    }

   
}
