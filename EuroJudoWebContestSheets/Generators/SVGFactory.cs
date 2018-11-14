using EuroJudoWebContestSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Generators
{
    public class SVGFactory
    {
        public static string Get(Category category)
        {
            switch (category.SheetSize)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                    throw new NotImplementedException();
                case 5:
                case 6:
                case 7:
                case 8:
                    return new DoubleElimination8(category).Image;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    return new DoubleElimination16(category).Image;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
