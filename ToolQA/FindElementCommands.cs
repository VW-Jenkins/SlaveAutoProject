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
    class FindElementCommands
    {
        [Test]
        [Category("FindElement")]
        public void TestFindElementCommands() {
            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://toolsqa.wpengine.com/Automation-practice-form/";

            driver.FindElement(By.Name("firstname")).SendKeys("Victor");
            driver.FindElement(By.Name("lastname")).SendKeys("Wang");
            driver.FindElement(By.Id("submit")).Click();

            driver.Close();

        }
    }
}
