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

        [TestMethod]
        public void HomePage_Create_expense2()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("main p>a")).Click();
            var input_name = _webDriver.FindElement(By.CssSelector("input[name='ItemName']"));
            var input_amount = _webDriver.FindElement(By.CssSelector("input[name='Amount']"));
            var input_expenseDate = _webDriver.FindElement(By.CssSelector("input[name='ExpenseDate']"));
            var input_category = _webDriver.FindElement(By.CssSelector("input[name='Category']"));
            input_name.SendKeys("Boots");
            input_amount.SendKeys("100.00");
            input_expenseDate.SendKeys("03");
            input_expenseDate.SendKeys(Keys.Tab);
            input_expenseDate.SendKeys("09");
            input_expenseDate.SendKeys("2022");
            input_expenseDate.SendKeys(Keys.Tab);
            input_category.SendKeys("Shopping");
            input_category.Submit();
        }

        [TestMethod]
        public void HomePage_Create_expense3()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("main p>a")).Click();
            var input_name = _webDriver.FindElement(By.CssSelector("input[name='ItemName']"));
            var input_amount = _webDriver.FindElement(By.CssSelector("input[name='Amount']"));
            var input_expenseDate = _webDriver.FindElement(By.CssSelector("input[name='ExpenseDate']"));
            var input_category = _webDriver.FindElement(By.CssSelector("input[name='Category']"));
            input_name.SendKeys("Vegetables");
            input_amount.SendKeys("120.00");
            input_expenseDate.SendKeys("03");
            input_expenseDate.SendKeys(Keys.Tab);
            input_expenseDate.SendKeys("10");
            input_expenseDate.SendKeys("2022");
            input_expenseDate.SendKeys(Keys.Tab);
            input_category.SendKeys("Groceries");
            input_category.Submit();
        }

        [TestMethod]
        public void HomePage_Create_expense4()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("main p>a")).Click();
            var input_name = _webDriver.FindElement(By.CssSelector("input[name='ItemName']"));
            var input_amount = _webDriver.FindElement(By.CssSelector("input[name='Amount']"));
            var input_expenseDate = _webDriver.FindElement(By.CssSelector("input[name='ExpenseDate']"));
            var input_category = _webDriver.FindElement(By.CssSelector("input[name='Category']"));
            input_name.SendKeys("car");
            input_amount.SendKeys("1000.00");
            input_expenseDate.SendKeys("03");
            input_expenseDate.SendKeys(Keys.Tab);
            input_expenseDate.SendKeys("15");
            input_expenseDate.SendKeys("2022");
            input_expenseDate.SendKeys(Keys.Tab);
            input_category.SendKeys("Transport");
            input_category.Submit();
        }
        // Edit first expense
        [TestMethod]
        public void HomePage_Navigate_Edit_First_Expense()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(1)")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='ItemName']"));
            input.Clear();
            input.SendKeys("Other");
            input.Submit();
        }

        [TestMethod]
        public void HomePage_Navigate_Edit_Second_Expense()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(2) td>a:nth-child(1)")).Click();
            var input = _webDriver.FindElement(By.CssSelector("input[name='ItemName']"));
            input.Clear();
            input.SendKeys("Other");
            input.Submit();
        }

        // delete the expense in the second row.
        [TestMethod]
        public void HomePage_Navigate_Delete_Second_Expense()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(2) td>a:nth-child(3)")).Click();
            var deleteButton = _webDriver.FindElement(By.CssSelector("input[value='Delete']"));
            deleteButton.Submit();
        }



        // delete the expense in the first row.
        [TestMethod]
        public void HomePage_Navigate_Delete_First_Expense()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(1) td>a:nth-child(3)")).Click();
            var deleteButton = _webDriver.FindElement(By.CssSelector("input[value='Delete']"));
            deleteButton.Submit();
        }


        // delete the expense in the 6th row.
        [TestMethod]
        public void HomePage_Navigate_Delete_Sixth_Expense()
        {
            _webDriver.Navigate().GoToUrl("https://localhost:5001/");
            _webDriver.FindElement(By.CssSelector("table tr:nth-child(6) td>a:nth-child(3)")).Click();
            var deleteButton = _webDriver.FindElement(By.CssSelector("input[value='Delete']"));
            deleteButton.Submit();
        }


        [TestCleanup]
        public void TearDown()
        {
            _webDriver.Quit();
        }
    }
}
