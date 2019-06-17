using System.Collections.Generic;
using System.Linq;
using PokerGame.Models;

namespace PokerGame
{
    public class HandCardTypeCreator
    {
        private readonly List<Card> _cards;

        public HandCardTypeCreator(List<Card> cards)
        {
            _cards = cards;
        }

        public IDictionary<CardNumber, int> GroupByNumber()
        {
            var numberGroups = new Dictionary<CardNumber, int>();
            _cards.ForEach(card =>
            {
                var cardCardNumber = card.CardNumber;
                if (numberGroups.ContainsKey(cardCardNumber))
                    numberGroups[cardCardNumber] = numberGroups[cardCardNumber] + 1;
                else
                    numberGroups.Add(cardCardNumber, 1);
            });
            return numberGroups;
        }

        public bool IsSameSuite()
        {
            return _cards.Select(card => card.Suite).Distinct().Count() == 1;
        }

        public bool IsTouching()
        {
            var orderedCardNumbers = _cards.Select(card => card.CardNumber.Number).OrderBy(number => number).ToList();
            for (var i = 0; i < orderedCardNumbers.Count - 1; i++)
            {
                if (orderedCardNumbers[i] + 1 != orderedCardNumbers[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

        public HandCardType BuildType()
        {
            return BuildType(GroupByNumber(), IsSameSuite(), IsTouching());
        }

        private HandCardType BuildType(IDictionary<CardNumber,int> dictionary, bool isSameSuite, bool isTouching)
        {
            if (dictionary.Count == 5)
            {
                var maxNumber = dictionary.Keys.Max(cardNumber => cardNumber);
                
                if (!isSameSuite && !isTouching)
                {
                    return new HandCardType(HoldemType.HighCard, maxNumber);
                }

                if (!isSameSuite)
                {
                    return new HandCardType(HoldemType.Straight, maxNumber);
                }

                if (!isTouching)
                {
                    return new HandCardType(HoldemType.Flush, maxNumber);
                }
                
                return new HandCardType(HoldemType.StraightFlush, maxNumber);
            }

            if (dictionary.Count == 4)
            {
                return new HandCardType(HoldemType.Pair, dictionary.First(pair => pair.Value == 2).Key);
            }

            if (dictionary.Count == 3)
            {
                var maxCount = dictionary.Values.Max();
                if (maxCount == 2)
                {
                    return new HandCardType(HoldemType.TwoPairs, dictionary.Where(pair => pair.Value == maxCount).Max(pair => pair.Key));
                } 
                
                if (maxCount == 3)
                {
                    return new HandCardType(HoldemType.ThreeOfAKind, dictionary.First(pair => pair.Value == maxCount).Key);
                }
            }

            if (dictionary.Count == 2)
            {
                var maxCount = dictionary.Values.Max();

                if (maxCount == 3)
                {
                    return new HandCardType(HoldemType.FullHouse, dictionary.First(pair => pair.Value == 3).Key);
                }

                if (maxCount == 4)
                {
                    return new HandCardType(HoldemType.FourOfAKind, dictionary.First(pair => pair.Value == 4).Key);
                }
            }
            
            return null;
        }
    }
}