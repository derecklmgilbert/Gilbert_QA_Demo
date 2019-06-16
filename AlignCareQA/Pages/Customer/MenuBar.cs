using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{ 
    class MenuBar
    {
        private static IWebDriver driver = UITests.driver;
        private static readonly By lnkMenuDropdown = By.XPath("//*[@menu-item='menu']");
        private static readonly By lnkLandingPage = By.XPath("//a[@title='Landing Page']");
        private static readonly By lnkAdmin = By.XPath("//a/div[contains(@class,'adminmenu')]");
        private static readonly By lnkMessages = By.XPath("//i[contains(@class,'fa-envelope-o')]/..");
        private static readonly By lnkClearAllMessages = By.LinkText("Clear all");

        public static void ExpandWaffleMenu()
        {
            driver.FindElement(lnkMenuDropdown).Click();

        }
        public static void ClickLandingPageLink()
        {
            driver.FindElement(lnkLandingPage).Click();
        }
        public static void ClickAdminLink()
        {
            driver.FindElement(lnkAdmin).Click();
        }
        public static void ValidateAdminLinkDoesntExist()
        {
            Assert.Zero(driver.FindElements(lnkAdmin).Count);
        }
        public static void ExpandMessages()
        {
            driver.FindElement(lnkMessages).Click();
        }

        public static void ClearAllMessages()
        {
            ExpandMessages();
            driver.FindElement(lnkClearAllMessages).Click();
            driver.SwitchTo().Alert().Accept();
            ExpandMessages();
        }
        public static void WaitForReportToGenerateByPatientName(string patientName)
        {
            string xpath = "//div[@class='dropdown-container']//a[contains(text(), '" + patientName + "')]";
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(x => x.FindElements(By.XPath(xpath)).Count > 0);
            System.Threading.Thread.Sleep(10000);
            driver.FindElement(lnkLandingPage).Click();
            ExpandMessages();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(x => x.FindElement(By.XPath(xpath)).Displayed);
        }
        public static void DownloadPatientReportByPatientName(string patientName)
        {
            string xpath = "//div[@class='dropdown-container']//a[contains(text(), '" + patientName + "')]";
            driver.FindElement(By.XPath(xpath)).Click();
        }
    }
}
