Feature: UsingCalculatorAvailability
In order to calculate MTBF and Availability
As someone who struggles with math
I want to be able to use my calculator to do this

    @Availability
    Scenario: Calculating MTBF
        Given I have a calculator
        When I have entered 1000 hours of total operating time and 5 breakdowns into the calculator and press MTBF
        Then the MTBF result should be "200 hours"

    @Availability
    Scenario: Calculating Availability with known MTTR
        Given I have a calculator
        When I have entered 200 hours for MTBF and 50 hours for MTTR into the calculator and press Availability
        Then the availability result should be "0.8" (or 80%)

    @Availability
    Scenario: Calculating Availability without known MTBF
        Given I have a calculator
        When I have entered 1000 hours of total operating time, 5 breakdowns, and 50 hours for MTTR into the calculator and press Availability
        Then the availability result should be "0.8" (or 80%)
        
    @Availability
    Scenario: Calculating Availability with zero breakdowns
        Given I have a calculator
        When I have entered 1000 hours of total operating time, 0 breakdowns, and 0 hours for MTTR into the calculator and press Availability
        Then the availability result should be "1.0" (or 100%)