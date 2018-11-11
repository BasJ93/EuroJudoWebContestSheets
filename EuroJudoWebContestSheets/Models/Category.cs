using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Models
{
    public class Category
    {
        public int ID { get; set; }
        public string CategoryName { get; set; }
        public int SheetSize { get; set; }
        public List<ContestSheetData> SheetData { get; set; }
    }
}
