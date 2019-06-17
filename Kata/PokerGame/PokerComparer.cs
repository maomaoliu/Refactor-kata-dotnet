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
    }
}