using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestDemo.Pages
{
    class CreatePage
    {
        //Modal
        private static readonly By btnCloseModal = By.XPath("//button[@data-automation='modal-close-button']");
        //Error Bar
        private static readonly By lblBannerErrorMessage = By.ClassName("eds-notification-bar__content-child");
        //Basic Info Fields
        private static readonly By txtEventTitle = By.Name("title");
        private static readonly By lblTitleError = By.XPath("//input[@name='title']/../../../../..//aside");
        private static readonly By ddlEventType = By.Name("eventType");
        private static readonly By ddlEventCategory = By.Name("eventTopic");
        private static readonly By txtOrganizer = By.Name("organizerName");
        private static readonly By txtEventTag = By.Id("tagging-form-field");
        private static readonly By btnAddTag = By.XPath("//div[@class='tagging-form-field__tag-button-container']/button");
        private static readonly By lblTagError = By.XPath("//input[@id='tagging-form-field']/../../../../..//aside");

        //Location Fields
        private static readonly By ddlVenue = By.Name("venueType");
        private static readonly By txtVenueAddress = By.Name("venue");
        private static readonly By lblVenueError = By.XPath("//input[@name='venue']/../../../../../../../..//aside");

        //Date and Time Fields
        private static readonly By rdoSingleEvent = By.Id("radio-isSeriesParent-0");
        private static readonly By rdoRecurringEvent = By.Id("radio-isSeriesParent-1");
        private static readonly By txtStartDate = By.Id("event-startDate");
        private static readonly By txtEndDate = By.Id("event-endDate");
        private static readonly By txtStartTime = By.Id("event-startTime");
        private static readonly By txtEndTime = By.Id("event-endTime");

        //Save & Continue Footer
        private static readonly By btnDiscard = By.XPath("//button[@data-automation='coyote-action-discard']");
        private static readonly By btnSaveAndContinue = By.XPath("//button[@data-automation='coyote-action-save']");


        public static void DismissBasicsModal()
        {
            SeleniumHelper.SafetyClick(btnCloseModal);
        }

        public static void SetEventTitle(string value)
        {
            SeleniumHelper.WaitForElement(txtEventTitle);
            SeleniumHelper.driver.FindElement(txtEventTitle).SendKeys(value);
        }
        public static void SetOrganizer(string value)
        {
            SeleniumHelper.WaitForElement(txtOrganizer);
            SeleniumHelper.driver.FindElement(txtOrganizer).SendKeys(value);
        }
        public static void SetEventTag(string value)
        {
            SeleniumHelper.WaitForElement(txtEventTag);
            SeleniumHelper.driver.FindElement(txtEventTag).SendKeys(value);
            SeleniumHelper.driver.FindElement(btnAddTag).Click();
        }
        public static string GetTagErrorMessage()
        {
            try
            {
                SeleniumHelper.WaitForElement(lblTagError);
                return SeleniumHelper.driver.FindElement(lblTagError).Text;
            }
            catch
            {
                return "";
            }
        }
        public static string GetBannerErrorMessage()
        {
            try
            {
                SeleniumHelper.WaitForElement(lblBannerErrorMessage);
                return SeleniumHelper.driver.FindElement(lblBannerErrorMessage).Text;
            }
            catch
            {
                return "";
            }
        }
        public static string GetTitleErrorMessage()
        {
            try
            {
                SeleniumHelper.WaitForElement(lblTitleError);
                return SeleniumHelper.driver.FindElement(lblTitleError).Text;
            }
            catch
            {
                return "";
            }
        }
        public static string GetVenueErrorMessage()
        {
            try
            {
                SeleniumHelper.WaitForElement(lblVenueError);
                return SeleniumHelper.driver.FindElement(lblVenueError).Text;
            }
            catch
            {
                return "";
            }
        }

        public static bool TagExistsByText(string value)
        {
            try
            {
                SeleniumHelper.WaitForElement(By.XPath("//div[@class='tagging-form-field__tag-container']/div/span[text()='" + value + "']"));
                return true;
            }
            catch
            {
                return false;
            }

        }
        public static bool SaveContinueButtonVisible()
        {
            if(SeleniumHelper.driver.FindElements(btnSaveAndContinue).Count > 0)
            {
                if (SeleniumHelper.driver.FindElement(btnSaveAndContinue).Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public static void ClickSaveAndContinueButton()
        {
            SeleniumHelper.SafetyClick(btnSaveAndContinue);
        }
        public static void ClickDiscardButton()
        {
            SeleniumHelper.SafetyClick(btnDiscard);
        }
    }
}
