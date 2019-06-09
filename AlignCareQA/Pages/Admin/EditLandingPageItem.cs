using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class EditLandingPageItem
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly string actionItemTableXpath = "//div[@id='tab_2']//table";
        private static readonly string colItemName = "1";
        private static readonly string colPanelName = "2";
        private static readonly string colParentItemName = "3";
        private static readonly string colStandard = "4";
        private static readonly string colChildElement = "5";
        private static readonly string colClientName = "6";
        private static readonly string colModule = "7";
        private static readonly string colEditDelete = "8";
        private static readonly By msgErrorMessage = By.Id("divErrorMessage");
        private static readonly By msgSuccessMessage = By.Id("divSuccessMessage");

        public static void ValidateItemExistsByName(string name)
        {
            Assert.True(driver.FindElements(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + name + "']")).Count > 0);
        }
        public static void ValidatePanelNameByItemName(string itemName, string panelName)
        {
            Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colPanelName+"]")).Text, panelName);
        }
        public static void ValidateParentItemNameByItemName(string itemName, string parentItemName)
        {
            Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colParentItemName + "]")).Text, parentItemName);
        }
        public static void ValidateStandardByItemName(string itemName, bool standard)
        {
            if (standard)
            {
                Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colStandard + "]")).Text, "Yes");
            }
            else
            {
                Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colStandard + "]")).Text, "No");
            }
        }
        public static void ValidateChildElementByItemName(string itemName, bool childElement)
        {
            if (childElement)
            {
                Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colChildElement + "]")).Text, "Yes");
            }
            else
            {
                Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colChildElement + "]")).Text, "No");
            }
        }
        public static void ValidateClientNameByItemName(string itemName, string clientName)
        {
            Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colClientName + "]")).Text, clientName);
        }
        public static void ValidateModuleByItemName(string itemName, string module)
        {
            Assert.AreEqual(driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colModule + "]")).Text, module);
        }
        public static void ClickEditByItemName(string itemName)
        {
            driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colEditDelete + "]/a[@title='Edit']")).Click();
        }
        public static void ClickDeleteByItemName(string itemName)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colEditDelete + "]/button[@title='Delete']")).Count > 0);
            driver.FindElement(By.XPath(actionItemTableXpath + "/tbody/tr/td[text()='" + itemName + "']/../td[" + colEditDelete + "]/button[@title='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            ValidateItemDeletedMessage();
        }
        public static void ValidateItemDeletedMessage()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(msgSuccessMessage).Displayed == true);
            Assert.IsTrue(driver.FindElement(msgSuccessMessage).Displayed);
            Assert.AreEqual("Record Deleted successfully.", driver.FindElement(msgSuccessMessage).Text);
        }
    }
}
