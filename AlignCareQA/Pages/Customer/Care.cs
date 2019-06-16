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
        private static readonly By btnD2DDownload = By.XPath("//a[contains(@href, 'ExportD2DInteractions')]");

        private static int colPatientID = 1;
        private static int colLastName = 2;
        private static int colFirstName = 3;
        private static int colDateOfBirth = 4;
        private static int colPredominantPrescribers = 5;
        private static int colMERLevel = 6;
        private static int colMERActualLevel = 7;

        private static readonly By errorMessage = By.Id("divErrorMessage");

        public static void ClickPatients()
        {
            WaitForPageToLoad();
            driver.FindElement(btnPatients).Click();
        }
        public static void ClickFirstSearchResult()
        {
            ClickSearchResult(1);
        }
        public static void ClickSearchResult(int index)
        {
            WaitForResultsToLoad();
            driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colPatientID + "]/a")).Click();
        }
        public static string GetSearchResultID(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colPatientID + "]")).Text;
        }
        public static string GetSearchResultFirstName(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colFirstName + "]")).Text;
        }
        public static string GetSearchResultLastName(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colLastName + "]")).Text;
        }
        public static string GetSearchResultDOB(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colDateOfBirth + "]")).Text;
        }
        public static string GetSearchResultPredominantPrescribers(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colPredominantPrescribers + "]")).Text;
        }
        public static string GetSearchResultMERLevel(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colMERLevel + "]")).Text;
        }
        public static string GetSearchResultMERActualLevel(int index)
        {
            WaitForResultsToLoad();
            return driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[" + (index + 1) + "]/td[" + colMERActualLevel + "]")).Text;
        }
        private static void WaitForResultsToLoad()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(tblSearchResults).Displayed == true || (d.FindElement(errorMessage).Displayed == true && d.FindElement(errorMessage).Text == "No result found."));
        }
        public static void WaitForPageToLoad()
        {
            if (driver.FindElement(By.XPath("//li[@class='active']/a")).Text.Contains("Summary"))
            {
                new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(By.Id("pr")).Displayed == true);
            }
            else
            {
                WaitForResultsToLoad();
            }

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
        private static void ClickDownloadD2DButton()
        {
            driver.FindElement(btnD2DDownload).Click();
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
        public static void DownloadD2D()
        {
            WaitForResultsToLoad();
            ClickDownloadD2DButton();
        }
        private static void ClickDownloadPDCButton()
        {
            driver.FindElement(btnPDCDownload).Click();
        }
        public static void ValidateNumberOfResults(int expectedCount, string itemName)
        {
            WaitForResultsToLoad();
            if (expectedCount > 1000)
            {
                Assert.AreEqual(expectedCount, GetResultsCountFromErrorMessage(), "Item " + itemName + " displayed count " + expectedCount + " on landing page, but search returned " + GetResultsCountFromErrorMessage());
            }
            else if(expectedCount != 0)
            {
                Assert.AreEqual(expectedCount, GetResultsCountFromPagination(), "Item " + itemName + " displayed count " + expectedCount + " on landing page, but search returned " + GetResultsCountFromPagination());
            }
            else
            {
                Assert.AreEqual("No result found.", driver.FindElement(errorMessage).Text);
            }
        }
        private static int GetResultsCountFromPagination()
        {
            if(driver.FindElement(errorMessage).Displayed && driver.FindElement(errorMessage).Text == "No result found.")
            {
                return 0;
            }
            string paginationText = driver.FindElement(By.ClassName("search-item-count-text")).Text;
            string subtext = paginationText.Substring(paginationText.IndexOf("of") + 3, paginationText.IndexOf("items")-(paginationText.IndexOf("of") + 3)).Trim();
            return Convert.ToInt32(subtext);
        }
        private static int GetResultsCountFromErrorMessage()
        {
            if (driver.FindElement(errorMessage).Displayed && driver.FindElement(errorMessage).Text == "No result found.")
            {
                return 0;
            }
            string paginationText = driver.FindElement(errorMessage).Text;
            return Convert.ToInt32(paginationText.Substring(paginationText.IndexOf("(") + 1, (paginationText.IndexOf(")")) - (paginationText.IndexOf("(") + 1)).Replace(",",""));
        }
    }
}
