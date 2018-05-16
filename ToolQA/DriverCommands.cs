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
    class DriverCommands
    {
        [Test]
        [Category("DriverCommand")]
        public void TestDriveCommnads1() {
            IWebDriver driver = new FirefoxDriver();
            driver.Url = "http://www.demoqa.com";

            string Title = driver.Title;
            int titleLength = driver.Title.Length;
            Console.WriteLine("Title of the page is : " + Title);
            Console.WriteLine("Length of the Title is : " + titleLength);

            string PageUrl = driver.Url;
            int URLLength = driver.Url.Length;
            Console.WriteLine("URL of the page is : " + PageUrl);
            Console.WriteLine("Length of the URL is : " + URLLength);

            string PageSource = driver.PageSource;
            int PageSourceLength = driver.PageSource.Length;
            Console.WriteLine("Page source of the page is " + PageSource);
            Console.WriteLine("Length of the page Source is : " + PageSourceLength);

            driver.Quit();
        }
    }
}
