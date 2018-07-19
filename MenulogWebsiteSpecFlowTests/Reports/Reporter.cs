using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NLog;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.Reflection;

namespace MenulogWebsiteSpecFlowTests.Reports
{
    public static class Reporter
    {
        private static ExtentReports extentReport;
        private static ExtentTest extentTest;
        private static ExtentHtmlReporter extentHtmlReporter;
        private static Logger logger;

        public static void StartReport()
        {
            string path = Assembly.GetCallingAssembly().CodeBase;
            string actualpath = path.Substring(0, path.LastIndexOf("bin"));
            string projectpath = new Uri(actualpath).LocalPath;
            string reportpath = projectpath + "Reports\\TestReport.html";
            extentHtmlReporter = new ExtentHtmlReporter(reportpath);
            extentHtmlReporter.LoadConfig(projectpath + "extent-config.xml");
            extentHtmlReporter.AppendExisting = false;
            extentReport = new ExtentReports();
            extentReport.AttachReporter(extentHtmlReporter);
            extentReport.AddSystemInfo("Host name", "Ramya Prabhakar");
            extentReport.AddSystemInfo("Environment", "QA Test");
        }

        public static void CreateTestReport()
        {
            string testName = TestContext.CurrentContext.Test.Name.ToString();
            logger = LogManager.GetLogger(testName);
            extentTest = extentReport.CreateTest(testName);
        }

        public static void LoggerMessage(string message)
        {
            logger.Info(message);
        }

        public static void LogMessage(string message, string status)
        {
            logger.Info(message);
            switch (status)
            {
                case "Pass":
                    extentTest.Pass(message);
                    break;
                case "Fail":
                    extentTest.Fail(message);
                    break;
                default:
                    extentTest.Info(message);
                    break;
            }
        }

        public static void GetResult()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var stacktrace = string.IsNullOrEmpty(TestContext.CurrentContext.Result.StackTrace) ? "" : string.Format("{0}", TestContext.CurrentContext.Result.StackTrace);
            var errorMessage = TestContext.CurrentContext.Result.Message;

            Status logstatus;
            switch (status)
            {
                case TestStatus.Failed:
                    logstatus = Status.Fail;
                    break;
                case TestStatus.Inconclusive:
                    logstatus = Status.Warning;
                    break;
                case TestStatus.Skipped:
                    logstatus = Status.Skip;
                    break;
                default:
                    logstatus = Status.Pass;
                    break;
            }
            extentTest.Log(logstatus, "Test ended with " + logstatus + stacktrace + errorMessage);
        }

        public static void EndReport()
        {
            extentReport.Flush();
        }
    }
}