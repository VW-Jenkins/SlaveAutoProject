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
    class FindElementsCommands
    {
        [Test]
        public void TestFindElementsCommands() {
            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://toolsqa.wpengine.com/Automation-practice-form/";
            driver.FindElement(By.PartialLinkText("Partial")).Click();
            Console.WriteLine("Partial Link Test Pass");

            String sClass = driver.FindElements(By.TagName("button")).ToString();
            Console.WriteLine(sClass);

            driver.FindElement(By.LinkText("Link Test")).Click();
            Console.WriteLine("Link Test Pass");

            driver.Close();
        }
    }
}
