using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using EJUPublisher.Configuration;
using EJUPublisher.Models;
using EJUPublisher.Services.Interfaces;
using EuroJudoProtocols.ShowFights.Models;
using EuroJudoWebContestSheets.Models.Tournament;
using Newtonsoft.Json;

namespace EJUPublisher.Services;

public class FailedUploadQueue : IFailedUploadQueue
{
    private readonly IWebTournamentService _webTournamentService;
    private readonly IContestSheetsConfiguration _contestSheetsConfiguration;

    private readonly Queue<QueuedUpload> _failedUploads = new();

    public FailedUploadQueue(IWebTournamentService webTournamentService, IContestSheetsConfiguration contestSheetsConfiguration)
    {
        _webTournamentService = webTournamentService;
        _contestSheetsConfiguration = contestSheetsConfiguration;
    }

    public async Task AddToQueue(Contest contest, CancellationToken ctx = default)
    {
        int? categoryId = await _webTournamentService.GetIdForCategory(contest.Short, contest.Weight, ctx);
        
        UploadContestResultDto contestResultDto = new(_contestSheetsConfiguration.TournamentId, categoryId == null ? 0 : categoryId.Value, contest.Number,
            contest.CompetitorWhite, contest.CompetitorBlue, contest.ScoreWhite, contest.ScoreBlue, true);

        QueuedUpload queuedUpload = new(contestResultDto, contest.Short, contest.Weight, _contestSheetsConfiguration.TournamentId);
        
        _failedUploads.Enqueue(queuedUpload);
    }

    public async Task<bool> RetryUpload(CancellationToken ctx = default)
    {
        /*bool isQueued = _failedUploads.TryPeek(out UploadContestResultDto contestToUpload);

        if (await _webTournamentService.UploadContestResult(contestToUpload, ctx))
        {
            _failedUploads.Dequeue();
        }*/
        
        throw new System.NotImplementedException();
    }

    public async Task FlushToDisk(CancellationToken ctx = default)
    {
        if (!Directory.Exists("QueuedUploads"))
        {
            Directory.CreateDirectory("QueuedUploads");
        }

        while (_failedUploads.TryDequeue(out QueuedUpload queuedUpload))
        {
            await using (StreamWriter fs = File.CreateText("QueuedUploads/" + Guid.NewGuid() + ".json"))
            {
                string asJson = JsonConvert.SerializeObject(queuedUpload);
                
                await fs.WriteAsync(asJson);
            }
        }
    }
}