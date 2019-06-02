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

        private static ChromeDriver driver = UITests.driver;
        private static readonly By lnkCreate = By.LinkText("Create");
        public static void ClickCreateLink()
        {
            driver.FindElement(lnkCreate).Click();
        }
    }
}
