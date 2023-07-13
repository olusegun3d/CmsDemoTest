using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace CmsDemoTest.Drivers
{
    public static class WebDriverWaitExtensions
    {
        public static double TimeoutInSeconds { get; set; }

        public static IWebElement FindElementWithWait(this IWebDriver driver, By by, int TimeoutInSeconds = 20)
        {
          WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           return  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
        }
    }
}    




