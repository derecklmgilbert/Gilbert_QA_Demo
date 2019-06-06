using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class Home
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By lnkCreateCustomer = By.LinkText("Create Customer");
        //Table management
        private static string tblCustomersXpath = "//table[@id='tblCustomers']";
        private static string colCustomerName = "1";
        private static string colCustomerType = "2";
        private static string colManageUsers = "3";
        private static string colEditCustomer = "4";
        private static string colLandingPageItems = "5";
        private static string colSelectCustomer = "6";
        private static readonly By tblCustomers = By.XPath(tblCustomersXpath);

        public static void ClickEditCustomerFromTable(string CustomerName)
        {
            driver.FindElement(By.XPath(tblCustomersXpath + @"/tbody/tr/td[text()='" + CustomerName + @"']/../td[" + colEditCustomer + "]")).Click();
        }
        public static void ClickSelectCustomerFromTable(string CustomerName)
        {
            driver.FindElement(By.XPath(tblCustomersXpath + @"/tbody/tr/td[text()='" + CustomerName + @"']/../td[" + colSelectCustomer + "]")).Click();
        }
        public static void ClickManageUsersFromTable(string CustomerName)
        {
            driver.FindElement(By.XPath(tblCustomersXpath + @"/tbody/tr/td[text()='" + CustomerName + @"']/../td[" + colManageUsers + "]")).Click();
        }
        public static void ClickCreateCustomerLink()
        {
            driver.FindElement(lnkCreateCustomer).Click();
        }
        public static void ValidateCreateCustomerLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkCreateCustomer).Count);
        }
    }
}
