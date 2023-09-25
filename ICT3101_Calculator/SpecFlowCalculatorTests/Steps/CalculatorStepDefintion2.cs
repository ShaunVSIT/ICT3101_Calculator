using NUnit.Framework;

namespace SpecFlowCalculatorTests.StepDefinitions;

[Binding]
public sealed class UsingCalculatorStepDefinitions2
{
    private readonly CalculatorContext _calculatorContext;
    private double _result;

    // Constructor
    public UsingCalculatorStepDefinitions2(CalculatorContext calculatorContext)
    {
        _calculatorContext = calculatorContext;
    }

    [When(@"I have entered (.*) and (.*) into the calculator and press divide")]
    public void WhenIHaveEnteredAndIntoTheCalculatorAndPressDivide(double p0, double p1)
    {
        try
        {
            _result = _calculatorContext.Calculator.Divide(p0, p1);
        }
        catch (ArgumentException)
        {
            _result = Double.PositiveInfinity;
        }
        catch (DivideByZeroException)
        {
            if(p0 == 0)
                _result = 1;
            else
                _result = Double.PositiveInfinity;
        }
    }
            
    [Then(@"the division result should be (.*)")]
    public void ThenTheDivisionResultShouldBe(double p0)
    {
        Assert.That(_result, Is.EqualTo(p0));
    }

    [Then(@"the division result equals positive_infinity")]
    public void ThenTheDivisionResultEqualsPositiveInfinity()
    {
        Assert.That(_result, Is.EqualTo(Double.PositiveInfinity));
    }
}
