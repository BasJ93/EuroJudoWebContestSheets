namespace EuroJudoWebContestSheets.Models.DTO
{
    public class RedisRoundRobinContestSheetDataDto : RoundRobinSheetDataDto
    {
        public ContestType ContestType { get; set; }

        public int TournamentID { get; set; }

        public int CategoryID { get; set; }
    }
}