using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class EditCustomer
    {
        private static ChromeDriver driver = UITests.driver;

        //General Info
        private static readonly By txtCustomerId = By.Name("customerId");
        private static readonly By txtCustomerName = By.Name("customerName");
        private static readonly By ddlCustomerType = By.Id("Customer_CustomerType");
        private static readonly By txtElasticSearchUrl = By.Name("elasticSearchURL");
        private static readonly By txtElasticSearchSecurityKey = By.Name("elasticSearchSecurityKey");
        private static readonly By txtRedisCacheUrl = By.Name("radisCacheURL");
        private static readonly By txtReportUrl = By.Name("reportURL");
        private static readonly By ckbxTwoFactorAuthentication = By.Name("twoFactorAuthentication");
        private static readonly By ckbxIsInNetworkDisplay = By.Name("IsInNetworkDisplay");
        private static readonly By ckbxDashboard = By.Name("dashboard");
        private static readonly By ckbxSSO = By.Name("sso");
        //private static readonly By ckbxCare = By.Name("sso");
        //private static readonly By ckbxQuality = By.Name("sso");
        //private static readonly By ckbxHCC = By.Name("sso");
        //private static readonly By ckbxFraud = By.Name("sso");
        //private static readonly By ckbxModel = By.Name("sso");
        //private static readonly By ckbxNewMember = By.Name("sso");


        //Elastic Search Index
        private static readonly By txtIndexName = By.XPath("//input[@ng-model='customer.Customer.ElasticSearchIndex.IndexName']");
        private static readonly By txtAliasName = By.XPath("//input[@ng-model='customer.Customer.ElasticSearchIndex.AliasName']");
        private static readonly By txtIndexSettings = By.Name("indexSettings");


        //Elastic Search Type

        //Common
        private static readonly By btnNext = By.XPath("//input[@value='Next']");
        private static readonly By btnPrevious = By.XPath("//input[@value='Previous']");
        private static readonly By btnUpdateCustomer = By.XPath("//button/span[text()='Update Customer']/..");
        private static readonly By lnkBackToList = By.LinkText("Back to List");
        private static readonly By alertSuccessMessage = By.Id("divSuccessMessage");
        private static readonly By alertErrorMessage = By.Id("divErrorMessage");


        public static void TurnOnInNetworkDisplay()
        {
            System.Threading.Thread.Sleep(500);
            if (!driver.FindElement(ckbxIsInNetworkDisplay).Selected)
            {
                driver.FindElement(ckbxIsInNetworkDisplay).Click();
            }
        }
        public static void ClickNextButton()
        {
            driver.FindElement(btnNext).Click();
            System.Threading.Thread.Sleep(500);
        }
        public static void ClickPreviousButton()
        {
            driver.FindElement(btnPrevious).Click();
        }
        public static void ClickUpdateCustomerButton()
        {
            driver.FindElement(btnUpdateCustomer).Click();
        }
        public static void VerifySuccessMessage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(alertSuccessMessage).Displayed == true);
            Assert.That(driver.FindElement(alertSuccessMessage).Text, Is.EqualTo("Customer submitted successfully."));
        }
        public static void ClickBackToListLink()
        {
            driver.FindElement(lnkBackToList).Click();
        }
    }
}
