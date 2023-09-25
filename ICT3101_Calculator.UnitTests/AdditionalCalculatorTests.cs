using Moq;
namespace ICT3101_Calculator.UnitTests;

[TestFixture]
public class AdditionalCalculatorTests
{
    private Calculator? _calculator;
    private Mock<IFileReader>? _mockFileReader;
    
    [SetUp]
    public void Setup()
    {
        _mockFileReader = new Mock<IFileReader>();
        _mockFileReader.Setup(fr =>
            fr.Read("MagicNumbers.txt")).Returns(new string[2]{"42","42"});
        _calculator = new Calculator();
    }
    
    [Test]
    public void GenMagicNum_ValidIndex_ReturnsPositiveDoubleValue()
    {
        // Act
        double result = _calculator!.GenMagicNum(0, _mockFileReader!.Object);

        // Assert
        Assert.That(result, Is.EqualTo(84)); // 2 * 42
    }
    [Test]
    public void GenMagicNum_InvalidIndex_ReturnsZero()
    {
        // Act
        double result = _calculator!.GenMagicNum(10, _mockFileReader!.Object);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void GenMagicNum_InvalidMagicNumber_ThrowsFormatException()
    {
        // Arrange
        _mockFileReader!.Setup(fr => fr.Read("MagicNumbers.txt")).Returns(new string[] { "invalid", "20.25" });

        // Act & Assert
        Assert.Throws<FormatException>(() => _calculator!.GenMagicNum(0, _mockFileReader.Object));
    }

}