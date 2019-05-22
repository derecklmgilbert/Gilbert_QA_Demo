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

namespace AlignCareQA
{
    [TestFixture]
    public class UITests
    {
        public static ChromeDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            var currentDirectory = Directory.GetCurrentDirectory();
            var driverService = ChromeDriverService.CreateDefaultService(currentDirectory);
            driverService.Start();
            ChromePerformanceLoggingPreferences logs = new ChromePerformanceLoggingPreferences();
            ChromeOptions options = new ChromeOptions();
            options.SetLoggingPreference(LogType.Browser, LogLevel.Severe);
            options.AddArgument("--start-maximized");
            options.AddArgument("--incognito");
            driver = new ChromeDriver(driverService, options);
            System.Threading.Thread.Sleep(5000);
        }
        [SetUp]
        public void SingleTestSetup()
        {
            driver.Url = "https://qa-presciencerx.azurewebsites.net/Account/Login";
            //Clear previous test results
            //singleTest = new Results();
            //Set test start time
            //singleTest.start = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
        }
        [OneTimeTearDown]
        public void Cleanup()
        {

            driver.Quit();
            driver = null;

            //using (StreamWriter file = File.CreateText(@"C:\Users\dereck\Documents\Test\Results.json"))
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    //serialize object directly into file stream
            //    serializer.Serialize(file, new TestRun { tests = allTests });
            //}
        }
        [TearDown]
        public void SingleTestClean()
        {
        //    //Set test end time
        //    singleTest.finish = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ssK");
        //    singleTest.testKey = TestContext.CurrentContext.Test.Properties.Get("TestKey").ToString();
        //    //Set test results
        //    if (TestContext.CurrentContext.Result.Outcome == ResultState.Success)
        //    {
        //        singleTest.status = "PASS";
        //    }
        //    else
        //    {
        //        singleTest.status = "FAIL";
        //        singleTest.evidences.Add(new Evidences { data = driver.GetScreenshot().AsBase64EncodedString, contentType = "image/jpeg", filename = "screenshot.jpg" });
        //    }
        //    try
        //    {
        //        FieldFunctions.LogOut();
        //    }
        //    catch
        //    {
        //
        //    }
        //    //Set Comment Info
        //    //Set Test Data
        //    if (testData.Count == 0)
        //    {
        //        testResultsComment.AppendLine("Please add test data method for this test");
        //    }
        //    else
        //    {
        //        //Methods for passengers
        //        testResultsComment.AppendLine(@"||Product Name||Price||Cancellation Date||Cancellation Cost||Passengers||");
        //        //Add Lines for Each Leg Type
        //        foreach (HotelLeg leg in testData.Where(x => x.GetType() == typeof(HotelLeg)))
        //        {
        //            List<Passenger> Pax = new List<Passenger>();
        //            foreach (Room x in leg.Rooms)
        //            {
        //                foreach (Passenger y in x.Passengers)
        //                {
        //                    Pax.Add(y);
        //                }
        //            }
        //            testResultsComment.AppendLine("|" + leg.Name + "|" + leg.BaseCost + "|" + leg.CancellationDate.ToShortDateString() + "|" + leg.CancellationCost + "|" + Pax.Where(x => x.Type == PaxType.Adult).Count().ToString() + " Adults " + Pax.Where(x => x.Type == PaxType.Child).Count().ToString() + " Children" + "|");
        //        }
        //        foreach (TransferLeg leg in testData.Where(x => x.GetType() == typeof(TransferLeg)))
        //        {
        //            List<Passenger> Pax = new List<Passenger>();
        //            foreach (Passenger y in leg.Passengers)
        //            {
        //                Pax.Add(y);
        //            }
        //            testResultsComment.AppendLine("|" + leg.Name + "|" + leg.BaseCost + "|" + leg.CancellationDate.ToShortDateString() + "|" + leg.CancellationCost + "|" + Pax.Where(x => x.Type == PaxType.Adult).Count().ToString() + " Adults " + Pax.Where(x => x.Type == PaxType.Child).Count().ToString() + " Children" + "|");
        //        }
        //        foreach (SightseeingLeg leg in testData.Where(x => x.GetType() == typeof(SightseeingLeg)))
        //        {
        //            List<Passenger> Pax = new List<Passenger>();
        //            foreach (Passenger y in leg.Passengers)
        //            {
        //                Pax.Add(y);
        //            }
        //            testResultsComment.AppendLine("|" + leg.Name + "|" + leg.BaseCost + "|" + leg.CancellationDate.ToShortDateString() + "|" + leg.CancellationCost + "|" + Pax.Where(x => x.Type == PaxType.Adult).Count().ToString() + " Adults " + Pax.Where(x => x.Type == PaxType.Child).Count().ToString() + " Children" + "|");
        //        }
        //    }
        //
        //    //Fail Reason
        //    foreach (AssertionResult assert in TestContext.CurrentContext.Result.Assertions)
        //    {
        //        testResultsComment.AppendLine(assert.Message);
        //    }
        //    //Console Logs from Browser
        //    logEntries = driver.Manage().Logs.GetLog(LogType.Browser);
        //    foreach (LogEntry entry in logEntries)
        //    {
        //        testResultsComment.AppendLine(entry.Timestamp.ToLongDateString() + " " + entry.Level + " " + entry.Message);
        //    }
        //    //Stack Trace from Exceptions
        //    testResultsComment.AppendLine("------------Test Stack-----------");
        //    testResultsComment.AppendLine(TestContext.CurrentContext.Result.StackTrace);
        //    singleTest.comment = testResultsComment.ToString();
        //    testResultsComment.Clear();
        //    //Add test info to full run
        //    allTests.Add(new Results { testKey = singleTest.testKey, start = singleTest.start, finish = singleTest.finish, status = singleTest.status, comment = singleTest.comment, evidences = singleTest.evidences });
        }

        //Safe for Live
        [Test]
        [Category("UAT")]
        public void Test()
        {
            Pages.Customer.Login.LoginWithDefault();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.TurnOnInNetworkDisplay();
        }

    }
}
