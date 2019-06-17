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
            var cards = new List<Card>
            {
                new Card("3", "H"), 
                new Card("6", "D"), 
                new Card("A", "D"), 
                new Card("Q", "C"),
                new Card("2", "C")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.HighCard, handCardType.HoldemType);
            Assert.Equal(new CardNumber("A"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetPair()
        {
            var cards = new List<Card>
            {
                new Card("3", "H"), 
                new Card("6", "D"), 
                new Card("A", "D"), 
                new Card("3", "C"),
                new Card("2", "C")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.Pair, handCardType.HoldemType);
            Assert.Equal(new CardNumber("3"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetTwoPairs()
        {
            var cards = new List<Card>
            {
                new Card("3", "H"), 
                new Card("4", "D"), 
                new Card("A", "D"), 
                new Card("3", "C"),
                new Card("4", "C")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.TwoPairs, handCardType.HoldemType);
            Assert.Equal(new CardNumber("4"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetThreeOfAKind()
        {
            var cards = new List<Card>
            {
                new Card("6", "H"), 
                new Card("4", "D"), 
                new Card("A", "D"), 
                new Card("4", "S"),
                new Card("4", "C")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.ThreeOfAKind, handCardType.HoldemType);
            Assert.Equal(new CardNumber("4"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetStraight()
        {
            var cards = new List<Card>
            {
                new Card("T", "H"), 
                new Card("J", "D"), 
                new Card("A", "D"), 
                new Card("Q", "S"),
                new Card("K", "C")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.Straight, handCardType.HoldemType);
            Assert.Equal(new CardNumber("A"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetFlush()
        {
            var cards = new List<Card>
            {
                new Card("T", "D"), 
                new Card("J", "D"), 
                new Card("4", "D"), 
                new Card("Q", "D"),
                new Card("K", "D")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.Flush, handCardType.HoldemType);
            Assert.Equal(new CardNumber("K"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetFullHouse()
        {
            var cards = new List<Card>
            {
                new Card("T", "D"), 
                new Card("J", "S"), 
                new Card("T", "S"), 
                new Card("T", "H"),
                new Card("J", "D")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.FullHouse, handCardType.HoldemType);
            Assert.Equal(new CardNumber("T"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetFourOfAKind()
        {
            var cards = new List<Card>
            {
                new Card("T", "D"), 
                new Card("J", "S"), 
                new Card("J", "C"), 
                new Card("J", "H"),
                new Card("J", "D")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.FourOfAKind, handCardType.HoldemType);
            Assert.Equal(new CardNumber("J"), handCardType.CardNumber);
        }

        [Fact]
        public void ShouldGetStraightFlush()
        {
            var cards = new List<Card>
            {
                new Card("T", "H"), 
                new Card("J", "H"), 
                new Card("A", "H"), 
                new Card("Q", "H"),
                new Card("K", "H")
            };
            var handCardType = new HandCardTypeCreator(cards).BuildType();
            Assert.Equal(HoldemType.StraightFlush, handCardType.HoldemType);
            Assert.Equal(new CardNumber("A"), handCardType.CardNumber);
        }
    }
}