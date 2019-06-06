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

        public static void ClickPatients()
        {
            driver.FindElement(btnPatients).Click();
        }
        public static void ClickFirstSearchResult()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(tblSearchResults).Displayed == true);
            driver.FindElement(By.XPath(tblSearchResultsXpath + "/tbody/tr[1]/td[1]/a")).Click();
        }
    }
}
