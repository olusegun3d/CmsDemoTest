Feature: Cart modification

A simple test to see if the user can modify the contents of a cart 


Scenario: Modifying the contents of a cart
	Given I add four random items to my cart
	When I view my cart
	Then I find total four items listed in my cart
	When I search for the lowest price item
	And I am able to remove the lowest item 
	Then I am able to verify three items in my cart
