using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
using AlignCareQA.Data;

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
        public static void ExpandSectionByText(string sectionName)
        {
            driver.FindElement(By.XPath("//div/h3[text()='" + sectionName +"']/../div/button")).Click();
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
        public static void ClickChildLandingPageItemByIndex(string parentName, int itemIndex)
        {
            driver.FindElement(By.XPath("//li/a[contains(text(),'" + parentName + "')]/../div/table/tbody/tr[" + (itemIndex + 1) + "]")).Click();
        }
        public static void ClickChildLandingPageItemByName(string parentName, int itemIndex)
        {
            driver.FindElement(By.XPath("//li/a[contains(text(),'" + parentName + "')]/../div/table/tbody/tr[" + (itemIndex + 1) + "]")).Click();
        }
        public static void ValidateParentLandingPageItemDoesNotExist(string itemName)
        {
            Assert.Zero(driver.FindElements(By.XPath("//li/a[contains(text(),'" + itemName + "')]")).Count);
        }
        public static List<LandingPageItem> GetLandingPageItemsBySectionName(string sectionName)
        {
            List<LandingPageItem> list = new List<LandingPageItem>();
            int parentCount = driver.FindElements(By.XPath("//div/h3[text()='" + sectionName + "']/../..//li/a")).Count;
            for (int n = 0; n < parentCount; n++)
            {
                LandingPageItem temp = new LandingPageItem
                {
                };
                string parentHelper = driver.FindElements(By.XPath("//div/h3[text()='" + sectionName + "']/../..//li/a"))[n].GetAttribute("onClick");
                temp.IsParent = (parentHelper.Contains("ShowHide") ? true : false);
                string nameHelper = driver.FindElements(By.XPath("//div/h3[text()='" + sectionName + "']/../..//li/a"))[n].GetProperty("innerText").Trim();
                temp.Name = nameHelper.Substring(0, nameHelper.Length - (nameHelper.Length - nameHelper.IndexOf(Environment.NewLine))).Trim();
                string count = driver.FindElements(By.XPath("//div/h3[text()='" + sectionName + "']/../..//li/a/span"))[n].GetProperty("innerText").Replace(",","").Trim();
                temp.Count = Convert.ToInt32(count);
                if (temp.IsParent)
                {
                    string href = driver.FindElements(By.XPath("//div/h3[text()='" + sectionName + "']/../..//li/a"))[n].GetAttribute("onClick");
                    string tableiD = href.Substring(10, href.Length - 10 - 2);
                    int childCount = driver.FindElements(By.XPath("//div[@id='" + tableiD + "']/table/tbody/tr")).Count;
                    for (int z = 0; z < childCount; z++)
                    {
                        LandingPageItem tempChild = new LandingPageItem();
                        tempChild.Name = driver.FindElement(By.XPath("//div[@id='" + tableiD + "']/table/tbody/tr[" + (z + 1) + "]/td[1]")).GetProperty("innerText");
                        string c = driver.FindElement(By.XPath("//div[@id='" + tableiD + "']/table/tbody/tr[" + (z + 1) + "]/td[2]")).GetProperty("innerText");
                        tempChild.Count = Convert.ToInt32(c);
                        tempChild.IsParent = false;
                        temp.Children.Add(tempChild);
                    }
                }
                list.Add(temp);
            }
            return list;
        }
        public static int GetCountOfClinicalManagementOpportunitiesParents()
        {
            return driver.FindElements(By.XPath("//div/h3[text()='Clinical Management Opportunities']//li/a")).Count;
        }
    }
}
