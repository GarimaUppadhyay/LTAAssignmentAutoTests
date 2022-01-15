using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using BuggyCarsRatingUIAutoTests.Objects;
using BuggyCarsRatingUIAutoTests.TestData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using BuggyCarsRatingUIAutoTests.Helper;

namespace BuggyCarsRatingUIAutoTests.Pages
{
    public class RegistrationPage
    {
        #region Class members
        WebDriverWait _wait;
        IJavaScriptExecutor executor;
        IWebDriver _driver;
        TestContext _testContext;
        RegistrationPageObject registrationPageObject;

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for RegistrationPage
        /// </summary>
        /// <param name="wait"></param>
        /// <param name="driver"></param>
        /// <param name="testContext"></param>
        public RegistrationPage(WebDriverWait wait, IWebDriver driver, TestContext testContext)
        {
            _wait = wait;
            executor = (IJavaScriptExecutor)driver;
            _driver = driver;
            _testContext = testContext;
            registrationPageObject = new RegistrationPageObject(_wait, _driver);
        }
        #endregion

        /// <summary>
        /// Method to register user details
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="fName"></param>
        /// <param name="lName"></param>
        /// <param name="pwd"></param>
        /// <param name="confirmPwd"></param>
        /// <returns></returns>
        public bool RegisterUserDetails(string scenario, string userName, string fName, string lName, string pwd, string confirmPwd)
        {
            bool registerSuccess = true;
            Random random = new Random();

            try
            {
                TestDataProvider.UserName = userName;
                Thread.Sleep(1000);
                if (scenario == "Valid")
                {
                    userName = userName + random.Next();
                    TestDataProvider.UserName = userName;

                }
                registrationPageObject.HomeRegisterButton.Click();
                registrationPageObject.UserName.SendKeys(userName);
                registrationPageObject.FirstName.SendKeys(fName);
                registrationPageObject.LastName.SendKeys(lName);
                registrationPageObject.Password.SendKeys(pwd);
                registrationPageObject.ConfirmPwd.SendKeys(confirmPwd);
                registrationPageObject.RegisterButton.Click();
                Thread.Sleep(1000);
                if (scenario == "Valid")
                    _testContext.WriteLine("Successfully registered user {0}", userName);
                else
                    _testContext.WriteLine("User already registered user {0}", userName);
                CommonUtilities.CaptureScreenshot("Registration", _driver, _testContext);
            }
            catch (Exception e)
            {
                registerSuccess = false;
                _testContext.WriteLine("Error registrating user {0}", e.Message);
                CommonUtilities.CaptureScreenshot("ErrorRegistration", _driver, _testContext);
            }
            return registerSuccess;
        }

        /// <summary>
        /// Method for validating user registration
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public bool ValidateIsRegistrationSuccessful(string message)
        {
            bool isSuccess = true;
            isSuccess = registrationPageObject.ResultMessage.GetAttribute("innerText").ToLower().Contains(message.ToLower());
            CommonUtilities.CaptureScreenshot("RegistrationSuccess", _driver, _testContext);
            return isSuccess;
        }

        /// <summary>
        /// Login User
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="scenario"></param>
        /// <returns></returns>
        public bool LoginUser(string userName, string password, string scenario)
        {
            bool isLoginSuccess = true;
            if (scenario == "RegisteredUser")
            {

                userName = TestDataProvider.UserName;
                registrationPageObject.LoginName.SendKeys(userName);
                registrationPageObject.LoginPassword.SendKeys(password);
                registrationPageObject.LoginButton.Click();
            }

            return isLoginSuccess;
        }
       
    }

}
