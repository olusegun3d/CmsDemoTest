using NUnit.Framework.Internal;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemoTest.Pages
{
    public class ProductPage : BasePage
    {
        private IWebDriver driver;
        public ProductPage(IWebDriver driver) : base(driver){ this.driver = driver; }
        public IWebElement producttitle => driver.FindElement(By.XPath("//h1[@class='product_title entry-title']"));
        public IWebElement productprice => driver.FindElement(By.XPath("//div[@class='summary entry-summary']//span[@class='woocommerce-Price-amount amount']"));
        public IWebElement productcurrency => driver.FindElement(By.XPath("//div[@class='summary entry-summary']//span[@class='woocommerce-Price-amount amount']/span"));
        public IWebElement addtocart => driver.FindElement(By.XPath("//div[@class='summary entry-summary']//button"));
        public IWebElement addtocartSwagStore => driver.FindElement(By.XPath("//button[@type='submit']"));
        public IWebElement viewSwagStoreCart => driver.FindElement(By.XPath("//a[@href='https://mercantile.wordpress.org/cart/']"));
        public IWebElement BuyOnSwagStore => driver.FindElement(By.XPath("//div[@class='summary entry-summary']//button"));
        public IWebElement ColourOption => driver.FindElement(By.Id("pa_color"));
        public IWebElement SizeOption => driver.FindElement(By.Id("size"));
        public IWebElement ProductVariant1Qty => driver.FindElement(By.XPath("(//input[@class='input-text qty text'])[1]"));
        public IWebElement ProductVariant2Qty => driver.FindElement(By.XPath("(//input[@class='input-text qty text'])[2]"));
        public IWebElement DecreaseQuantity => driver.FindElement(By.XPath("//div[@class='quantity-button quantity-down']"));
        public IWebElement IncreaseQuantity => driver.FindElement(By.XPath("//div[@class='quantity-button quantity-up']"));

        public void SelectAColourIfApplicable() 
        {
            SelectElement selectElement;
            if (driver.PageSource.Contains("id=\"pa_color\""))
            {
                selectElement = new SelectElement(ColourOption);;
                selectElement.SelectByIndex(new Random().Next(1, selectElement.Options.Count));
            }
        }

        public void SelectASizeIfApplicable()
        {
            SelectElement selectElement;
            if (driver.PageSource.Contains("id=\"size\""))
            {
                selectElement = new SelectElement(SizeOption); 
                selectElement.SelectByIndex(new Random().Next(1, selectElement.Options.Count));
            }
        }

        public void SetQuantity(int quantity)
        {            
            ProductVariant1Qty.Click();
            ProductVariant1Qty.SendKeys(Keys.Control +'a');
            ProductVariant1Qty.SendKeys(quantity.ToString());            
        }
    }
}
