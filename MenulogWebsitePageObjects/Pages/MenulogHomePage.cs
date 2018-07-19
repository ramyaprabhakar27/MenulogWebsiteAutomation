using MenulogWebsitePageObjects.Utilities;
using OpenQA.Selenium;
using System;
using System.Threading;

namespace MenulogWebsitePageObjects.Pages
{
    public static class MenulogHomePage
    {
        private static IWebElement SearchBox { get => Driver.UIDriver.FindElement(By.Id("homepage-search-fullAddress")); }
        private static IWebElement AddressLookUp { get => Driver.UIDriver.FindElement(By.CssSelector(".addressLookup-suggestions-item.is-selected")); }
        private static IWebElement SearchButton { get => Driver.UIDriver.FindElement(By.CssSelector(".btn.btn--primary.addressLookup-actionBtn.form-submit")); }

        public static void SearchSuburb(string suburb)
        {
            Thread.Sleep(2000);
            SearchBox.Click();
            SearchBox.SendKeys(Keys.Control + "a");
            SearchBox.SendKeys(Keys.Backspace);
            SearchBox.SendKeys(suburb);
            try
            {
                Helper.WaitForElementVisibleByCssSelector(".addressLookup-suggestions-item.is-selected", 2);
                AddressLookUp.Click();
            }
            catch (Exception e)
            {

            }
        }

        public static void SubmitSearch()
        {
            SearchButton.Click();
        }
    }
}