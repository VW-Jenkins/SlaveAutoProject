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
    class Navigation
    {
        [Test]
        [Category("NavigationCommand")]
        public void NavigationCommands() {
            IWebDriver driver = new FirefoxDriver();

            driver.Navigate().GoToUrl("http://demoqa.com");

            driver.FindElement(By.XPath(".//*[@id='menu-item-374']/a")).Click();

            driver.Navigate().Back();
            driver.Navigate().Forward();
            driver.Navigate().Refresh();

            driver.Close();
        }
    }
}
