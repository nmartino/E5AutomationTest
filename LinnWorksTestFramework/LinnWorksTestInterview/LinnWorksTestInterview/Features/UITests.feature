Feature: UITests
	Test for the interview for LinnWorks

@LinnkWorks
Scenario: Succesfull Log In
	Given The user goes to the LinnWorks Test Page
	And Try to Log In with correct token 'bccf905c-6592-40f2-8db1-c976791fa40a'
	Then The log out button is displayed in the home page
	And the Category Title is displayed

Scenario: Unsuccesfull Log In
	Given The user goes to the LinnWorks Test Page
	And Try to Log In with correct token 'false 123'
	Then The Alert message is displaying saying 'Invalid token'

Scenario Outline: add a new Category
	Given The user goes to the LinnWorks Test Page
	And Try to Log In with correct token 'bccf905c-6592-40f2-8db1-c976791fa40a'
	Then The log out button is displayed in the home page
	And the Category Title is displayed
	When the user clicks on Create new link
	Then the name input should be displayed
	When the user write a name <names> and clicks on save
	Then the new category should be displayed in the list <names>
	Examples: 
	| names   |
	| juan    |
	| nicolas |
	| pedro   |

Scenario Outline: delete a new Category
	Given The user goes to the LinnWorks Test Page
	And Try to Log In with correct token 'bccf905c-6592-40f2-8db1-c976791fa40a'
	Then The log out button is displayed in the home page
	And the Category Title is displayed
	When the user clicks on Create new link
	Then the name input should be displayed
	When the user write a name <names> and clicks on save
	Then the new category should be displayed in the list <names>
	When the user clicks on Delete button of the new Category <names>
	Then the new category should not be displayed in the list <names>
	Examples: 
	| names   |
	| juan    |
	| nicolas |
	| pedro   |
