Feature: APITests
	API Test for the interview for LinnWorks

@APITest
Scenario: The user tries to do a log in with wrong input
Given the user tries to log in with wrong input

@APITest
Scenario: The user tries to do a log in with correct input and wrong token
Given the user tries to log in with correct input and wrong token '11111'

@APITest
Scenario: The user tries to do a log in with correct input and correct token
Given the user tries to log in with correct input and correct token 'bccf905c-6592-40f2-8db1-c976791fa40a'

