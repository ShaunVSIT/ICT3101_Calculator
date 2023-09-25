namespace ICT3101_Caculator.UnitTests
{
    [TestFixture]
    public class CircleAreaTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void CircleArea_WhenGivenRadius_ReturnsCorrectArea()
        {
            // Arrange
            double radius = 7;
            double expectedArea = Math.PI * radius * radius;  // π * r^2

            // Act
            double result = _calculator.CircleArea(radius);

            // Assert
            Assert.That(result, Is.EqualTo(expectedArea).Within(0.01));  // Tolerance added due to precision of floating point calculations
        }

        [Test]
        public void CircleArea_WhenGivenNegativeRadius_ThrowsArgumentException()
        {
            // Arrange
            double negativeRadius = -5;

            // Assert
            Assert.That(() => _calculator.CircleArea(negativeRadius), Throws.ArgumentException.With.Message.EqualTo("Radius should be non-negative."));
        }
    }
}
