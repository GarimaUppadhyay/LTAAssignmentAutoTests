using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingUIAutoTests.Objects
{
    public class VotingPageObject
    {
        #region class members
        IWebDriver _driver;
        WebDriverWait _wait;
        #endregion

        #region Constructor
        public VotingPageObject(WebDriverWait wait, IWebDriver webDriver)
        {
            _wait = wait;
            _driver = webDriver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }
        #endregion

        #region Class Properties
        public IWebElement ImageList
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(VotePageLocators.ImageList)));

            }
        }
        public IWebElement VoteButton
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(VotePageLocators.VoteButton)));

            }
        }

        public IWebElement Comment
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.Id(VotePageLocators.Comment)));

            }
        }
        public IWebElement CarLink(string name)
        {
            string item = VotePageLocators.CarLink.Replace("{0}", name);
            return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                   ElementExists(By.XPath(item)));

        }
        public IWebElement PreviousVotesCount
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(VotePageLocators.PreviousVotesCount)));

            }
        }
        public IWebElement VoteMessage
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(VotePageLocators.VoteMessage)));

            }
        }
        #endregion
    }
    public static class VotePageLocators
    {
        public static string ImageList = "//img[@src='/img/overall.jpg']";
        public static string CarLink = "//a[text()= '{0}']";
        public static string Comment = "comment";
        public static string VoteButton = "//button[text()= 'Vote!']";
        public static string PreviousVotesCount = "//*[text()='Votes: ']";
        public static string VoteMessage = "//p[@class='card-text']";
    }
}
