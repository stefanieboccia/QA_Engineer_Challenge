using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class Login_Page
    {
        private readonly IWebDriver _driver;
        public Login_Page(IWebDriver driver) => _driver = driver;

        public IWebElement SignIn_Button => _driver.FindElement(By.XPath("//a[text()='Sign in']"));
        public IWebElement Login_Button => _driver.FindElement(By.ClassName("btnSubmit"));
        public IWebElement Email_Input => _driver.FindElement(By.Id("email"));
        public IWebElement Password_Input => _driver.FindElement(By.Id("password"));

        /// <summary>
        /// Open Login Page - 'Sign In' button
        /// </summary>
        public void LoginPage()
        {
            SignIn_Button.Click();
        }

        /// <summary>
        /// Enter Provided Credentials
        /// </summary>
        public void Credentials(string email, string password)
        {
            // Clean Email Field
            Email_Input.Clear();
            // Type Email
            Email_Input.SendKeys(email);

            // Clean Password Field
            Password_Input.Clear();
            // Type Password
            Password_Input.SendKeys(password);
        }

        /// <summary>
        /// Click on Login Button
        /// </summary>
        public void Login()
        {
            Login_Button.Click();
        }
    }
}
