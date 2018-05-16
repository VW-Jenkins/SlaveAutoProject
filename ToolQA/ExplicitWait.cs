using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace ToolQA
{
    class ExplicitWait
    {
        [Test]
        [Category("ExplicitWait")]
        public void TestWebDriverWait() {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-switch-windows/";

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(1));
            Func<IWebDriver,IWebElement> waitForElement = new Func<IWebDriver, IWebElement>((IWebDriver Web) => { 
                Console.WriteLine("Waiting for color to change");
                IWebElement element = Web.FindElement(By.Id("colorVar"));
                if (element.GetAttribute("style").Contains("red")) {
                    return element;
                }
                return null;
            });

            IWebElement targetElement = wait.Until(waitForElement);
            Console.WriteLine("Inner HTML of element is " + targetElement.GetAttribute("innerHTML"));
            driver.Quit();
        }

        [Test]
        [Category("ExplicitWait")]
        public void TestDefaultWait() {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://toolsqa.wpengine.com/automation-practice-switch-windows/";

            IWebElement element = driver.FindElement(By.Id("clock"));
            DefaultWait<IWebElement> wait = new DefaultWait<IWebElement>(element);
            wait.Timeout = TimeSpan.FromMinutes(2);
            wait.PollingInterval = TimeSpan.FromMilliseconds(250);

            Func<IWebElement, bool> waiter = new Func<IWebElement, bool>((IWebElement ele)=>{
                string styleAttrib = ele.Text;
                if (styleAttrib.Contains("Buzz")) {
                    return true;
                }
                Console.WriteLine("Current time is " + styleAttrib);
                return false;
            });
            wait.Until(waiter);

            driver.Quit();
        }
    }
}
