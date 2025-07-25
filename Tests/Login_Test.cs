using AventStack.ExtentReports.Model;
using NUnit.Framework;
using NUnit.Framework.Legacy;
using OpenQA.Selenium;
using SeleniumTestProject.Utils;
using SeleniumTests.Pages;
using SeleniumTests.Utils;
using System.Threading;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class Login_Test : Home_Page
    {
        [OneTimeSetUp]
        public void SetupReport()
        {
            ReportManager.InitReport();
        }

        [Test]
        public void ValidLogin()
        {
            ReportManager.CreateTest("ValidLogin Test");

            var login = new Login_Page(driver);

            // Login Page
            login.LoginPage();
            //ClassicAssert.IsTrue(driver.Url.Contains("/auth/login"));
            ReportManager.CaptureScreenshot(driver, "Access Login Page");
            ReportManager.LogPass("Login Page - Success");

            // Enter credentials
            login.Credentials("customer@practicesoftwaretesting.com", "welcome01");
            login.Login();
            Thread.Sleep(4000);

            // Account Page
            ClassicAssert.IsTrue(driver.Url.Contains("/account"));
            ReportManager.CaptureScreenshot(driver, "Successful Login");
            ReportManager.LogPass("Valid credentials - Login successful");
        }

        [Test]
        public void InvalidLogin_EmailFormat()
        {
            ReportManager.CreateTest("InvalidLogin_EmailFormat Test");

            var login = new Login_Page(driver);

            // Login Page
            login.LoginPage();
            Thread.Sleep(3000);
            ClassicAssert.IsTrue(driver.Url.Contains("/auth/login"));
            ReportManager.CaptureScreenshot(driver, "Access Login Page");

            // Enter Credentials
            login.Credentials("wrong", "badpass");
            login.Login();

            var error = driver.FindElement(By.XPath("//*[text()='Email format is invalid']"));
            ClassicAssert.IsTrue(error.Displayed);
            ReportManager.CaptureScreenshot(driver, "Invalid Email Format Error");
            ReportManager.LogPass("Proper validation message for invalid email format");
        }

        [Test]
        public void InvalidLogin()
        {
            ReportManager.CreateTest("InvalidLogin Test");

            var login = new Login_Page(driver);

            // Login Page
            login.LoginPage();
            Thread.Sleep(3000);
            ClassicAssert.IsTrue(driver.Url.Contains("/auth/login"));
            ReportManager.CaptureScreenshot(driver, "Access Login Page");

            // Enter Credentials
            login.Credentials("wrong@x.com", "badpass");
            login.Login();

            var error = driver.FindElement(By.XPath("//*[text()='Invalid email or password']"));
            ClassicAssert.IsTrue(error.Displayed);
            ReportManager.CaptureScreenshot(driver, "Invalid Credentials Error");
            ReportManager.LogPass("Proper validation message for incorrect credentials");
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            ReportManager.FlushReport();
        }
    }
}
