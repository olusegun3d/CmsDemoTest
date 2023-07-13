using NUnit.Framework;
using System.Diagnostics;
using TechTalk.SpecFlow;
using CmsDemoTest.Pages;
using OpenQA.Selenium;
using CmsDemoTest.Drivers;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using SpecFlowBDDAutomationFramework.Utility;
using CmsDemoTest.WebTestData;
using NUnit.Framework.Interfaces;

namespace CmsDemoTest.StepDefinitions
{
    [Binding]
    public sealed class Hooks1 : TestReport
    {
        static IWebDriver driver = WebDriverFactory.BrowserDriverType(TestData.ChromeBrowser);

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            InitTestReport();
        }


        [AfterTestRun]
        public static void AfterTestRun()
        {
            TestReportFlush();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(TestData.CmsDemoKatalonHomePage);
            TestReport.driver = driver;
            new WebSite(driver);//No variable needed just to instantiate static member web pages
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            CreateScenarioNodes(scenarioContext, driver);
        }

        [AfterFeature]
        public static void AfterFeature(FeatureContext featurecontext)
        {
            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}