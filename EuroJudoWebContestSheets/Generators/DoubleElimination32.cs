using EuroJudoWebContestSheets.Models;
using System.Linq;

namespace EuroJudoWebContestSheets.Generators
{
    public class DoubleElimination32 : GenerateSVG
    {
        private string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        //@TODO: Extend to 32 compeditors.
        public DoubleElimination32(Category category)
        {
            string SVG = "";

            SVG = SVG + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            SVG = SVG + "<svg viewBox=\"0 0 1250 1000\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";

            //Draw the left of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"170\" y1=\"75\" x2=\"320\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"185\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"295\" x2=\"320\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"405\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            
            ContestSheetData contest = category.SheetData.Where(o => o.Contest == 9).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"9W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"9B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"9W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"9B\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 10).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"10W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"10B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"10W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"10B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"320\" y1=\"75\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"295\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"130\" x2=\"470\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"350\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 21).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"21W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"21B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"21W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"21B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"470\" y1=\"130\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"470\" y1=\"240\" x2=\"620\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";

            //This depends on whether the 9 and 11 places are played. if so this is contest 31, otherwise it is contest 29
            contest = category.SheetData.Where(o => o.Contest == 31).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"31W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"31W\">" + contest.CompeditorWhite + "</text>";
            }

            //Draw the right of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"1090\" y1=\"75\" x2=\"940\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"185\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"295\" x2=\"940\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"405\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 11).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"950\" y=\"65\" fill=\"black\" id=\"11W\"></text>";
                SVG = SVG + "<text x=\"950\" y=\"175\" fill=\"black\" id=\"11B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"950\" y=\"65\" fill=\"black\" id=\"11W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"950\" y=\"175\" fill=\"black\" id=\"11B\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 10).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"950\" y=\"285\" fill=\"black\" id=\"12W\"></text>";
                SVG = SVG + "<text x=\"950\" y=\"395\" fill=\"black\" id=\"12B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"950\" y=\"285\" fill=\"black\" id=\"12W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"950\" y=\"395\" fill=\"black\" id=\"12B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"940\" y1=\"75\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"295\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"130\" x2=\"790\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"350\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 22).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"800\" y=\"120\" fill=\"black\" id=\"22W\"></text>";
                SVG = SVG + "<text x=\"800\" y=\"340\" fill=\"black\" id=\"22B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"800\" y=\"120\" fill=\"black\" id=\"22W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"800\" y=\"340\" fill=\"black\" id=\"22B\">" + contest.CompeditorBlue + "</text>";
            }            

            SVG = SVG + "<line x1=\"790\" y1=\"130\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"640\" y1=\"240\" x2=\"790\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";

            //This depends on whether the 9 and 11 places are played. if so this is contest 31, otherwise it is contest 29
            contest = category.SheetData.Where(o => o.Contest == 31).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"650\" y=\"230\" fill=\"black\" id=\"31B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"650\" y=\"230\" fill=\"black\" id=\"31B\">" + contest.CompeditorBlue + "</text>";
            }

            //Draw the left of the 16 person sheet, main bracket
            SVG = SVG + "<line x1=\"20\" y1=\"40\" x2=\"170\" y2=\"40\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"110\" x2=\"170\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"150\" x2=\"170\" y2=\"150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"220\" x2=\"170\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"260\" x2=\"170\" y2=\"260\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"330\" x2=\"170\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"370\" x2=\"170\" y2=\"370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"440\" x2=\"170\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 1).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"30\" fill=\"black\" id=\"1W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"100\" fill=\"black\" id=\"1B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"30\" fill=\"black\" id=\"1W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"100\" fill=\"black\" id=\"1B\">" + contest.CompeditorBlue + "</text>";
            }
            

            contest = category.SheetData.Where(o => o.Contest == 2).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"140\" fill=\"black\" id=\"2W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"210\" fill=\"black\" id=\"2B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"140\" fill=\"black\" id=\"2W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"210\" fill=\"black\" id=\"2B\">" + contest.CompeditorBlue + "</text>";
            }
            

            contest = category.SheetData.Where(o => o.Contest == 3).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"250\" fill=\"black\" id=\"3W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"320\" fill=\"black\" id=\"3B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"250\" fill=\"black\" id=\"3W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"320\" fill=\"black\" id=\"3B\">" + contest.CompeditorBlue + "</text>";
            }
            

            contest = category.SheetData.Where(o => o.Contest == 4).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"360\" fill=\"black\" id=\"4W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"430\" fill=\"black\" id=\"4B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"360\" fill=\"black\" id=\"4W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"430\" fill=\"black\" id=\"4B\">" + contest.CompeditorBlue + "</text>";
            }
            


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

            contest = category.SheetData.Where(o => o.Contest == 5).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1100\" y=\"30\" fill=\"black\" id=\"5W\"></text>";
                SVG = SVG + "<text x=\"1100\" y=\"100\" fill=\"black\" id=\"5B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1100\" y=\"30\" fill=\"black\" id=\"5W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"1100\" y=\"100\" fill=\"black\" id=\"5B\">" + contest.CompeditorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 6).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1100\" y=\"140\" fill=\"black\" id=\"5W\"></text>";
                SVG = SVG + "<text x=\"1100\" y=\"210\" fill=\"black\" id=\"5B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1100\" y=\"140\" fill=\"black\" id=\"5W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"1100\" y=\"210\" fill=\"black\" id=\"5B\">" + contest.CompeditorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 7).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1100\" y=\"250\" fill=\"black\" id=\"7W\"></text>";
                SVG = SVG + "<text x=\"1100\" y=\"320\" fill=\"black\" id=\"7B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1100\" y=\"250\" fill=\"black\" id=\"7W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"1100\" y=\"320\" fill=\"black\" id=\"7B\">" + contest.CompeditorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 8).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1100\" y=\"360\" fill=\"black\" id=\"8W\"></text>";
                SVG = SVG + "<text x=\"1100\" y=\"430\" fill=\"black\" id=\"8B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1100\" y=\"360\" fill=\"black\" id=\"8W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"1100\" y=\"430\" fill=\"black\" id=\"8B\">" + contest.CompeditorBlue + "</text>";
            }

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

            //Repachage
            //Draw the left of the 8 person sheet, main bracket (+405) @TODO: Move them coser together
            SVG = SVG + "<line x1=\"20\" y1=\"480\" x2=\"170\" y2=\"480\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"550\" x2=\"170\" y2=\"550\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"590\" x2=\"170\" y2=\"590\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"660\" x2=\"170\" y2=\"660\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 13).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"470\" fill=\"black\" id=\"13W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"540\" fill=\"black\" id=\"13B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"470\" fill=\"black\" id=\"13W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"550\" fill=\"black\" id=\"13B\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 14).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"580\" fill=\"black\" id=\"14W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"650\" fill=\"black\" id=\"14B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"580\" fill=\"black\" id=\"QFA3\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"650\" fill=\"black\" id=\"QFA4\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"170\" y1=\"480\" x2=\"170\" y2=\"550\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"590\" x2=\"170\" y2=\"660\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"170\" y1=\"515\" x2=\"320\" y2=\"515\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"625\" x2=\"320\" y2=\"625\" stroke=\"black\" stroke-width=\"1\" />";

            //Repachage2
            SVG = SVG + "<line x1=\"170\" y1=\"575\" x2=\"320\" y2=\"575\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"685\" x2=\"320\" y2=\"685\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 17).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"505\" fill=\"black\" id=\"17W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"565\" fill=\"black\" id=\"17B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"505\" fill=\"black\" id=\"17W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"565\" fill=\"black\" id=\"17B\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 18).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"615\" fill=\"black\" id=\"18W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"675\" fill=\"black\" id=\"18B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"615\" fill=\"black\" id=\"18W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"675\" fill=\"black\" id=\"18B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"320\" y1=\"515\" x2=\"320\" y2=\"575\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"625\" x2=\"320\" y2=\"685\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"545\" x2=\"470\" y2=\"545\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"655\" x2=\"470\" y2=\"655\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 23).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"535\" fill=\"black\" id=\"21W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"645\" fill=\"black\" id=\"21B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"535\" fill=\"black\" id=\"21W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"645\" fill=\"black\" id=\"21B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"470\" y1=\"545\" x2=\"470\" y2=\"655\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"600\" x2=\"620\" y2=\"600\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"670\" x2=\"620\" y2=\"670\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"600\" x2=\"620\" y2=\"670\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"635\" x2=\"770\" y2=\"635\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 27).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"590\" fill=\"black\" id=\"27W\"></text>";
                SVG = SVG + "<text x=\"480\" y=\"660\" fill=\"black\" id=\"27B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"590\" fill=\"black\" id=\"27W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"660\" fill=\"black\" id=\"27B\">" + contest.CompeditorBlue + "</text>";
            }

            //And the other side of the repachage (+220)
            SVG = SVG + "<line x1=\"20\" y1=\"700\" x2=\"170\" y2=\"700\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"770\" x2=\"170\" y2=\"770\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"810\" x2=\"170\" y2=\"810\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"880\" x2=\"170\" y2=\"880\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 15).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"690\" fill=\"black\" id=\"15W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"760\" fill=\"black\" id=\"15B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"690\" fill=\"black\" id=\"15W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"760\" fill=\"black\" id=\"15B\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 16).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"800\" fill=\"black\" id=\"16W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"870\" fill=\"black\" id=\"16B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"800\" fill=\"black\" id=\"16W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"870\" fill=\"black\" id=\"16B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"170\" y1=\"700\" x2=\"170\" y2=\"770\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"810\" x2=\"170\" y2=\"880\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"170\" y1=\"735\" x2=\"320\" y2=\"735\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"845\" x2=\"320\" y2=\"845\" stroke=\"black\" stroke-width=\"1\" />";

            //Repachage2
            SVG = SVG + "<line x1=\"170\" y1=\"795\" x2=\"320\" y2=\"795\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"905\" x2=\"320\" y2=\"905\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 19).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"725\" fill=\"black\" id=\"19W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"785\" fill=\"black\" id=\"19B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"725\" fill=\"black\" id=\"17W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"785\" fill=\"black\" id=\"17B\">" + contest.CompeditorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 20).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"835\" fill=\"black\" id=\"20W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"895\" fill=\"black\" id=\"20B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"835\" fill=\"black\" id=\"20W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"895\" fill=\"black\" id=\"20B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"320\" y1=\"735\" x2=\"320\" y2=\"795\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"845\" x2=\"320\" y2=\"905\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"765\" x2=\"470\" y2=\"765\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"875\" x2=\"470\" y2=\"875\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 24).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"755\" fill=\"black\" id=\"24W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"865\" fill=\"black\" id=\"24B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"755\" fill=\"black\" id=\"21W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"865\" fill=\"black\" id=\"21B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"470\" y1=\"765\" x2=\"470\" y2=\"875\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"820\" x2=\"620\" y2=\"820\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"890\" x2=\"620\" y2=\"890\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"820\" x2=\"620\" y2=\"890\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"855\" x2=\"770\" y2=\"855\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 28).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"810\" fill=\"black\" id=\"28W\"></text>";
                SVG = SVG + "<text x=\"480\" y=\"880\" fill=\"black\" id=\"28B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"810\" fill=\"black\" id=\"28W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"880\" fill=\"black\" id=\"28B\">" + contest.CompeditorBlue + "</text>";
            }




            SVG = SVG + "</svg>";

            _Image = SVG;
        }
    }
}
