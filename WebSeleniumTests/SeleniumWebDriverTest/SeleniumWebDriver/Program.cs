using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumWebDriver
{
    class Program
    {
        static readonly IWebDriver driver = new ChromeDriver();
        static void Main(string[] args)
        {
            driver.Navigate().GoToUrl(@"http://google.com");
            System.Threading.Thread.Sleep(1000); // for visualization
            IWebElement search = driver.FindElement(By.Name("q"));
            search.Click();
            search.SendKeys("unit testing");
            System.Threading.Thread.Sleep(1000); // for visualization
            search.SendKeys(Keys.Enter);

            IWebElement wiki = driver.FindElement(By.XPath("//a[@href='https://en.wikipedia.org/wiki/Unit_testing']"));
            System.Threading.Thread.Sleep(1000); // for visualization
            wiki.Click();

            search = driver.FindElement(By.Name("search"));
            search.Click();
            search.SendKeys("nunit");
            System.Threading.Thread.Sleep(1000); // for visualization
            search.SendKeys(Keys.Enter);

        
            wiki = driver.FindElement(By.XPath("//a[@href='https://ru.wikipedia.org/wiki/NUnit']"));
            System.Threading.Thread.Sleep(1000); // for visualization
            wiki.Click();
        }
    }
}
