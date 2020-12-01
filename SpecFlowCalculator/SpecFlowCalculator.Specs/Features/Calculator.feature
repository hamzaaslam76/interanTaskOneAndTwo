Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
	In order to avoid silly mistakes
	As a math idiot
	I *want* to be told the **sum** of ***two*** numbers

Link to a feature: [Calculator](SpecFlowCalculator.Specs/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Add two numbers
	Given i input email "Hamza@gmail.com"
	And i input password "Hamza12@"
	And i input grant_type "password"
	When i send api call
	Then validateuser

@mytag
	Scenario:AddStudent
	Given i login field email password  "Hamza@gmail.com" ,"Hamza12@"
	Given add student field "hamza rest","Hamza@gmail.com","Hamza12@","10/12/2020","2332432","57567"
	When i send login api call
	When i send add student api call
	When i send Delete student api call
	Then studentAddedresponse