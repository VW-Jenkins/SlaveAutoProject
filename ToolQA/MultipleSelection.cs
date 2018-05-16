using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace ToolQA
{
    class MultipleSelection
    {
        [Test]
        [Category("MutipleSelection")]
        public void TestMultipleSelection() {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);

            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            SelectElement oSelection = new SelectElement(driver.FindElement(By.Name("selenium_commands")));

            oSelection.SelectByIndex(0);
            Thread.Sleep(2000);
            oSelection.DeselectByIndex(0);

            oSelection.SelectByText("Navigation Commands");
            Thread.Sleep(2000);
            oSelection.DeselectByText("Navigation Commands");

            IList<IWebElement> oSize = oSelection.Options;
            int iListSize = oSize.Count;

            for (int i = 0; i<iListSize; i++) {
                String sValue = oSelection.Options.ElementAt(i).Text;
                Console.WriteLine("Value of the Item is : " + sValue);
                oSelection.SelectByIndex(i);
                Thread.Sleep(2000);
            }
            oSelection.DeselectAll();

            driver.Close();
        }
    }
}
