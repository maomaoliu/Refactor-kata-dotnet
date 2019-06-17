namespace PokerGame.Models
{
    public class HandCard
    {
        public HandCardType HandCardType { get; }
        public Player Player { get; }

        public HandCard(Player player, HandCardType handCardType)
        {
            Player = player;
            HandCardType = handCardType;
        }

    }
}