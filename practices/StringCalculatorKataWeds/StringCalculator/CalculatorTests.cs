

namespace StringCalculator;
public class CalculatorTests
{
    [Fact]
    public void EmptyStringReturnsZero()
    {
        var calculator = new Calculator();

        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("108", 108)]
    public void SingleNumber(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("2,2", 4)]
    [InlineData("5,5", 10)]
    [InlineData("10,2", 12)]
    [InlineData("212,8", 220)]

    public void TwoDigits(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]


    public void Arbitrary(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }
    [Theory]
    [InlineData("1,2\n3", 6)]
    [InlineData("1,2\n3\n5", 11)]
    public void MixedDelimeters(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//X\n1X2X3", 6)]
    [InlineData("//X\n1,2\n10", 13)]
    [InlineData("//X\n1X3,20", 24)]
    [InlineData("//#\n1#2", 3)]

    public void CustomDelimeters(string input, int expected)
    {
        var calculator = new Calculator();

        var result = calculator.Add(input);
        Assert.Equal(expected, result);
    }

}
