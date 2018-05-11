using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace ToolQA
{
    class FirstTestCase
    {
        
        static void Main(string[] args)
        {
            IWebDriver drive = new FirefoxDriver();
            drive.Url = "http://www.baidu.com";
        }
    }
}
