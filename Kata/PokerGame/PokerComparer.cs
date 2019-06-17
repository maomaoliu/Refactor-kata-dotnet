using System.Text.RegularExpressions;
using PokerGame.Models;

namespace PokerGame
{
    public class PokerComparer
    {
        private const string PlayerAndCardsSeparator = ":";
        private const int PlayerIndex = 0;
        private const int CardsIndex = 1;

        public HandCard ToHandCard(string onePlayerCardsString)
        {
            var playerAndCards = onePlayerCardsString.Split(PlayerAndCardsSeparator);
            return new HandCardCreator().BuildHandCard(playerAndCards[PlayerIndex].Trim(), playerAndCards[CardsIndex].Trim());
        }

        public string Compare(string roundString)
        {
            var regex = new Regex(@"\w+:\s*(\w{2}\s*){5}");
            var match = regex.Match(roundString.Trim());
            var playerCardsStringOne = string.Empty;
            var playerCardsStringTwo = string.Empty;
            if (match.Success)
            {
                playerCardsStringOne = match.Value;
                match = match.NextMatch();
            }

            if (match.Success)
            {
                playerCardsStringTwo = match.Value;
            }

            var handCardOne = ToHandCard(playerCardsStringOne);
            var handCardTwo = ToHandCard(playerCardsStringTwo);
            var compareResult = handCardOne.CompareTo(handCardTwo);
            if (compareResult == 0)
            {
                return new RoundResult().ToString();
            }

            var hasSameHoldemType = handCardOne.HandCardType.HoldemType == handCardTwo.HandCardType.HoldemType;
            var winSide = compareResult > 0 ? handCardOne : handCardTwo;

            return new RoundResult(winSide, hasSameHoldemType).ToString();
        }
    }
}