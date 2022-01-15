using BuggyCarsRatingAPIAutoTests.Helper;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingAPIAutoTests.Models.BuggyCarsAPI.users
{
    public class Users : APIHelper
    {
        string _requestBody;
        IRestResponse _restResponse;
        public static string UserName { get; set; }
        Random random = new Random();
        public Users(string baseURL) : base(baseURL)
        {
            if (String.IsNullOrEmpty(UserName))
                UserName = "Test" + random.Next();
        }

        public void GenerateRequestBody(string userName, string firstName, string lastName, string password, string confirmPassword, string endPointName)
        {
            _requestBody = CommonUtilities.ReadJson(Path.Combine(ConfigHelper.TestDataFolder, endPointName, endPointName + ".json"));
            //update parameters in json
            _requestBody = _requestBody.Replace("{{username}}", UserName);
            _requestBody = _requestBody.Replace("{{firstname}}", firstName);
            _requestBody = _requestBody.Replace("{{lastname}}", lastName);
            _requestBody = _requestBody.Replace("{{password}}", password);
            _requestBody = _requestBody.Replace("{{confirmpassword}}", confirmPassword);
        }

        public void CaptureResponse(string methodType, string endpoint)
        {
            //Execute the request
            _restResponse = Execute(endpoint, (Method)Enum.Parse(typeof(Method), methodType), _requestBody);
        }

        public bool ValidateResponse(string element, ComparisonType comparisionType, string expectedData)
        {
            bool result = true;
            CommonUtilities.ValidateResponseData(element, _restResponse, comparisionType, expectedData);
            return result;
        }
    }
}
