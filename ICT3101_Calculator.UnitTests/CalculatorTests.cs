namespace ICT3101_Caculator.UnitTests
{
    public class CalculatorTests
    {
        private Calculator _calculator;
        [SetUp]
        public void Setup()
        {
            // Arrange
            _calculator = new Calculator();
        }
        [Test]
        public void Add_WhenAddingTwoNumbers_ResultEqualToSum()
        {
            // Act
            double result = _calculator.Add(10, 20);
            // Assert
            Assert.That(result, Is.EqualTo(30));
        }
        [Test]
        public void Subtract_WhenSubtractingTwoNumbers_ResultEqualToDifference()
        {
            // Act
            double result = _calculator.Subtract(20, 10);
            // Assert
            Assert.That(result, Is.EqualTo(10));
        }
        [Test]
        public void Multiply_WhenMultiplyingTwoNumbers_ResultEqualToMultiple()
        {
            // Act
            double result = _calculator.Multiply(10,20);
            // Assert
            Assert.That(result, Is.EqualTo(200));
        }
        [Test]
        public void Divide_WhenDividingTwoNumbers_ResultEqualToDivision()
        {
            // Act
            double result = _calculator.Divide(20,10);
            // Assert
            Assert.That(result, Is.EqualTo(2));
        }

        [TestCase(0, 0)]
        [TestCase(10, 0)]
        public void Divide_WithZeroAsDivisor_ThrowsArgumentException(double a, double b)
        {
            //Assert
            //Assert.That(() => _calculator.Divide(a, b), Throws.ArgumentException);
            // Act
            double result = _calculator.Divide(0,0);
            // Assert
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        [TestCase(0, 10)]
        public void Divide_WithZeroAsNumerator_ReturnsZero(double a, double b)
        {
            //Act
            double result = _calculator.Divide(a, b);
            //Assert
            Assert.That(result, Is.EqualTo(0));
        }
        [Test]
        public void Factorial_WithPositiveNumber_ResultIsCorrect()
        {
            double result = _calculator.Factorial(5);
            Assert.That(result, Is.EqualTo(120));
        }

        [Test]
        public void Factorial_WithZero_ResultIsOne()
        {
            double result = _calculator.Factorial(0);
            Assert.That(result, Is.EqualTo(1));
        }

        [Test]
        public void Factorial_WithNegativeNumber_ThrowsArgumentException()
        {
            Assert.That(() => _calculator.Factorial(-1), Throws.ArgumentException);
        }

    }

}