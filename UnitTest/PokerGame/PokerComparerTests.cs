using PokerGame.Models;
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

        [Fact]
        public void ShouldGetCompareResultWhenHoldemTypeSameButNotTie()
        {
            var result = new PokerComparer().Compare("Black: 2H 3D 5S 9C KD White: 2C 3H 4S 8C AH");
            Assert.Equal("White wins - high card: Ace", result);
        }

        [Fact]
        public void ShouldGetCompareResultWhenHoldemTypeNotSame()
        {
            var result = new PokerComparer().Compare("Black: 2H 4S 4C 2D 4H White: 2S 8S AS QS 3S");
            Assert.Equal("Black wins - full house", result);
        }

        [Fact]
        public void ShouldGetCompareResultWhenTie()
        {
            var result = new PokerComparer().Compare(" Black: 2H 3D 5S 9C KD White: 2D 3H 5C 9S KH");
            Assert.Equal("Tie", result);
        }
    }
}