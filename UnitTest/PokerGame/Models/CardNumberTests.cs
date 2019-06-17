using Xunit;

namespace PokerGame.Models
{
    public class CardNumberTests
    {
        [Fact]
        public void ShouldEqualIfCardNumberStringAreTheSame()
        {
            Assert.Equal(new CardNumber("A"), new CardNumber("A"));
        }
    }
}