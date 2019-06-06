using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class ManageUsers
    {

        private static IWebDriver driver = UITests.driver;
        private static readonly By lnkCreate = By.LinkText("Create");

        //Table management
        private static string tblUsersXpath = "//table[@id='tblUsers']";
        private static string colUsername = "1";
        private static string colFullName = "2";
        private static string colResetPassword = "3";
        private static string colEditUser = "4";
        private static readonly By tblUsers = By.XPath(tblUsersXpath);

        public static void ClickCreateLink()
        {
            driver.FindElement(lnkCreate).Click();
        }
        public static void ClickResetPasswordFromTable(string Username)
        {
            driver.FindElement(By.XPath(tblUsersXpath + @"/tbody/tr/td[text()='" + Username + @"']/../td[" + colResetPassword + "]")).Click();
        }
        public static void ClickEditUserFromTable(string Username)
        {
            driver.FindElement(By.XPath(tblUsersXpath + @"/tbody/tr/td[text()='" + Username + @"']/../td[" + colEditUser + "]")).Click();
        }
    }
}
