using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StackExchange.Redis;

namespace EuroJudoWebContestSheets.Cache
{
    public class RedisCacheHelper : ICacheHelper
    {
        private IConnectionMultiplexer _redis;

        public RedisCacheHelper(IConnectionMultiplexer redis)
        {
            _redis = redis;
        }

        public async Task<T> SetCache<T>(string key, T entry)
        {
            var db = _redis.GetDatabase();
            await db.StringSetAsync(key, JsonConvert.SerializeObject(entry), new TimeSpan(1, 0, 0));

            return entry;
        }

        public bool TryGetValue<T>(string key, out T entry)
        {
            bool found = false;

            var db = _redis.GetDatabase();
            string content = db.StringGet(key);
            if (content != null)
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
    }
}