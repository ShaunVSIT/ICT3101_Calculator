using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class CalculatorAvailabilityStepDefinitions
    {
        private readonly CalculatorContext _calculatorContext;
        private double _result;

        public CalculatorAvailabilityStepDefinitions(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        [When(@"I have entered (.*) hours of total operating time and (.*) breakdowns into the calculator and press MTBF")]
        public void WhenIHaveEnteredHoursAndBreakdownsForMTBF(double operatingTime, double breakdowns)
        {
            _result = _calculatorContext.Calculator.CalculateMTBF(operatingTime, breakdowns);
        }

        [When(@"I have entered (.*) hours for MTBF and (.*) hours for MTTR into the calculator and press Availability")]
        public void WhenIHaveEnteredMTBFAndMTTRForAvailability(double mtbf, double mttr)
        {
            _result = _calculatorContext.Calculator.CalculateAvailability(mtbf, mttr);
        }

        [When(@"I have entered (.*) hours of total operating time, (.*) breakdowns, and (.*) hours for MTTR into the calculator and press Availability")]
        public void WhenIHaveEnteredOperatingTimeBreakdownsAndMTTRForAvailability(double operatingTime, double breakdowns, double mttr)
        {
            double mtbf = _calculatorContext.Calculator.CalculateMTBF(operatingTime, breakdowns);
            _result = _calculatorContext.Calculator.CalculateAvailability(mtbf, mttr);
        }

        [Then(@"the MTBF result should be ""(.*) hours""")]
        public void ThenTheMTBFResultShouldBe(string expected)
        {
            double expectedValue = double.Parse(expected);
            Assert.That(_result, Is.EqualTo(expectedValue).Within(0.01)); //Add tolerance
        }

        [Then(@"the availability result should be ""(-?\d+(?:\.\d+)?)"" \(or (\d+)%\)")]
        public void ThenTheAvailabilityResultShouldBe(double value, int percentage)
        {
            var calculatedPercentage = (int)(_result * 100);
            Assert.That(_result, Is.EqualTo(value).Within(0.01)); // Adding a tolerance due to floating point precision
            Assert.That(calculatedPercentage, Is.EqualTo(percentage));
        }

    }
}
