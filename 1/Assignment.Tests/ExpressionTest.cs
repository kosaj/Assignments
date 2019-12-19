using Xunit;

namespace Assignment.Tests
{
    public class ExpressionTest
    {
        [Theory]
        [InlineData("3+4*5-3", 20)]
        [InlineData("4+5*2", 14)]
        [InlineData("4+5/2", 6.5)]
        [InlineData("4*2+5/2-1", 9.5)]
        [InlineData("4*2-5/2-1", 4.5)]
        [InlineData("4*2+5/2-1+7*8-4/2", 63.5)]
        public void Evaluate_Success(string infix, float expected)
        {
            Assert.Equal(Expression.Evaluate(infix), expected);
        }
    }
}
