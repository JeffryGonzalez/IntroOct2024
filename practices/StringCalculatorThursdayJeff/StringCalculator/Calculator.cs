
public class Calculator(ILogAnswers logger, IWebService webService)
{
    public int Add(string numbers)
    {

        if (numbers == "")
        {
            return 0;
        }



        // Language Integrated Query (LINQ)
        var answer = numbers.Split(',', '\n') // ["3","2"]
            .Select(int.Parse) // [3, 2]
            .Sum();

        // log out the answer to the logger service
        try
        {
            logger.LogAnswer(answer.ToString());
        }
        catch (Exception)
        {

            webService.NotifyOfLogFailure();
        }
        return answer;
    }
}

public interface ILogAnswers
{
    void LogAnswer(string answer);
}

public interface IWebService
{
    void NotifyOfLogFailure();
}