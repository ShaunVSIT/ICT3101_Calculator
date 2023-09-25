Feature: Musa Logarithmic Model Integration
In order to accurately estimate software reliability metrics
As a system quality engineer
I want to use the Musa Logarithmic model to calculate failure intensity and the number of expected failures

Scenario: Calculate Failure Intensity using Musa Logarithmic Model
    Given I have a calculator
    When I enter an initial failure intensity of 10, observed failures of 5, and expected total failures of 50
    Then I should get the failure intensity as 9

Scenario: Calculate Expected Failures using Musa Logarithmic Model
    Given I have a calculator
    When I enter an initial failure intensity of 10, time since first failure of 2, and expected total failures of 50
    Then I should get the expected failures result as 16.484