
namespace CSharpSyntax;
public class Stuff
{
    [Fact]
    public void DoingTHingsWithEmployees()
    {
        var bob = new Employee();
        bob.Id = 99;
        var sue = new Employee();
        sue.Id = 23;

        Assert.Equal(99, bob.Id);
        Assert.Equal(23, sue.Id);

        bob.Name = "   Robert Smith  ";

        bob.Email = "bob@company.com";

        Assert.Equal("bob@company.com", bob.Email);

        Assert.Equal("ROBERT SMITH", bob.Name);
    }
}


public class Employee
{
    private int _id; // "backing" field

    //public void SetId(int id)
    //{
    //    this._id = id;
    //}

    //public int GetId()
    //{
    //    return _id;
    //}
    public int Id
    {
        get { return _id; }
        set { _id = value; }
    }

    private string _name;

    public string Name
    {
        get { return _name; }
        set { _name = value.Trim().ToUpper(); }
    }

    public string Email { get; set; } = "";

}