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
        private static readonly By lblOrganizationData = By.XPath("//div[@id='patientProfile']//td[text()='Organization']/../td[2]");
        private static readonly By lblEnrolledData = By.XPath("//div[@id='patientProfile']//td[text()='Enrolled']/../td[2]");
        private static readonly By lblPatientIdData = By.XPath("//div[@id='patientProfile']//td[text()='Patient Id']/../td[2]");
        private static readonly By lblSexData = By.XPath("//div[@id='patientProfile']//td[text()='Sex']/../td[2]");
        private static readonly By lblDOBData = By.XPath("//div[@id='patientProfile']//td[text()='DOB']/../td[2]");
        private static readonly By lblAgeData = By.XPath("//div[@id='patientProfile']//td[text()='Age']/../td[2]");
        private static readonly By lblAgeGroupData = By.XPath("//div[@id='patientProfile']//td[text()='Age Group']/../td[2]");
        private static readonly By lblCOAData = By.XPath("//div[@id='patientProfile']//td[text()='COA']/../td[2]");
        private static readonly By lblZipCodeData = By.XPath("//div[@id='patientProfile']//td[text()='Zip  Code']/../td[2]");

        private static readonly By lblPCPNameData = By.XPath("//div[@id='patientProfile']//td[text()='PCP Name']/../td[2]");
        private static readonly By lblPCPNPIData= By.XPath("//div[@id='patientProfile']//td[text()='PCP NPI']/../td[2]");
        private static readonly By lblPCPSpecialtyData = By.XPath("//div[@id='patientProfile']//td[text()='PCP Specialty']/../td[2]");
        private static readonly By lblPhysicianNameData = By.XPath("//div[@id='patientProfile']//td[text()='Physician Name']/../td[2]");
        private static readonly By lblNPIData = By.XPath("//div[@id='patientProfile']//td[text()='NPI']/../td[2]");
        private static readonly By lblNetworkParticipantData = By.XPath("//div[@id='patientProfile']//td[text()='NetWork Participant']/../td[2]");
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

        public static void ClickReportButton()
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(btnReport).Displayed);
            driver.FindElement(btnReport).Click();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(x => x.FindElement(ddlFormat).Displayed);
        }
    }
}
