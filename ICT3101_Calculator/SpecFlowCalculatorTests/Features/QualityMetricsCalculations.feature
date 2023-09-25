Feature: Quality Metrics Calculations
In order to maintain and improve the quality of our software
As a system quality engineer
I want to calculate defect density and compute total SSI for successive releases

Scenario: Calculate Defect Density
    Given I have a calculator
    When I enter the number of defects as 15 and size of the module as 1000 lines of code
    Then I should get the defect density as 0.015

Scenario: Compute Total SSI for Successive Releases
    Given I have a calculator
    When I enter the SSI of the previous release as 3000 and additional SSI for the current release as 500
    Then I should get the new total SSI as 3500