using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Authorization;

namespace EuroJudoWebContestSheets.ApiKey
{
    public class InMemoryGetApiKeyQuery : IGetApiKeyQuery
    {
        private readonly IDictionary<string, ApiKey> _apiKeys;

        public InMemoryGetApiKeyQuery()
        {
            var existingApiKeys = new List<ApiKey>
        {
            new ApiKey(1, "Bas", "C5BFF7F0-B4DF-475E-A331-F737424F013C", new DateTime(2022, 03, 02),
                new List<string>
                {
                    Roles.Admin,
                    Roles.Uploader,
                }),
            new ApiKey(2, "Annelies", "5908D47C-85D3-4024-8C2B-6EC9464398AD", new DateTime(2022, 03, 02),
                new List<string>
                {
                    Roles.Uploader
                }),
        };

            _apiKeys = existingApiKeys.ToDictionary(x => x.Key, x => x);
        }

        public Task<ApiKey> Execute(string providedApiKey)
        {
            _apiKeys.TryGetValue(providedApiKey, out var key);
            return Task.FromResult(key);
        }
    }

}