

namespace CSharpSyntax;
public class BasicDataTypes
{
    [Fact]
    public void DeterminingTypes()
    {
        var fido = new Dog();



        fido.Name = "Fido";

        Assert.Equal("Fido", fido.Name);

        Dog rover = fido;


        rover.Name = "Bowzer";

        Assert.Equal("Bowzer", fido.Name);

        int myAge = 55;

        int yourAge = myAge;

        Assert.Equal(55, myAge);
        Assert.Equal(55, yourAge);

        yourAge = 32;
        Assert.Equal(55, myAge);
        Assert.Equal(32, yourAge);

        string myName = "Jeff";

        string yourName = myName;

        string numbers = "";

        foreach (var n in Enumerable.Range(1, 10_000))
        {
            numbers += n;
        }

        Assert.StartsWith("123456789101112", numbers);

    }


}


public class Dog
{
    public string Name = "";
}