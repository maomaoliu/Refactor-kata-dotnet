using System.Collections.Generic;
using PokerGame.Models;
using Xunit;

namespace PokerGame
{
    public partial class HandCardTypeCreatorTests
    {
        [Fact]
        public void ShouldGroupByNumber()
        {
            var cards = new List<Card> {new Card("A", "D"), new Card("A", "S"), new Card("2", "D")};
            var groupByNumber = new HandCardTypeCreator(cards).GroupByNumber();
            Assert.Equal(2, groupByNumber.Count);
            Assert.Equal(2, groupByNumber[new CardNumber("A")]);
            Assert.Equal(1, groupByNumber[new CardNumber("2")]);
        }

        [Fact]
        public void ShouldGetTrueIfAllSameSuite()
        {
            var cards = new List<Card> {new Card("A", "D"), new Card("4", "D"), new Card("K", "D")};
            Assert.True(new HandCardTypeCreator(cards).IsSameSuite());
        }

        [Fact]
        public void ShouldGetFalseIfNotSameSuite()
        {
            var cards = new List<Card> {new Card("A", "H"), new Card("4", "D"), new Card("K", "D")};
            Assert.False(new HandCardTypeCreator(cards).IsSameSuite());
        }

        [Fact]
        public void ShouldGetTrueIfAllTouching()
        {
            var cards = new List<Card> {new Card("2", "H"), new Card("3", "D"), new Card("4", "D")};
            Assert.True(new HandCardTypeCreator(cards).IsTouching());
        }

        [Fact]
        public void ShouldGetTrueIfAllTouchingIncludingTAndJ()
        {
            var cards = new List<Card> {new Card("J", "H"), new Card("9", "D"), new Card("T", "D"), new Card("8", "C")};
            Assert.True(new HandCardTypeCreator(cards).IsTouching());
        }

        [Fact]
        public void ShouldNotTouchingFor2AndA()
        {
            var cards = new List<Card> {new Card("A", "H"), new Card("2", "D")};
            Assert.False(new HandCardTypeCreator(cards).IsTouching());
        }
    }
}