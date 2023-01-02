using EuroJudoWebContestSheets.Models.Tournament;

namespace EJUPublisher.Models;

public record QueuedUpload()
{
    public QueuedUpload(UploadContestResultDto contestResult, string shortName, string weight, int? tournamentId) : this()
    {
        ContestResult = contestResult;
        Short = shortName;
        Weight = weight;
        TournamentId = tournamentId;
    }

    public UploadContestResultDto ContestResult { get; }
    
    public string Short { get; }
    
    public string Weight { get; }
    
    public int? TournamentId { get; }
}