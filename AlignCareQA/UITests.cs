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
using TestDemo.Pages;
using TestDemo.Helpers;

namespace TestDemo
{
    [TestFixture]
    public class UITests : SeleniumTestBase
    {
        [Test]
        [Category("Basic Info")]
        public void OneFieldSetSaveAndContinueFooterAppears()
        {
            Assert.IsFalse(CreatePage.SaveContinueButtonVisible());
            CreatePage.SetEventTitle(Functions.GenerateRandomString(10));
            Assert.IsTrue(CreatePage.SaveContinueButtonVisible());
        }

        [Test]
        [Category("Basic Info")]
        public void SendFormEmptyTitleHighlighted()
        {
            CreatePage.SetOrganizer(Functions.GenerateRandomString(10));
            CreatePage.ClickSaveAndContinueButton();
            Assert.AreEqual("Please fill out all of the required fields correctly", CreatePage.GetBannerErrorMessage());
            Assert.AreEqual("Title is required.", CreatePage.GetTitleErrorMessage());
        }

        [Test]
        [Category("Location")]
        public void SendFormEmptyLocationHighlighted()
        {
            CreatePage.SetEventTitle(Functions.GenerateRandomString(10));
            CreatePage.ClickSaveAndContinueButton();
            Assert.AreEqual("Please fill out all of the required fields correctly", CreatePage.GetBannerErrorMessage());
            Assert.AreEqual("Location is required.", CreatePage.GetVenueErrorMessage());
        }

        [Test]
        [Category("Basic Info")]
        public void Add11TagsErrorMessage()
        {
            CreatePage.SetEventTitle(Functions.GenerateRandomString(10));
            for(int i = 0; i < 10; i++)
            {
                string y = "E" + Functions.GenerateRandomString(5).ToLower();
                CreatePage.SetEventTag(y);
                Assert.IsTrue(CreatePage.TagExistsByText(y));
            }
            string z = Functions.GenerateRandomString(5);
            CreatePage.SetEventTag(z);
            Assert.AreEqual("10/10 tag limit reached.", CreatePage.GetTagErrorMessage());
        }

    }
}

