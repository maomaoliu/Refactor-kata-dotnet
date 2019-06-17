namespace PokerGame.Models
{
    public class HandCardType
    {
        public HoldemType HoldemType { get; }
        public CardNumber CardNumber { get; }

        public HandCardType(HoldemType holdemType, CardNumber cardNumber)
        {
            HoldemType = holdemType;
            CardNumber = cardNumber;
        }
    }
}