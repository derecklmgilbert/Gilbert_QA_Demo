using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestDemo.Helpers
{
    class Browser
    {
        public static IWebDriver GetRandomBrowser()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var chromeService = ChromeDriverService.CreateDefaultService(currentDirectory);
            chromeService.Start();
            ChromePerformanceLoggingPreferences logs = new ChromePerformanceLoggingPreferences();
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            options.AddArgument("--start-maximized");
            options.AddArgument("--incognito");
            return new ChromeDriver(chromeService, options);
        }
    }
}
