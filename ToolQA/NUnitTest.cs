using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;

namespace ToolQA
{
    class NUnitTest
    {
        /*
        public void TestApp() {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.demoqa.com";
            driver.Close();
        }
        */
        IWebDriver driver;
        [SetUp]
        public void Initialize() {
            driver = new FirefoxDriver();
        }
        [Category("FirstCases")]
        [Test]
        public void OpenAppTest() {
            driver.Url = "http://www.demoqa.com";
        }
        [TearDown]
         public void EndTest() {
            driver.Close();
        }

    }
}
