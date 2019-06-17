using System.Collections.Generic;

namespace PokerGame.Models
{
    public class RoundResult
    {
        private readonly string _resultString;

        private static readonly Dictionary<HoldemType, string> HoldemTypesMap = new Dictionary<HoldemType, string>
        {
            { HoldemType.Flush, "flush" },
            { HoldemType.HighCard, "high card" },
            { HoldemType.Pair, "pair" },
            { HoldemType.TwoPairs, "two pairs" },
            { HoldemType.ThreeOfAKind, "three of a kind" },
            { HoldemType.Straight, "straight" },
            { HoldemType.StraightFlush, "straight flush" },
            { HoldemType.FullHouse, "full house" },
            { HoldemType.FourOfAKind, "four of a kind" }
        };

        public RoundResult()
        {
            _resultString = "Tie";
        }

        public RoundResult(HandCard winSide, bool hasSameHoldemType)
        {
            _resultString = winSide.Player.Name + " wins - " + ToHoldemTypeString(winSide);
            if (hasSameHoldemType)
            {
                _resultString += ": " + winSide.HandCardType.CardNumber.DisplayName;
            }
        }

        private string ToHoldemTypeString(HandCard handCard)
        {
            return HoldemTypesMap[handCard.HandCardType.HoldemType];
        }

        public override string ToString()
        {
            return _resultString;
        }
    }
}