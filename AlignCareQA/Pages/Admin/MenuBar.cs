using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
namespace AlignCareQA.Pages.Admin
{
    class MenuBar
    {
        private static IWebDriver driver = UITests.driver;

        // Header section
        private static readonly By lnkEditLandingPage = By.LinkText("Edit/Delete Landing Page Items");
        private static readonly By lnkAddLandingPage = By.LinkText("Add Landing Page Item");
        private static readonly By lnkManageProperty = By.LinkText("Manage Property");
        private static readonly By lnkManageCustomers = By.LinkText("Manage Customers");
        private static readonly By lnkManageSuperAdmin = By.LinkText("Manage SuperAdmin");

        public static void ClickManageCustomers()
        {
            driver.FindElement(lnkManageCustomers).Click();
        }
        public static void ClickAddLandingPage()
        {
            driver.FindElement(lnkAddLandingPage).Click();
        }
        public static void ClickEditLandingPage()
        {
            driver.FindElement(lnkManageCustomers).Click();
        }
        public static void ClickManageProperty()
        {
            driver.FindElement(lnkManageProperty).Click();
        }
        public static void ClickManageSuperAdmin()
        {
            driver.FindElement(lnkManageSuperAdmin).Click();
        }
        public static void ValidateManageSuperAdminLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkManageSuperAdmin).Count);
        }
        public static void ValidateManagePropertyLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkManageProperty).Count);
        }
        public static void ValidateManageCustomersLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkManageCustomers).Count);
        }
        public static void ValidateAddLandingPageLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkAddLandingPage).Count);
        }
        public static void ValidateEditLandingPageLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkEditLandingPage).Count);
        }
    }
}
