using OpenQA.Selenium;

namespace SeleniumTests.Pages
{
    public class Products_Cart_Pages
    {
        private readonly IWebDriver _driver;
        public Products_Cart_Pages(IWebDriver driver) => _driver = driver;

        public IWebElement signIn_Button => _driver.FindElement(By.XPath("//a[text()='Sign in']"));
        public IWebElement quantity_Input => _driver.FindElement(By.Id("quantity-input"));
        public IWebElement addToCart_Button => _driver.FindElement(By.Id("btn-add-to-cart"));
        public IWebElement home_Button => _driver.FindElement(By.XPath("//a[text()='Home']"));
        public IWebElement checkout_Button => _driver.FindElement(By.CssSelector("[aria-label='cart']"));


        public void Edit_Item(string productName, string newQuantity)
        {
            var quantity_Cart_Input = _driver.FindElement(By.XPath($"//tr[.//span[@data-test='product-title' and contains(normalize-space(text()), '{productName}')]]//input[@data-test='product-quantity']"));

            quantity_Cart_Input.Clear();
            quantity_Cart_Input.SendKeys(newQuantity);
        }
        public void Delete_Item(string productName)
        {
            var delete_btn = _driver.FindElement(By.XPath($"//tr[.//span[@data-test='product-title' and contains(normalize-space(), '{productName}')]]//a[contains(@class, 'btn-danger')]"));

            delete_btn.Click();
        }
        public void Add_Item_Cart(string productName, string quantity)
        {
            var item = _driver.FindElement(By.XPath($"//a[.//h5[contains(text(),'{productName}')]]"));
            item.Click();

            var addToCart_Button = _driver.FindElement(By.Id("btn-add-to-cart"));

            quantity_Input.Clear();
            quantity_Input.SendKeys(quantity);

            addToCart_Button.Click();
        }
        public void Products_Page()
        {
            home_Button.Click();
        }
        public void Checkout_Page()
        {
            checkout_Button.Click();
        }
        public string Search_Item(string productName)
        {
            var products = GetAllProducts();
            var item = products.FindElement(By.XPath($"//a[.//h5[contains(text(),'{productName}')]]"));

            var productID = item.GetAttribute("data-test").Split("-")[1].ToLower();
            item.Click();

            return productID;
        }
        public IWebElement GetAllProducts()
        {

            return _driver.FindElement(By.ClassName("col-md-9"));
        }
    }
}
