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

        public bool IsTouching(List<Card> cards)
        {
            var orderedCardNumbers = cards.Select(card => card.CardNumber.Number).OrderBy(number => number).ToList();
            for (var i = 0; i < orderedCardNumbers.Count - 1; i++)
            {
                if (orderedCardNumbers[i] + 1 != orderedCardNumbers[i + 1])
                {
                    return false;
                }
            }

            return true;
        }
    }
}