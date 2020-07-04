using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinnWorksTestInterview.PageObjects
{
    public class BasePage : driverManager
    {
        public IWebDriver driver { get; }
        public WebDriverWait wait = null;

        public BasePage(IWebDriver driver) : base()
        {
            this.driver = getDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public bool testCaseShouldPass(bool tc) {

            return true;
        }

      public NavigationBarWebObject navigationBarWebObject()
        {

            return new NavigationBarWebObject(driver);
        }

        public MiddlePage middlePage()
        {

            return new MiddlePage(driver);
        }





    }
}
