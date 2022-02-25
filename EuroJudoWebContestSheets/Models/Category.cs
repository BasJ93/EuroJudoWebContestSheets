using System.Collections.Generic;
using System.Linq;

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

        public bool TryGet(int contestIndex, out ContestSheetData contest)
        {
            contest = SheetData.Where(o => o.Contest == contestIndex).FirstOrDefault();
            if(contest == null)
            {
                return false;
            }

            return true;
        }
    }
}
