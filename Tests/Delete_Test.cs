using NUnit.Framework;
using SeleniumTests.Pages;
using SeleniumTests.Utils; // updated namespace
using SeleniumTestProject.Utils;
using NUnit.Framework;
using SeleniumTests.Pages;
using SeleniumTestProject.Utils;
using System.Threading;

namespace SeleniumTests.Tests
{
    [TestFixture]
    public class Delete_Test : Home_Page
    {
        [OneTimeSetUp]
        public void SetupReport()
        {
            ReportManager.InitReport();
        }

        [Test]
        public void Delete_Item()
        {
            ReportManager.CreateTest("Delete_Item Test");

            var products_Cart = new Products_Cart_Pages(driver);

            products_Cart.Add_Item_Cart("Bolt Cutters", "1");
            ReportManager.CaptureScreenshot(driver, "Add Cart");

            Thread.Sleep(4000);

            products_Cart.Checkout_Page();
            Thread.Sleep(4000);

            ReportManager.CaptureScreenshot(driver, "Before delete product");

            products_Cart.Delete_Item("Bolt Cutters");
            ReportManager.CaptureScreenshot(driver, "After delete product");


            ReportManager.LogPass("Deleted Bolt Cutters from cart");
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            ReportManager.FlushReport();
        }
    }
}
