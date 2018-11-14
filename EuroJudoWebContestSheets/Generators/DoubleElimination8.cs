using EuroJudoWebContestSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Generators
{
    public class DoubleElimination8 : GenerateSVG
    {
        private string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        public DoubleElimination8(Category category)
        {
            string SVG = "";

            SVG = SVG + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            SVG = SVG + "<svg viewBox=\"150 50 1100 450\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";

            //Draw the left of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"170\" y1=\"75\" x2=\"320\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"185\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"295\" x2=\"320\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"405\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            //Rewrite to check if the result is not null, then use the object to get the compeditors.
            ContestSheetData contest = category.SheetData.Where(o => o.Contest == 9).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"QFA1\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"QFA2\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"QFA1\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"QFA2\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 10).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"QFA3\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"QFA4\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"QFA3\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"QFA4\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"320\" y1=\"75\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"295\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"130\" x2=\"470\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"350\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 21).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"semifinalA1\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"semifinalA2\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"semifinalA1\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"semifinalA2\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"470\" y1=\"130\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"470\" y1=\"240\" x2=\"620\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"finalA\"></text>";

            //Draw the right of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"1090\" y1=\"75\" x2=\"940\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"185\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"295\" x2=\"940\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"405\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<text x=\"950\" y=\"65\" fill=\"black\" id=\"QFB1\"></text>";
            SVG = SVG + "<text x=\"950\" y=\"175\" fill=\"black\" id=\"QFB2\"></text>";
            SVG = SVG + "<text x=\"950\" y=\"285\" fill=\"black\" id=\"QFB3\"></text>";
            SVG = SVG + "<text x=\"950\" y=\"395\" fill=\"black\" id=\"QFB4\"></text>";

            SVG = SVG + "<line x1=\"940\" y1=\"75\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"295\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"130\" x2=\"790\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"350\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<text x=\"800\" y=\"120\" fill=\"black\" id=\"semifinalB1\"></text>";
            SVG = SVG + "<text x=\"800\" y=\"340\" fill=\"black\" id=\"semifinalB2\"></text>";

            SVG = SVG + "<line x1=\"790\" y1=\"130\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"640\" y1=\"240\" x2=\"790\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<text x=\"650\" y=\"230\" fill=\"black\" id=\"finalB\"></text>";
            
            SVG = SVG + "<text x=\"155\" y=\"80\" fill=\"black\">1</text>";
            SVG = SVG + "<text x=\"155\" y=\"190\" fill=\"black\">2</text>";
            SVG = SVG + "<text x=\"155\" y=\"300\" fill=\"black\">3</text>";
            SVG = SVG + "<text x=\"155\" y=\"410\" fill=\"black\">4</text>";
            SVG = SVG + "<text x=\"1092\" y=\"80\" fill=\"black\">5</text>";
            SVG = SVG + "<text x=\"1092\" y=\"190\" fill=\"black\">6</text>";
            SVG = SVG + "<text x=\"1092\" y=\"300\" fill=\"black\">7</text>";
            SVG = SVG + "<text x=\"1092\" y=\"410\" fill=\"black\">8</text>";
           
            SVG = SVG + "</svg>";

            _Image = SVG;
        }
    }
}
