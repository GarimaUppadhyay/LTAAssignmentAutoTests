using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingAPIAutoTests.Helper
{
    public class CommonUtilities
    {
        public static string ReadJson(string filePath)
        {
            string json;
            using (StreamReader r = new StreamReader(filePath))
            {
                json = r.ReadToEnd();
            }
            return json;
        }
        public static string GetResponseData(string elementName, IRestResponse response)
        {
            string elementValue = String.Empty;
            try
            {
                switch (elementName.ToLower())
                {
                    case "message":
                        elementValue = JsonConvert.DeserializeObject<dynamic>(response.Content)
                            ["message"].Value;
                        break;
                    case "statuscode":
                        elementValue = response.StatusCode.ToString();
                        break;

                }
            }
            catch (Exception)
            {
                elementValue = String.Empty;
            }
            return elementValue;
        }

        /// <summary>
        /// Method to validate the response data
        /// </summary>
        /// <param name="element"></param>
        /// <param name="response"></param>
        /// <param name="operatorType"></param>
        /// <param name="expectedData"></param>
        public static bool ValidateResponseData(string element, IRestResponse response, ComparisonType comparisionType, string expectedData)
        {
            bool result = true;
            try
            {
                string actualData = GetResponseData(element, response);
                switch (comparisionType)
                {
                    case ComparisonType.EQUALS:
                        result = expectedData.ToLower().Trim().Equals(actualData.ToLower().Trim());
                        
                        break;
                    case ComparisonType.CONTAINS:
                        result = actualData.ToLower().Contains(expectedData.ToLower());
                         break;
                }
                Console.WriteLine($"Verifying the value for :{element} \n Expected Data was: {expectedData} and Actal Data is: {actualData} and Comparision Result: {result.ToString().ToUpper()}");
            }
            catch (Exception) { }
            return result;
        }
    }
    /// <summary>
    /// Enum for different comparision type used for data validations
    /// </summary>
    public enum ComparisonType
    {
        EQUALS,
        CONTAINS
    }
}
