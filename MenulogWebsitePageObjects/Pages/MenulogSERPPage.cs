using MenulogWebsitePageObjects.Utilities;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Threading;

namespace MenulogWebsitePageObjects.Pages
{
    public static class MenulogSERPPage
    {
        private static Actions builder = new Actions(Driver.UIDriver);
        private static IWebElement RestaurantsServingCount { get => Driver.UIDriver.FindElement(By.CssSelector(".beta.u-alignBottom.u-spacingRight")); }        

        public static string GetRestaurantsServingCount()
        {
            try
            {
                Helper.WaitForElementVisibleByCssSelector(".beta.u-alignBottom.u-spacingRight", 5);
                return RestaurantsServingCount.Text.Split(' ')[0].ToString();
            }
            catch (Exception e)
            {
                return "-1";
            }
        }            
    }
}
