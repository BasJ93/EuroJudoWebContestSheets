using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models;

namespace EuroJudoWebContestSheets.Authentication
{
    public interface IGetApiKeyQuery
    {
        Task<ApiKey> Execute(string providedApiKey);
    }

}