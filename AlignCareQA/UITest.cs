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
        public static IWebDriver driver;

        [OneTimeSetUp]
        public void Init()
        {
            driver = Helpers.Browser.GetRandomBrowser();
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


        [Test]
        [Category("QA")]
        public void Test()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.TurnOnInNetworkDisplay();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickUpdateCustomerButton();
            Pages.Admin.EditCustomer.VerifySuccessMessage();
            Pages.Admin.EditCustomer.ClickBackToListLink();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandRiskProfile();
            Pages.Customer.Home.ClickRiskProfileSummary();
            Pages.Customer.Care.ClickPatients();
            Pages.Customer.Care.ClickFirstSearchResult();
            //Pages.Customer.PatientSummary.ClickPolyprescriberLink();
           // Pages.Customer.PatientSummary.ValidatePrescriberPopupTable();
            Pages.Customer.PatientSummary.ClickViewAllPatientDetailsLink();
            Pages.Customer.AllPatientDetails.ClickReportButton();
        }
        [Test]
        [Category("CreateUser")]
        public void CreateValidUser()
        {
            Data.User user = new Data.User() {username="Test", password= "TESTTEST123", confirmpassword= "TESTTEST123", active=true}; 
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.CreateNewUser(user);

        }
        [Test]
        [Category("CreateUser"), Category("Rerun Safe")]
        public void CreateUserPasswordTooShort()
        {
            Data.User user = new Data.User() { username = "TestFail", password = "TEST123", confirmpassword = "TEST123", active = true };
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.CreateNewUser(user);
            Pages.Admin.AddUser.ValidatePasswordLengthError();

        }
        [Test]
        [Category("CreateUser"), Category("Rerun Safe")]
        public void CreateUserPasswordTooLong()
        {
            Data.User user = new Data.User() { username = "TestFail", password = "TESTTESTTESTTESTTEST123", confirmpassword = "TESTTESTTESTTESTTEST123", active = true };
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.CreateNewUser(user);
            Pages.Admin.AddUser.ValidateInvalidPassword();

        }
        [Test]
        [Category("CreateUser"), Category("Rerun Safe")]
        public void CreateUserPasswordNoNumbers()
        {
            Data.User user = new Data.User() { username = "TestFail", password = "TESTTEST", confirmpassword = "TESTTEST", active = true };
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.CreateNewUser(user);
            Pages.Admin.AddUser.ValidateInvalidPassword();

        }
        [Test]
        [Category("CreateUser"), Category("Rerun Safe")]
        public void CreateUserDuplicateUsername()
        {
            Data.User user = new Data.User() { username = "Test", password = "TESTTEST123", confirmpassword = "TESTTEST123", active = true };
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.CreateNewUser(user);
            Pages.Admin.AddUser.ValidateDuplicateAccountMessage();

        }
        [Test]
        [Category("Login")]
        public void LoginInvalidPassword()
        {
            Pages.Customer.Login.AttemptLogin("dereck.gilbert@aligncare.com", "TESTTEST123");
            Pages.Customer.Login.ValidateInvalidPasswordMessage();
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void LoginDormantAccount()
        {
            Pages.Customer.Login.AttemptLogin("TestDormant", "TESTTEST123");
            Pages.Customer.Login.ValidateDormantAccountMessage();
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void LoginExpiredAccount()
        {
            Pages.Customer.Login.AttemptLogin("TestExpired", "TESTTEST123");
            Pages.Customer.Login.ValidateExpiredAccountMessage();
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void Login3FailsLocked()
        {
            Pages.Customer.Login.AttemptLogin("dereck.gilbert@aligncare.com", "TESTTEST123");
            Pages.Customer.Login.ValidateInvalidPasswordMessage();
        }
        [Test]
        [Category("Permissions"), Category("Rerun Safe")]
        public void ValidateSuperAdminPermissions()
        {
            //Create Saved Search for PrescienceRx and Landing Page Category.

            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickCreateCustomerLink();
            Pages.Admin.MenuBar.ClickAddLandingPage();
            Pages.Admin.MenuBar.ClickEditLandingPage();
            Pages.Admin.MenuBar.ClickManageSuperAdmin();
            Pages.Admin.MenuBar.ClickManageProperty();

        }
        [Test]
        [Category("Permissions"), Category("Rerun Safe")]
        public void ValidateStaffAdminPermissions()
        {
            Pages.Customer.Login.LoginWithStaffAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ValidateCreateCustomerLinkDoesntExist();
            Pages.Admin.MenuBar.ClickAddLandingPage();
            Pages.Admin.MenuBar.ClickEditLandingPage();
            Pages.Admin.MenuBar.ValidateManageSuperAdminLinkDoesntExist();
            Pages.Admin.MenuBar.ValidateManagePropertyLinkDoesntExist();

        }
        [Test]
        [Category("Permissions"), Category("Rerun Safe")]
        public void ValidateClientAdminPermissions()
        {
            Pages.Customer.Login.LoginWithClientAdmin();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.ClickBackToListLink();
            Pages.Admin.MenuBar.ValidateAddLandingPageLinkDoesntExist();
            Pages.Admin.MenuBar.ValidateEditLandingPageLinkDoesntExist();
            Pages.Admin.MenuBar.ValidateManageCustomersLinkDoesntExist();
            Pages.Admin.MenuBar.ValidateManagePropertyLinkDoesntExist();
            Pages.Admin.MenuBar.ValidateManageSuperAdminLinkDoesntExist();
        }
        [Test]
        [Category("Permissions"), Category("Rerun Safe")]
        public void ValidateUserPermissions()
        {
            Pages.Customer.Login.LoginWithUser();
            Pages.Customer.MenuBar.ExpandMenu();
            Pages.Customer.MenuBar.ValidateAdminLinkDoesntExist();

        }
    }
}
