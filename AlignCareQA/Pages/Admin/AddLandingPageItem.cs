using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        private static readonly By btnSave = By.XPath("//button[text()='Save']");
    }
}
