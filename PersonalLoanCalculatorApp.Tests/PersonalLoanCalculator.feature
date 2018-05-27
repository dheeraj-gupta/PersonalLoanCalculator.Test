Feature: PersonalLoanCalculator
	In order to buy something nice now
	As a cash poor customer
	I want to borrow money so I don't have to wait


Scenario: Calculate borrowing estimate
	Given I am on loan application screen
	And I selected single applicant
	And I selected dependent as 0
	And I am buying house to live in
	And I enter income as $80000
	And I enter other  income as $10000
	And I enter living expense as $500
	And I enter other loan repayment as $100
	And I enter other commitments as 0
	And I entrer total credit card limits as $10000
	When I press Work out how much I could borrow
	Then the result  should display borrowing estimate of $532,000


Scenario: Clears the form
    Given I am on loan application screen
	And I enter living expense as $1
	When I press Work out how much I could borrow
	When I have clicked start over button
	Then Clears the form

Scenario: Message display for partially filled info
     Given I am on loan application screen
	 And I enter a living expenses as $1
	 And Leaving all other Fields as $0
	 When I press Work out how much I could borrow
	 Then I should see message telling me Based on the details you've entered, we're unable to give you an estimate of your borrowing power with this calculator. For questions, call us on 1800 100 641
