using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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

        //Elastic Search Type

        public static void TurnOnInNetworkDisplay()
        {
            if(!driver.FindElement(ckbxIsInNetworkDisplay).Selected)
            {
                driver.FindElement(ckbxIsInNetworkDisplay).Click();
            }
        }

    }
}
