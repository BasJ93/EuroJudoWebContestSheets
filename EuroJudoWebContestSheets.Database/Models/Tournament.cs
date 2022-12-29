namespace EuroJudoWebContestSheets.Database.Models
{
    public class Tournament : BaseIdEntity
    {
        public string TournamentName { get; set; } = String.Empty;
        
        public virtual IList<Category>? Categories { get; set; }
    }
}
