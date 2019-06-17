using System.Collections.Generic;
using PokerGame.Models;
using Xunit;

namespace PokerGame
{
    public class HandCardTypeCreatorTests
    {
        [Fact]
        public void ShouldGroupByNumber()
        {
            var cards = new List<Card> { new Card("A", "D"), new Card("A", "S"), new Card("2", "D") };
            var groupByNumber = new HandCardTypeCreator().GroupByNumber(cards);
            Assert.Equal(2, groupByNumber.Count);
            Assert.Equal(2, groupByNumber[new CardNumber("A")]);
            Assert.Equal(1, groupByNumber[new CardNumber("2")]);
        }

        [Fact]
        public void ShouldGetTrueIfAllSameSuite()
        {
            var cards = new List<Card> { new Card("A", "D"), new Card("4", "D"), new Card("K", "D")};
            Assert.True(new HandCardTypeCreator().IsSameSuite(cards));
        }

        [Fact]
        public void ShouldGetFalseIfNotSameSuite()
        {
            var cards = new List<Card> { new Card("A", "H"), new Card("4", "D"), new Card("K", "D")};
            Assert.False(new HandCardTypeCreator().IsSameSuite(cards));
        }
    }
}