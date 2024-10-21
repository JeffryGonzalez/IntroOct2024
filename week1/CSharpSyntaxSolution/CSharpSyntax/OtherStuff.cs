

namespace CSharpSyntax.Esoterica;

public static class Utils
{
    public static bool IsEven(this int x)
    {
        return x % 2 == 0;
    }

    public static DateTime Tomorrow(this DateTime dt)
    {
        return dt.AddDays(1);
    }


}
