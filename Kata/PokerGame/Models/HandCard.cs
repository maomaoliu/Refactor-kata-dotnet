using System;

namespace PokerGame.Models
{
    public class HandCard : IComparable
    {
        public HandCardType HandCardType { get; }
        public Player Player { get; }

        public HandCard(Player player, HandCardType handCardType)
        {
            Player = player;
            HandCardType = handCardType;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var that = (HandCard)obj;
            return HandCardType.CompareTo(that.HandCardType);
        }
    }
}