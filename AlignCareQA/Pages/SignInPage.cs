using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo.Pages
{
    public class SignInPage
    {
        private static readonly By lnkSignIn = By.LinkText("Sign In");
        private static readonly By txtEmail = By.Id("email");
        private static readonly By btnGetStarted = By.XPath("//button[@data-automation='signup-submit-button']");
        private static readonly By txtPassword = By.Id("password");

        private static readonly string email = "derecklmgilbert@gmail.com";
        private static readonly string password = "TESTtest123!";

        public static void Login()
        {
            SeleniumHelper.driver.FindElement(txtEmail).SendKeys(email);
            SeleniumHelper.driver.FindElement(btnGetStarted).Click();
            SeleniumHelper.WaitForElement(txtPassword);
            SeleniumHelper.driver.FindElement(txtPassword).SendKeys(password);
            SeleniumHelper.driver.FindElement(btnGetStarted).Click();
        }
    }
}
