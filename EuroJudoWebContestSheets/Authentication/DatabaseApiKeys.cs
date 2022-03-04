using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models;

namespace EuroJudoWebContestSheets.Authentication
{
    public class DatabaseGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public DatabaseGetApiKeyQuery(dbContext db)
        {
            var existingApiKeys = db.ApiKeys.Select(k => new ApiKey(k.Id, k.Owner, k.Key, k.Created, k.Roles.ToList())).ToList();

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }

}