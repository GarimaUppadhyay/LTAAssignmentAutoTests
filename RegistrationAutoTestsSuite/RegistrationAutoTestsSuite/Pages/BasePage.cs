using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingUIAutoTests.Pages
{
    public class BasePage
    {
        IWebDriver _webDriver;
        TestContext _testContext;
        WebDriverWait _webDriverWait;

        public BasePage(WebDriverWait webDriverWait, IWebDriver webDriver, TestContext testContext)
        {
            _webDriver = webDriver;
            _testContext = testContext;
            _webDriverWait = webDriverWait;
        }
        public RegistrationPage RegistrationPage
        {
            get
            {
                return new RegistrationPage(_webDriverWait, _webDriver, _testContext);
            }
        }
        public VotingPage VotingPage
        {
            get
            {
                return new VotingPage(_webDriverWait, _webDriver, _testContext);
            }
        }
    }
}
