using System.Collections.Generic;
using System.Linq;
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

        public bool IsSameSuite(List<Card> cards)
        {
            return cards.Select(card => card.Suite).Distinct().Count() == 1;
        }
    }
}