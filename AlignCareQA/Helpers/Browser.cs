using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AlignCareQA.Helpers
{
    class Browser
    {
        public static IWebDriver GetRandomBrowser()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            Random rnd = new Random();
            int browser = rnd.Next(3, 4);
            switch (browser)
            {
                //case 1:
                //    var operaService = OpenQA.Selenium.Opera.OperaDriverService.CreateDefaultService(currentDirectory);
                //    operaService.Start();
                //    return new OpenQA.Selenium.Opera.OperaDriver(operaService, new OpenQA.Selenium.Opera.OperaOptions() { BinaryLocation = @"C:\Users\dereck.gilbert\AppData\Local\Programs\Opera\60.0.3255.106\opera.exe" });
                //case 2:
                //    var ffService = OpenQA.Selenium.Firefox.FirefoxDriverService.CreateDefaultService(currentDirectory);
                //    ffService.Start();
                //    return new OpenQA.Selenium.Firefox.FirefoxDriver(ffService, new OpenQA.Selenium.Firefox.FirefoxOptions() { BrowserExecutableLocation = @"C:\Users\dereck.gilbert\AppData\Local\Mozilla Firefox\firefox.exe" });
                //    
                case 3:
                    var chromeService = ChromeDriverService.CreateDefaultService(currentDirectory);
                    chromeService.Start();
                    ChromePerformanceLoggingPreferences logs = new ChromePerformanceLoggingPreferences();
                    ChromeOptions options = new ChromeOptions();
                    options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
                    options.AddArgument("--start-maximized");
                    options.AddArgument("--incognito");
                    return new ChromeDriver(chromeService, options);
                default:

                    var defaultService = ChromeDriverService.CreateDefaultService(currentDirectory);
                    defaultService.Start();
                    return new ChromeDriver(defaultService);

            }
        }

            
    }
}
