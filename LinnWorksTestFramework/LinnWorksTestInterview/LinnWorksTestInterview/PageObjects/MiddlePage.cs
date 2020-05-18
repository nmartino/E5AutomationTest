using Dynamitey.Internal.Optimization;
using Io.Cucumber.Messages;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace LinnWorksTestInterview.PageObjects
{
    public class MiddlePage : BasePage
    {
        public IWebDriver driver { get; }

        public MiddlePage(IWebDriver driver) : base(driver)
        {
            this.driver = driver;
        }

        public IWebElement tokenInput => driver.FindElement(By.CssSelector("#token"));
        public IWebElement logInButtonTokenEnable => driver.FindElement(By.XPath("//*[@type='submit']"));
        public IWebElement alertText => driver.FindElement(By.CssSelector(".alert li"));
        public IWebElement categoriesTitle => driver.FindElement(By.XPath("//h1[contains(text(),'Categories')]"));
        public IWebElement createNewLink => driver.FindElement(By.XPath("//a[contains(text(),'Create New')]"));
        public IWebElement nameInput => driver.FindElement(By.XPath("//input[@type='text']"));
        public IWebElement saveButton => driver.FindElement(By.XPath("//button[contains(text(),'Save')]"));
        public IList<IWebElement> tableItems => driver.FindElements(By.CssSelector(".table tr td"));

        public void enterATokenInput(string token)
        {
            wait.Until(driver => tokenInput.Displayed);
            tokenInput.SendKeys(token);
            clickLogInButtonToken();
        }
        public void clickLogInButtonToken() => logInButtonTokenEnable.Click();

        public void clickCreateNewLink() => createNewLink.Click();

        public void clickSaveButton() => saveButton.Click();

        public bool categoriesTitleIsDisplayed()
        {

            return wait.Until(driver => categoriesTitle.Displayed);
        }
        public bool nameInputIsDisplayed()
        {

            return wait.Until(driver => nameInput.Displayed);
        }
        public bool createNewLinkIsDisplayed()
        {

            return wait.Until(driver => createNewLink.Displayed);
        }
        public bool tableIsDisplayed()
        {

            return wait.Until(driver => tableItems[0].Displayed);
        }
        public void writeNameOnNameInput(string name)
        {

            nameInput.SendKeys(name);
        }

        public string alertTextContent()
        {

            wait.Until(driver => alertText.Displayed);
            return alertText.Text;
        }


        public bool checkIfNameIsDisplayedOnTable(string name)
        {
            try
            {
                for (int i = 0; i < tableItems.Count; i++)
                {

                    if (tableItems[i].Text.Contains(name))
                    {

                        return true;

                    }
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }


        public void clickDeleteButtonSpecificName(string name)
        {
            deleteButtonSpecificNameElement(name).Click();
            driver.SwitchTo().Alert().Accept();
        }
        public IWebElement deleteButtonSpecificNameElement(string name)
        {
            string xpath = "//*[contains(text(),'#NAME')]/..//td/a[contains(text(),'Delete')]";
            return driver.FindElement(By.XPath((xpath).Replace("#NAME", name)));

        }

    }
}
