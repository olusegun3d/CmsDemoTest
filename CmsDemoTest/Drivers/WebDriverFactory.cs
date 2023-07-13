using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmsDemoTest.Drivers
{
    public class WebDriverFactory
    {
        public static ChromeOptions chromeOptions = new ChromeOptions();

        public static IWebDriver BrowserDriverType(String BrowserName)
        {
            return BrowserName switch
            {
                //The commented line immediately below has become necessary because there seems to be limited access to the website in the uk
                //The only time the access is snmooth is around 7 to 8 pm onwards
                "Chrome" => new ChromeDriver("C:\\Work\\CmsDemoTest\\CmsDemoTest\\bin\\Debug\\chromedriver.exe", chromeOptions, TimeSpan.FromSeconds(500)),
                //"Chrome" => new ChromeDriver(),
                "Edge" => new EdgeDriver(),
                "Firefox" => new FirefoxDriver(),
                _ => throw new ArgumentOutOfRangeException(BrowserName.ToString(), $"Unknown {BrowserName.ToString()}")
            };
        }
    }
}

