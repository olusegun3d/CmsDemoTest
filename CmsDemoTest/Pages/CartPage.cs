using CmsDemoTest.Drivers;
using OpenQA.Selenium;
using System.Collections.ObjectModel;


namespace CmsDemoTest.Pages
{
    public class CartPage : BasePage
    {
        private IWebDriver driver;
        public CartPage(IWebDriver driver) : base(driver) { this.driver = driver; }   
        public ReadOnlyCollection<IWebElement> ItemsInCart => driver.FindElements(By.XPath("//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']"));
        public ReadOnlyCollection<IWebElement> ProductName => driver.FindElements(By.XPath($"//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']/td[@class='product-name']//a"));
        public ReadOnlyCollection<IWebElement> RemoveProduct => driver.FindElements(By.XPath($"//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']/td[@class='product-remove']/a"));        
        public ReadOnlyCollection<IWebElement> ProductPrice => driver.FindElements(By.XPath($"//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']/td[@class='product-price']/span"));
        public ReadOnlyCollection<IWebElement> ProdcutQauantity => driver.FindElements(By.XPath($"//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']/td[@class='product-quantity']//input"));
        public ReadOnlyCollection<IWebElement> ProductSubTotal => driver.FindElements(By.XPath($"//tbody//tr[@class='woocommerce-cart-form__cart-item cart_item']/td[@class='product-subtotal']/span/text()"));
        public IWebElement UpdateCart => driver.FindElement(By.XPath("//tbody//button[@name='update_cart']"));
        public IWebElement ShippingTotals => driver.FindElement(By.XPath("//tbody//tr[@class='woocommerce-shipping-totals shipping']//span"));
        public IWebElement OrderTotals => driver.FindElement(By.XPath("//tbody//tr[@class='order-total']//span"));
        public IWebElement RemoveProductOnSwagSite => driver.FindElement(By.XPath("//button[@class='wc-block-cart-item__remove-link']"));
        public IWebElement ShopLisTable =>  driver.FindElement(By.XPath("//form[@class='woocommerce-cart-form']"));
        public By UndoDeleteButton => By.XPath("//div[@class='woocommerce-message']//a");
        

        public int SearchForLowestPriceInCart() 
        {
            var price = Double.Parse(ProductPrice.ToArray()[0].Text.Substring(1));
            var index = -1;
            for (int x = 0; x<ItemsInCart.Count; x++)
            {
                if (Double.Parse(ProductPrice.ToArray()[x].Text.Substring(1)) <= price)
                {
                    price = Double.Parse(ProductPrice.ToArray()[x].Text.Substring(1));
                    index = x;
                }
            }
            return index;
        }

        public void DeleteAProduct(int index)
        {
            var CountBeforeDeletion = RemoveProduct.Count;
            RemoveProduct.ToArray()[index].Click();
            driver.FindElementWithWait(UndoDeleteButton);
        }
    }
}
