using System.Collections.Generic;
using PokerGame.Models;
using Xunit;

namespace PokerGame
{
    public partial class HandCardTypeCreatorTests
    {
        [Fact]
        public void ShouldGetHighCard()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("3"), 1},
                {new CardNumber("6"), 1},
                {new CardNumber("A"), 1},
                {new CardNumber("Q"), 1},
                {new CardNumber("2"), 1}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, false, false);
            Assert.Equal(HoldemType.HighCard, handCardType.HoldemType);
            Assert.Equal(new CardNumber("A"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetPair()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("3"), 2},
                {new CardNumber("6"), 1},
                {new CardNumber("A"), 1},
                {new CardNumber("2"), 1}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, false, false);
            Assert.Equal(HoldemType.Pair, handCardType.HoldemType);
            Assert.Equal(new CardNumber("3"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetTwoPairs()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("3"), 2},
                {new CardNumber("A"), 1},
                {new CardNumber("4"), 2}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, false, false);
            Assert.Equal(HoldemType.TwoPairs, handCardType.HoldemType);
            Assert.Equal(new CardNumber("4"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetThreeOfAKind()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("6"), 1},
                {new CardNumber("A"), 1},
                {new CardNumber("4"), 3}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, false, false);
            Assert.Equal(HoldemType.ThreeOfAKind, handCardType.HoldemType);
            Assert.Equal(new CardNumber("4"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetStraight()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("T"), 1},
                {new CardNumber("J"), 1},
                {new CardNumber("A"), 1},
                {new CardNumber("Q"), 1},
                {new CardNumber("K"), 1}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, false, true);
            Assert.Equal(HoldemType.Straight, handCardType.HoldemType);
            Assert.Equal(new CardNumber("A"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetFlush()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("T"), 1},
                {new CardNumber("J"), 1},
                {new CardNumber("4"), 1},
                {new CardNumber("Q"), 1},
                {new CardNumber("K"), 1}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, true, false);
            Assert.Equal(HoldemType.Flush, handCardType.HoldemType);
            Assert.Equal(new CardNumber("K"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetFullHouse()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("T"), 3},
                {new CardNumber("J"), 2}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, true, false);
            Assert.Equal(HoldemType.FullHouse, handCardType.HoldemType);
            Assert.Equal(new CardNumber("T"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetFourOfAKind()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("T"), 1},
                {new CardNumber("J"), 4}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, true, false);
            Assert.Equal(HoldemType.FourOfAKind, handCardType.HoldemType);
            Assert.Equal(new CardNumber("J"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetStraightFlush()
        {
            var cardNumberGroups = new Dictionary<CardNumber, int>
            {
                {new CardNumber("T"), 1},
                {new CardNumber("J"), 1},
                {new CardNumber("A"), 1},
                {new CardNumber("Q"), 1},
                {new CardNumber("K"), 1}
            };
            var handCardType = new HandCardTypeCreator().BuildType(cardNumberGroups, true, true);
            Assert.Equal(HoldemType.StraightFlush, handCardType.HoldemType);
            Assert.Equal(new CardNumber("A"), handCardType.CardNumber);
        }
    }
}