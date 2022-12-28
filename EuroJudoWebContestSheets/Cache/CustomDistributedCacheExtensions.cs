using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace EuroJudoWebContestSheets.Cache;

public static class CustomDistributedCacheExtensions
{
    public static async Task<T> GetAsync<T>(this IDistributedCache cache, string key, CancellationToken ctx = default)
    {
        string content = await cache.GetStringAsync(key, ctx);
        
        if (content != null)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        return default;
    }

    public static async Task SetAsync<T>(this IDistributedCache cache, string key, T entry, CancellationToken ctx = default)
    {
        await cache.SetStringAsync(key, JsonConvert.SerializeObject(entry), ctx);
    }
    
    public static bool TryGet<T>(this IDistributedCache cache, string key, out T entry)
    {
        bool found = false;
        
        string content = cache.GetString(key);
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