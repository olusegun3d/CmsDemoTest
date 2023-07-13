using CmsDemoTest.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemoTest.Pages
{
    public class BasePage
    {
        private IWebDriver driver;
        public BasePage(IWebDriver driver) { this.driver = driver; }

        //Header links common to all pages
        public  IWebElement CartLink => driver.FindElement(By.XPath("//li/a[@href='https://cms.demo.katalon.com/cart/']"));
        public  IWebElement HomePageLink => driver.FindElement(By.XPath("//li/a[@href='https://cms.demo.katalon.com/']"));

    }
}
