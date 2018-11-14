using EuroJudoWebContestSheets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EuroJudoWebContestSheets.Generators
{
    public class DoubleElimination16 : GenerateSVG
    {
        private string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        public DoubleElimination16(Category category)
        {
            string SVG = "";

            SVG = SVG + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            SVG = SVG + "<svg viewBox=\"0 0 1250 500\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";

            //Draw the left of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"170\" y1=\"75\" x2=\"320\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"185\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"295\" x2=\"320\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"405\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            
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

            //Draw the left of the 16 person sheet, main bracket
            SVG = SVG + "<line x1=\"20\" y1=\"40\" x2=\"170\" y2=\"40\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"110\" x2=\"170\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"150\" x2=\"170\" y2=\"150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"220\" x2=\"170\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"260\" x2=\"170\" y2=\"260\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"330\" x2=\"170\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"370\" x2=\"170\" y2=\"370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"440\" x2=\"170\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<text x=\"30\" y=\"30\" fill=\"black\" id=\"R16A1\">A1</text>";
            SVG = SVG + "<text x=\"30\" y=\"100\" fill=\"black\" id=\"R16A2\">A2</text>";
            SVG = SVG + "<text x=\"30\" y=\"140\" fill=\"black\" id=\"R16A3\">A3</text>";
            SVG = SVG + "<text x=\"30\" y=\"210\" fill=\"black\" id=\"R16A4\">A4</text>";
            SVG = SVG + "<text x=\"30\" y=\"250\" fill=\"black\" id=\"R16A5\">A5</text>";
            SVG = SVG + "<text x=\"30\" y=\"320\" fill=\"black\" id=\"R16A6\">A6</text>";
            SVG = SVG + "<text x=\"30\" y=\"360\" fill=\"black\" id=\"R16A7\">A7</text>";
            SVG = SVG + "<text x=\"30\" y=\"430\" fill=\"black\" id=\"R16A8\">A8</text>";


            SVG = SVG + "<line x1=\"170\" y1=\"40\" x2=\"170\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"150\" x2=\"170\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"260\" x2=\"170\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"370\" x2=\"170\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";

            //Draw the right side of the 16 person sheet, main bracket
            SVG = SVG + "<line x1=\"1230\" y1=\"40\" x2=\"1090\" y2=\"40\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"110\" x2=\"1090\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"150\" x2=\"1090\" y2=\"150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"220\" x2=\"1090\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"260\" x2=\"1090\" y2=\"260\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"330\" x2=\"1090\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"370\" x2=\"1090\" y2=\"370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1230\" y1=\"440\" x2=\"1090\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<text x=\"1100\" y=\"30\" fill=\"black\" id=\"R16B1\">B1</text>";
            SVG = SVG + "<text x=\"1100\" y=\"100\" fill=\"black\" id=\"R16B2\">B2</text>";
            SVG = SVG + "<text x=\"1100\" y=\"140\" fill=\"black\" id=\"R16B3\">B3</text>";
            SVG = SVG + "<text x=\"1100\" y=\"210\" fill=\"black\" id=\"R16B4\">B4</text>";
            SVG = SVG + "<text x=\"1100\" y=\"250\" fill=\"black\" id=\"R16B5\">B5</text>";
            SVG = SVG + "<text x=\"1100\" y=\"320\" fill=\"black\" id=\"R16B6\">B6</text>";
            SVG = SVG + "<text x=\"1100\" y=\"360\" fill=\"black\" id=\"R16B7\">B7</text>";
            SVG = SVG + "<text x=\"1100\" y=\"430\" fill=\"black\" id=\"R16B8\">B8</text>";

            SVG = SVG + "<line x1=\"1090\" y1=\"40\" x2=\"1090\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"150\" x2=\"1090\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"260\" x2=\"1090\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"370\" x2=\"1090\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";
            
            SVG = SVG + "<text x=\"5\" y=\"45\" fill=\"black\">1</text>";
            SVG = SVG + "<text x=\"5\" y=\"115\" fill=\"black\">2</text>";
            SVG = SVG + "<text x=\"5\" y=\"155\" fill=\"black\">3</text>";
            SVG = SVG + "<text x=\"5\" y=\"225\" fill=\"black\">4</text>";
            SVG = SVG + "<text x=\"5\" y=\"265\" fill=\"black\">5</text>";
            SVG = SVG + "<text x=\"5\" y=\"335\" fill=\"black\">6</text>";
            SVG = SVG + "<text x=\"5\" y=\"375\" fill=\"black\">7</text>";
            SVG = SVG + "<text x=\"5\" y=\"445\" fill=\"black\">8</text>";

            SVG = SVG + "<text x=\"1235\" y=\"45\" fill=\"black\">9</text>";
            SVG = SVG + "<text x=\"1232\" y=\"115\" fill=\"black\">10</text>";
            SVG = SVG + "<text x=\"1232\" y=\"155\" fill=\"black\">11</text>";
            SVG = SVG + "<text x=\"1232\" y=\"225\" fill=\"black\">12</text>";
            SVG = SVG + "<text x=\"1232\" y=\"265\" fill=\"black\">13</text>";
            SVG = SVG + "<text x=\"1232\" y=\"335\" fill=\"black\">14</text>";
            SVG = SVG + "<text x=\"1232\" y=\"375\" fill=\"black\">15</text>";
            SVG = SVG + "<text x=\"1232\" y=\"445\" fill=\"black\">16</text>";
            SVG = SVG + "</svg>";

            _Image = SVG;
        }
    }
}
