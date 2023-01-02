using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EJUPublisher.Configuration;
using EJUPublisher.Models;
using EJUPublisher.Services.Interfaces;
using EuroJudoProtocols.ShowFights.Models;
using EuroJudoWebContestSheets.Models.Tournament;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace EJUPublisher.Services;

/// <inheritdoc />
public class FailedUploadQueue : IFailedUploadQueue
{
    private readonly ILogger<FailedUploadQueue> _logger;

    private readonly IWebTournamentService _webTournamentService;
    private readonly IContestSheetsConfiguration _contestSheetsConfiguration;

    private readonly Queue<QueuedUpload> _failedUploads = new();

    private const string StoragePath = "QueuedUploads";
    
    public FailedUploadQueue(IWebTournamentService webTournamentService,
        IContestSheetsConfiguration contestSheetsConfiguration, ILogger<FailedUploadQueue> logger)
    {
        _webTournamentService = webTournamentService;
        _contestSheetsConfiguration = contestSheetsConfiguration;
        _logger = logger;
    }

    /// <inheritdoc />
    public async Task AddToQueue(Contest contest, CancellationToken ctx = default)
    {
        int? categoryId = await _webTournamentService.GetIdForCategory(contest.Short, contest.Weight, ctx);

        UploadContestResultDto contestResultDto = new(_contestSheetsConfiguration.TournamentId,
            categoryId == null ? 0 : categoryId.Value, contest.Number,
            contest.CompetitorWhite, contest.CompetitorBlue, contest.ScoreWhite, contest.ScoreBlue, true);

        QueuedUpload queuedUpload = new(contestResultDto, contest.Short, contest.Weight,
            _contestSheetsConfiguration.TournamentId);

        _logger.LogInformation(
            "Adding contest to queue. Tournament [{tournamentId}], Category [{categoryId}] ({Short} {Weight}), number {contestNumber}",
            queuedUpload.TournamentId, queuedUpload.ContestResult.CategoryId, queuedUpload.ShortName, queuedUpload.Weight,
            queuedUpload.ContestResult.Contest);

        _failedUploads.Enqueue(queuedUpload);
    }

    /// <inheritdoc />
    public async Task<bool> RetryUpload(CancellationToken ctx = default)
    {
        // See if there's anything to upload.
        if (_failedUploads.TryPeek(out QueuedUpload contestToUpload))
        {
            _logger.LogInformation("Retrying failed result uploads (Amount [{count}])", _failedUploads.Count);
            // Check if it can now be uploaded.
            if (await _webTournamentService.UploadContestResult(contestToUpload, ctx))
            {
                _logger.LogInformation("First try success.");
                // Success, so remove the one we just tried.
                _failedUploads.Dequeue();

                // Now try the others
                while (_failedUploads.TryPeek(out contestToUpload))
                {
                    if (await _webTournamentService.UploadContestResult(contestToUpload, ctx))
                    {
                        _failedUploads.Dequeue();
                    }
                    else
                    {
                        return false;
                    }
                }

                return true;
            }

            return false;
        }

        return true;
    }

    /// <inheritdoc />
    public async Task FlushToDisk(CancellationToken ctx = default)
    {
        if (!Directory.Exists(StoragePath))
        {
            Directory.CreateDirectory(StoragePath);
        }

        while (_failedUploads.TryDequeue(out QueuedUpload queuedUpload))
        {
            await using (StreamWriter fs = File.CreateText(Path.Combine(StoragePath, Guid.NewGuid() + ".json")))
            {
                string asJson = JsonConvert.SerializeObject(queuedUpload);

                await fs.WriteAsync(asJson);
            }
        }
    }

    /// <inheritdoc />
    public async Task<bool> ReadFromDisk(CancellationToken ctx = default)
    {
        if (!Directory.Exists(StoragePath))
        {
            return false;
        }

        IList<string> files = Directory.EnumerateFiles(StoragePath, "*.json").ToList();

        if (!files.Any())
        {
            return false;
        }
        
        foreach (string file in files)
        {
            using (StreamReader sr = File.OpenText(file))
            {
                string content = await sr.ReadToEndAsync();
                if (!string.IsNullOrEmpty(content))
                {
                    QueuedUpload upload = JsonConvert.DeserializeObject<QueuedUpload>(content);
                    _failedUploads.Enqueue(upload);
                }
            }
            
            File.Delete(file);
        }

        return true;
    }
}