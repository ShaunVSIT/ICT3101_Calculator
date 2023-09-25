using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions
{
    [Binding]
    public sealed class UsingCalculatorStepDefinitions
    {
        private readonly CalculatorContext _calculatorContext;
        private double _result;

        public UsingCalculatorStepDefinitions(CalculatorContext calculatorContext)
        {
            _calculatorContext = calculatorContext;
        }

        [Given(@"I have a calculator")]
        public void GivenIHaveACalculator()
        {
            _calculatorContext.Calculator = new Calculator();
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press add")]
        public void WhenIHaveEnteredAndIntoTheCalculator(double p0, double p1)
        {
            _result = _calculatorContext.Calculator.Add(p0, p1);
        }

        [When(@"I have entered (.*) and (.*) into the calculator and press binary add")]
        public void WhenIHaveEnteredAndIntoTheCalculatorForBinaryAdd(double p0, double p1)
        {
            _result = _calculatorContext.Calculator.BinaryAdd(p0, p1);
        }

        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(double p0)
        {
            Assert.That(_result, Is.EqualTo(p0));
        }
    }
}