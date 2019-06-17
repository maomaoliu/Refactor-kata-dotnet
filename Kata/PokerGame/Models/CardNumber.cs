using System;
using System.Collections.Generic;

namespace PokerGame.Models
{
    public class CardNumber : IComparable
    {
        private readonly Dictionary<string, int> _dictionary = new Dictionary<string, int>
        {
            {"2", 2},
            {"3", 3},
            {"4", 4},
            {"5", 5},
            {"6", 6},
            {"7", 7},
            {"8", 8},
            {"9", 9},
            {"T", 10},
            {"J", 11},
            {"Q", 12},
            {"K", 13},
            {"A", 14}
        };
        
        public string NumberString { get; }
        
        public int Number { get; }

        public CardNumber(string numberString)
        {
            NumberString = numberString;
            Number = _dictionary[numberString];
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

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            return Number.CompareTo(((CardNumber) obj).Number);
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