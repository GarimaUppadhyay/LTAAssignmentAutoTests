using BuggyCarsRatingAPIAutoTests.Helper;
using BuggyCarsRatingAPIAutoTests.Models.BuggyCarsAPI.users;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;

namespace BuggyCarsRatingAPIAutoTests.StepDefiniton.BuggyCarsAPI.users
{
    [Binding]
    public class BuggyRegistrationAPISteps
    {
        Users user;
        public BuggyRegistrationAPISteps()
        {
            user = new Users(ConfigHelper.APIBaseUrl);
        }
        [StepDefinition(@"User has provided ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" ""(.*)"" for ""(.*)"" API")]
        public void GivenUserHasProvidedForAPI(string userName, string firstName, string lastName, string password, string confirmPassword, string endPointName)
        {
            user.GenerateRequestBody(userName, firstName, lastName, password, confirmPassword, endPointName);
        }

        [StepDefinition(@"User Submit API Request by ""(.*)"" method with json for ""(.*)"" to end point ""(.*)""")]
        public void WhenUserSubmitAPIRequestByMethodWithJsonForToEndPoint(string methodType, string friendlyName, string endPointName)
        {
            user.CaptureResponse(methodType, endPointName);
        }

        [StepDefinition(@"the response should show ""(.*)"" ""(.*)"" ""(.*)""")]
        public void ThenTheResponseShouldShow(string element, ComparisonType comparisionType, string expectedData)
        {
            Assert.IsTrue(user.ValidateResponse(element, comparisionType, expectedData));
        }
    }
}
