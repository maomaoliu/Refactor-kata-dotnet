using System.Collections.Generic;
using PokerGame.Models;
using Xunit;

namespace PokerGame
{
    public class HandCardTypeCreatorTests
    {
        private HandCardTypeCreator _handCardTypeCreator;

        [Fact]
        public void ShouldGroupByNumber()
        {
            _handCardTypeCreator = new HandCardTypeCreator();
            var cards = new List<Card> { new Card("A", "D"), new Card("A", "S"), new Card("2", "D") };
            var groupByNumber = _handCardTypeCreator.GroupByNumber(cards);
            Assert.Equal(2, groupByNumber.Count);
            Assert.Equal(2, groupByNumber[new CardNumber("A")]);
            Assert.Equal(1, groupByNumber[new CardNumber("2")]);
        }
    }
}