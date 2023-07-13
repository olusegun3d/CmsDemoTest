using CmsDemoTest.Drivers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemoTest.Pages
{
    public  class WebSite 
    {
        private static IWebDriver _driver;
        public static BasePage basePage;
        public static HomePage homePage;
        public static ProductPage productPage;
        public static CartPage cartPage;
        public static WebSiteUser webSiteUser;

        public WebSite(IWebDriver driver) 
        {
             _driver = driver;
             basePage = new CartPage(_driver);
             homePage = new HomePage(_driver);
             productPage = new ProductPage(_driver);
             cartPage = new CartPage(_driver);
             webSiteUser = new WebSiteUser(_driver);
        }
    }
}
