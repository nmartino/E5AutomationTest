using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace LinnWorksTestInterview
{
    public class driverManager
    {
        IWebDriver driver;

        [BeforeScenario("UI")]
        public IWebDriver getDriver() {
            this.driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:59509/");
            driver.Manage().Window.Maximize();
            return driver;            
        }
    }
}
