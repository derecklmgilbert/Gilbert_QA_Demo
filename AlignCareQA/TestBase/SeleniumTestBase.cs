using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework.Interfaces;
using System.IO; 
using Newtonsoft.Json;
using RestSharp;
using OpenQA.Selenium.Support.UI;

namespace TestDemo
{
    [TestFixture]
    public abstract class SeleniumTestBase
    {
        
        [OneTimeSetUp]
        public void Init()
        {
            SeleniumHelper.driver = Helpers.Browser.GetRandomBrowser();
            SeleniumHelper.driver.Url = "https://www.eventbrite.com/manage/events/create/";
            Pages.SignInPage.Login();
        }
        [SetUp]
        public void SingleTestSetup()
        {
            SeleniumHelper.driver.Url = "https://www.eventbrite.com/manage/events/create/";
            Pages.CreatePage.DismissBasicsModal();
        }
        [OneTimeTearDown]
        public void Cleanup()
        {
            SeleniumHelper.driver.Quit();
            SeleniumHelper.driver = null;
        }
        [TearDown]
        public void SingleTestClean()
        {
            Pages.CreatePage.ClickDiscardButton();
        }
    }
    public class SeleniumHelper
    {
        public static IWebDriver driver;
        public static void SafetyClick(By element)
        {
            WaitForElement(element);
            driver.FindElement(element).Click();
        }
        public static void WaitForElement(By element, int timeLimit=10)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeLimit)).Until(x => x.FindElements(element).Count > 0 && x.FindElement(element).Displayed);
        }
    }
}
