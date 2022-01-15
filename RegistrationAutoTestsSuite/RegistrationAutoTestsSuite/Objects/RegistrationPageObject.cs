using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingUIAutoTests.Objects
{
    public class RegistrationPageObject
    {
        #region class members
        IWebDriver _driver;
        WebDriverWait _wait;
        #endregion

        #region Constructor
        public RegistrationPageObject(WebDriverWait wait, IWebDriver webDriver)
        {
            _wait = wait;
            _driver = webDriver;
            _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));
        }
        #endregion

        #region Class Properties
        public IWebElement HomeRegisterButton
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(RegistrationPageLocators.HomeRegisterButton)));

            }
        }
        public IWebElement UserName
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.Id(RegistrationPageLocators.UserName)));

            }
        }

        public IWebElement FirstName
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.Id(RegistrationPageLocators.FirstName)));

            }
        }

        public IWebElement LastName
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.Id(RegistrationPageLocators.LastName)));

            }
        }
        public IWebElement Password
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.Id(RegistrationPageLocators.Password)));

            }
        }
        public IWebElement ConfirmPwd
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.Id(RegistrationPageLocators.ConfirmPwd)));

            }
        }
        public IWebElement RegisterButton
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(RegistrationPageLocators.RegisterButton)));

            }
        }
        public IWebElement ResultMessage
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(RegistrationPageLocators.ResultMessage)));

            }
        }
        public IWebElement LoginName
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(RegistrationPageLocators.LoginName)));

            }
        }
        public IWebElement LoginPassword
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(RegistrationPageLocators.LoginPassword)));

            }
        }
        public IWebElement LoginButton
        {
            get
            {
                return _wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.
                    ElementExists(By.XPath(RegistrationPageLocators.LoginButton)));

            }
        }
        #endregion
    }
    public static class RegistrationPageLocators
    {
        public static string HomeRegisterButton= "//a[text()= 'Register']";
        public static string UserName = "username";
        public static string FirstName = "firstName";
        public static string LastName = "lastName";
        public static string Password = "password";
        public static string ConfirmPwd = "confirmPassword";
        public static string RegisterButton = "//button[text()= 'Register']";
        public static string ResultMessage = "//div[contains(@class,'result alert')]";
        public static string LoginName = "//input[@name='login']";
        public static string LoginPassword = "//input[@name='password']";
        public static string LoginButton = "//button[text()= 'Login']";
    }
    
}
