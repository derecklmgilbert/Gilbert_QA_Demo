using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class Home
    {
        private static ChromeDriver driver = UITests.driver;
        private static string tblCustomersXpath = "//table[@id='tblCustomers']";
        private static readonly By tblCustomers = By.XPath(tblCustomersXpath);

        public static void ClickEditCustomerFromTable(string CustomerName)
        {
            driver.FindElement(By.XPath(tblCustomersXpath + @"/tbody/tr/td[text()='" + CustomerName + @"']/../td[4]")).Click();
        }
        public static void ClickSelectCustomerFromTable(string CustomerName)
        {
            driver.FindElement(By.XPath(tblCustomersXpath + @"/tbody/tr/td[text()='" + CustomerName + @"']/../td[6]")).Click();
        }
    }
}
