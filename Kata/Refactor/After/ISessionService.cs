using System.Collections.Generic;

namespace Refactor.After
{
    public interface ISessionService
    {
        IEnumerable<string> Get<T>(string sessionKey);
    }
}