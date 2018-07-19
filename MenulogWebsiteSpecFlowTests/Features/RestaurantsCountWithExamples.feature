@RestaurantsCountWithExamples
Feature: RestaurantsCountWithExamples
	In order to avoid silly mistakes
	As a user
	I want to be told the count of Restaurants in Searched suburb

@RestaurantsCountWithExamples
Scenario Outline: Restaurants Count using Examples
	Given I am at the Menulog Home Page
	And I enter the suburb as <Suburb>
	Then the restaurant count should be displayed for the searched suburb on the SERP

	Examples: 
	| Suburb            |
	| Westmead          |
	| Harris Park       |
	| Parramatta        |
	| Ajana             |
	| Albany            |
	| Aldersyde         |
	| Alexander Heights |






