using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace GestionInventario.Test.Login
{
    public class LoginTests
    {
        private IWebDriver driver;
        private ExtentReports extent;
        private ExtentTest test;
        private ExtentHtmlReporter htmlReporter;
        private string reportFolder;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            reportFolder = Path.Combine(TestContext.CurrentContext.WorkDirectory, "TestResults");
            Directory.CreateDirectory(reportFolder);
            string reportPath = Path.Combine(reportFolder, "ReportePruebas.html");
            htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();

            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
        }

        [TearDown]
        public void TearDown()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            var errorMsg = TestContext.CurrentContext.Result.Message;

            string screenshotPath = TakeScreenshot(TestContext.CurrentContext.Test.Name);

            if (status == NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                test.Pass("Test passed").AddScreenCaptureFromPath(screenshotPath);
            }
            else if (status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                test.Fail("Test failed: " + errorMsg).AddScreenCaptureFromPath(screenshotPath);
            }
            else
            {
                test.Skip("Test skipped");
            }

            driver.Quit();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            extent.Flush();
        }

        private string TakeScreenshot(string testName)
        {
            try
            {
                var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                string fileName = $"{testName}_{DateTime.Now:yyyyMMdd_HHmmss}.png";
                string path = Path.Combine(reportFolder, fileName);
                screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);
                return path;
            }
            catch (Exception e)
            {
                Console.WriteLine("Error taking screenshot: " + e.Message);
                return null;
            }
        }

        [Test]
        public void Login_Successful()
        {
            driver.Navigate().GoToUrl("https://localhost:7129/");

            driver.FindElement(By.Id("userName")).SendKeys("King");
            driver.FindElement(By.Id("password")).SendKeys("1234");
            driver.FindElement(By.Id("loginButton")).Click();

            Assert.That(driver.Url, Does.Contain("/Producto/Index"));
            Assert.That(driver.FindElement(By.Id("logOut")).Displayed, Is.True);
        }
    }
}
