Feature: UsingCalculatorBasicReliability
	In order to calculate the Basic Musa model's failures/intensities
	As a Software Quality Metric enthusiast
	I want to use my calculator to do this

@BasicReliability
Scenario: Calculating Current Failure Intensity
	Given I have a calculator
	When I have entered an initial failure intensity of 10, observed failures of 5, and expected total failures of 50 into the calculator and press Current Failure Intensity
	Then the failure intensity result should be "9" 
	
@BasicReliability
Scenario: Calculating Expected Number of Failures
	Given I have a calculator
	When I have entered an initial failure intensity of 10, time since first failure of 2, and expected total failures of 50 into the calculator and press Expected Failures
	Then the expected failures result should be "16.484"
