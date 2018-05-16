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
    class MultipleWindows
    {
        [Test]
        [Category("HandleMultipleWindows")]
        public void TestMultipleWindos() {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://toolsqa.com/automation-practice-switch-windows/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);
            driver.Manage().Window.Maximize();

            string parentWindowHandle = driver.CurrentWindowHandle;
            Console.WriteLine("Parent window's handle => " + parentWindowHandle);
            IWebElement clickElement = driver.FindElement(By.XPath("//div[@id='content']/p[2]/button[@id='button1']"));

            for (var i = 0; i < 3; i++) {
                clickElement.Click();
                Thread.Sleep(3000);
            }

            List<string> lstWindow = driver.WindowHandles.ToList();
            foreach (var handle in lstWindow) {
                // Console.WriteLine(handle);
                Console.WriteLine("Switching to window => " + handle);
                Console.WriteLine("Navigating to google.com");
                driver.SwitchTo().Window(handle);
                driver.Navigate().GoToUrl("https://www.google.com");
            }

            driver.Quit();
        }
    }
}
