using Xunit;

namespace PokerGame.Models
{
    public class HandCardTests
    {
        [Fact]
        public void ShouldCompareTwoHandCardsByHandCardTypeType()
        {
            var handCardOne = new HandCard(new Player("White"), new HandCardType(HoldemType.Flush, new CardNumber("A")));
            var handCardTwo = new HandCard(new Player("Black"), new HandCardType(HoldemType.FourOfAKind, new CardNumber("A")));
            Assert.Equal(-1, handCardOne.CompareTo(handCardTwo));
        }
    }
}