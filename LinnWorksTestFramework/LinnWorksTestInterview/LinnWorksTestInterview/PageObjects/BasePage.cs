using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinnWorksTestInterview.PageObjects
{
    public class BasePage
    {
        public IWebDriver driver { get; }
        public WebDriverWait wait = null;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
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
