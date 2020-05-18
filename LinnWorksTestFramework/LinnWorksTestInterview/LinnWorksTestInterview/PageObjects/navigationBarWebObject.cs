using Dynamitey.Internal.Optimization;
using Io.Cucumber.Messages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinnWorksTestInterview.PageObjects
{
    public class NavigationBarWebObject : BasePage
    {
        public IWebDriver driver;

        public NavigationBarWebObject(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement logInButtonNavigationBar => driver.FindElement(By.XPath("//div[@class='navbar-collapse collapse']//a[@ng-reflect-router-link = '/login']"));
        public IWebElement logOutButton => driver.FindElement(By.XPath("//a[@ng-reflect-router-link='/logout']"));

        public void clicLogInButton() {

            logInButtonNavigationBar.Click();
        }

        public bool logInButtonIsDisplayed()
        {

            return wait.Until(WebDriver => logInButtonNavigationBar.Displayed);
        }

        public bool logOutButtonIsDisplayed()
        {

            return wait.Until(WebDriver => logOutButton.Displayed);
        }

    }
}
