using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.Threading;

namespace ToolQA
{
    class Alerts
    {

        IWebDriver driver = new FirefoxDriver();
        [Test]
        [Category("Alert")]
        public void TestSimplrAlerts() {
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//div[@id='content']/p[4]/button")).Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();

            string alertText = simpleAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);

            simpleAlert.Accept();

            driver.Close();
        }

        [Test]
        [Category("Alert")]
        public void TestConfirmationAlert() {
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);
            driver.Manage().Window.Maximize();

            //driver.FindElement(By.XPath("//div[@id='content']/p[8]/button")).Click();
            IWebElement element = driver.FindElement(By.XPath("//*[@id='content']/p[8]/button"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            IAlert confirmationAlert = driver.SwitchTo().Alert();
            String alertText = confirmationAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);
            confirmationAlert.Dismiss();

            driver.Close();
        }

        [Test]
        [Category("Alert")]
        public void TestPromptAlert() {
            driver.Url = "http://toolsqa.wpengine.com/handling-alerts-using-selenium-webdriver/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(3);
            driver.Manage().Window.Maximize();

            driver.FindElement(By.XPath("//div[@id='content']/p[11]/button")).Click();

            IAlert promptAlert = driver.SwitchTo().Alert();

            string alertText = promptAlert.Text;
            Console.WriteLine("Alert Text is " + alertText);

            promptAlert.SendKeys("Accepting the alert");
            Thread.Sleep(2000);

            promptAlert.Accept();

            driver.Close();
        }
    }
}
