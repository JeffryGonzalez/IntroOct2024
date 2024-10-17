
public class Calculator
{
    public int Add(string numbers)
    {
        var delimeters = new List<char> { ',', '\n' };

        if (numbers == "")
        {
            return 0;
        }
        if (numbers.StartsWith("//"))
        {
            var delim = numbers[2];
            delimeters.Add(delim);
            numbers = numbers.Substring(4);
        }
        return numbers.Split(delimeters.ToArray()).Select(int.Parse).Sum();

    }
}
