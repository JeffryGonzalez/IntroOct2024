namespace Software.Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
        // Given (Arrange)
        int x = 10; int y = 20; int answer;

        // When (act)
        answer = x + y;

        // Then (assert)
        Assert.Equal(30, answer);
    }
}