using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YUTPLAT.Tests.Selenium
{
    [TestFixture]
    public class LoginTest
    {

        IWebDriver driver;

        [SetUp]
        public void StartTest()
        {
            driver = new ChromeDriver();
            driver.Url = "http://localhost:58491/Account/Login";
        }

        [TearDown]
        public void EndTest()
        {
            driver.Quit();
        }

        [Test]
        public void LoguearseBienTest()
        {            
            Assert.IsTrue(driver.Title.Contains("Hola"));
        }
    }
}
