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
    public class Edit_Test : Home_Page
    {
        [OneTimeSetUp]
        public void SetupReport()
        {
            ReportManager.InitReport();
        }

        [Test]
        public void Edit_Item()
        {
            ReportManager.CreateTest("Edit_Item Test");

            var products_Cart = new Products_Cart_Pages(driver);

            products_Cart.Add_Item_Cart("Bolt Cutters", "1");
            ReportManager.CaptureScreenshot(driver, "Add Cart");

            Thread.Sleep(4000);

            products_Cart.Checkout_Page();
            Thread.Sleep(4000);

            ReportManager.CaptureScreenshot(driver, "Before edit product");

            products_Cart.Edit_Item("Bolt Cutters", "3");
            ReportManager.CaptureScreenshot(driver, "After edit product");

            ReportManager.LogPass("Edited Bolt Cutters quantity to 3");
        }

        [OneTimeTearDown]
        public void TearDownReport()
        {
            ReportManager.FlushReport();
        }
    }
}