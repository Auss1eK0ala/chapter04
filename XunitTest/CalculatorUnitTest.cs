using Packt;
using Xunit;

namespace CalculatoryLibUnitItests;

public class CalculatorUnitTest
{
    [Fact]
    public void Test1Adding2And2()
    {
        double a = 2;
        double b = 2;
        double expected = 4;
        Calculator calc = new();

        double actual = calc.Add(a, b);
        Assert.Equal(expected, actual);
    }
}