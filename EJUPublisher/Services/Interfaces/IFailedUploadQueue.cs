using System.Threading;
using System.Threading.Tasks;
using EuroJudoProtocols.ShowFights.Models;

namespace EJUPublisher.Services.Interfaces;

/// <summary>
/// A queue to store the failed uploads, and retry them later on.
/// </summary>
public interface IFailedUploadQueue
{
    /// <summary>
    /// Add a contest to the queue, and try to add the things we need to be able to retry it later.
    /// </summary>
    /// <param name="contest">The contest to upload the result for.</param>
    /// <param name="ctx">Cancellation token.</param>
    Task AddToQueue(Contest contest, CancellationToken ctx = default);

    /// <summary>
    /// Retry uploading the queued failed uploads.
    /// </summary>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A boolean indicating if the retry was successful or not.</returns>
    Task<bool> RetryUpload(CancellationToken ctx = default);

    /// <summary>
    /// Call to flush the queue to disk, so that it can be re-read later on.
    /// </summary>
    /// <example>Can be called when the app shuts down.</example>
    /// <param name="ctx">Cancellation token.</param>
    Task FlushToDisk(CancellationToken ctx = default);

    /// <summary>
    /// Call to read possibly flushed data back from disk.
    /// </summary>
    /// <example>Can be called on app startup.</example>
    /// <param name="ctx">Cancellation token.</param>
    /// <returns>A boolean indicating if data was read back from disk.</returns>
    Task<bool> ReadFromDisk(CancellationToken ctx = default);
}