using System.Collections.Generic;
using Refactor.After;

namespace Refactor
{
    public class FakeSessionService : ISessionService
    {
        public IDictionary<string, IList<string>> SessionKeys { get; set; }

        public FakeSessionService()
        {
            SessionKeys = new Dictionary<string, IList<string>>();
            SessionKeys["GoldenKey"] = new List<string>();
            SessionKeys["SilverKey"] = new List<string>();
            SessionKeys["CopperKey"] = new List<string>();
        }

        public IEnumerable<string> Get<T>(string sessionKey)
        {
            return this.SessionKeys[sessionKey];
        }
    }
}