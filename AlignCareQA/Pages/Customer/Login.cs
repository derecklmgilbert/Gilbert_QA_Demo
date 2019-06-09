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
        private static IWebDriver driver = UITests.driver;
        private static readonly By txtUsername = By.Id("UserName");
        private static readonly By txtPassword = By.Name("Password");
        private static readonly By btnSubmit = By.CssSelector("input[type='Submit']");
        private static readonly By msgError = By.ClassName("validation-summary-errors");

        public static void LoginWithSuperAdmin()
        {
            AttemptLogin("dereck.gilbert@aligncare.com", "HelloW0rld123!");
        }
        public static void LoginWithStaffAdmin()
        {
            AttemptLogin("AdminStaffTest", "Test12345");
        }
        public static void LoginWithClientAdmin()
        {
            AttemptLogin("StaticTestAdmin", "DGxy1234!");
        }
        public static void LoginWithUser()
        {
            AttemptLogin("Test", "TESTTEST123");
        }
        public static void AttemptLogin(string username, string password)
        {
            driver.FindElement(txtUsername).Clear();
            driver.FindElement(txtUsername).SendKeys(username);
            driver.FindElement(txtPassword).SendKeys(password);
            driver.FindElement(btnSubmit).Click();
        }
        public static void ValidateInvalidPasswordMessage(string contactEmail)
        {
            Assert.IsTrue(driver.FindElement(msgError).Displayed);
            Assert.AreEqual("Invalid User Name or Password. If you have forgotten your credentials please contact " + contactEmail, driver.FindElement(msgError).Text);
        }
        public static void ValidateDormantAccountMessage(string contactName, string contactPhone, string contactEmail)
        {
            Assert.IsTrue(driver.FindElement(msgError).Displayed);
            Assert.AreEqual("Your Account is dormant due to inactivity please contact " + contactName + " , " + contactPhone + " " + contactEmail + "", driver.FindElement(msgError).Text);
        }
        public static void ValidateExpiredAccountMessage(string contactName, string contactPhone, string contactEmail)
        {
            Assert.IsTrue(driver.FindElement(msgError).Displayed);
            Assert.AreEqual("Your Account has expired please contact " + contactName + " , " + contactPhone + " " + contactEmail + "", driver.FindElement(msgError).Text);
        }
        public static void ValidateLockedAccountMessage(string contactName, string contactPhone, string contactEmail)
        {
            Assert.IsTrue(driver.FindElement(msgError).Displayed);
            Assert.AreEqual("Your account has been locked Please Contact " + contactName + ", " + contactPhone + ", " + contactEmail + ".", driver.FindElement(msgError).Text);
        }
    }
}
