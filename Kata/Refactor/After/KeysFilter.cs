using System.Collections.Generic;
using System.Linq;

namespace Kata.Refactor.After
{
    public class KeysFilter
    {
        private ISessionService SessionService { get; set; }
        
        public IList<string> Filter(IList<string> marks, bool isGoldenKey)
        {
            return isGoldenKey ? FilterGoldenKeys(marks) : FilterSilverAndCopperKeys(marks);
        }

        public IList<string> FilterGoldenKeys(IList<string> marks)
        {
            var filteredMarks = FilterMarkBasedOnSessionKey(marks, new List<string> { "GoldenKey" });
            return FilterInvalidGoldenMarks(filteredMarks);
        }

        public IList<string> FilterSilverAndCopperKeys(IList<string> marks)
        {
            return FilterMarkBasedOnSessionKey(marks, new List<string> { "SilverKey", "CopperKey" });
        }

        private List<string> FilterMarkBasedOnSessionKey(IList<string> marks, List<string> sessionKeys)
        {
            if (IsEmpty(marks))
            {
                return new List<string>();
            }

            return FilterValidMarks(marks, GetMarksBySessionKey(sessionKeys));
        }

        private List<string> FilterValidMarks(IList<string> marks, List<string> validMarks)
        {
            return marks.Where(mark => validMarks.Contains(mark) || IsFakeKey(mark)).ToList();
        }

        private static bool IsEmpty(IList<string> marks)
        {
            return marks == null || marks.Count == 0;
        }

        private List<string> GetMarksBySessionKey(List<string> sessionKeys)
        {
            return sessionKeys.Select(sessionKey => SessionService.Get<List<string>>(sessionKey))
                .SelectMany(k => k) .ToList();
        }

        private IList<string> FilterInvalidGoldenMarks(IList<string> marks)
        {
            return marks.Where(mark => !IsGolden02Mark(mark) || marks.Any(x => IsGolden01MarkForSameCustomer(x, mark))).ToList();
        }

        private static bool IsGolden01MarkForSameCustomer(string mark, string anotherMark)
        {
            return IsGolden01Mark(mark) && IsSameCustomer(anotherMark, mark);
        }

        private static bool IsSameCustomer(string mark, string anotherMark)
        {
            return ParseCustomerFromMark(mark).Equals(ParseCustomerFromMark(anotherMark));
        }

        private static string ParseCustomerFromMark(string mark)
        {
            return mark.Substring(4, 6);
        }

        private static bool IsGolden01Mark(string x)
        {
            return x.StartsWith("GD01");
        }

        private static bool IsGolden02Mark(string x)
        {
            return x.StartsWith("GD02");
        }

        private bool IsFakeKey(string mark)
        {
            return mark.EndsWith("FAKE");
        }
    }
}
