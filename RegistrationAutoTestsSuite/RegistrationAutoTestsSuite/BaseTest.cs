using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using BuggyCarsRatingUIAutoTests.Pages;
using System;
using TechTalk.SpecFlow;

namespace BuggyCarsRatingUIAutoTests
{
    [Binding]
    public class BaseTest
    {
        public IWebDriver driver { get; set; }
        public Pages.BasePage ApplicationUnderTest { get; set; }
        public WebDriverWait webDriverWait { get; set; }

        public BaseTest()
        {

        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [Before]
        public void SetUp(ScenarioContext context, TestContext testContext)
        {
            TestContext = testContext;
            driver = new ChromeDriver();
            driver.Url = "https://buggy.justtestit.org/";
            ApplicationUnderTest = new BasePage(webDriverWait, driver, TestContext);
            driver.Manage().Window.Maximize();
            context["WEB_DRIVER"] = driver;
            context["AUT"] = new BasePage(webDriverWait, driver, TestContext);

        }

        [After]
        public void CleanUp()
        {
            driver.Quit();
        }

    }
}
