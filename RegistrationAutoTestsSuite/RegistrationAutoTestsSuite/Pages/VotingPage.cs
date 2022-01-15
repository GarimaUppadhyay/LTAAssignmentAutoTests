using BuggyCarsRatingUIAutoTests.Objects;
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
    public class VotingPage
    {
        #region Class members
        WebDriverWait _wait;
        IJavaScriptExecutor executor;
        IWebDriver _driver;
        TestContext _testContext;
        VotingPageObject votingPageObject;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for RegistrationPage
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="driver"></param>
        /// <param name="testContext"></param>
        public VotingPage(WebDriverWait wait, IWebDriver driver, TestContext testContext)
        {
            _wait = wait;
            executor = (IJavaScriptExecutor)driver;
            _driver = driver;
            _testContext = testContext;
            votingPageObject = new VotingPageObject(_wait, _driver);
        }
        #endregion
        /// <summary>
        /// Method for User Vote
        /// </summary>
        /// <param name="comment"></param>
        /// <param name="carType"></param>
        /// <param name="scenario"></param>
        /// <returns></returns>
        public bool ValidateUserVotingForSportsCar(string comment, string carType, string user, string message)
        {
            bool isSuccess = true;

            votingPageObject.ImageList.Click();
            votingPageObject.CarLink(carType).Click();
            executor.ExecuteScript("arguments[0].scrollIntoView(true);", votingPageObject.PreviousVotesCount);
            try
            {
                switch (user)
                {

                    case "RegisteredUser":
                        if (votingPageObject.VoteButton.Displayed)
                        {
                            votingPageObject.Comment.SendKeys(comment);
                            votingPageObject.VoteButton.Click();
                        }
                        isSuccess &= votingPageObject.VoteMessage.GetAttribute("innerText").ToLower().Contains(message.ToLower());
                        break;
                    case "UnRegisteredUser":
                        try
                        {
                            if (votingPageObject.VoteButton.Displayed)
                            {
                                isSuccess = false;
                                _testContext.WriteLine("UnAuthorized Vote");
                            }
                        }
                        catch (Exception)
                        {
                            isSuccess &= votingPageObject.VoteMessage.GetAttribute("innerText").ToLower().Contains(message.ToLower());
                        }
                        break;
                }
            }

            catch (Exception e)
            {
                isSuccess = false;
                _testContext.WriteLine("Error while voting car {0}", e.Message);
            }
            return isSuccess;
        }
    }
}
