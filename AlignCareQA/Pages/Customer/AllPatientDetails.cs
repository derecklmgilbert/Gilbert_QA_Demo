using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;
namespace AlignCareQA.Pages.Customer
{
    class AllPatientDetails
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By btnNext = By.Id("btnNext");
        private static readonly By btnBackToSummary = By.XPath("//div[@id='sticky']/a/img[@alt='Back to Summary']/..");
        private static readonly By btnBackToSearch = By.XPath("//div[@id='sticky']/a/img[@alt='Back to Search']/..");
        private static readonly By btnPrevious = By.Id("btnPrev");
        private static readonly By btnReport = By.XPath("//button[@id='btnModal']/../img");

        //ReportModal
        private static readonly By ddlFormat = By.Id("formatSelect");
        private static readonly By txtReportName = By.XPath("//form[@name='rptForm']//input[@ng-model='ReportName']");
        private static readonly By btnModalOk = By.XPath("//button[text()='Ok']");
        private static readonly By btnModalCancel = By.Id("btnCancelModal");

        //PatientProfile
        private static readonly By lblPatientProfileHeader = By.XPath("//div[@id='patientProfile']//div[contains(@class, 'panel-heading')]");

        private static readonly By lblOrganizationData = By.XPath("//div[@id='patientProfile']//td[text()='Organization']/../td[2]");
        private static readonly By lblEnrolledData = By.XPath("//div[@id='patientProfile']//td[text()='Enrolled']/../td[2]");
        private static readonly By lblPatientIdData = By.XPath("//div[@id='patientProfile']//td[text()='Patient Id']/../td[2]");
        private static readonly By lblSexData = By.XPath("//div[@id='patientProfile']//td[text()='Sex']/../td[2]");
        private static readonly By lblDOBData = By.XPath("//div[@id='patientProfile']//td[text()='DOB']/../td[2]");
        private static readonly By lblAgeData = By.XPath("//div[@id='patientProfile']//td[text()='Age']/../td[2]");
        private static readonly By lblAgeGroupData = By.XPath("//div[@id='patientProfile']//td[text()='Age Group']/../td[2]");
        private static readonly By lblCOAData = By.XPath("//div[@id='patientProfile']//td[text()='COA']/../td[2]");
        private static readonly By lblZipCodeData = By.XPath("//div[@id='patientProfile']//td[text()='Zip Code']/../td[2]");

        private static readonly By lblPCPNameData = By.XPath("//div[@id='patientProfile']//td[text()='PCP Name']/../td[2]");
        private static readonly By lblPCPNPIData= By.XPath("//div[@id='patientProfile']//td[text()='PCP NPI']/../td[2]");
        private static readonly By lblPCPSpecialtyData = By.XPath("//div[@id='patientProfile']//td[text()='PCP Specialty']/../td[2]");
        private static readonly By lblPhysicianNameData = By.XPath("//div[@id='patientProfile']//td[text()='Physician Name']/../td[2]");
        private static readonly By lblNPIData = By.XPath("//div[@id='patientProfile']//td[text()='NPI']/../td[2]");
        private static readonly By lblNetworkParticipantData = By.XPath("//div[@id='patientProfile']//td[text()='Network Participant']/../td[2]");
        private static readonly By lblSpecialtyData = By.XPath("//div[@id='patientProfile']//td[text()='Specialty']/../td[2]");

        private static readonly By lblRegionData = By.XPath("//div[@id='patientProfile']//td[text()='Region']/../td[2]");
        private static readonly By lblGroupData = By.XPath("//div[@id='patientProfile']//td[text()='Group']/../td[2]");
        private static readonly By lblSiteData = By.XPath("//div[@id='patientProfile']//td[text()='Site']/../td[2]");
        private static readonly By lblEmployerGroupData = By.XPath("//div[@id='patientProfile']//td[text()='Employer Group']/../td[2]");
        private static readonly By lblProductData = By.XPath("//div[@id='patientProfile']//td[text()='Product']/../td[2]");
        private static readonly By lblBenefitTierData = By.XPath("//div[@id='patientProfile']//td[text()='Benefit Tier']/../td[2]");
        private static readonly By lblCareManagementData = By.XPath("//div[@id='patientProfile']//td[text()='Care Management']/../td[2]");
        private static readonly By lblDentalCoverageData = By.XPath("//div[@id='patientProfile']//td[text()='Dental Coverage']/../td[2]");
        private static readonly By lblDMProgramData = By.XPath("//div[@id='patientProfile']//td[text()='DM Program']/../td[2]");
        private static readonly By lblHRACompletedData = By.XPath("//div[@id='patientProfile']//td[text()='HRA Completed']/../td[2]");
        private static readonly By lblMTMProgramData = By.XPath("//div[@id='patientProfile']//td[text()='MTM Program']/../td[2]");
        private static readonly By lblOptionalCoverageData = By.XPath("//div[@id='patientProfile']//td[text()='Optional Coverage']/../td[2]");
        private static readonly By lblPainManagementData = By.XPath("//div[@id='patientProfile']//td[text()='Pain Management']/../td[2]");

        //Prescriber Section
        private static readonly string tblPrescriberXpath = "//div[@id='prescriber']//table";

        //Prescribing Section
        private static readonly By chrtPrescribers = By.Id("DifferentPrescriberChart");

        //Drug Consumption Detail Section
        private static readonly string drugXpath = "//div[contains(text(), 'Drug Consumption Detail')]/../div/div[@class='ng-scope']";
        private static void WaitForPageLoad()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElements(lblOptionalCoverageData).Count > 0);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(lblOptionalCoverageData).Displayed);
        }
        public static void ClickReportButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(btnReport).Displayed);
            driver.FindElement(btnReport).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(ddlFormat).Displayed);
        }
        public static void ClickOkToGenerateReport()
        {
            driver.FindElement(btnModalOk).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(60)).Until(x => !x.FindElement(btnModalOk).Displayed);
        }
        public static void ValidateInNetworkIsHidden()
        {
            WaitForPageLoad();
            Assert.False(driver.FindElement(lblNetworkParticipantData).Displayed);
            Assert.False(PrescriberTableNetworkColumnDisplayed());
            Assert.False(driver.FindElement(chrtPrescribers).Displayed);
            CheckDrugConsumptionPrescriptionTablesForInNetwork(false);
        }
        public static void ValidateInNetworkIsDisplayed()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElements(lblOptionalCoverageData).Count > 0);
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(lblOptionalCoverageData).Displayed);
            Assert.NotZero(driver.FindElements(lblNetworkParticipantData).Count);
            Assert.True(PrescriberTableNetworkColumnDisplayed());
            Assert.NotZero(driver.FindElements(chrtPrescribers).Count);
            CheckDrugConsumptionPrescriptionTablesForInNetwork(true);
        }
        private static bool PrescriberTableNetworkColumnDisplayed()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(By.XPath(tblPrescriberXpath)).Displayed);
            return driver.FindElement(By.XPath(tblPrescriberXpath + "/tbody/tr/th[text()='In Network']")).Displayed;
        }
        private static void CheckDrugConsumptionPrescriptionTablesForInNetwork(bool expectedDisplayed)
        {
            int drugCount = driver.FindElements(By.XPath(drugXpath + "/div[@class='ng-scope']")).Count;
            for(int i =0; i<drugCount; i++)
            {
                driver.FindElements(By.XPath("//div[contains(text(),'Prescription History')]/.."))[i].Click();
                System.Threading.Thread.Sleep(1000);
            }

            for (int i = 0; i < drugCount; i++)
            {
                Assert.True(driver.FindElements(By.XPath("//table[@id='tblPrescriptionHistory']"))[i].Displayed);
                Assert.AreEqual(driver.FindElements(By.XPath("//table[@id='tblPrescriptionHistory']"))[i].FindElement(By.XPath(".//th[text()='In Network']")).Displayed, expectedDisplayed);
            }
        }
        public static void ValidatePatientName(string expectedName)
        {
            WaitForPageLoad();
            Assert.AreEqual(expectedName, GetPatientName());
        }
        public static void ValidatePatientID(string expectedID)
        {
            WaitForPageLoad();
            Assert.AreEqual(expectedID, GetPatientID());
            Assert.AreEqual(expectedID, driver.FindElement(lblPatientIdData).Text);
        }
        public static string GetPatientName()
        {
            return driver.FindElement(lblPatientProfileHeader).Text.Substring(0, driver.FindElement(lblPatientProfileHeader).Text.IndexOf("(") - 1);
        }
        public static string GetPatientID()
        {
            return driver.FindElement(lblPatientProfileHeader).Text.Substring(driver.FindElement(lblPatientProfileHeader).Text.IndexOf("(") + 1, driver.FindElement(lblPatientProfileHeader).Text.Length - driver.FindElement(lblPatientProfileHeader).Text.IndexOf("(")-2);
        }
        public static void ClickNextButton()
        {
            driver.FindElement(btnNext).Click();
            System.Threading.Thread.Sleep(500);
        }
    }
}
