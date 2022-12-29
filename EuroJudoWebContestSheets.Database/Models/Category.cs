namespace EuroJudoWebContestSheets.Database.Models
{
    public class Category : BaseIdEntity
    {
        //Perhaps a property for the contests for 9th and 11th place.
        public int TournamentId { get; set; }
        public string CategoryName { get; set; }
        public string Short { get; set; }
        public string Weight { get; set; }
        public int SheetSize { get; set; }
        
        public virtual Tournament? Tournament { get; set; }
        public virtual IList<ContestSheetData>? SheetData { get; set; }

        public bool TryGet(int contestIndex, out ContestSheetData contest)
        {
            contest = SheetData.FirstOrDefault(o => o.Contest == contestIndex);
            if(contest == null)
            {
                return false;
            }

            return true;
        }
    }
}
