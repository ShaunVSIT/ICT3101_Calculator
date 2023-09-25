using NUnit.Framework;
namespace SpecFlowCalculatorTests.StepDefinitions;

[Binding]
public class QualityMetricsCalculationsSteps
{
    private readonly CalculatorContext _calculatorContext;
    private double _result;

    public QualityMetricsCalculationsSteps(CalculatorContext calculatorContext)
    {
        _calculatorContext = calculatorContext;
    }

    [When(@"I enter the number of defects as (.*) and size of the module as (.*) lines of code")]
    public void WhenIEnterTheNumberOfDefectsAndSizeOfTheModule(int defects, int loc)
    {
        _result = _calculatorContext.Calculator.CalculateDefectDensity(defects, loc);
    }

    [Then(@"I should get the defect density as (.*)")]
    public void ThenIShouldGetTheDefectDensityAs(double expected)
    {
        Assert.AreEqual(expected, _result);
    }

    [When(@"I enter the SSI of the previous release as (.*) and additional SSI for the current release as (.*)")]
    public void WhenIEnterTheSSIOfThePreviousReleaseAndAdditionalSSIForTheCurrentRelease(int prevSSI, int additionalSSI)
    {
        _result = _calculatorContext.Calculator.ComputeTotalSSIForSuccessiveReleases(prevSSI, additionalSSI);
    }

    [Then(@"I should get the new total SSI as (.*)")]
    public void ThenIShouldGetTheNewTotalSSIAs(int expected)
    {
        Assert.AreEqual(expected, _result);
    }
}
