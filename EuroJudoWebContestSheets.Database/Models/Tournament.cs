namespace EuroJudoWebContestSheets.Database.Models
{
    public class Tournament : BaseIdEntity
    {
        public string TournamentName { get; set; } = String.Empty;
        
        public virtual IList<Category>? Categories { get; set; }

        public Tournament()
        {
            
        }

        public Tournament(string name)
        {
            TournamentName = name;
        }

        public Tournament(string name, IList<Category> categories)
        {
            TournamentName = name;
            Categories = categories;
        }
    }
}
