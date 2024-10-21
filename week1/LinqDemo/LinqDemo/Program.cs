namespace LinqDemo;

internal class Program
{
    static void Main(string[] args)
    {
        var nums = new List<int>() { 1, 2, 3, 4, 5, 6, 8, 9, 10, 11, 12, };


        var evens = nums.Where(x => x % 2 == 0);


        nums[0] = 8;

        foreach (var c in GetCustomers().Where(c => c.OutstandingBalance >= 3000).Select(c => new { Name = c.Name, Over = c.OutstandingBalance - 3000 }))
        {
            Console.WriteLine($"Customer {c.Name} owes us {c.Over:c}");
        }

        //foreach (var num in IntegersOneToOneThousand()
        //    .Where(i => i % 2 == 0)
        //    .Select(x => x.ToString())
        //    .Skip(10)
        //    .Take(30))
        //{
        //    {
        //        Console.WriteLine(num);
        //    }

        //    //Console.WriteLine("Hello, World!");
        //    //var cw = new Stopwatch();
        //    //cw.Start();
        //    //var theStuff = IntegersOneToOneThousand();
        //    //foreach (var num in theStuff)
        //    //{
        //    //    Console.WriteLine(num);
        //    //    if (num > 100)
        //    //    {
        //    //        break;
        //    //    }
        //    //}
        //    //cw.Stop();
        //    //Console.WriteLine($"That took about {cw.ElapsedMilliseconds} milliseconds");
        //}
    }
    // Generators
    static IEnumerable<int> IntegersOneToOneThousand()
    {

        for (var t = 1; t < 1001; t++)
        {
            // do some actual big work
            Thread.Sleep(10);
            yield return t;
        }

    }


    public static IEnumerable<Customer> GetCustomers()
    {
        yield return new Customer("Bob Smith", 3000);
        yield return new Customer("Jill Jones", 8000);
        yield return new Customer("Ray Palmer", 2800);
    }
}


public record Customer(string Name, decimal OutstandingBalance);