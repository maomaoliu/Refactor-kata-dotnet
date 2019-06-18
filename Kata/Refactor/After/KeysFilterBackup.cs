using System.Collections.Generic;
using System.Linq;

namespace Kata.Refactor.After
{
    public class KeysFilterBackup
    {
        private ISessionService SessionService { get; set; }

        public IList<string> Filter(IList<string> marks, bool isGoldenKey)
        {
            return isGoldenKey ? FilterGoldenKeys(marks) : FilterSilverAndCopperKeys(marks);
        }

        public IList<string> FilterGoldenKeys(IList<string> marks)
        {
            var filteredMarks = FilterMarkBasedOnSessionKey(marks, new List<string>() {"GoldenKey"});
            return FilterInvalidGoldenMarks(filteredMarks);
        }

        public List<string> FilterSilverAndCopperKeys(IList<string> marks)
        {
            return FilterMarkBasedOnSessionKey(marks, new List<string>() {"SilverKey", "CopperKey"});
        }

        private List<string> GetMarksBySessionKey(List<string> sessionKeys)
        {
            return sessionKeys.Select(sessionKey => SessionService.Get<List<string>>(sessionKey))
                .SelectMany(k => k).ToList();
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

        private bool IsEmpty(IList<string> marks)
        {
            return marks == null || marks.Count == 0;
        }

        private IList<string> FilterInvalidGoldenMarks(IList<string> marks)
        {
            return marks.Where(mark => !IsGolden02Mark(mark) || marks.Any(anotherMark => IsGolden01MarkForSameCustomer(mark, anotherMark)))
                .ToList();
        }

        private bool IsGolden01MarkForSameCustomer(string mark, string anotherMark)
        {
            return IsGolden01Mark(anotherMark) && IsSameCustomer(mark, anotherMark);
        }

        private bool IsSameCustomer(string mark, string anotherMark)
        {
            return ParseCustomerFromMark(mark).Equals(ParseCustomerFromMark(anotherMark));
        }

        private static string ParseCustomerFromMark(string mark)
        {
            const int startIndex = 4;
            const int endIndex = 6;
            return mark.Substring(startIndex, endIndex);
        }

        private bool IsGolden01Mark(string x)
        {
            return x.StartsWith("GD01");
        }

        private bool IsGolden02Mark(string x)
        {
            return x.StartsWith("GD02");
        }

        private bool IsFakeKey(string mark)
        {
            return mark.EndsWith("FAKE");
        }
    }
}