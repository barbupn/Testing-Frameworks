Feature: PlayAGame


@mytag
Scenario Outline: Search a game and spin once
	Given I am on 888casino page
		And I login using personal credentials
	Then I should be logged in
	When I search for game with name '<gameName>' using the search function
		And I open the searched game
		And I click on the spin button
	Then I should see a modal with the message: '<modalMessage>'
Examples:
| gameName        | modalMessage                                                                                  |
| Trail of Treats | Miza vă depăşeşte soldul actual. Pentru a continua ajustaţi miza sau depuneţi mai mulţi bani. |