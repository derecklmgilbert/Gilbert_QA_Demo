using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{
    class MustChangePassword
    {
        private static IWebDriver driver = UITests.driver;
        private static readonly By msgErrorMessage = By.Id("divErrorMessage");
        private static readonly By lblUsername = By.TagName("strong");
        private static readonly By txtCurrentPassword = By.Id("OldPassword");
        private static readonly By txtNewPassword = By.Id("NewPassword");
        private static readonly By txtConfirmPassword = By.Id("ConfirmPassword");
        private static readonly By btnChangePassword = By.XPath("//input[@value='Change password']");

        public static void ValidateChangePasswordPageIsOpen(string username)
        {
            Assert.AreEqual("Your password has expired, Please change your password before proceed", driver.FindElement(msgErrorMessage).Text);
            Assert.AreEqual(username, driver.FindElement(lblUsername).Text);
            Assert.True(driver.FindElement(txtCurrentPassword).Displayed);
            Assert.True(driver.FindElement(txtNewPassword).Displayed);
            Assert.True(driver.FindElement(txtConfirmPassword).Displayed);
            Assert.True(driver.FindElement(btnChangePassword).Displayed);
        }
    }
}
