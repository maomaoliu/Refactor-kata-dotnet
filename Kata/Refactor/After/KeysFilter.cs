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
            if (marks == null || marks.Count == 0)
            {
                return new List<string>();
            }

            var keys = GetMarksBySessionKey(new List<string> { "GoldenKey" });

            var filteredMarks = marks.Where(mark => keys.Contains(mark) || IsFakeKey(mark)).ToList();

            return ValidateGoldenKeys(filteredMarks);
        }

        public IList<string> FilterSilverAndCopperKeys(IList<string> marks)
        {
            if (marks == null || marks.Count == 0)
            {
                return new List<string>();
            }

            var keys = GetMarksBySessionKey(new List<string> { "SilverKey", "CopperKey" });

            return marks.Where(mark => keys.Contains(mark) || IsFakeKey(mark)).ToList();
        }

        private List<string> GetMarksBySessionKey(List<string> sessionKeys)
        {
            return sessionKeys.Select(sessionKey => SessionService.Get<List<string>>(sessionKey))
                .SelectMany(k => k) .ToList();
        }

        private IList<string> ValidateGoldenKeys(IList<string> marks)
        {
            var invalidKeys = GetInvalidGolderMarks(marks);
            return marks.Where(m => !invalidKeys.Contains(m)).ToList();
        }

        private static List<string> GetInvalidGolderMarks(IList<string> marks)
        {
            var golden02Mark = marks.Where(x => x.StartsWith("GD02"));
            var invalidKeys = new List<string>();

            foreach (var mark in golden02Mark)
            {
                if (!marks.Any(x => x.StartsWith("GD01") && mark.Substring(4, 6).Equals(x.Substring(4, 6))))
                {
                    invalidKeys.Add(mark);
                }
            }

            return invalidKeys;
        }

        private bool IsFakeKey(string mark)
        {
            return mark.EndsWith("FAKE");
        }
    }
}
