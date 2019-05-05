namespace FizzBuzz
{
    public class FizzBuzz
    {
        public string Of(int index)
        {
            var result = string.Empty;

            if (MatchFizzCondition(index))
            {
                result += "Fizz";
            }

            if (MatchBuzzCondition(index))
            {
                result += "Buzz";
            }

            return result == string.Empty ? result + index : result;
        }

        private static bool MatchBuzzCondition(int index)
        {
            return index % 5 == 0 || index.ToString().Contains("5");
        }

        private static bool MatchFizzCondition(int index)
        {
            return index % 3 == 0 || index.ToString().Contains("3");
        }
    }
}