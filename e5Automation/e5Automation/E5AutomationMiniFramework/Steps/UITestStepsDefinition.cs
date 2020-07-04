using LinnWorksTestInterview.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;
using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LinnWorksTestInterview.Steps
{
    [Binding]
    public sealed class UITestStepsDefinition
    {

        BasePage basePage;
        IWebDriver driver;
        Random random = new Random();
        int rmd;
        string newName;
        string nameToLook;


        [Given(@"The user goes to the LinnWorks Test Page")]
        public void GivenTheUserGoesToTheLinnWorksTestPage()
        {

            this.basePage = new BasePage(driver);
            basePage.navigationBarWebObject().logInButtonIsDisplayed().Should().BeTrue();
        }

        [Given(@"Try to Log In with correct token '(.*)'")]
        public void GivenTryToLogInWithCorrect(string token)
        {
            basePage.navigationBarWebObject().clicLogInButton();
            basePage.middlePage().enterATokenInput(token);
        }

        [Then(@"The log out button is displayed in the home page")]
        public void ThenTheLogOutButtonIsDisplayedInTheHomePage()
        {
            basePage.navigationBarWebObject().logOutButtonIsDisplayed().Should().BeTrue();
        }

        [Then(@"the Category Title is displayed")]
        public void ThenTheCategoryTitleIsDisplayed()
        {
            basePage.middlePage().categoriesTitleIsDisplayed().Should().BeTrue();
        }

        [Then(@"The Alert message is displaying saying '(.*)'")]
        public void ThenTheAlertMessageIsDisplayingSaying(string alertMessage)
        {
            basePage.middlePage().alertTextContent().Should().Contain(alertMessage);
        }

        [When(@"the user clicks on Create new link")]
        public void WhenTheUserClicksOnCreateNewLink()
        {
            basePage.middlePage().createNewLinkIsDisplayed().Should().BeTrue();
            basePage.middlePage().clickCreateNewLink();
        }

        [Then(@"the name input should be displayed")]
        public void ThenTheNameInputShouldBeDisplayed()
        {
            basePage.middlePage().nameInputIsDisplayed().Should().BeTrue();
        }

        [When(@"the user write a name (.*) and clicks on save")]
        public void WhenTheUserWriteANameAndClicksOnSave(string name)
        {
            rmd = random.Next(999);
            nameToLook = name + "_" + rmd.ToString();
            basePage.middlePage().writeNameOnNameInput(nameToLook);
            basePage.middlePage().clickSaveButton();
        }

        [Then(@"the new category should be displayed in the list (.*)")]
        public void ThenTheNewCategoryShouldBeDisplayedInTheList(string name)
        {
            basePage.middlePage().tableIsDisplayed().Should().BeTrue();
            basePage.middlePage().checkIfNameIsDisplayedOnTable(name + "_" + rmd.ToString()).Should().BeTrue();
        }

        [When(@"the user clicks on Delete button of the new Category (.*)")]
        public void WhenTheUserClicksOnDeleteButtonOfTheNewCategory(string name)
        {
            basePage.middlePage().clickDeleteButtonSpecificName(name + "_" + rmd.ToString());
        }

        [Then(@"the new category should not be displayed in the list (.*)")]
        public void ThenTheNewCategoryShouldNotBeDisplayedInTheList(string name)
        {
            nameToLook = name + "_" + rmd.ToString();
            basePage.middlePage().tableIsDisplayed().Should().BeTrue();
            basePage.middlePage().checkIfNameIsDisplayedOnTable(nameToLook).Should().BeFalse();
        }

        [When(@"the user clicks on Edit button of the new Category (.*)")]
        public void WhenTheUserClicksOnEditButtonOfTheNewCategory(string name)
        {
            basePage.middlePage().clickEditButtonSpecificName(name + "_" + rmd.ToString());
        }

        [When(@"the user changes the name of the category '(.*)'")]
        public void WhenTheUserChangesTheNameOfTheCategory(string name)
        {
            newName = basePage.middlePage().writeNameAndReturnANewOne(name, nameToLook);
        }

        [Then(@"The category is displayed with the new name")]
        public void ThenTheCategoryIsDisplayedWithTheNewName()
        {
            basePage.middlePage().checkIfNameIsDisplayedOnTable(newName).Should().BeTrue();
        }


        [Then(@"The Test Case Should Pass")]
        public void ThenTheTestCaseShouldPass()
        {
            basePage.testCaseShouldPass(true).Should().BeTrue();
        }





        [AfterScenario("UI")]
        public void afterScenario()
        {
            if (this.driver != null)
            {
                this.driver.Dispose();
                this.driver = null;
            }
        }


    }
}
