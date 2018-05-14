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
    class CheckBoxRadio
    {
        [Test]
        public void TestCheckBox_Radio() {
            IWebDriver driver = new FirefoxDriver();

            driver.Url = "http://toolsqa.wpengine.com/automation-practice-form";

            IList<IWebElement> rdBtn_Sex = driver.FindElements(By.Name("sex"));
            Boolean bValue = false;
            bValue = rdBtn_Sex.ElementAt(0).Selected;

            if (bValue)
            {
                rdBtn_Sex.ElementAt(1).Click();
            }
            else {
                rdBtn_Sex.ElementAt(0).Click();
            }

            IWebElement rdBtn_Exp = driver.FindElement(By.Id("exp-2"));
            rdBtn_Exp.Click();

            IList<IWebElement> chkBx_Profession = driver.FindElements(By.Name("profession"));
            int iSize = chkBx_Profession.Count;

            for (int i = 0; i < iSize; i++) {
                String Value = chkBx_Profession.ElementAt(i).GetAttribute("value");
                if (Value.Equals("Automation Tester")) {
                    chkBx_Profession.ElementAt(i).Click();
                    break;
                }
            }

            IWebElement oCheckBox = driver.FindElement(By.CssSelector("input[value='Selenium IDE']"));
            oCheckBox.Click();
            driver.Close();
        }
    }
}
