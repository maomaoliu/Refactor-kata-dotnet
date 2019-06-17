using Xunit;

namespace PokerGame
{
    public class PokerComparerTests
    {
        [Fact]
        public void ShouldParseStringToHandCard()
        {
            var pokerComparer = new PokerComparer();
            var handCard = pokerComparer.ToHandCard("White: 2C 3H 4S 8C KH");
            Assert.Equal(new Player("White"), handCard.Player);
            Assert.Equal(HoldemType.HighCard, handCard.HandCardType.HoldemType);
        }
    }
}