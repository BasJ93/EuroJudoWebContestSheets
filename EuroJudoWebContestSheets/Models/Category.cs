using System.Collections.Generic;

namespace EuroJudoWebContestSheets.Models
{
    public class Category
    {
        //Perhaps a property for the contests for 9th and 11th place.
        public int ID { get; set; }
        public int TournamentID { get; set; }
        public string CategoryName { get; set; }
        public int SheetSize { get; set; }
        public List<ContestSheetData> SheetData { get; set; }
    }
}
