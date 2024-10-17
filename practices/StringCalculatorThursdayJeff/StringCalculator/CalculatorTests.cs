



namespace StringCalculator;
public class CalculatorTests
{
    private Calculator calculator;

    public CalculatorTests()
    {
        calculator = new Calculator(Substitute.For<ILogAnswers>(), Substitute.For<IWebService>());
    }
    [Fact]
    public void EmptyStringReturnsZero()
    {


        var result = calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("1", 1)]
    [InlineData("2", 2)]
    [InlineData("1024", 1024)]
    public void SingleDigits(string numbers, int expected)
    {

        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1", 2)]
    [InlineData("1,2", 3)]
    [InlineData("10,3", 13)]
    [InlineData("108,200", 308)]

    public void TwoDigits(string numbers, int expected)
    {


        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1,1", 3)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]

    public void Arbitrary(string numbers, int expected)
    {


        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,1\n1", 3)]


    public void MixedDelimeters(string numbers, int expected)
    {


        var result = calculator.Add(numbers);

        Assert.Equal(expected, result);
    }


}

public class DummyLogger : ILogAnswers
{
    public void LogAnswer(string answer)
    {

    }
}