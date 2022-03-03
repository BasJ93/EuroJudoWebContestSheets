using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.ApiKey
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }

}