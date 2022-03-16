using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;

namespace EuroJudoWebContestSheets.Cache
{
    public class MemoryCacheHelper : ICacheHelper
    {
        private IMemoryCache _memCache;

        public MemoryCacheHelper(IMemoryCache memCache)
        {
            _memCache = memCache;
        }

        public async Task<T> SetCache<T>(string key, T entry)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetPriority(CacheItemPriority.Normal);

            _memCache.Set(key, entry, cacheEntryOptions);

            return entry;
        }

        public bool TryGetValue<T>(string key, out T entry)
        {
            bool found = false;
            found = _memCache.TryGetValue(key, out entry);
            return found;
        }
    }
}