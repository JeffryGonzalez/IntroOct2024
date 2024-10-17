
public class Calculator
{
    public int Add(string numbers)
    {

        if (numbers == "")
        {
            return 0;
        }



        // Language Integrated Query (LINQ)
        return numbers.Split(',', '\n') // ["3","2"]
            .Select(int.Parse) // [3, 2]
            .Sum();



    }
}
