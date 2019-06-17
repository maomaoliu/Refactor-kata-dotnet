using System.Linq;
using PokerGame.Models;
using Xunit;

namespace PokerGame
{
    public class HandCardCreatorTests
    {
        [Fact]
        public void ShouldParsePlayer()
        {
            Assert.Equal(new Player("White"), new HandCardCreator().ParsePlayer("White"));
        }
        
        [Fact]
        public void ShouldParseCards()
        {
            var cards = new HandCardCreator().ParseCards("2C 3H 4S 8C KH");
            Assert.Equal(5, cards.Count);
            Assert.Equal("C", cards.First().Suite);
            Assert.Equal(new CardNumber("2"), cards.First().CardNumber);
        }

        [Fact]
        public void ShouldGetHandCardType()
        {
            var cards = new HandCardCreator().ParseCards("2C 3H 4S 8C KH");
            Assert.Equal(HoldemType.HighCard, new HandCardCreator().GetHandCardType(cards).HoldemType);
        }

        [Fact]
        public void ShouldBuildHandCard()
        {
            var handCard = new HandCardCreator().BuildHandCard("White", "2C 3H 4S 8C KH");
            Assert.Equal(new Player("White"), handCard.Player);
            Assert.Equal(HoldemType.HighCard, handCard.HandCardType.HoldemType);
        }
    }
}