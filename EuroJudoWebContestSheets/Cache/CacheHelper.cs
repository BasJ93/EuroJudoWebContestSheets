using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace EuroJudoWebContestSheets.Cache
{
    public class CacheHelper : ICacheHelper
    {
        private bool _useRedis = false;
        private IConnectionMultiplexer _redis;
        private IMemoryCache _memCache;

        public CacheHelper(IConnectionMultiplexer redis)
        {
            _redis = redis;
            _useRedis = true;
        }

        public CacheHelper(IMemoryCache memCache)
        {
            _memCache = memCache;
        }

        public async Task<T> SetCache<T>(string key, T entry)
        {
            if (_useRedis)
            {
                var db = _redis.GetDatabase();
                await db.StringSetAsync(key, JsonConvert.SerializeObject(entry), new TimeSpan(1, 0, 0));
            }
            else
            {
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                .SetPriority(CacheItemPriority.Normal);

                _memCache.Set(key, entry, cacheEntryOptions);
            }

            return entry;
        }

        public bool TryGetValue<T>(string key, out T entry)
        {
            bool found = false;
            if (_useRedis)
            {
                var db = _redis.GetDatabase();
                string content = db.StringGet(key);
                if(content != null)
                {
                    found = true;
                    entry = JsonConvert.DeserializeObject<T>(content);
                }
                else
                {
                    entry = default;
                }
                return found;
            }
            else
            {
                found = _memCache.TryGetValue(key, out entry);
                return found;
            }
        }
    }
}