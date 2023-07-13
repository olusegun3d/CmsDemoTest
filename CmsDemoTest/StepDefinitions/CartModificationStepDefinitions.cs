using System;
using TechTalk.SpecFlow;
using CmsDemoTest.Pages;
using System.Xml.Linq;
using OpenQA.Selenium;

namespace CmsDemoTest.StepDefinitions
{
    [Binding]
    public class CartModificationStepDefinitions 
    {
        private readonly ScenarioContext _scenarioContext;
        public CartModificationStepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        int lowestPriiceIndex { get; set; }
        [Given(@"I add four random items to my cart")]
        public void GivenIAddFourRandomItemsToMyCart()
        {
            WebSite.webSiteUser.ProductsToBeBought(4);
            WebSite.webSiteUser.Buy();
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            WebSite.homePage.CartLink.Click();
        }

        [Then(@"I find total four items listed in my cart")]
        public void ThenIFindTotalFourItemsListedInMyCart()
        {
            
            WebSite.cartPage.ItemsInCart.Should().HaveCount(4);
        }

        [When(@"I search for the lowest price item")]
        public void WhenISearchForTheLowestPriceItem()
        {
            lowestPriiceIndex = WebSite.cartPage.SearchForLowestPriceInCart();
        }

        [When(@"I am able to remove the lowest item")]
        public void WhenIAmAbleToRemoveTheLowestItem()
        {
            WebSite.cartPage.DeleteAProduct(lowestPriiceIndex);
        }

        [Then(@"I am able to verify three items in my cart")]
        public void ThenIAmAbleToVerifyThreeItemsInMyCart()
        {           
            WebSite.cartPage.ItemsInCart.Should().HaveCount(3);
        }
    }
}
