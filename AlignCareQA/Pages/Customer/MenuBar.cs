using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{ 
    class MenuBar
    {
        private static IWebDriver driver = UITests.driver;
        private static readonly By lnkMenuDropdown = By.XPath("//*[@menu-item='menu']");
        private static readonly By lnkAdmin = By.XPath("//a/div[contains(@class,'adminmenu')]");

        public static void ExpandMenu()
        {
            driver.FindElement(lnkMenuDropdown).Click();

        }
        public static void ClickAdminLink()
        {
            driver.FindElement(lnkAdmin).Click();
        }
        public static void ValidateAdminLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkAdmin).Count);
        }
    }
}
