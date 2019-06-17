using Xunit;

namespace PokerGame.Models
{
    public class HandCardTypeTests
    {
        [Fact]
        public void ShouldCompareByHoldemType()
        {
            var handCardTypeOne = new HandCardType(HoldemType.Straight, new CardNumber("9"));
            var handCardTypeTwo = new HandCardType(HoldemType.FullHouse, new CardNumber("9"));
            Assert.Equal(-1, handCardTypeOne.CompareTo(handCardTypeTwo));
        }

        [Fact]
        public void ShouldCompareByCardNumberIfHoldemTypeAreEquals()
        {
            var handCardTypeOne = new HandCardType(HoldemType.Straight, new CardNumber("9"));
            var handCardTypeTwo = new HandCardType(HoldemType.Straight, new CardNumber("K"));
            Assert.Equal(1, handCardTypeTwo.CompareTo(handCardTypeOne));
        }

        [Fact]
        public void ShouldGetEquals()
        {
            var handCardTypeOne = new HandCardType(HoldemType.Straight, new CardNumber("9"));
            var handCardTypeTwo = new HandCardType(HoldemType.Straight, new CardNumber("9"));
            Assert.Equal(0, handCardTypeTwo.CompareTo(handCardTypeOne));
            Assert.Equal(0, handCardTypeOne.CompareTo(handCardTypeTwo));
        }
    }
}