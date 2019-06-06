using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Customer
{
    class PatientSummary
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By divPolyprescriber = By.Id("ps");
        private static readonly By lnkPolyprescriber = By.Id("pa");
        private static readonly By lnkViewAllPatientDetails = By.Id("vda");

        private static readonly By tblPopupTable = By.XPath("//div[@class='container menu_in_tbl']/div/table");

        public static void MouseOverPolyprescriber()
        {
            Actions mouseOver = new Actions(driver);
            mouseOver.MoveToElement(driver.FindElement(divPolyprescriber)).Perform();
        }
        public static void ClickPolyprescriberLink()
        {
            MouseOverPolyprescriber();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(lnkPolyprescriber).Displayed == true);
            driver.FindElement(lnkPolyprescriber).Click();
        }
        public static void ValidatePrescriberPopupTable()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(tblPopupTable).Displayed == true);
        }
        public static void ClickViewAllPatientDetailsLink()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElement(lnkViewAllPatientDetails).Displayed == true);
            System.Threading.Thread.Sleep(1000);
            driver.FindElement(lnkViewAllPatientDetails).Click();
        }
    }
}
