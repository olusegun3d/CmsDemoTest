using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemoTest.Pages
{
    public class HomePage : BasePage
    {
        private IWebDriver driver;
        public HomePage(IWebDriver driver) : base (driver){ this.driver = driver; } 

        public IReadOnlyCollection<IWebElement> ProductThumbnailNamePrice => driver.FindElements(By.XPath("//li[contains(@class,'product type-product')]"));
        public IReadOnlyCollection<IWebElement> ProductDynamicLabel  => driver.FindElements(By.XPath("//li[contains(@class,'product type-product')]//a[@data-product_id]"));
        public IReadOnlyCollection<IWebElement> OnProductThumbnailAddToCart => driver.FindElements(By.XPath("//a[@class='woocommerce-LoopProduct-link woocommerce-loop-product__link']/following-sibling::a[1]"));
        public IReadOnlyCollection<IWebElement> ProductName => driver.FindElements(By.XPath("//li[contains(@class,'product type-product')]/a/h2"));
        public IReadOnlyCollection<IWebElement> ProductPrice => driver.FindElements(By.XPath("//li[contains(@class,'product type-product')]/a/span"));
        public IReadOnlyCollection<IWebElement> ProductCatalogueNavigation => driver.FindElements(By.XPath("//nav[@class='woocommerce-pagination']//li"));

        public List<int> ProductsToBuy = new List<int>();

        By test = By.XPath("//li[contains(@class,'product type-product')]/a/span");

        public void navigate() 
        {
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = new TimeSpan(0, 5, 0);
            driver.Manage().Timeouts().PageLoad = new TimeSpan(0, 5, 0);
            driver.Navigate().GoToUrl("https://cms.demo.katalon.com/");                        
        }

        public void BuyPrdduct(int ProductIndex)
        {
            ProductThumbnailNamePrice.ToArray()[ProductIndex].Click();
        }
    }
}
