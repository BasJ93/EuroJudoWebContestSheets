using System.Linq;
using EuroJudoWebContestSheets.Database.Models;

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

        public DoubleElimination32(Category category)
        {
            string SVG = "";

            SVG = SVG + "<?xml version=\"1.0\" encoding=\"UTF-8\"?>";
            SVG = SVG + "<svg viewBox=\"0 0 1550 1900\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";

            //Draw the left of the 32 person sheet, main bracket
            //Round of 32
            SVG = SVG + "<line x1=\"20\" y1=\"40\" x2=\"170\" y2=\"40\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"110\" x2=\"170\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"150\" x2=\"170\" y2=\"150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"220\" x2=\"170\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"260\" x2=\"170\" y2=\"260\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"330\" x2=\"170\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"370\" x2=\"170\" y2=\"370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"440\" x2=\"170\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"170\" y1=\"40\" x2=\"170\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"150\" x2=\"170\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"260\" x2=\"170\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"370\" x2=\"170\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"20\" y1=\"480\" x2=\"170\" y2=\"480\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"550\" x2=\"170\" y2=\"550\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"590\" x2=\"170\" y2=\"590\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"660\" x2=\"170\" y2=\"660\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"700\" x2=\"170\" y2=\"700\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"770\" x2=\"170\" y2=\"770\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"810\" x2=\"170\" y2=\"810\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"880\" x2=\"170\" y2=\"880\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"170\" y1=\"480\" x2=\"170\" y2=\"550\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"590\" x2=\"170\" y2=\"660\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"700\" x2=\"170\" y2=\"770\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"810\" x2=\"170\" y2=\"880\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<text x=\"0\" y=\"45\" fill=\"black\">32</text>";
            SVG = SVG + "<text x=\"0\" y=\"115\" fill=\"black\">16</text>";
            SVG = SVG + "<text x=\"0\" y=\"155\" fill=\"black\">24</text>";
            SVG = SVG + "<text x=\"5\" y=\"225\" fill=\"black\">8</text>";
            SVG = SVG + "<text x=\"0\" y=\"265\" fill=\"black\">28</text>";
            SVG = SVG + "<text x=\"0\" y=\"335\" fill=\"black\">12</text>";
            SVG = SVG + "<text x=\"0\" y=\"375\" fill=\"black\">20</text>";
            SVG = SVG + "<text x=\"5\" y=\"445\" fill=\"black\">4</text>";
            SVG = SVG + "<text x=\"0\" y=\"485\" fill=\"black\">30</text>";
            SVG = SVG + "<text x=\"0\" y=\"555\" fill=\"black\">14</text>";
            SVG = SVG + "<text x=\"0\" y=\"595\" fill=\"black\">22</text>";
            SVG = SVG + "<text x=\"5\" y=\"665\" fill=\"black\">6</text>";
            SVG = SVG + "<text x=\"0\" y=\"705\" fill=\"black\">26</text>";
            SVG = SVG + "<text x=\"0\" y=\"775\" fill=\"black\">10</text>";
            SVG = SVG + "<text x=\"0\" y=\"815\" fill=\"black\">18</text>";
            SVG = SVG + "<text x=\"5\" y=\"885\" fill=\"black\">2</text>";


            ContestSheetData contest = category.SheetData.Where(o => o.Contest == 1).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"30\" fill=\"black\" id=\"1W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"100\" fill=\"black\" id=\"1B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"30\" fill=\"black\" id=\"1W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"100\" fill=\"black\" id=\"1B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 2).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"140\" fill=\"black\" id=\"2W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"210\" fill=\"black\" id=\"2B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"140\" fill=\"black\" id=\"2W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"210\" fill=\"black\" id=\"2B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 3).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"250\" fill=\"black\" id=\"3W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"320\" fill=\"black\" id=\"3B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"250\" fill=\"black\" id=\"3W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"320\" fill=\"black\" id=\"3B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 4).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"360\" fill=\"black\" id=\"4W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"430\" fill=\"black\" id=\"4B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"360\" fill=\"black\" id=\"4W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"430\" fill=\"black\" id=\"4B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 5).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"470\" fill=\"black\" id=\"5W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"540\" fill=\"black\" id=\"5B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"470\" fill=\"black\" id=\"5W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"540\" fill=\"black\" id=\"5B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 6).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"580\" fill=\"black\" id=\"6W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"650\" fill=\"black\" id=\"6B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"580\" fill=\"black\" id=\"6W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"650\" fill=\"black\" id=\"6B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 7).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"690\" fill=\"black\" id=\"7W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"760\" fill=\"black\" id=\"7B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"690\" fill=\"black\" id=\"7W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"760\" fill=\"black\" id=\"7B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 8).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"800\" fill=\"black\" id=\"8W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"870\" fill=\"black\" id=\"8B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"800\" fill=\"black\" id=\"8W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"870\" fill=\"black\" id=\"8B\">" + contest.CompetitorBlue + "</text>";
            }



            //Round of 16

            SVG = SVG + "<line x1=\"170\" y1=\"75\" x2=\"320\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"185\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"295\" x2=\"320\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"405\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"515\" x2=\"320\" y2=\"515\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"625\" x2=\"320\" y2=\"625\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"735\" x2=\"320\" y2=\"735\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"845\" x2=\"320\" y2=\"845\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 17).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"17W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"17B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"17W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"17B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 18).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"18W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"18B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"18W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"18B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 19).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"505\" fill=\"black\" id=\"19W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"615\" fill=\"black\" id=\"19B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"505\" fill=\"black\" id=\"19W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"615\" fill=\"black\" id=\"19B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 20).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"725\" fill=\"black\" id=\"20W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"835\" fill=\"black\" id=\"20B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"725\" fill=\"black\" id=\"20W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"835\" fill=\"black\" id=\"20B\">" + contest.CompetitorBlue + "</text>";
            }
            

            //Round of 8

            SVG = SVG + "<line x1=\"320\" y1=\"75\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"295\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"130\" x2=\"470\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"350\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"515\" x2=\"320\" y2=\"625\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"735\" x2=\"320\" y2=\"845\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"570\" x2=\"470\" y2=\"570\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"790\" x2=\"470\" y2=\"790\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 41).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"41W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"41B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"41W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"41B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 42).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"560\" fill=\"black\" id=\"42W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"780\" fill=\"black\" id=\"42B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"560\" fill=\"black\" id=\"42W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"780\" fill=\"black\" id=\"42B\">" + contest.CompetitorBlue + "</text>";
            }


            //Round of 4

            SVG = SVG + "<line x1=\"470\" y1=\"130\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"570\" x2=\"470\" y2=\"790\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"470\" y1=\"240\" x2=\"620\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"680\" x2=\"620\" y2=\"680\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 53).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"53W\"></text>";
                SVG = SVG + "<text x=\"480\" y=\"670\" fill=\"black\" id=\"53W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"53W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"670\" fill=\"black\" id=\"53W\">" + contest.CompetitorWhite + "</text>";
            }

            //Final, white

            SVG = SVG + "<line x1=\"620\" y1=\"240\" x2=\"620\" y2=\"680\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"620\" y1=\"460\" x2=\"770\" y2=\"460\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 59).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"630\" y=\"450\" fill=\"black\" id=\"59W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"630\" y=\"450\" fill=\"black\" id=\"59W\">" + contest.CompetitorWhite + "</text>";
            }




            //Draw the right side of the 32 person sheet, main bracket

            SVG = SVG + "<line x1=\"1530\" y1=\"40\" x2=\"1390\" y2=\"40\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"110\" x2=\"1390\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"150\" x2=\"1390\" y2=\"150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"220\" x2=\"1390\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"260\" x2=\"1390\" y2=\"260\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"330\" x2=\"1390\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"370\" x2=\"1390\" y2=\"370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"440\" x2=\"1390\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"480\" x2=\"1390\" y2=\"480\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"550\" x2=\"1390\" y2=\"550\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"590\" x2=\"1390\" y2=\"590\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"660\" x2=\"1390\" y2=\"660\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"700\" x2=\"1390\" y2=\"700\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"770\" x2=\"1390\" y2=\"770\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"810\" x2=\"1390\" y2=\"810\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1530\" y1=\"880\" x2=\"1390\" y2=\"880\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"1390\" y1=\"40\" x2=\"1390\" y2=\"110\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"150\" x2=\"1390\" y2=\"220\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"260\" x2=\"1390\" y2=\"330\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"370\" x2=\"1390\" y2=\"440\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"480\" x2=\"1390\" y2=\"550\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"590\" x2=\"1390\" y2=\"660\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"700\" x2=\"1390\" y2=\"770\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"810\" x2=\"1390\" y2=\"880\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<text x=\"1535\" y=\"45\" fill=\"black\">31</text>";
            SVG = SVG + "<text x=\"1532\" y=\"115\" fill=\"black\">15</text>";
            SVG = SVG + "<text x=\"1532\" y=\"155\" fill=\"black\">23</text>";
            SVG = SVG + "<text x=\"1532\" y=\"225\" fill=\"black\">7</text>";
            SVG = SVG + "<text x=\"1532\" y=\"265\" fill=\"black\">27</text>";
            SVG = SVG + "<text x=\"1532\" y=\"335\" fill=\"black\">11</text>";
            SVG = SVG + "<text x=\"1532\" y=\"375\" fill=\"black\">19</text>";
            SVG = SVG + "<text x=\"1532\" y=\"445\" fill=\"black\">3</text>";
            SVG = SVG + "<text x=\"1535\" y=\"485\" fill=\"black\">29</text>";
            SVG = SVG + "<text x=\"1532\" y=\"555\" fill=\"black\">13</text>";
            SVG = SVG + "<text x=\"1532\" y=\"595\" fill=\"black\">21</text>";
            SVG = SVG + "<text x=\"1532\" y=\"665\" fill=\"black\">5</text>";
            SVG = SVG + "<text x=\"1532\" y=\"705\" fill=\"black\">25</text>";
            SVG = SVG + "<text x=\"1532\" y=\"755\" fill=\"black\">9</text>";
            SVG = SVG + "<text x=\"1532\" y=\"815\" fill=\"black\">17</text>";
            SVG = SVG + "<text x=\"1532\" y=\"885\" fill=\"black\">1</text>";

            contest = category.SheetData.Where(o => o.Contest == 9).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"30\" fill=\"black\" id=\"9W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"100\" fill=\"black\" id=\"9B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"30\" fill=\"black\" id=\"9W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"100\" fill=\"black\" id=\"9B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 10).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"140\" fill=\"black\" id=\"10W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"210\" fill=\"black\" id=\"10B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"140\" fill=\"black\" id=\"10W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"210\" fill=\"black\" id=\"10B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 11).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"250\" fill=\"black\" id=\"11W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"320\" fill=\"black\" id=\"11B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"250\" fill=\"black\" id=\"11W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"320\" fill=\"black\" id=\"11B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 12).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"360\" fill=\"black\" id=\"12W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"430\" fill=\"black\" id=\"12B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"360\" fill=\"black\" id=\"12W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"430\" fill=\"black\" id=\"12B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 13).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"470\" fill=\"black\" id=\"12W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"540\" fill=\"black\" id=\"12B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"470\" fill=\"black\" id=\"12W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"540\" fill=\"black\" id=\"12B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 14).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"580\" fill=\"black\" id=\"13W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"650\" fill=\"black\" id=\"13B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"580\" fill=\"black\" id=\"13W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"650\" fill=\"black\" id=\"13B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 15).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"690\" fill=\"black\" id=\"14W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"760\" fill=\"black\" id=\"14B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"690\" fill=\"black\" id=\"14W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"760\" fill=\"black\" id=\"14B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 16).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1400\" y=\"800\" fill=\"black\" id=\"15W\"></text>";
                SVG = SVG + "<text x=\"1400\" y=\"870\" fill=\"black\" id=\"15B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1400\" y=\"800\" fill=\"black\" id=\"15W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1400\" y=\"870\" fill=\"black\" id=\"15B\">" + contest.CompetitorBlue + "</text>";
            }


            //Round of 16

            SVG = SVG + "<line x1=\"1390\" y1=\"75\" x2=\"1240\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"185\" x2=\"1240\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"295\" x2=\"1240\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"405\" x2=\"1240\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"515\" x2=\"1240\" y2=\"515\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"625\" x2=\"1240\" y2=\"625\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"735\" x2=\"1240\" y2=\"735\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1390\" y1=\"845\" x2=\"1240\" y2=\"845\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"1240\" y1=\"75\" x2=\"1240\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1240\" y1=\"295\" x2=\"1240\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1240\" y1=\"515\" x2=\"1240\" y2=\"625\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1240\" y1=\"735\" x2=\"1240\" y2=\"845\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"1240\" y1=\"130\" x2=\"1090\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1240\" y1=\"350\" x2=\"1090\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1240\" y1=\"570\" x2=\"1090\" y2=\"570\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1240\" y1=\"790\" x2=\"1090\" y2=\"790\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 21).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1250\" y=\"65\" fill=\"black\" id=\"21W\"></text>";
                SVG = SVG + "<text x=\"1250\" y=\"175\" fill=\"black\" id=\"21B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1250\" y=\"65\" fill=\"black\" id=\"21W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1250\" y=\"175\" fill=\"black\" id=\"21B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 22).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1250\" y=\"285\" fill=\"black\" id=\"22W\"></text>";
                SVG = SVG + "<text x=\"1250\" y=\"395\" fill=\"black\" id=\"22B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1250\" y=\"285\" fill=\"black\" id=\"22W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1250\" y=\"395\" fill=\"black\" id=\"22B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 23).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1250\" y=\"505\" fill=\"black\" id=\"23W\"></text>";
                SVG = SVG + "<text x=\"1250\" y=\"615\" fill=\"black\" id=\"23B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1250\" y=\"505\" fill=\"black\" id=\"23W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1250\" y=\"615\" fill=\"black\" id=\"23B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 24).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1250\" y=\"725\" fill=\"black\" id=\"24W\"></text>";
                SVG = SVG + "<text x=\"1250\" y=\"835\" fill=\"black\" id=\"24B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1250\" y=\"725\" fill=\"black\" id=\"24W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1250\" y=\"835\" fill=\"black\" id=\"24B\">" + contest.CompetitorBlue + "</text>";
            }


            //Round of 8          

            SVG = SVG + "<line x1=\"1090\" y1=\"130\" x2=\"1090\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"570\" x2=\"1090\" y2=\"790\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 43).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1100\" y=\"120\" fill=\"black\" id=\"43W\"></text>";
                SVG = SVG + "<text x=\"1100\" y=\"340\" fill=\"black\" id=\"43B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1100\" y=\"120\" fill=\"black\" id=\"43W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1100\" y=\"340\" fill=\"black\" id=\"43B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 44).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"1100\" y=\"120\" fill=\"black\" id=\"44W\"></text>";
                SVG = SVG + "<text x=\"1100\" y=\"340\" fill=\"black\" id=\"44B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"1100\" y=\"120\" fill=\"black\" id=\"44W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"1100\" y=\"340\" fill=\"black\" id=\"44B\">" + contest.CompetitorBlue + "</text>";
            }

            //Round of 4

            SVG = SVG + "<line x1=\"940\" y1=\"240\" x2=\"1090\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"680\" x2=\"1090\" y2=\"680\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"240\" x2=\"940\" y2=\"680\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 54).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"950\" y=\"230\" fill=\"black\" id=\"54W\"></text>";
                SVG = SVG + "<text x=\"950\" y=\"670\" fill=\"black\" id=\"54B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"950\" y=\"230\" fill=\"black\" id=\"54W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"950\" y=\"670\" fill=\"black\" id=\"54B\">" + contest.CompetitorBlue + "</text>";
            }

            //Finale
            SVG = SVG + "<line x1=\"820\" y1=\"460\" x2=\"940\" y2=\"460\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 59).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"830\" y=\"450\" fill=\"black\" id=\"59B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"830\" y=\"450\" fill=\"black\" id=\"59B\">" + contest.CompetitorBlue + "</text>";
            }


            //Repachage
            SVG = SVG + "<line x1=\"20\" y1=\"920\" x2=\"170\" y2=\"920\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"990\" x2=\"170\" y2=\"990\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1030\" x2=\"170\" y2=\"1030\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1100\" x2=\"170\" y2=\"1100\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1140\" x2=\"170\" y2=\"1140\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1210\" x2=\"170\" y2=\"1210\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1250\" x2=\"170\" y2=\"1250\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1320\" x2=\"170\" y2=\"1320\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"170\" y1=\"920\" x2=\"170\" y2=\"990\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1030\" x2=\"170\" y2=\"1100\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1140\" x2=\"170\" y2=\"1210\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1250\" x2=\"170\" y2=\"1320\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"20\" y1=\"1360\" x2=\"170\" y2=\"1360\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1430\" x2=\"170\" y2=\"1430\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1470\" x2=\"170\" y2=\"1470\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1540\" x2=\"170\" y2=\"1540\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1580\" x2=\"170\" y2=\"1580\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1650\" x2=\"170\" y2=\"1650\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1690\" x2=\"170\" y2=\"1690\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"20\" y1=\"1760\" x2=\"170\" y2=\"1760\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"170\" y1=\"1360\" x2=\"170\" y2=\"1430\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1470\" x2=\"170\" y2=\"1540\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1580\" x2=\"170\" y2=\"1650\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1690\" x2=\"170\" y2=\"1760\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 25).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"910\" fill=\"black\" id=\"25W\">25</text>";
                SVG = SVG + "<text x=\"30\" y=\"980\" fill=\"black\" id=\"25B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"910\" fill=\"black\" id=\"25W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"980\" fill=\"black\" id=\"25B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 26).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1030\" fill=\"black\" id=\"26W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"1100\" fill=\"black\" id=\"26B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1030\" fill=\"black\" id=\"26W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1100\" fill=\"black\" id=\"26B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 27).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1130\" fill=\"black\" id=\"27W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"1210\" fill=\"black\" id=\"27B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1130\" fill=\"black\" id=\"27W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1210\" fill=\"black\" id=\"27B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 28).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1240\" fill=\"black\" id=\"28W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"1310\" fill=\"black\" id=\"28B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1240\" fill=\"black\" id=\"28W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1310\" fill=\"black\" id=\"28B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 29).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1350\" fill=\"black\" id=\"29W\">29</text>";
                SVG = SVG + "<text x=\"30\" y=\"1420\" fill=\"black\" id=\"29B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1350\" fill=\"black\" id=\"29W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1420\" fill=\"black\" id=\"29B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 30).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1460\" fill=\"black\" id=\"30W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"1530\" fill=\"black\" id=\"30B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1460\" fill=\"black\" id=\"30W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1530\" fill=\"black\" id=\"30B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 31).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1570\" fill=\"black\" id=\"31W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"1640\" fill=\"black\" id=\"31B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1570\" fill=\"black\" id=\"31W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1640\" fill=\"black\" id=\"31B\">" + contest.CompetitorBlue + "</text>";
            }


            contest = category.SheetData.Where(o => o.Contest == 32).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"30\" y=\"1680\" fill=\"black\" id=\"32W\"></text>";
                SVG = SVG + "<text x=\"30\" y=\"1750\" fill=\"black\" id=\"32B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"30\" y=\"1680\" fill=\"black\" id=\"32W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"30\" y=\"1750\" fill=\"black\" id=\"32B\">" + contest.CompetitorBlue + "</text>";
            }



            //Repachage2

            SVG = SVG + "<line x1=\"170\" y1=\"955\" x2=\"320\" y2=\"955\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1010\" x2=\"320\" y2=\"1010\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1065\" x2=\"320\" y2=\"1065\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1120\" x2=\"320\" y2=\"1120\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1175\" x2=\"320\" y2=\"1175\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1230\" x2=\"320\" y2=\"1230\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1285\" x2=\"320\" y2=\"1285\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1340\" x2=\"320\" y2=\"1340\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1395\" x2=\"320\" y2=\"1395\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1450\" x2=\"320\" y2=\"1450\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1505\" x2=\"320\" y2=\"1505\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1560\" x2=\"320\" y2=\"1560\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1615\" x2=\"320\" y2=\"1615\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1670\" x2=\"320\" y2=\"1670\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1725\" x2=\"320\" y2=\"1725\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"1780\" x2=\"320\" y2=\"1780\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 33).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"945\" fill=\"black\" id=\"33W\">33</text>";
                SVG = SVG + "<text x=\"180\" y=\"1100\" fill=\"black\" id=\"33B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"945\" fill=\"black\" id=\"33W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1100\" fill=\"black\" id=\"33B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 34).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1010\" fill=\"black\" id=\"34W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"1055\" fill=\"black\" id=\"34B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1010\" fill=\"black\" id=\"34W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1055\" fill=\"black\" id=\"34B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 35).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1165\" fill=\"black\" id=\"35W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"1220\" fill=\"black\" id=\"35B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1165\" fill=\"black\" id=\"35W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1220\" fill=\"black\" id=\"35B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 36).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1275\" fill=\"black\" id=\"36W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"1330\" fill=\"black\" id=\"36B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1275\" fill=\"black\" id=\"36W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1330\" fill=\"black\" id=\"36B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 37).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1385\" fill=\"black\" id=\"37W\">37</text>";
                SVG = SVG + "<text x=\"180\" y=\"1440\" fill=\"black\" id=\"37B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1385\" fill=\"black\" id=\"37W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1440\" fill=\"black\" id=\"37B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 38).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1495\" fill=\"black\" id=\"38W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"1550\" fill=\"black\" id=\"38B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1495\" fill=\"black\" id=\"38W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1550\" fill=\"black\" id=\"38B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 39).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1605\" fill=\"black\" id=\"39W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"1670\" fill=\"black\" id=\"39B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1605\" fill=\"black\" id=\"39W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1670\" fill=\"black\" id=\"39B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 40).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"180\" y=\"1715\" fill=\"black\" id=\"40W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"1770\" fill=\"black\" id=\"40B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"1715\" fill=\"black\" id=\"40W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"1770\" fill=\"black\" id=\"40B\">" + contest.CompetitorBlue + "</text>";
            }

            //Repachage 3 (+880)

            SVG = SVG + "<line x1=\"320\" y1=\"955\" x2=\"320\" y2=\"1010\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1065\" x2=\"320\" y2=\"1120\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1175\" x2=\"320\" y2=\"1230\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1285\" x2=\"320\" y2=\"1340\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1395\" x2=\"320\" y2=\"1450\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1505\" x2=\"320\" y2=\"1560\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1615\" x2=\"320\" y2=\"1670\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1725\" x2=\"320\" y2=\"1780\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"985\" x2=\"470\" y2=\"985\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1095\" x2=\"470\" y2=\"1095\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1205\" x2=\"470\" y2=\"1205\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1315\" x2=\"470\" y2=\"1315\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1425\" x2=\"470\" y2=\"1425\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1535\" x2=\"470\" y2=\"1535\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1645\" x2=\"470\" y2=\"1645\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"1755\" x2=\"470\" y2=\"1755\" stroke=\"black\" stroke-width=\"1\" />";


            contest = category.SheetData.Where(o => o.Contest == 45).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"975\" fill=\"black\" id=\"45W\">45</text>";
                SVG = SVG + "<text x=\"330\" y=\"1055\" fill=\"black\" id=\"45B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"975\" fill=\"black\" id=\"45W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"1055\" fill=\"black\" id=\"45B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 46).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"1195\" fill=\"black\" id=\"46W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"1305\" fill=\"black\" id=\"46B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"1195\" fill=\"black\" id=\"46W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"1305\" fill=\"black\" id=\"46B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 47).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"1415\" fill=\"black\" id=\"47W\">47</text>";
                SVG = SVG + "<text x=\"330\" y=\"1525\" fill=\"black\" id=\"47B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"1415\" fill=\"black\" id=\"47W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"1525\" fill=\"black\" id=\"47B\">" + contest.CompetitorBlue + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 48).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"330\" y=\"1635\" fill=\"black\" id=\"48W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"1745\" fill=\"black\" id=\"48B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"1635\" fill=\"black\" id=\"48W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"1745\" fill=\"black\" id=\"48B\">" + contest.CompetitorBlue + "</text>";
            }


            SVG = SVG + "<line x1=\"470\" y1=\"985\" x2=\"470\" y2=\"1095\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1205\" x2=\"470\" y2=\"1315\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1425\" x2=\"470\" y2=\"1535\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1645\" x2=\"470\" y2=\"1755\" stroke=\"black\" stroke-width=\"1\" />";


            //Repachage 4

            SVG = SVG + "<line x1=\"470\" y1=\"1040\" x2=\"620\" y2=\"1040\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1150\" x2=\"620\" y2=\"1150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1260\" x2=\"620\" y2=\"1260\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1370\" x2=\"620\" y2=\"1370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1480\" x2=\"620\" y2=\"1480\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1590\" x2=\"620\" y2=\"1590\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1700\" x2=\"620\" y2=\"1700\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"470\" y1=\"1810\" x2=\"620\" y2=\"1810\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"620\" y1=\"1040\" x2=\"620\" y2=\"1150\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"1260\" x2=\"620\" y2=\"1370\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"1480\" x2=\"620\" y2=\"1590\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"1700\" x2=\"620\" y2=\"1810\" stroke=\"black\" stroke-width=\"1\" />";


            contest = category.SheetData.Where(o => o.Contest == 49).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"1030\" fill=\"black\" id=\"49W\">49</text>";
                SVG = SVG + "<text x=\"480\" y=\"1140\" fill=\"black\" id=\"49W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"1030\" fill=\"black\" id=\"49W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"1140\" fill=\"black\" id=\"49W\">" + contest.CompetitorWhite + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 50).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"1250\" fill=\"black\" id=\"50W\"></text>";
                SVG = SVG + "<text x=\"480\" y=\"1360\" fill=\"black\" id=\"50W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"1250\" fill=\"black\" id=\"50W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"1360\" fill=\"black\" id=\"50W\">" + contest.CompetitorWhite + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 51).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"1470\" fill=\"black\" id=\"51W\">51</text>";
                SVG = SVG + "<text x=\"480\" y=\"1580\" fill=\"black\" id=\"51W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"1470\" fill=\"black\" id=\"51W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"1580\" fill=\"black\" id=\"51W\">" + contest.CompetitorWhite + "</text>";
            }
            contest = category.SheetData.Where(o => o.Contest == 52).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"480\" y=\"1690\" fill=\"black\" id=\"52W\"></text>";
                SVG = SVG + "<text x=\"480\" y=\"1800\" fill=\"black\" id=\"52W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"1690\" fill=\"black\" id=\"52W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"480\" y=\"1800\" fill=\"black\" id=\"52W\">" + contest.CompetitorWhite + "</text>";
            }


            //Repachage 5

            SVG = SVG + "<line x1=\"620\" y1=\"1095\" x2=\"770\" y2=\"1095\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"1315\" x2=\"770\" y2=\"1315\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"1535\" x2=\"770\" y2=\"1535\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"620\" y1=\"1755\" x2=\"770\" y2=\"1755\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"770\" y1=\"1095\" x2=\"770\" y2=\"1315\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"770\" y1=\"1535\" x2=\"770\" y2=\"1755\" stroke=\"black\" stroke-width=\"1\" />";

            contest = category.SheetData.Where(o => o.Contest == 55).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"630\" y=\"1085\" fill=\"black\" id=\"55W\">55</text>";
                SVG = SVG + "<text x=\"630\" y=\"1305\" fill=\"black\" id=\"55W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"630\" y=\"1085\" fill=\"black\" id=\"55W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"630\" y=\"1305\" fill=\"black\" id=\"55W\">" + contest.CompetitorWhite + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 56).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"630\" y=\"1525\" fill=\"black\" id=\"56W\">56</text>";
                SVG = SVG + "<text x=\"630\" y=\"1745\" fill=\"black\" id=\"55B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"630\" y=\"1525\" fill=\"black\" id=\"56W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"630\" y=\"1745\" fill=\"black\" id=\"56W\">" + contest.CompetitorWhite + "</text>";
            }


            //Repachage 6 (RF)

            SVG = SVG + "<line x1=\"770\" y1=\"1205\" x2=\"920\" y2=\"1205\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"770\" y1=\"1425\" x2=\"920\" y2=\"1425\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"770\" y1=\"1645\" x2=\"920\" y2=\"1645\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"770\" y1=\"1865\" x2=\"920\" y2=\"1865\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"920\" y1=\"1205\" x2=\"920\" y2=\"1425\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"920\" y1=\"1645\" x2=\"920\" y2=\"1865\" stroke=\"black\" stroke-width=\"1\" />";


            contest = category.SheetData.Where(o => o.Contest == 57).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"780\" y=\"1195\" fill=\"black\" id=\"57W\">57</text>";
                SVG = SVG + "<text x=\"780\" y=\"1415\" fill=\"black\" id=\"57W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"780\" y=\"1195\" fill=\"black\" id=\"57W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"780\" y=\"1415\" fill=\"black\" id=\"57W\">" + contest.CompetitorWhite + "</text>";
            }

            contest = category.SheetData.Where(o => o.Contest == 58).FirstOrDefault();
            if (contest == null)
            {
                SVG = SVG + "<text x=\"780\" y=\"1635\" fill=\"black\" id=\"58W\">58</text>";
                SVG = SVG + "<text x=\"780\" y=\"1855\" fill=\"black\" id=\"58B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"780\" y=\"1635\" fill=\"black\" id=\"58W\">" + contest.CompetitorWhite + "</text>";
                SVG = SVG + "<text x=\"780\" y=\"1855\" fill=\"black\" id=\"58B\">" + contest.CompetitorBlue + "</text>";
            }

            //TODO: Add 3rd places
            SVG = SVG + "<line x1=\"920\" y1=\"1315\" x2=\"1070\" y2=\"1315\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"920\" y1=\"1755\" x2=\"1070\" y2=\"1755\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "</svg>";

            _Image = SVG;
        }
    }
}
