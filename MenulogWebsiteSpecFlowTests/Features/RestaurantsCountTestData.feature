@RestaurantsCountUsingTestData
Feature: RestaurantsCountTestData
	In order to avoid silly mistakes
	As a user
	I want to be told the count of Restaurants in Searched suburb

@RestaurantsCountUsingTestData
Scenario: Restaurants Count using Test Data
	Given I have a data in a testdata class file
	Then I search for each of the suburb from the testdata,restaurant count should be displayed for the searched suburb on the SERP Page

