using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace BuggyCarsRatingUIAutoTests.Helper
{
    class ConfigurationHelper
    {
        public static string AppUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["buggycarsurl"];
            }
        }

    }
}
