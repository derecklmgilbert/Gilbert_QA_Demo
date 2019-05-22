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

        public static void LoginWithDefault()
        {
            driver.FindElement(txtUsername).SendKeys("dereck.gilbert@aligncare.com");
            driver.FindElement(txtPassword).SendKeys("HelloW0rld123!");
            driver.FindElement(btnSubmit).Click();
            
        }
    }
}
