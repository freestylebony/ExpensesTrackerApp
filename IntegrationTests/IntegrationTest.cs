using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace IntegrationTests
{
    [TestClass]
    public class IntegrationTest
    {
        private IWebDriver _webDriver;

        [TestInitialize]
        public void SetUp()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            _webDriver = new EdgeDriver();

        }

        //Check the Home page's title name if contains 'ExpensesTrackerApp'.
        [TestMethod]
        public void HomePage_Navigate_CheckTitleForName()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            Assert.IsTrue(_webDriver.Title.Contains("ExpensesTrackerApp"));
        }


        //check if the element of "a.nav-link.text-dark" contains the title name 'Privacy'.
        [TestMethod]
        public void HomePage_Navigate_NavigatePrivacy()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("a.nav-link.text-dark")).Click();
            Assert.IsTrue(_webDriver.Title.Contains("Privacy"));
        }

        //create/add expense
        [TestMethod]
        public void HomePage_Create_expense()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("main p>a")).Click();
            var input_name = _webDriver.FindElement(By.CssSelector("input[name='ItemName']"));
            var input_amount = _webDriver.FindElement(By.CssSelector("input[name='Amount']"));
            var input_expenseDate = _webDriver.FindElement(By.CssSelector("input[name='ExpenseDate']"));
            var input_category = _webDriver.FindElement(By.CssSelector("input[name='Category']"));
            input_name.SendKeys("shirts");
            input_amount.SendKeys("50.00");
            input_expenseDate.SendKeys("03");
            input_expenseDate.SendKeys(Keys.Tab);
            input_expenseDate.SendKeys("08");
            input_expenseDate.SendKeys("2022");
            input_expenseDate.SendKeys(Keys.Tab);
            input_category.SendKeys("Shopping");
            input_category.Submit();
        }




        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
