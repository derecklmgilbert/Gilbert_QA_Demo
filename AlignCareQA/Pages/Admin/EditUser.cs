using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlignCareQA.Pages.Admin
{
    class EditUser
    {
        private static IWebDriver driver = UITests.driver;

        private static readonly By txtUsername = By.Id("User_UserName");
        private static readonly By ddlRoles = By.Id("roleList");
        private static readonly By txtFirstName = By.Id("User_FirstName");
        private static readonly By txtLastName = By.Id("User_LastName");
        private static readonly By txtPhone = By.Id("User_Phone");
        private static readonly By txtEmail = By.Id("User_Email");
        private static readonly By txtDaysInExpiration = By.Id("User_DaysInExpiration");
        private static readonly By txtDaysInDormancy = By.Id("User_DaysInDormancy");
        private static readonly By ckbxActive = By.Id("User_IsActive");
        private static readonly By ckbxDormant = By.Id("User_IsDormant");
        private static readonly By ckbxExpired = By.Id("User_IsExpired");
        private static readonly By ckbxLocked = By.Id("User_IsLocked");
        private static readonly By ckbxChangePasswordOnNextLogin = By.Id("User_AdminReset");
        private static readonly By btnRegister = By.XPath("//input[@value='Register']");
    }
}
