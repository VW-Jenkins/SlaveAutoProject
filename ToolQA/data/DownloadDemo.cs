using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
//using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using System.IO;
using System.IO.Compression;
using OpenQA.Selenium.Chrome;

namespace ToolQA.data
{
    class DownloadDemo
    {      
        string currentFile = string.Empty;
        string name = string.Empty;
        bool result = false;

        IWebDriver driver;

        [SetUp]
        public void Initialize() {
            // driver = new FirefoxDriver();
            driver = new ChromeDriver();
        }

        [Test]
        [Category("DownloadFile")]
        public void Download_Demo() {
            driver.Url = "file:///C:/Users/v-victw/Desktop/ToolQA/ToolQA/data/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMinutes(2);
            name = driver.FindElement(By.LinkText("sample.zip")).Text;
            driver.FindElement(By.LinkText("sample.zip")).Click();

            Task.Delay(5000).Wait();
            string path = "C:\\Users\\v-victw\\Downloads";

            if (Directory.Exists(path))
            {
                bool result = CheckFile(name);
                if (result == true)
                {
                    ExtractFile();
                }
                else {
                    Assert.Fail("The file does not exist");
                }

            }
            else {
                Assert.Fail("The directory or folder does not exist");
            }
        }

        public bool CheckFile(string name) {
            currentFile = @"C:\Users\v-victw\Downloads\" + name + "";
            if (File.Exists(currentFile))
            {
                return true;
            }
            else {
                return false;
            }
        }

        public void ExtractFile() {
            string newExtractFolder = @"C:\Users\v-victw\Downloads\Extract";
            ZipFile.ExtractToDirectory(currentFile, newExtractFolder);
            VerifyFiles(newExtractFolder);
        }

        public void VerifyFiles(string newExtractFolder) {
            string[] fileExtries = Directory.GetFiles(newExtractFolder);
            List<string> listItemsName = new List<string>();
            for (int i = 0; i < fileExtries.Length; i++) {
                string[] split = fileExtries[i].Split('\\');
                listItemsName.Add(split.Last());
            }

            List<string> originalList = new List<string>() { "sample_1.txt", "sample_2.txt" };
            result = originalList.Count == listItemsName.Count && originalList.All(listItemsName.Contains);

            if (result == true)
            {
                Console.WriteLine("The expected files are present");
                DeleteFilesAndDirectory();
                Assert.Pass("The expected files are present");
            }
            else {
                Console.WriteLine("The exoected files are not present");
                DeleteFilesAndDirectory();
                Assert.Fail("The expected files are not present");
            }
        }

        public void DeleteFilesAndDirectory() {
            if (Directory.Exists(@"C:\Users\v-victw\Downloads\Extract")) {
                Directory.Delete(@"C:\Users\v-victw\Downloads\Extract", true);
            }
            if (File.Exists(currentFile)) {
                File.Delete(currentFile);
            }
        }

        [TearDown]
        public void End() {
            driver.Close();
        }

    }
}
