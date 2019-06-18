using System.Collections.Generic;

namespace Kata.Refactor.After
{
    public interface ISessionService
    {
        IEnumerable<string> Get<T>(string sessionKey);
    }
}