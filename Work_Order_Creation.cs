using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using SeleniumWaitHelper = SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace Work_Order_Creation
{
    class Program
    {   
        //Create the reference for our browser.
        IWebDriver driver = new ChromeDriver();
       
        static void Main(string[] args)
        {
            



        }

        [SetUp]
        public void Initialize()
        {

            //Navigate to FieldEdge Page
            driver.Navigate().GoToUrl("http://login.fieldedge.com");
            Console.WriteLine("Opened URL");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(value: 1);

            //Find the Element assign user
            IWebElement user = driver.FindElement(By.CssSelector("#LoginEmail"));
            user.SendKeys("radasilva@fieldedge.com");

            //Password 
            IWebElement pass = driver.FindElement(By.CssSelector("#Password"));
            pass.SendKeys("Tippmann305");

            //Submit_key
            IWebElement submit = driver.FindElement(By.CssSelector("#login-form > div:nth-child(8) > input"));
            submit.Click();

            Console.WriteLine("Executed test.");
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [Test]
        public void CreateCustomer()
        {
            //func vars
            WebDriverWait wait5 = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Navigate to Customers list.
            IWebElement customerList = driver.FindElement(By.CssSelector("#sidebar-wrapper > ul > li:nth-child(4) > a > span:nth-child(2)"));
            customerList.Click();

            //Find, and click customer.
            IWebElement clickCustomer = driver.FindElement(By.CssSelector("#settings-information-container > div:nth-child(2) > div.clearfix.main-content > table > tbody > tr:nth-child(1) > td:nth-child(1) > div"));
            clickCustomer.Click();

            //Work-Orders Microdashboard.       
            IWebElement workOrdersMicro = driver.FindElement(By.CssSelector("#details-navigator > div:nth-child(3) > div.clearfix.section-summary"));
            workOrdersMicro.Click();
            
            //Add Work-order.            
            IWebElement addWorkOrder = driver.FindElement(By.CssSelector("#details-list-container > div:nth-child(2) > button"));             
            wait5.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#details-list-container > div:nth-child(2) > button")));
            addWorkOrder.Click(); 
            
            //Task Search bar.
            IWebElement taskFinder = driver.FindElement(By.CssSelector("#select2-taskCombobox-container"));
            wait5.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector("#select2-taskCombobox-container")));
            taskFinder.Click();
            
            //Type task -- Select Task. 
            IWebElement taskSearchBar = driver.FindElement(By.CssSelector(".select2-search__field"));
            wait5.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Ray Test Task");
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);
 
            //Call lead Source.
            IWebElement selectLeadSource = driver.FindElement(By.Id("select2-leadSourceCombobox-container"));
            selectLeadSource.Click();

            //Type Lead -- Select task
            IWebElement selectLeadSourceOption = driver.FindElement(By.CssSelector(".select2-search__field"));
            wait5.Until(SeleniumWaitHelper.ExpectedConditions.ElementIsVisible(By.CssSelector(".select2-search__field")));
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys("Aliens");
            driver.FindElement(By.CssSelector(".select2-search__field")).SendKeys(Keys.Enter);            
           
            //Create Work-order.
            IWebElement createWO = driver.FindElement(By.CssSelector("button.custom-btn:nth-child(3)"));
            createWO.Click();
            
        }

        [TearDown]
        public void CloseUp()
        {
            //Close Page and alot extra time
            Thread.Sleep(10000);
            driver.Close();

        }
    }
}