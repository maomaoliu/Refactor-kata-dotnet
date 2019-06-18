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
            IList<string> marks1 = marks;
            var keys = new List<string>();

            if (marks1 == null || marks1.Count == 0)
            {
                return keys;
            }

            var goldenKey = SessionService.Get<List<string>>("GoldenKey");

            keys.AddRange(goldenKey);

            marks1 = ValidateGoldenKeys(marks1);

            return marks1.Where(mark => keys.Contains(mark) || IsFakeKey(mark)).ToList();
        }
        
        public IList<string> FilterSilverAndCopperKeys(IList<string> marks)
        {
            IList<string> marks1 = marks;
            var keys = new List<string>();

            if (marks1 == null || marks1.Count == 0)
            {
                return keys;
            }

            var SilverKeys = SessionService.Get<List<string>>("SilverKey");
            var CopperKeys = SessionService.Get<List<string>>("CopperKey");

            keys.AddRange(SilverKeys);
            keys.AddRange(CopperKeys);

            return marks1.Where(mark => keys.Contains(mark) || IsFakeKey(mark)).ToList();
        }
        
        private IList<string> ValidateGoldenKeys(IList<string> marks)
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

            return marks.Where(m => !invalidKeys.Contains(m)).ToList();
        }

        private bool IsFakeKey(string mark)
        {
            return mark.EndsWith("FAKE");
        }
    }
}
