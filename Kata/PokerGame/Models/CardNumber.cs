namespace PokerGame.Models
{
    public class CardNumber
    {
        public string NumberString { get; }

        public CardNumber(string numberString)
        {
            NumberString = numberString;
        }

        protected bool Equals(CardNumber other)
        {
            return string.Equals(NumberString, other.NumberString);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CardNumber) obj);
        }

        public override int GetHashCode()
        {
            return (NumberString != null ? NumberString.GetHashCode() : 0);
        }

        public static bool operator ==(CardNumber left, CardNumber right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(CardNumber left, CardNumber right)
        {
            return !Equals(left, right);
        }
    }
}