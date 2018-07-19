using MenulogWebsiteSpecFlowTests.Reports;
using TechTalk.SpecFlow;

namespace MenulogWebsiteSpecFlowTests.Steps
{
    [Binding]
    public sealed class BaseTestReportSteps
    {      
        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            Reporter.StartReport();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            Reporter.EndReport();
        }
    }
}
