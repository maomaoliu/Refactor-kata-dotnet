using System.Collections.Generic;
using PokerGame.Models;

namespace PokerGame
{
    public class HandCardTypeCreator
    {
        public IDictionary<CardNumber, int> GroupByNumber(List<Card> cards)
        {
            var numberGroups = new Dictionary<CardNumber, int>();
            cards.ForEach(card =>
            {
                var cardCardNumber = card.CardNumber;
                if (numberGroups.ContainsKey(cardCardNumber))
                    numberGroups[cardCardNumber] = numberGroups[cardCardNumber] + 1;
                else
                    numberGroups.Add(cardCardNumber, 1);
            });
            return numberGroups;
        }
    }
}