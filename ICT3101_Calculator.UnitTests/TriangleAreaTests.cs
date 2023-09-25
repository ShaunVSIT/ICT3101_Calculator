namespace ICT3101_Caculator.UnitTests
{
    [TestFixture]
    public class TriangleAreaTests
    {
        private Calculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void TriangleArea_WhenGivenBaseAndHeight_ReturnsCorrectArea()
        {
            // Arrange
            double baseLength = 10;
            double height = 5;
            double expectedArea = 25;  // 0.5 * base * height = 0.5 * 10 * 5

            // Act
            double result = _calculator.TriangleArea(baseLength, height);

            // Assert
            Assert.That(result, Is.EqualTo(expectedArea));
        }
    }
}
