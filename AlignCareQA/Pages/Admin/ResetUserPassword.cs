using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class ResetUserPassword
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By txtPassword = By.Id("Password");
        private static readonly By txtConfirmPassword = By.Id("roleList");
        private static readonly By btnReset = By.XPath("//input[@value='Reset']");
    }
}
