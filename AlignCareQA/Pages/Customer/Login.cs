using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{
    class Login
    {
        private static ChromeDriver driver = UITests.driver;
        private static readonly By txtUsername = By.Id("UserName");
        private static readonly By txtPassword = By.Name("Password");
        private static readonly By btnSubmit = By.CssSelector("input[type='Submit']");
        private static readonly By msgError = By.ClassName("validation-summary-errors");

        public static void LoginWithDefault()
        {
            AttemptLogin("dereck.gilbert@aligncare.com", "HelloW0rld123!");
        }
        public static void AttemptLogin(string username, string password)
        {
            driver.FindElement(txtUsername).SendKeys(username);
            driver.FindElement(txtPassword).SendKeys(password);
            driver.FindElement(btnSubmit).Click();
        }
        public static void ValidateInvalidPasswordMessage()
        {
            Assert.IsTrue(driver.FindElement(msgError).Displayed);
            Assert.AreEqual("Password is incorrect.", driver.FindElement(msgError).Text);

        }
    }
}
