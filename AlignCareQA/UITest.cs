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
using Syroot.Windows.IO;
using AlignCareQA.Data;

namespace AlignCareQA
{
    [TestFixture]
    public class UITests
    {
        public static IWebDriver driver;
        private static List<Data.Results> AllResults = new List<Data.Results>();
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
        [Category("CreateUser")]
        public void CreateValidUser()
        {
            Data.User user = new Data.User() {username="Test", password= "TESTTEST123", confirmpassword= "TESTTEST123", active=true}; 
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickCreateLink();
            Pages.Admin.AddUser.CreateNewUser(user);
            Pages.Admin.AddUser.ValidateDuplicateAccountMessage();

        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void LoginInvalidPassword()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            string contactName = Pages.Admin.EditCustomer.GetContactPersonName();
            string contactEmail = Pages.Admin.EditCustomer.GetContactPersonEmail();
            string contactPhone = Pages.Admin.EditCustomer.GetContactPersonPhone();
            Pages.Admin.MenuBar.SignOut();
            Pages.Customer.Login.AttemptLogin("StaticTestAdmin", "TESTTEST123");
            Pages.Customer.Login.ValidateInvalidPasswordMessage(contactEmail);
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void LoginDormantAccount()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            string contactName = Pages.Admin.EditCustomer.GetContactPersonName();
            string contactEmail = Pages.Admin.EditCustomer.GetContactPersonEmail();
            string contactPhone = Pages.Admin.EditCustomer.GetContactPersonPhone();
            Pages.Admin.MenuBar.SignOut();
            Pages.Customer.Login.AttemptLogin("TestDormant", "TESTTEST123");
            Pages.Customer.Login.ValidateDormantAccountMessage(contactName, contactPhone, contactEmail);
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void LoginExpiredAccount()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            string contactName = Pages.Admin.EditCustomer.GetContactPersonName();
            string contactEmail = Pages.Admin.EditCustomer.GetContactPersonEmail();
            string contactPhone = Pages.Admin.EditCustomer.GetContactPersonPhone();
            Pages.Admin.MenuBar.SignOut();
            Pages.Customer.Login.AttemptLogin("TestExpired", "TESTTEST123");
            Pages.Customer.MustChangePassword.ValidateChangePasswordPageIsOpen("TestExpired");
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void Login3FailsLocked()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            string contactName = Pages.Admin.EditCustomer.GetContactPersonName();
            string contactEmail = Pages.Admin.EditCustomer.GetContactPersonEmail();
            string contactPhone = Pages.Admin.EditCustomer.GetContactPersonPhone();
            Pages.Admin.MenuBar.SignOut();
            Pages.Customer.Login.AttemptLogin("TestFailedLoginLock", Helpers.Functions.GenerateRandomString(8));
            Pages.Customer.Login.ValidateInvalidPasswordMessage(contactEmail);
            Pages.Customer.Login.AttemptLogin("TestFailedLoginLock", Helpers.Functions.GenerateRandomString(8));
            Pages.Customer.Login.ValidateInvalidPasswordMessage(contactEmail);
            Pages.Customer.Login.AttemptLogin("TestFailedLoginLock", Helpers.Functions.GenerateRandomString(8));
            Pages.Customer.Login.ValidateInvalidPasswordMessage(contactEmail);
            Pages.Customer.Login.AttemptLogin("TestFailedLoginLock", "TESTTEST123");
            Pages.Customer.Login.ValidateLockedAccountMessage(contactName, contactPhone, contactEmail);
            //Have to add teardown to unlock account for next run
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickManageUsersFromTable("AlignCare Services, LLC");
            Pages.Admin.ManageUsers.ClickEditUserFromTable("TestFailedLoginLock");
            Pages.Admin.EditUser.SetLocked(false);
            Pages.Admin.EditUser.SaveForm();
        }
        [Test]
        [Category("Login"), Category("Rerun Safe")]
        public void LoginLockedAccount()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            string contactName = Pages.Admin.EditCustomer.GetContactPersonName();
            string contactEmail = Pages.Admin.EditCustomer.GetContactPersonEmail();
            string contactPhone = Pages.Admin.EditCustomer.GetContactPersonPhone();
            Pages.Admin.MenuBar.SignOut();
            Pages.Customer.Login.AttemptLogin("TestLocked", "TESTTEST123");
            Pages.Customer.Login.ValidateLockedAccountMessage(contactName, contactPhone, contactEmail);
        }
        [Test]
        [Category("Permissions"), Category("Rerun Safe")]
        public void ValidateSuperAdminPermissions()
        {
            //Create Saved Search for PrescienceRx and Landing Page Category.

            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
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
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ValidateAdminLinkDoesntExist();

        }
        [Test]
        [Category("LandingPage"), Category("Rerun Safe")]
        public void CreateBasicLandingPageItem()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.MenuBar.ClickAddLandingPage();
            Pages.Admin.AddLandingPageItem.SetModuleType("Care ");
            Pages.Admin.AddLandingPageItem.SetPanelType("ActionItem");
            Pages.Admin.AddLandingPageItem.SetPanelName("Clinical Management Opportunities");
            Pages.Admin.AddLandingPageItem.SetPanelItemName("Warsaids");
            Pages.Admin.AddLandingPageItem.SetCustomerName("AlignCare Services, LLC");
            Pages.Admin.AddLandingPageItem.SetSavedSearch("Nsaids");
            Pages.Admin.AddLandingPageItem.ClickSaveButton();
            Pages.Admin.AddLandingPageItem.ValidateLandingPageAddedSuccess();
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemExistsByName("Warsaids");
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.MenuBar.ClickEditLandingPage();
            Pages.Admin.EditLandingPageItem.ClickDeleteByItemName("Warsaids");
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemDoesNotExist("Warsaids");
        }
        [Test]
        [Category("LandingPage"), Category("Rerun Safe")]
        public void CreateStandardLandingPageItem()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.MenuBar.ClickAddLandingPage();
            Pages.Admin.AddLandingPageItem.SetModuleType("Care ");
            Pages.Admin.AddLandingPageItem.SetPanelType("ActionItem");
            Pages.Admin.AddLandingPageItem.SetPanelName("Clinical Management Opportunities");
            Pages.Admin.AddLandingPageItem.SetPanelItemName("Warsaids");
            Pages.Admin.AddLandingPageItem.SetStandardCheckbox(true);
            //Pages.Admin.AddLandingPageItem.SetCustomerName("AlignCare Services, LLC");
            Pages.Admin.AddLandingPageItem.SetSavedSearch("Nsaids");
            Pages.Admin.AddLandingPageItem.ClickSaveButton();
            Pages.Admin.AddLandingPageItem.ValidateLandingPageAddedSuccess();
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemExistsByName("Warsaids");
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickSelectCustomerFromTable("Stanford");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemExistsByName("Warsaids");
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.MenuBar.ClickEditLandingPage();
            Pages.Admin.EditLandingPageItem.ClickDeleteByItemName("Warsaids");
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemDoesNotExist("Warsaids");
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickSelectCustomerFromTable("Stanford");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemDoesNotExist("Warsaids");
        }
        [Test]
        [Category("LandingPage"), Category("Rerun Safe")]
        public void CreateParentChildLandingPageItem()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.MenuBar.ClickAddLandingPage();
            Pages.Admin.AddLandingPageItem.SetModuleType("Care ");
            Pages.Admin.AddLandingPageItem.SetPanelType("ActionItem");
            Pages.Admin.AddLandingPageItem.SetPanelName("Clinical Management Opportunities");
            Pages.Admin.AddLandingPageItem.SetPanelItemName("Generic Parent");
            Pages.Admin.AddLandingPageItem.SetCustomerName("AlignCare Services, LLC");
            Pages.Admin.AddLandingPageItem.SetParentCheckbox(true);
            Pages.Admin.AddLandingPageItem.ClickSaveButton();
            Pages.Admin.AddLandingPageItem.ValidateLandingPageAddedSuccess();
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.MenuBar.ClickAddLandingPage();
            Pages.Admin.AddLandingPageItem.SetModuleType("Care ");
            Pages.Admin.AddLandingPageItem.SetPanelType("ActionItem");
            Pages.Admin.AddLandingPageItem.SetPanelName("Clinical Management Opportunities");
            Pages.Admin.AddLandingPageItem.SetPanelItemName("Warsaids");
            Pages.Admin.AddLandingPageItem.SetCustomerName("AlignCare Services, LLC");
            Pages.Admin.AddLandingPageItem.SetSavedSearch("Nsaids");
            Pages.Admin.AddLandingPageItem.SetParentPanelItem("Generic Parent");
            Pages.Admin.AddLandingPageItem.ClickSaveButton();
            Pages.Admin.AddLandingPageItem.ValidateLandingPageAddedSuccess();
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemExistsByName("Generic Parent");
            Pages.Customer.Home.ClickParentLandingPageItemByName("Generic Parent");
            Pages.Customer.Home.ValidateChildLandingPageItemExistsByName("Generic Parent", "Warsaids");
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.MenuBar.ClickEditLandingPage();
            Pages.Admin.EditLandingPageItem.ClickDeleteByItemName("Generic Parent");
            Pages.Admin.MenuBar.ClickManageCustomers();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ValidateParentLandingPageItemDoesNotExist("Generic Parent");
        }
        [Test]
        [Category("Downloads"), Category("Rerun Safe"), Category("Unfinished")]
        public void DownloadRiskSummaryPatientList()
        {
            //Need to validate downloaded file
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.Home.ExpandRiskProfile();
            Pages.Customer.Home.ClickRiskProfileSummary();
            Pages.Customer.Care.ClickPatients();
            Pages.Customer.Care.DownloadPatientList();
            string downloadedFile = Pages.Special.BrowserDownloads.GetDownloadFileName();
            //string pdftext = Helpers.PDF.GetTextFromPDF(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
            File.Delete(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
        }
        [Test]
        [Category("Downloads"), Category("Rerun Safe"), Category("Unfinished")]
        public void DownloadRiskSummaryHCC()
        {
            //Need to validate downloaded file
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.Home.ExpandRiskProfile();
            Pages.Customer.Home.ClickRiskProfileSummary();
            Pages.Customer.Care.ClickPatients();
            Pages.Customer.Care.DownloadHCC();
            string downloadedFile = Pages.Special.BrowserDownloads.GetDownloadFileName();
            //string pdftext = Helpers.PDF.GetTextFromPDF(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
            File.Delete(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
        }
        [Test]
        [Category("Downloads"), Category("Rerun Safe"), Category("Unfinished")]
        public void DownloadRiskSummaryPDC()
        {
            //Need to validate downloaded file
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.Home.ExpandRiskProfile();
            Pages.Customer.Home.ClickRiskProfileSummary();
            Pages.Customer.Care.ClickPatients();
            Pages.Customer.Care.DownloadPDC();
            string downloadedFile = Pages.Special.BrowserDownloads.GetDownloadFileName();
            //string pdftext = Helpers.PDF.GetTextFromPDF(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
            File.Delete(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
        }
        [Test]
        [Category("Downloads"), Category("Rerun Safe"), Category("Unfinished")]
        public void DownloadDrugInteractionD2D()
        {
            //Need to validate downloaded file
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.Home.ExpandClinicalManagementOpportunities();
            Pages.Customer.Home.ClickParentLandingPageItemByName("Drug Interaction Alerts");
            Pages.Customer.Home.ClickChildLandingPageItemByIndex("Drug Interaction Alerts", 0);
            Pages.Customer.Care.DownloadD2D();
            Pages.Special.BrowserDownloads.OpenDownloadsPage();
            string downloadedFile = Pages.Special.BrowserDownloads.GetDownloadFileName();
            //string pdftext = Helpers.PDF.GetTextFromPDF(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
            File.Delete(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
        }
        [Test]
        [Category("Downloads"), Category("Rerun Safe"), Category("Unfinished")]
        public void DownloadAllPatientDetailsReport()
        {
            //Need to validate downloaded file
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.MenuBar.ClearAllMessages();
            Pages.Customer.Home.ExpandRiskProfile();
            Pages.Customer.Home.ClickRiskProfileSummary();
            Pages.Customer.Care.ClickPatients();
            string firstresultname = Pages.Customer.Care.GetSearchResultFirstName(1) + " " + Pages.Customer.Care.GetSearchResultLastName(1);
            string patientID = Pages.Customer.Care.GetSearchResultID(1);
            Pages.Customer.Care.ClickFirstSearchResult();
            Pages.Customer.PatientSummary.ValidatePatientName(firstresultname);
            Pages.Customer.PatientSummary.ClickViewAllPatientDetailsLink();
            Pages.Customer.AllPatientDetails.ValidatePatientName(firstresultname);
            Pages.Customer.AllPatientDetails.ValidatePatientID(patientID);
            Pages.Customer.AllPatientDetails.ClickReportButton();
            Pages.Customer.AllPatientDetails.ClickOkToGenerateReport();
            Pages.Customer.MenuBar.ExpandMessages();
            Pages.Customer.MenuBar.WaitForReportToGenerateByPatientName(firstresultname);
            Pages.Customer.MenuBar.DownloadPatientReportByPatientName(firstresultname);
            Pages.Special.BrowserDownloads.OpenDownloadsPage();
            string downloadedFile = Pages.Special.BrowserDownloads.GetDownloadFileName();
            string pdftext = Helpers.PDF.GetTextFromPDF(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
            File.Delete(new KnownFolder(KnownFolderType.Downloads).Path + @"\" + downloadedFile);
        }
        [Test]
        [Category("Navigation"), Category("Rerun Safe")]
        public void InNetworkDisplayOffDataHidden()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.TurnOffInNetworkDisplay();
            Pages.Admin.EditCustomer.ClickNextButton();
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
            Pages.Customer.PatientSummary.ClickViewAllPatientDetailsLink();
            Pages.Customer.AllPatientDetails.ValidateInNetworkIsHidden();
        }
        [Test]
        [Category("Navigation"), Category("Rerun Safe")]
        public void InNetworkDisplayOnDataShows()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.TurnOnInNetworkDisplay();
            Pages.Admin.EditCustomer.ClickNextButton();
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
            Pages.Customer.PatientSummary.ClickViewAllPatientDetailsLink();
            Pages.Customer.AllPatientDetails.ValidateInNetworkIsDisplayed();
        }
        [Test]
        [Category("Navigation"), Category("Rerun Safe")]
        public void AllPatientDetailsNextButtonNavigation()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            Pages.Admin.Home.ClickEditCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.EditCustomer.TurnOnInNetworkDisplay();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickNextButton();
            Pages.Admin.EditCustomer.ClickUpdateCustomerButton();
            Pages.Admin.EditCustomer.VerifySuccessMessage();
            Pages.Admin.EditCustomer.ClickBackToListLink();
            Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Customer.Home.ExpandRiskProfile();
            Pages.Customer.Home.ClickRiskProfileSummary();
            Pages.Customer.Care.ClickPatients();
            List<string> Patients = new List<string>();
            for (int x = 1; x < 11; x++)
            {
                Patients.Add(Pages.Customer.Care.GetSearchResultFirstName(x) + " " + Pages.Customer.Care.GetSearchResultLastName(x));
            }
            Pages.Customer.Care.ClickFirstSearchResult();
            Pages.Customer.PatientSummary.ClickViewAllPatientDetailsLink();
            for (int x = 0; x < 10; x++)
            {

                Pages.Customer.AllPatientDetails.ValidatePatientName(Patients[x]);
                Pages.Customer.AllPatientDetails.ClickNextButton();
            }
        }
        [Test]
        [Category("Navigation"), Category("Rerun Safe"), Category("Unfinished")]
        public void CheckLandingPageCounts()
        {
            Pages.Customer.Login.LoginWithSuperAdmin();
            Pages.Customer.MenuBar.ExpandWaffleMenu();
            Pages.Customer.MenuBar.ClickAdminLink();
            //Pages.Admin.Home.ClickSelectCustomerFromTable("AlignCare Services, LLC");
            Pages.Admin.Home.ClickSelectCustomerFromTable("Stanford");
            Dictionary<string, List<LandingPageItem>> LandingPageMap = new Dictionary<string, List<LandingPageItem>>();
            List<string> RiskSummarySections = new List<string>() {
            "Risk Profile",
            "Clinical Management Opportunities",
            "Cost & Revenue Optimization Opportunities",
            "Client Selected Focus on Cost & Quality Management"
            };
            foreach(string s in RiskSummarySections)
            {
                LandingPageMap.Add(s, Pages.Customer.Home.GetLandingPageItemsBySectionName(s));
            }
            foreach(KeyValuePair<string, List<LandingPageItem>> kvp in LandingPageMap)
            {
                Pages.Customer.Home.ExpandSectionByText(kvp.Key);
                foreach(LandingPageItem l in kvp.Value)
                {
                    Pages.Customer.Home.ClickParentLandingPageItemByName(l.Name);
                    if (l.IsParent)
                    {
                        for(int x=0; x< l.Children.Count; x++)
                        {
                            Pages.Customer.Home.ClickChildLandingPageItemByIndex(l.Name, x);
                            Pages.Customer.Care.ClickPatients();
                            Pages.Customer.Care.ValidateNumberOfResults(l.Children[x].Count, l.Children[x].Name);
                            Pages.Customer.MenuBar.ClickLandingPageLink();
                        }
                    }
                    else
                    {
                        Pages.Customer.Care.ClickPatients();
                        Pages.Customer.Care.ValidateNumberOfResults(l.Count, l.Name);
                        Pages.Customer.MenuBar.ClickLandingPageLink();
                    }
                }
            }
        }
    }
}

