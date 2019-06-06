using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{
    class Home
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By btnRiskProfile = By.XPath("//div/h3[text()='Risk Profile']/../div/button");

        private static readonly By lnkRiskProfileSummary = By.PartialLinkText("Risk Profile Summary");

        public static void ExpandRiskProfile()
        {
            driver.FindElement(btnRiskProfile).Click();
        }
        public static void ClickRiskProfileSummary()
        {
            driver.FindElement(lnkRiskProfileSummary).Click();
        }
    }
}
