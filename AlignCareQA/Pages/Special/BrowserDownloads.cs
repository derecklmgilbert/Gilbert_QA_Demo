using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Special
{
    class BrowserDownloads
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By lnkDownloadTitle = By.Id("file-link");
        private static readonly By btnCloseDownload = By.Id("remove");

        public static void OpenDownloadsPage()
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("window.open()");
            System.Threading.Thread.Sleep(1000);
            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.SwitchTo().Window(tabs[1]);
            driver.Url = "about:downloads";
            System.Threading.Thread.Sleep(1000);
        }
        public static string GetDownloadFileName()
        {
            IWebElement manager = driver.FindElement(By.CssSelector("body/deep/downloads-manager"));
            var shadow = ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot;", manager);
            IWebElement item = ((IWebElement)shadow).FindElement(By.TagName("downloads-item"));
            shadow = ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].shadowRoot;", item);
            IWebElement link = ((IWebElement)shadow).FindElement(By.CssSelector("div#title-area>a"));
            string filename = link.Text;
            ((IWebElement)shadow).FindElement(btnCloseDownload).Click();

            List<string> tabs = new List<string>(driver.WindowHandles);
            driver.Close();
            driver.SwitchTo().Window(tabs[0]);
            return filename;
        }
    }
}
