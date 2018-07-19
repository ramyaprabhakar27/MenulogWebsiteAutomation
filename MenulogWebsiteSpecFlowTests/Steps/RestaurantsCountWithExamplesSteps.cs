using MenulogWebsitePageObjects.Pages;
using MenulogWebsitePageObjects.Utilities;
using MenulogWebsiteSpecFlowTests.Reports;
using MenulogWebsiteSpecFlowTests.Utilities;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace MenulogWebsiteSpecFlowTests.Steps
{
    [Binding]
    [Scope(Tag = "RestaurantsCountWithExamples")]
    public class RestaurantsCountWithExamplesSteps
    {
        [BeforeFeature]
        public static void SetUp()
        {
            Driver.SetUp();
            Reporter.CreateTestReport();
        }

        [AfterFeature]
        public static void TearDown()
        {
            Reporter.GetResult();
            Driver.TearDown();
        }

        [Given(@"I am at the Menulog Home Page")]
        public void GivenIAmAtTheMenulogHomePage()
        {            
            Driver.GoToSite(URL.MenulogHomePageUrl);
        }

        [Given(@"I enter the suburb as(.*)")]
        public void GivenIEnterTheSuburbAs(string suburb)
        {
            MenulogHomePage.SearchSuburb(suburb);
            ScenarioContext.Current["Suburb"] = suburb;
        }

        [Then(@"the restaurant count should be displayed for the searched suburb on the SERP")]
        public void ThenTheRestaurantCountShouldBeDisplayedForTheSearchedSuburbOnTheSERP()
        {            ;
            Reporter.LoggerMessage($"{MenulogSERPPage.GetRestaurantsServingCount()} Restaurants Serving in {ScenarioContext.Current["Suburb"]} Suburb");            
        }
    }
}
