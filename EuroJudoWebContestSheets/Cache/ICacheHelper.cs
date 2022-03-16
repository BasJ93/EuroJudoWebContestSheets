using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Cache
{
    public interface ICacheHelper
    {
        public Task<T> SetCache<T>(string key, T entry);

        public bool TryGetValue<T>(string key, out T entry);
    }
}