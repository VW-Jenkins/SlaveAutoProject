using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
namespace ToolQA
{
    class DriverCommands2
    {
        [Test]
        [Category("DriverCommand")]
        public void TestDriveCommands2(){
            IWebDriver drive = new FirefoxDriver();
            drive.Url = "http://demoqa.com/frames-and-windows/";

            drive.FindElement(By.XPath(".//*[@id='tabs-1']/div/p/a")).Click();

            drive.Close();
        }
    }
}
