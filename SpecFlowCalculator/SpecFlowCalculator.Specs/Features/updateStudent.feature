Feature: updateStudent
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: UpadetStudent
	Given i Enter Email and Password "Hamza@gmail.com","Hamza12@"
	Given i Enter Update student id 1129
	When  i send login Api call
	When  i send get update student Api call
	When  i send update Api call
	Then check record update response