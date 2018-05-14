using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

namespace ToolQA
{
    class DropDownBox
    {
        [Test]
        public void TestDropdownBox() {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);

            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            SelectElement oSelection = new SelectElement(driver.FindElement(By.Id("continents")));
            oSelection.SelectByText("Europe");

            Thread.Sleep(2000);
            oSelection.SelectByIndex(2);

            Thread.Sleep(2000);

            IList<IWebElement> oSize = oSelection.Options;
            int iListSize = oSize.Count;

            for (int i = 0; i < iListSize; i++) {
                string sValue = oSelection.Options.ElementAt(i).Text;
                Console.WriteLine("Value of the Select item is : " + sValue);

                if (sValue.Equals("Africa")) {
                    oSelection.SelectByIndex(i);
                    break;
                }
            }

            driver.Close();
        }
    }
}
