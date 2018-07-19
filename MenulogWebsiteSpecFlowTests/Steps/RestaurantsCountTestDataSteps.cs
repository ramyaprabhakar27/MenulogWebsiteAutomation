using MenulogWebsitePageObjects.Pages;
using MenulogWebsitePageObjects.Utilities;
using MenulogWebsiteSpecFlowTests.Reports;
using MenulogWebsiteSpecFlowTests.Utilities;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace MenulogWebsiteSpecFlowTests.Steps
{
    [Binding]
    [Scope (Tag = "RestaurantsCountUsingTestData")]
    public class RestaurantsCountTestDataSteps
    {
        List<string> testData = new List<string>();

        [BeforeFeature]
        public static void SetUp()
        {
            Driver.SetUp();
        }

        [AfterFeature]
        public static void TearDown()
        {
            Reporter.GetResult();
            Driver.TearDown();
        }

        [Given(@"I have a data in a testdata class file")]
        public void GivenIHaveADataInATestdataClassFile()
        {
            testData = TestData.GetTestData();
            Reporter.CreateTestReport();
        }

        [Then(@"I search for each of the suburb from the testdata,restaurant count should be displayed for the searched suburb on the SERP Page")]
        public void ThenISearchForEachOfTheSuburbFromTheTestdataRestaurantCountShouldBeDisplayedForTheSearchedSuburbOnTheSERPPage()
        {
            foreach (var data in testData)
            {
                Driver.GoToSite(URL.MenulogHomePageUrl);
                MenulogHomePage.SearchSuburb(data);
                Reporter.LoggerMessage(MenulogSERPPage.GetRestaurantsServingCount() + " Restaurants Serving in " + data + " Suburb");                
            }
        }
    }
}