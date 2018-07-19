using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace MenulogWebsitePageObjects.Utilities
{
    public static class Helper
    {
        public static void WaitForElementVisibleById(string elementID, int timeOutInSeconds)
        {
            new WebDriverWait(Driver.UIDriver, TimeSpan.FromSeconds(timeOutInSeconds)).Until(ExpectedConditions.ElementIsVisible(By.Id(elementID)));
        }
        public static void WaitForElementVisibleByCssSelector(string elementID, int timeOutInSeconds)
        {
            new WebDriverWait(Driver.UIDriver, TimeSpan.FromSeconds(timeOutInSeconds)).Until(ExpectedConditions.ElementIsVisible(By.CssSelector(elementID)));
        }
        public static void WaitForElementByCssSelector(string elementID, int timeOutInSeconds)
        {
            new WebDriverWait(Driver.UIDriver, TimeSpan.FromSeconds(timeOutInSeconds)).Until<IWebElement>((d) =>
            {
                return d.FindElement(By.CssSelector(elementID));
            });
        }
        public static void DefaultFluentWaitByCssSelector(string elementID, int timeOutInSeconds)
        {
            DefaultWait<IWebDriver> wait = new DefaultWait<IWebDriver>(Driver.UIDriver)
            {
                Timeout = TimeSpan.FromSeconds(timeOutInSeconds),
                PollingInterval = TimeSpan.FromMilliseconds(500),
                Message = "Element Not Found",
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            wait.Until<IWebElement>((d) =>
            {
                return d.FindElement(By.Id(elementID));
            });
        }
    }
}