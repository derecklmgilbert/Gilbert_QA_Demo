using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{
    class Care
    {
        private static IWebDriver driver = UITests.driver;
        private static readonly By btnPatients = By.Id("tbSearchData");
        private static readonly string tblSearchResultsXpath = "//table[@id='tblBeneficiaryResult']";
        private static readonly By tblSearchResults = By.XPath(tblSearchResultsXpath);

        private static readonly By btnPatientListDownload = By.XPath("//a[contains(@href, 'ExportSearchResults')]");
        private static readonly By btnHCCDownload = By.XPath("//a[contains(@href, 'ExportHCCResults')]");
        private static readonly By btnPDCDownload = By.XPath("//a[contains(@href, 'ExportPDCResults')]");

        private static int colPatientID = 1;
        private static int colLastName = 2;
        private static int colFirstName = 3;
        private static int colDateOfBirth = 4;
        private static int colPredominantPrescribers = 5;
        private static int colMERLevel = 6;
        private static int colMERActualLevel = 7;

        public static void ClickPatients()
        {
            driver.FindElement(btnPatients).Click();
        }
        public static void ClickFirstSearchResult()
        {
            ClickSearchResult(1);
        }
        public static void ClickSearchResult(int indexFrom1)
        {
            WaitForResultsToLoad();
            driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + indexFrom1 + "]/td[" + colPatientID + "]/a")).Click();
        }
        public static string GetSearchResultFirstName(int indexFrom1)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + indexFrom1 + "]/td[" + colFirstName + "]")).Text;
        }
        public static string GetSearchResultLastName(int indexFrom1)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + indexFrom1 + "]/td[" + colLastName + "]")).Text;
        }
        private static void WaitForResultsToLoad()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(tblSearchResults).Displayed == true);
        }
        public static void DownloadPatientList()
        {
            WaitForResultsToLoad();
            ClickDownloadPatientListButton();

        }
        private static void ClickDownloadPatientListButton()
        {
            driver.FindElement(btnPatientListDownload).Click();
        }
        public static void DownloadHCC()
        {
            WaitForResultsToLoad();
            ClickDownloadHCCButton();

        }
        private static void ClickDownloadHCCButton()
        {
            driver.FindElement(btnHCCDownload).Click();
        }
        public static void DownloadPDC()
        {
            WaitForResultsToLoad();
            ClickDownloadPDCButton();

        }
        private static void ClickDownloadPDCButton()
        {
            driver.FindElement(btnPDCDownload).Click();
        }
    }
}
