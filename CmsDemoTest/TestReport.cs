﻿using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using CmsDemoTest.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlowBDDAutomationFramework.Utility
{
    public class TestReport
    {
        public static IWebDriver driver { get; set; }       
        public static ExtentReports _extentReports;
        public static ExtentTest _feature;
        public static ExtentTest _scenario;

        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String testResultPath = dir.Replace("bin\\Debug\\net6.0", "TestResults");

        public static void InitTestReport()
        {
            var htmlReporter = new ExtentHtmlReporter(testResultPath);
            htmlReporter.Config.ReportName = "Automation Status Report";
            htmlReporter.Config.DocumentTitle = "Automation Status Report";
            htmlReporter.Start();

            _extentReports = new ExtentReports();
            _extentReports.AttachReporter(htmlReporter);
        }

        public static void TestReportFlush()
        {
            _extentReports.Flush();
        }


        public static void CreateScenarioNodes(ScenarioContext scenarioContext, IWebDriver driver)
        {

            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Pass("TestReportPassed",
                    MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, WebSite.cartPage.ShopLisTable, "green")).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {
                var cleanErrorMessage = scenarioContext.TestError.Message.Remove(scenarioContext.TestError.Message.IndexOf('{'), (scenarioContext.TestError.Message.IndexOf('}')+1) - scenarioContext.TestError.Message.IndexOf('{')+1);

                if (stepType == "Given")                
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, WebSite.cartPage.ShopLisTable, "red")).Build());
                }
                    else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, WebSite.cartPage.ShopLisTable, "red")).Build());
                }
                else if (stepType == "Then")
                {                    
                    _scenario.CreateNode<Then>(stepName).Fail(cleanErrorMessage,
                       MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, WebSite.cartPage.ShopLisTable, "red")).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext, WebSite.cartPage.ShopLisTable, "red")).Build());                    
                }
            }
            
        }


        public static void HighlightWebElement(IWebElement theElement, string color)
        {
            IJavaScriptExecutor j = (IJavaScriptExecutor)driver;
            j.ExecuteScript("arguments[0].scrollIntoView({block: 'center', inline: 'nearest'})", theElement);
            var jsDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = $@"arguments[0].style.cssText = ""border-width: 4px; border-style: solid; border-color: {color}"";";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { theElement });
        }

        public static string addScreenshot(IWebDriver driver, ScenarioContext scenarioContext, IWebElement webElement, string colour)
        {
            string screenshotLocation;

            if (scenarioContext.TestError == null)
            {
                HighlightWebElement(webElement, colour);
                screenshotLocation = Path.Combine(testResultPath, "PASS " + scenarioContext.ScenarioInfo.Title + ".png");
            }
            else
            {
                HighlightWebElement(webElement, colour);
                screenshotLocation = Path.Combine(testResultPath, "FAIL " + scenarioContext.ScenarioInfo.Title + ".png");
            }
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;
            Screenshot screenshot = takesScreenshot.GetScreenshot();
            screenshot.SaveAsFile(screenshotLocation, ScreenshotImageFormat.Png);
            return screenshotLocation;
        }
    }
}
