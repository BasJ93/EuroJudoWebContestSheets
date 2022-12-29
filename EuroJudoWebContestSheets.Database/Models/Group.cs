namespace EuroJudoWebContestSheets.Database.Models
{
    public class Group : BaseIdEntity
    {
        public int TournamentId { get; set; }
        public int EventNumber { get; set; }
        public string Name { get; set; } = String.Empty;
        public bool Teams { get; set; }
        public int UseCompetition { get; set; }
        public int UseCompetitionWithFinals { get; set; }
        public string Short { get; set; }  = String.Empty;
        public string System { get; set; } = String.Empty;
        
        public virtual Tournament Tournament { get; set; }
    }
}
