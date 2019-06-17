using System.Collections.Generic;
using System.Linq;
using PokerGame.Models;

namespace PokerGame
{
    public class HandCardCreator
    {
        private const string HandCardSeparator = " ";
        private const int CardNumberIndex = 0;
        private const int SuiteIndex = 1;

        public Player ParsePlayer(string playerName, string handCardString)
        {
            return new Player(playerName);
        }

        public IList<Card> ParseCards(string playerName, string handCardString)
        {
            var cardsStrings = handCardString.Split(HandCardSeparator);
            return cardsStrings.Select(cardString => new Card(cardString[CardNumberIndex].ToString(), cardString[SuiteIndex].ToString())).ToList();
        }

        public HandCardType GetHandCardType(IList<Card> cards)
        {
            return new HandCardTypeCreator(cards).BuildType();
        }

        public HandCard BuildHandCard(string playerName, string handCardsString)
        {
            return new HandCard(ParsePlayer(playerName, handCardsString), GetHandCardType(ParseCards(playerName, handCardsString)));
        }
    }
}