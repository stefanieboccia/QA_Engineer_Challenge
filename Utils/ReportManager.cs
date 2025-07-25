using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;

namespace SeleniumTestProject.Utils
{
    public static class ReportManager
    {
        private static ExtentReports _extent;
        private static ExtentSparkReporter _htmlReporter;
        public static ExtentTest Test;

        public static void InitReport()
        {
            string reportName = $"TestReport_{DateTime.Now:yyyyMMdd_HHmmss}.html";
            _htmlReporter = new ExtentSparkReporter(reportName);
            _extent = new ExtentReports();
            _extent.AttachReporter(_htmlReporter);
            Console.WriteLine($"Report will be saved to: {System.IO.Path.GetFullPath(reportName)}");
        }

        public static void CreateTest(string name)
        {
            Test = _extent.CreateTest(name);
        }

        public static void LogPass(string msg) => Test.Pass(msg);
        public static void LogFail(string msg) => Test.Fail(msg);
        public static void LogInfo(string msg) => Test.Info(msg);

        public static void CaptureScreenshot(IWebDriver driver, string stepName)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            string path = $"screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            screenshot.SaveAsFile(path);
            Test.AddScreenCaptureFromPath(path, stepName);
        }

        public static void FlushReport()
        {
            _extent.Flush();
        }
    }
}
