namespace PokerGame.Models
{
    public class Card
    {
        public CardNumber CardNumber { get; }
        public string Suite { get; }

        public Card(string cardNumber, string suite)
        {
            CardNumber = new CardNumber(cardNumber);
            Suite = suite;
        }
    }
}