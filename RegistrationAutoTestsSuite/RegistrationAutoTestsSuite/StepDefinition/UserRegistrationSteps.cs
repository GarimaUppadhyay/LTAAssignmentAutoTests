using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using BuggyCarsRatingUIAutoTests.Pages;
using System;
using TechTalk.SpecFlow;
using BuggyCarsRatingUIAutoTests.Helper;

namespace BuggyCarsRatingUIAutoTests.StepDefinition
{
    [Binding]
    public class UserRegistrationSteps
    {
        BasePage basePage;
        IWebDriver driver;
        public UserRegistrationSteps(ScenarioContext context)
        {
            basePage = context["AUT"] as BasePage;
            driver = context["WEB_DRIVER"] as IWebDriver;
        }

        [Then(@"User validates success ""(.*)""")]
        public void ThenUserValidatesSuccess(string message)
        {
            Assert.IsTrue(basePage.RegistrationPage.ValidateIsRegistrationSuccessful(message));
        }

        [Given(@"User navigates to Buggy Cars site")]
        public void GivenUserNavigatesToBuggyCarsSite()
        {
            driver.Url = ConfigurationHelper.AppUrl;
        }

        [When(@"User clicks on Registration ""(.*)"" and enter ""(.*)"", ""(.*)"", ""(.*)"", ""(.*)"" and ""(.*)"" to registor")]
        public void WhenUserClicksOnRegistrationAndEnterAndToRegistor(string scenario, string userName, string fName, string lName, string password, string confirmPwd)
        {
            Assert.IsTrue(basePage.RegistrationPage.RegisterUserDetails(scenario,userName, fName, lName, password, confirmPwd));
        }

       [When(@"""(.*)"" user enters ""(.*)"" and ""(.*)"" and login")]
        public void WhenUserEntersAndAndLogin(string registered, string userName, int password)
        {
            Assert.IsTrue(basePage.RegistrationPage.LoginUser(userName, password.ToString(), registered));
        }

        [Then(@"""(.*)"" User can Vote and ""(.*)"" for Sports ""(.*)"" and ""(.*)""")]
        public void ThenUserCanVoteAndForSportsAnd(string registered, string comment, string carType, string message)
        {
            Assert.IsTrue(basePage.VotingPage.ValidateUserVotingForSportsCar(comment, carType, registered, message));
        }
        [When(@"The ""(.*)"" user enters ""(.*)"" and ""(.*)"" and login")]
        public void WhenTheUserEntersAndAndLogin(string registered, string userName, string password)
        {
            Assert.IsTrue(basePage.RegistrationPage.LoginUser(userName, password, registered));
        }

    }
}
