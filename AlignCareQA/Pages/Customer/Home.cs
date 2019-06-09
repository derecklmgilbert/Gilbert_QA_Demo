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
        private static readonly By btnClinicalManagementOpportunities = By.XPath("//div/h3[text()='Clinical Management Opportunities']/../div/button");

        private static readonly By lnkRiskProfileSummary = By.PartialLinkText("Risk Profile Summary");

        public static void ExpandRiskProfile()
        {
            driver.FindElement(btnRiskProfile).Click();
        }
        public static void ClickRiskProfileSummary()
        {
            driver.FindElement(lnkRiskProfileSummary).Click();
        }
        public static void ExpandClinicalManagementOpportunities()
        {
            driver.FindElement(btnClinicalManagementOpportunities).Click();
        }
        public static void ValidateParentLandingPageItemExistsByName(string itemName)
        {
            Assert.NotZero(driver.FindElements(By.XPath("//li/a[contains(text(),'" + itemName + "')]")).Count);
        }
        public static void ClickParentLandingPageItemByName(string itemName)
        {
            driver.FindElement(By.XPath("//li/a[contains(text(),'" + itemName + "')]")).Click();
        }
        public static void ValidateChildLandingPageItemExistsByName(string parentName, string itemName)
        {
            Assert.NotZero(driver.FindElements(By.XPath("//li/a[contains(text(),'" + parentName + "')]/../div/table/tbody/tr/td[text()='" + itemName + "']")).Count);
        }
        public static void ValidateParentLandingPageItemDoesNotExist(string itemName)
        {
            Assert.Zero(driver.FindElements(By.XPath("//li/a[contains(text(),'" + itemName + "')]")).Count);
        }
    }
}
