using System.Threading;
using System.Threading.Tasks;
using EuroJudoProtocols.ShowFights.Models;

namespace EJUPublisher.Services.Interfaces;

public interface IFailedUploadQueue
{
    Task AddToQueue(Contest contest, CancellationToken ctx = default);

    Task<bool> RetryUpload(CancellationToken ctx = default);

    Task FlushToDisk(CancellationToken ctx = default);
}