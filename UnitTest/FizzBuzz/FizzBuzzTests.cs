using Xunit;

namespace FizzBuzz
{
    public class FizzBuzzTests
    {
        [Theory]
        [InlineData(1, "1")]
        [InlineData(3, "Fizz")]
        [InlineData(5, "Buzz")]
        [InlineData(15, "FizzBuzz")]
        public void ShouldGetFizzBuzzResult(int index, string expected)
        {
            Assert.Equal(expected, new FizzBuzz().Of(index));
        }
    }
}