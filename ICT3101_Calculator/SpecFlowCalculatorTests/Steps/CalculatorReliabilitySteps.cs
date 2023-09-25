using NUnit.Framework;
namespace SpecFlowCalculatorTests.StepDefinitions;

[Binding]
public sealed class CalculatorReliabilityStepDefinitions
{
    private readonly CalculatorContext _calculatorContext;
    private double _result;

    public CalculatorReliabilityStepDefinitions(CalculatorContext calculatorContext)
    {
        _calculatorContext = calculatorContext;
    }
    [When(@"I have entered an initial failure intensity of (.*) observed failures of (.*) and expected total failures of (.*) into the calculator and press Current Failure Intensity")]
    public void WhenIHaveEnteredValuesForCurrentFailureIntensity(double initialIntensity, double observedFailures, double totalFailures)
    {
        _result = _calculatorContext.Calculator.CalculateFailureIntensity(initialIntensity, observedFailures, totalFailures);
    }
    
    [When(@"I have entered an initial failure intensity of (.*) time since first failure of (.*) and expected total failures of (.*) into the calculator and press Expected Failures")]
    public void WhenIHaveEnteredValuesForExpectedFailures(double initialIntensity, double timeSinceFirst, double totalFailures)
    {
        _result = _calculatorContext.Calculator.CalculateExpectedFailures(initialIntensity, timeSinceFirst, totalFailures);
    }
    
    [Then(@"the failure intensity result should be ""(.*)""")]
    public void ThenTheFailureIntensityResultShouldBe(string expectedValueStr)
    {
        double expectedValue = double.Parse(expectedValueStr);
        Assert.That(_result, Is.EqualTo(expectedValue).Within(0.01));
    }
    
    [Then(@"the expected failures result should be ""(.*)""")]
    public void ThenTheExpectedFailuresResultShouldBe(string valueStr)
    {
        double value = double.Parse((valueStr));
        Assert.That(_result, Is.EqualTo(value).Within(0.01));
    }

}