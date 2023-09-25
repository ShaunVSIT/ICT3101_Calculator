using NUnit.Framework;
namespace SpecFlowCalculatorTests.StepDefinitions;

[Binding]
public class MusaLogarithmicModelSteps
{
    private readonly CalculatorContext _calculatorContext;
    private double _result;

    public MusaLogarithmicModelSteps(CalculatorContext calculatorContext)
    {
        _calculatorContext = calculatorContext;
    }

    [When(@"I enter an initial failure intensity of (.*), observed failures of (.*), and expected total failures of (.*)")]
    public void WhenIEnterAnInitialFailureIntensityObservedFailuresAndExpectedTotalFailures(double initialIntensity, double observedFailures, double totalFailures)
    {
        _result = _calculatorContext.Calculator.CalculateFailureIntensity(initialIntensity, observedFailures, totalFailures);
    }

    [Then(@"I should get the failure intensity as (.*)")]
    public void ThenIShouldGetTheFailureIntensityAs(double expected)
    {
        Assert.AreEqual(expected, _result);
    }

    [When(@"I enter an initial failure intensity of (.*), time since first failure of (.*), and expected total failures of (.*)")]
    public void WhenIEnterAnInitialFailureIntensityTimeSinceFirstFailureAndExpectedTotalFailures(double initialIntensity, double timeSinceFirst, double totalFailures)
    {
        _result = _calculatorContext.Calculator.CalculateExpectedFailures(initialIntensity, timeSinceFirst, totalFailures);
    }

    [Then(@"I should get the expected failures result as (.*)")]
    public void ThenIShouldGetTheExpectedFailuresResultAs(double expected)
    {
        Assert.That(_result, Is.EqualTo(expected).Within(0.01));
    }
}
