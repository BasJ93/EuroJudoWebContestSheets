using EuroJudoWebContestSheets.Models;
using System;

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
                    return new RoundRobin3(category).Image;
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
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                    return new DoubleElimination32(category).Image;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
