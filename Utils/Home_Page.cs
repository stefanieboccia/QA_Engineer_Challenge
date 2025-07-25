using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests.Utils
{
    public class Home_Page
    {
        protected IWebDriver? driver;

        [SetUp]
        public void HomePage()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://practicesoftwaretesting.com/");
            Thread.Sleep(5000);
        }

        [TearDown]
        public void TearDown()
        {
            driver?.Quit();
            driver?.Dispose();
        }
    }
}
