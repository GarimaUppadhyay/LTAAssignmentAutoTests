using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuggyCarsRatingUIAutoTests.Helper
{
    public static class  CommonUtilities
    {

        public static void CaptureScreenshot(string fileName, IWebDriver driver, TestContext testContext)
        {
            Random random = new Random();
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            fileName = fileName + "_" + random.Next();
            string screenshotFile = Path.Combine(fileName + "_screenshot.png");
            screenshot.SaveAsFile(screenshotFile, ScreenshotImageFormat.Png);
            testContext.AddResultFile(screenshotFile);
        }
    }
}
