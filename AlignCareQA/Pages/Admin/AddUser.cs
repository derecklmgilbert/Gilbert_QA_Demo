using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class AddUser
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By txtUsername = By.Id("User_UserName");
        private static readonly By ddlRoles = By.Id("roleList");
        private static readonly By txtPassword = By.Id("User_Password");
        private static readonly By txtConfirmPassword = By.Id("User_ConfirmPassword");
        private static readonly By txtFirstName = By.Id("User_FirstName");
        private static readonly By txtLastName = By.Id("User_LastName");
        private static readonly By txtPhone = By.Id("User_Phone");
        private static readonly By txtEmail = By.Id("User_Email");
        private static readonly By txtDaysInExpiration = By.Id("User_DaysInExpiration");
        private static readonly By txtDaysInDormancy = By.Id("User_DaysInDormancy");
        private static readonly By ckbxActive = By.Id("User_IsActive");
        private static readonly By ckbxDormant = By.Id("User_IsDormant");
        private static readonly By ckbxExpired = By.Id("User_IsExpired");
        private static readonly By ckbxLocked = By.Id("User_IsLocked");
        private static readonly By ckbxChangePasswordOnNextLogin = By.Id("User_AdminReset");
        private static readonly By btnRegister = By.XPath("//input[@value='Register']");

        private static readonly By lnkBackToList = By.LinkText("Back to List");

        private static readonly By lblConfirmPasswordValidationError = By.XPath("//input[@id='User_ConfirmPassword']/../span[@class='field-validation-error']");
        private static readonly By lblPasswordValidationError = By.XPath("//input[@id='User_Password']/../span[@class='field-validation-error']");
        private static readonly By msgErrorMessage = By.Id("divErrorMessage");

        private static void SetUsername(string username)
        {
            driver.FindElement(txtUsername).SendKeys(username);
        }
        private static void SetRole(string role)
        {

        }
        private static void SetPassword(string password)
        {
            driver.FindElement(txtPassword).SendKeys(password);
        }
        private static void SetPasswordConfirmation(string password)
        {
            driver.FindElement(txtConfirmPassword).SendKeys(password);
        }
        private static void SetFirstName(string name)
        {
            driver.FindElement(txtFirstName).SendKeys(name);
        }
        private static void SetLastname(string name)
        {
            driver.FindElement(txtLastName).SendKeys(name);
        }
        private static void SetPhone(string phone)
        {
            driver.FindElement(txtLastName).SendKeys(phone);
        }
        private static void SetEmail(string email)
        {
            driver.FindElement(txtLastName).SendKeys(email);
        }
        private static void SetDaysInExpiration(string days)
        {
            driver.FindElement(txtLastName).SendKeys(days);
        }
        private static void SetDaysInDormancy(string days)
        {
            driver.FindElement(txtLastName).SendKeys(days);
        }
        private static void SetActiveStatus(bool active)
        {
            if (active)
            {
                if (!driver.FindElement(ckbxActive).Selected)
                {
                    driver.FindElement(ckbxActive).Click();
                }
            }
            else
            {
                if (driver.FindElement(ckbxActive).Selected)
                {
                    driver.FindElement(ckbxActive).Click();
                }
            }
        }
        private static void ClickRegisterButton()
        {
            driver.FindElement(btnRegister).Click();
        }
        public static void ClickBackToListLink()
        {
            driver.FindElement(lnkBackToList).Click();
        }
        public static void ValidatePasswordMismatch()
        {
            Assert.IsTrue(driver.FindElement(lblConfirmPasswordValidationError).Displayed);
            Assert.AreEqual("The password and confirmation password do not match.", driver.FindElement(lblConfirmPasswordValidationError).Text);
        }
        public static void ValidatePasswordLengthError()
        {
            Assert.IsTrue(driver.FindElement(lblPasswordValidationError).Displayed);
            Assert.AreEqual("The Password must be at least 8 characters long.", driver.FindElement(lblPasswordValidationError).Text);

        }
        public static void ValidateInvalidPassword()
        {
            Assert.IsTrue(driver.FindElement(msgErrorMessage).Displayed);
            Assert.AreEqual("Min Length - 8 Characters<br />Max Length - 20 Characters<br />At least 1 Alphabet<br />At least 1 number or special character<br />Up to 3 repeating characters<br />", driver.FindElement(msgErrorMessage).Text);
        }
        public static void ValidateDuplicateAccountMessage()
        {
            Assert.IsTrue(driver.FindElement(msgErrorMessage).Displayed);
            Assert.AreEqual("Username Test already exists", driver.FindElement(msgErrorMessage).Text);
        }
        public static void CreateNewUser(Data.User user)
        {

            SetUsername(user.username);
            SetPassword(user.password);
            SetPasswordConfirmation(user.confirmpassword);
            SetActiveStatus(user.active);
            ClickRegisterButton();

        }
    }
}
