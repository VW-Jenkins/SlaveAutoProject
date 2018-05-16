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
    class HandleDynamicsTable
    {
        [Test]
        [Category("HandleTable")]
        public void TestDyanmicsTable() {
            IWebDriver driver = new FirefoxDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);

            driver.Url = "https://en.wikipedia.org/wiki/Programming_languages_used_in_most_popular_websites";
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(3);

            var elemTable = driver.FindElement(By.XPath("//div[@id='mw-content-text']//table[1]"));
            List<IWebElement> lstTrElem = new List<IWebElement>(elemTable.FindElements(By.TagName("tr")));

            String strRowData = "";

            foreach (var elemTr in lstTrElem) {
                List<IWebElement> lstTdElem = new List<IWebElement>(elemTr.FindElements(By.TagName("td")));
                if (lstTdElem.Count > 0)
                {
                    foreach (var elemTd in lstTdElem)
                    {
                        strRowData = strRowData + elemTd.Text + "\t\t";
                    }
                }
                else {
                    Console.WriteLine("This is Header Row");
                    Console.WriteLine(lstTrElem[0].Text.Replace("", "\t\t"));
                }
                Console.WriteLine(strRowData);
                strRowData = string.Empty;
            }
            Console.WriteLine("");
            driver.Close();
        }
    }
}
