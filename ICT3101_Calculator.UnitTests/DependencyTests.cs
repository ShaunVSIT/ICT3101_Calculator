using Moq;
using NUnit.Framework;
using ICT3101_Calculator;

[TestFixture]
public class DependencyTests
{
    [Test]
    public void GenMagicNum_ValidIndex_ReturnsPositiveDoubleValue()
    {
        // Arrange
        var mockFileReader = new Mock<IFileReader>();
        mockFileReader.Setup(fr => fr.Read(It.IsAny<string>())).Returns(new string[] { "10.5", "20.25" });
        var calculator = new Calculator();

        // Act
        double result = calculator.GenMagicNum(0, mockFileReader.Object);

        // Assert
        Assert.That(result, Is.EqualTo(21));
    }

    [Test]
    public void GenMagicNum_InvalidIndex_ReturnsZero()
    {
        // Arrange
        var mockFileReader = new Mock<IFileReader>();
        mockFileReader.Setup(fr => fr.Read(It.IsAny<string>())).Returns(new string[] { "10.5", "20.25" });
        var calculator = new Calculator();

        // Act
        double result = calculator.GenMagicNum(10, mockFileReader.Object);

        // Assert
        Assert.That(result, Is.EqualTo(0));
    }

    [Test]
    public void GenMagicNum_InvalidMagicNumber_ThrowsFormatException()
    {
        // Arrange
        var mockFileReader = new Mock<IFileReader>();
        mockFileReader.Setup(fr => fr.Read(It.IsAny<string>())).Returns(new string[] { "invalid", "20.25" });
        var calculator = new Calculator();

        // Act & Assert
        Assert.Throws<FormatException>(() => calculator.GenMagicNum(0, mockFileReader.Object));
    }
}