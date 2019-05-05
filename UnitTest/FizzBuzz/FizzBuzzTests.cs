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
        [InlineData(13, "Fizz")]
        [InlineData(31, "Fizz")]
        [InlineData(53, "FizzBuzz")]
        [InlineData(54, "FizzBuzz")]
        public void ShouldGetFizzBuzzResult(int index, string expected)
        {
            Assert.Equal(expected, new FizzBuzz().Of(index));
        }
    }
}