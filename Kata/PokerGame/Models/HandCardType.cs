using System;

namespace PokerGame.Models
{
    public class HandCardType : IComparable
    {
        public HoldemType HoldemType { get; }
        public CardNumber CardNumber { get; }

        public HandCardType(HoldemType holdemType, CardNumber cardNumber)
        {
            HoldemType = holdemType;
            CardNumber = cardNumber;
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            var that = (HandCardType)obj;
            var holdemTypeResult = HoldemType.CompareTo(that.HoldemType);
            return holdemTypeResult != 0 ? holdemTypeResult : CardNumber.CompareTo(that.CardNumber);
        }
    }
}