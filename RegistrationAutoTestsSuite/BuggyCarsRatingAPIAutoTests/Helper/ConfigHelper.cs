using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingAPIAutoTests.Helper
{
    class ConfigHelper
    {

        public static string APIBaseUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["buggycarsurl"];
            }
        }

        public static string TestDataFolder
        {
            get
            {
                return ConfigurationManager.AppSettings["testdatafolder"];
            }
        }
    }
}
