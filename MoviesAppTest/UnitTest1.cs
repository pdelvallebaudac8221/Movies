namespace MoviesAppTest;
using MoviesApp.SimpleFunctions;

public class UnitTest1
{
    [Fact]
    public void CompareTwoIntegers_ReturnsBool()
    {
        int a = 1;
        int b = 2;
        var example = new Example();
        var result = example.CompareTwoIntegers(a, b);
        
        Assert.IsType<bool>(result);
    }

    [Theory]
    [InlineData(1, 1)]
    [InlineData(2,2)]
    public void CompareTwoIntegers_ReturnsTrueIfMatched(int a, int b)
    {
        var example = new Example();
        var result = example.CompareTwoIntegers(a, b);
        
        Assert.True(result);
    }
}