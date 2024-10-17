namespace StringCalculator;
public class CalculatorInteractionTests
{
    [Fact]
    public void AnswerIsLogged()
    {
        // Given
        var mockedLogger = Substitute.For<ILogAnswers>();
        var mockedWebService = Substitute.For<IWebService>();
        var calculator = new Calculator(mockedLogger, mockedWebService);

        // When
        calculator.Add("1,2,3");

        var expectedLoggedThing = "6";
        // Assert.
        mockedLogger.Received().LogAnswer(expectedLoggedThing);
        mockedWebService.DidNotReceive().NotifyOfLogFailure();
    }

    [Fact]
    public void WhenLoggerThrowsAnExceptiontheWebServiceisCalled()
    {
        var stubbedLogger = Substitute.For<ILogAnswers>();

        stubbedLogger.When(d => d.LogAnswer("99"))
            .Do((x) => { throw new Exception(); });

        var mockedWebService = Substitute.For<IWebService>();

        var calculator = new Calculator(stubbedLogger, mockedWebService);


        calculator.Add("99");

        mockedWebService.Received().NotifyOfLogFailure();

    }
}


public class MockedLogger : ILogAnswers
{
    public string ProvidedAnswer = "";
    public void LogAnswer(string answer)
    {
        ProvidedAnswer = answer;
    }
}