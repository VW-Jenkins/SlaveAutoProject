using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;

namespace ToolQA
{
    class ImplicitWait
    {
        [Test]
        [Category("ImplicitWait")]
        public void TestImplicitWait() {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(50);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(50);
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-switch-windows/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(50);
            IWebElement element = driver.FindElement(By.Id("target"));

            Thread.Sleep(2000);
            driver.Quit();
        }
    }
}
