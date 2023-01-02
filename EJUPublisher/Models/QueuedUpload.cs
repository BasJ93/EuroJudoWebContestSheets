using EuroJudoWebContestSheets.Models.Tournament;

namespace EJUPublisher.Models;

public sealed record QueuedUpload(UploadContestResultDto ContestResult, string ShortName, string Weight, int? TournamentId)
{
    public UploadContestResultDto ContestResult { get; } = ContestResult;

    public string ShortName { get; } = ShortName;

    public string Weight { get; } = Weight;

    public int? TournamentId { get; } = TournamentId;
}