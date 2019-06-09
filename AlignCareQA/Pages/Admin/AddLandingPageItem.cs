using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;


namespace AlignCareQA.Pages.Admin
{
    class AddLandingPageItem
    {
        private static IWebDriver driver = UITests.driver;


        private static readonly By ddlModuleType = By.Id("ModuleType");
        private static readonly By ddlPanelType = By.Id("PanelType");
        private static readonly By ddlPanelName = By.Id("PanelName");
        private static readonly By txtPanelItemName = By.Id("PanelItemName");
        private static readonly By ddlCustomerName = By.Id("CustomerId");
        private static readonly By ddlSavedSearch = By.Id("SavedSearchName");
        private static readonly By ddlParentPanelItem = By.Id("ParentPanelItem");
        private static readonly By ckbxParent = By.Id("IsChildItems");
        private static readonly By ckbxStandard = By.Id("IsStandard");
        private static readonly By btnSave = By.XPath("//button/span[text()='Save']");
        private static readonly By msgErrorMessage = By.Id("divErrorMessage");
        private static readonly By msgSuccessMessage = By.Id("divSuccessMessage");

        public static void SetModuleType(string option)
        {
            driver.FindElement(ddlModuleType).Click();
            driver.FindElement(By.XPath("//option[text()='" + option + "']")).Click();
        }
        public static void SetPanelType(string option)
        {
            driver.FindElement(ddlPanelType).Click();
            driver.FindElement(By.XPath("//option[text()='" + option + "']")).Click();
        }
        public static void SetPanelName(string option)
        {
            driver.FindElement(ddlPanelName).Click();
            driver.FindElement(By.XPath("//option[text()='" + option + "']")).Click();
        }
        public static void SetPanelItemName(string text)
        {
            driver.FindElement(txtPanelItemName).Clear();
            driver.FindElement(txtPanelItemName).SendKeys(text);
        }
        public static void SetCustomerName(string option)
        {
            driver.FindElement(ddlCustomerName).Click();
            driver.FindElement(By.XPath("//option[text()='" + option + "']")).Click();
        }
        public static void SetSavedSearch(string option)
        {
            driver.FindElement(ddlSavedSearch).Click();
            driver.FindElement(By.XPath("//option[contains(text(),'" + option + "')]")).Click();
        }
        public static void SetParentPanelItem(string option)
        {
            driver.FindElement(ddlParentPanelItem).Click();
            driver.FindElement(By.XPath("//option[contains(text(),'" + option + "')]")).Click();
        }
        public static void SetParentCheckbox(bool option)
        {
            if (option)
            {
                if (!driver.FindElement(ckbxParent).Selected)
                {
                    driver.FindElement(ckbxParent).Click();
                }
            }
            else
            {
                if (driver.FindElement(ckbxParent).Selected)
                {
                    driver.FindElement(ckbxParent).Click();
                }
            }
        }
        public static void SetStandardCheckbox(bool option)
        {
            if (option)
            {
                if (!driver.FindElement(ckbxStandard).Selected)
                {
                    driver.FindElement(ckbxStandard).Click();
                }
            }
            else
            {
                if (driver.FindElement(ckbxStandard).Selected)
                {
                    driver.FindElement(ckbxStandard).Click();
                }
            }
        }
        public static void ClickSaveButton()
        {
            driver.FindElement(btnSave).Click();
        }
        public static void ValidateLandingPageAddedSuccess()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(d => d.FindElement(msgSuccessMessage).Displayed == true);
            Assert.IsTrue(driver.FindElement(msgSuccessMessage).Displayed);
            Assert.AreEqual("Record submitted successfully.", driver.FindElement(msgSuccessMessage).Text);
        }
    }
}
