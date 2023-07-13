using CmsDemoTest.Drivers;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.ServiceWorker;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemoTest.Pages
{
    public class WebSiteUser
    {
        public static List<int> ProductsToBuy = new List<int>();

        private IWebDriver driver;

        public WebSiteUser(IWebDriver driver)  { this.driver = driver; }

        public void Buy()
        {
            ProductsToBuy = ProductsToBuy.OrderBy(x => x).ToList();
            int productsPerPage = 12;
            int index = 0;

            foreach (var item in ProductsToBuy)
            {
                index = item;
                if (item >= productsPerPage)
                {
                    index = item - productsPerPage;
                    WebSite.homePage.ProductCatalogueNavigation.ToArray()[1].Click();//go to page 2. 
                }

                if (index <= productsPerPage)
                {
                    WebSite.homePage.ProductThumbnailNamePrice.ToArray()[index].Click();
                    WebSite.productPage.SelectAColourIfApplicable();
                    WebSite.productPage.SelectASizeIfApplicable();
                    WebSite.productPage.SetQuantity(1);
                    WebSite.productPage.addtocart.Click();
                    WebSite.productPage.HomePageLink.Click();
                }
            }
        }

        public void ProductsToBeBought(int Number)
        {            
            IEnumerable<int> numbers = Enumerable.Empty<int>();
            int productIndex = 0;
            int productsPerPage = 12;
            for (int page = 1; page < WebSite.homePage.ProductCatalogueNavigation.Count; page++)
            {
                foreach (var item in WebSite.homePage.ProductDynamicLabel)
                {
                    //The code commented below uses selenium actions to go every product card. However I find it quite slow s I used java script
                    /*Actions actions = new Actions(BasePage.driver);                
                    actions.MoveToElement(item);
                    actions.Perform();
                    if (!item.Text.Equals("BUY ON WORDPRESS SWAG STORE", StringComparison.OrdinalIgnoreCase) && !item.Text.Equals("SELECT OPTIONS", StringComparison.OrdinalIgnoreCase))
                    {
                        numbers = numbers.Append(_homePage.ProductDynamicLabel.ToList().IndexOf(item));
                    }*/

                    var itemText = ((IJavaScriptExecutor)driver).ExecuteScript("return arguments[0].firstChild.textContent;", item).ToString();
                    if (!itemText!.Equals("BUY ON WORDPRESS SWAG STORE", StringComparison.OrdinalIgnoreCase) && !itemText.Equals("READ MORE", StringComparison.OrdinalIgnoreCase))
                    {
                        if (page == 1)
                        {
                            productIndex = WebSite.homePage.ProductDynamicLabel.ToList().IndexOf(item);
                            numbers = numbers.Append(productIndex);
                        }
                        if (page == 2)
                        {
                            productIndex = WebSite.homePage.ProductDynamicLabel.ToList().IndexOf(item);
                            numbers = numbers.Append(productIndex + productsPerPage);
                        }
                    }
                }
                WebSite.homePage.ProductCatalogueNavigation.ToArray()[1].Click();//go to page 2
            }
            var ShortListed = numbers.Count();
            for (int ctr = 0; ctr < Number; ctr++)
            {
                var RandomlySelectedProduct = new Random().Next(ShortListed);//select a random number
                ProductsToBuy.Add(numbers.ToArray()[RandomlySelectedProduct]);
                int exclude = numbers.ToArray()[RandomlySelectedProduct];
                numbers = numbers.Where(i => i != exclude);//regenerate a list without that number
                ShortListed = numbers.Count();
            }               
            
        }

    }
}
