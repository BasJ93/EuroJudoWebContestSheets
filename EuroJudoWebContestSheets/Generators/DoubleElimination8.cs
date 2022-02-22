using EuroJudoWebContestSheets.Models;
using System.Linq;

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
            SVG = SVG + "<svg viewBox=\"140 50 1100 900\" xmlns=\"http://www.w3.org/2000/svg\" version=\"1.1\">";

            //Draw the left of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"170\" y1=\"75\" x2=\"320\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"185\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"295\" x2=\"320\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"405\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";
            
            if (category.TryGet(1, out ContestSheetData contest))
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"1W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"1B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"65\" fill=\"black\" id=\"1W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"175\" fill=\"black\" id=\"1B\">" + contest.CompeditorBlue + "</text>";
            }

            if (category.TryGet(2, out contest))
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"2W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"2B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"285\" fill=\"black\" id=\"2W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"395\" fill=\"black\" id=\"2B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"320\" y1=\"75\" x2=\"320\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"295\" x2=\"320\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"130\" x2=\"470\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"350\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            if (category.TryGet(5, out contest))
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"5W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"5B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"120\" fill=\"black\" id=\"5W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"340\" fill=\"black\" id=\"5B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"470\" y1=\"130\" x2=\"470\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"470\" y1=\"240\" x2=\"620\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";

            if (category.TryGet(11, out contest))
            {
                SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"11W\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"480\" y=\"230\" fill=\"black\" id=\"11W\">" + contest.CompeditorWhite + "</text>";
            }

            //Draw the right of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"1090\" y1=\"75\" x2=\"940\" y2=\"75\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"185\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"295\" x2=\"940\" y2=\"295\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"405\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            if (category.TryGet(3, out contest))
            {
                SVG = SVG + "<text x=\"950\" y=\"65\" fill=\"black\" id=\"3W\"></text>";
                SVG = SVG + "<text x=\"950\" y=\"175\" fill=\"black\" id=\"3B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"950\" y=\"65\" fill=\"black\" id=\"3W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"950\" y=\"175\" fill=\"black\" id=\"3B\">" + contest.CompeditorBlue + "</text>";
            }            

            if (category.TryGet(4, out contest))
            {
                SVG = SVG + "<text x=\"950\" y=\"285\" fill=\"black\" id=\"4W\"></text>";
                SVG = SVG + "<text x=\"950\" y=\"395\" fill=\"black\" id=\"4B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"950\" y=\"285\" fill=\"black\" id=\"4W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"950\" y=\"395\" fill=\"black\" id=\"4B\">" + contest.CompeditorBlue + "</text>";
            }
            

            SVG = SVG + "<line x1=\"940\" y1=\"75\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"295\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"130\" x2=\"790\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"350\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            if (category.TryGet(6, out contest))
            {
                SVG = SVG + "<text x=\"800\" y=\"120\" fill=\"black\" id=\"6W\"></text>";
                SVG = SVG + "<text x=\"800\" y=\"340\" fill=\"black\" id=\"6B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"800\" y=\"120\" fill=\"black\" id=\"6W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"800\" y=\"340\" fill=\"black\" id=\"6B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"790\" y1=\"130\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"640\" y1=\"240\" x2=\"790\" y2=\"240\" stroke=\"black\" stroke-width=\"1\" />";


            if (category.TryGet(11, out contest))
            {
                SVG = SVG + "<text x=\"650\" y=\"230\" fill=\"black\" id=\"11B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"650\" y=\"230\" fill=\"black\" id=\"11B\">" + contest.CompeditorBlue + "</text>";
            }
            
            SVG = SVG + "<text x=\"155\" y=\"80\" fill=\"black\">1</text>";
            SVG = SVG + "<text x=\"155\" y=\"190\" fill=\"black\">2</text>";
            SVG = SVG + "<text x=\"155\" y=\"300\" fill=\"black\">3</text>";
            SVG = SVG + "<text x=\"155\" y=\"410\" fill=\"black\">4</text>";
            SVG = SVG + "<text x=\"1092\" y=\"80\" fill=\"black\">5</text>";
            SVG = SVG + "<text x=\"1092\" y=\"190\" fill=\"black\">6</text>";
            SVG = SVG + "<text x=\"1092\" y=\"300\" fill=\"black\">7</text>";
            SVG = SVG + "<text x=\"1092\" y=\"410\" fill=\"black\">8</text>";


            SVG = SVG + "<line x1=\"940\" y1=\"75\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"295\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"130\" x2=\"790\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"350\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";




            //Repachage

            SVG = SVG + "<line x1=\"170\" y1=\"505\" x2=\"320\" y2=\"505\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"170\" y1=\"615\" x2=\"320\" y2=\"615\" stroke=\"black\" stroke-width=\"1\" />";
            
            if (category.TryGet(7, out contest))
            {
                SVG = SVG + "<text x=\"180\" y=\"495\" fill=\"black\" id=\"7W\"></text>";
                SVG = SVG + "<text x=\"180\" y=\"605\" fill=\"black\" id=\"7B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"180\" y=\"495\" fill=\"black\" id=\"7W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"180\" y=\"605\" fill=\"black\" id=\"7B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"320\" y1=\"505\" x2=\"320\" y2=\"615\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"320\" y1=\"560\" x2=\"470\" y2=\"560\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"320\" y1=\"670\" x2=\"470\" y2=\"670\" stroke=\"black\" stroke-width=\"1\" />";

            if (category.TryGet(9, out contest))
            {
                SVG = SVG + "<text x=\"330\" y=\"550\" fill=\"black\" id=\"9W\"></text>";
                SVG = SVG + "<text x=\"330\" y=\"660\" fill=\"black\" id=\"9B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"330\" y=\"550\" fill=\"black\" id=\"9W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"330\" y=\"660\" fill=\"black\" id=\"9B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"470\" y1=\"560\" x2=\"470\" y2=\"670\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"470\" y1=\"615\" x2=\"620\" y2=\"615\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<text x=\"480\" y=\"605\" fill=\"black\" id=\"repachageA\"></text>";

            //Draw the right of the 8 person sheet, main bracket
            SVG = SVG + "<line x1=\"1090\" y1=\"505\" x2=\"940\" y2=\"505\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"1090\" y1=\"615\" x2=\"940\" y2=\"615\" stroke=\"black\" stroke-width=\"1\" />";
            
            if (category.TryGet(8, out contest))
            {
                SVG = SVG + "<text x=\"950\" y=\"495\" fill=\"black\" id=\"8W\"></text>";
                SVG = SVG + "<text x=\"950\" y=\"605\" fill=\"black\" id=\"8B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"950\" y=\"495\" fill=\"black\" id=\"8W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"950\" y=\"605\" fill=\"black\" id=\"8B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"940\" y1=\"505\" x2=\"940\" y2=\"615\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"560\" x2=\"790\" y2=\"560\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"670\" x2=\"790\" y2=\"670\" stroke=\"black\" stroke-width=\"1\" />";

            if (category.TryGet(10, out contest))
            {
                SVG = SVG + "<text x=\"800\" y=\"550\" fill=\"black\" id=\"10W\"></text>";
                SVG = SVG + "<text x=\"800\" y=\"660\" fill=\"black\" id=\"10B\"></text>";
            }
            else
            {
                SVG = SVG + "<text x=\"800\" y=\"550\" fill=\"black\" id=\"10W\">" + contest.CompeditorWhite + "</text>";
                SVG = SVG + "<text x=\"800\" y=\"660\" fill=\"black\" id=\"10B\">" + contest.CompeditorBlue + "</text>";
            }

            SVG = SVG + "<line x1=\"790\" y1=\"560\" x2=\"790\" y2=\"670\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"640\" y1=\"615\" x2=\"790\" y2=\"615\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<text x=\"650\" y=\"605\" fill=\"black\" id=\"repachageB\"></text>";

            SVG = SVG + "<text x=\"148\" y=\"510\" fill=\"black\">R1</text>";
            SVG = SVG + "<text x=\"148\" y=\"620\" fill=\"black\">R2</text>";
            SVG = SVG + "<text x=\"1098\" y=\"510\" fill=\"black\">R3</text>";
            SVG = SVG + "<text x=\"1098\" y=\"620\" fill=\"black\">R4</text>";


            SVG = SVG + "<line x1=\"940\" y1=\"75\" x2=\"940\" y2=\"185\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"295\" x2=\"940\" y2=\"405\" stroke=\"black\" stroke-width=\"1\" />";

            SVG = SVG + "<line x1=\"940\" y1=\"130\" x2=\"790\" y2=\"130\" stroke=\"black\" stroke-width=\"1\" />";
            SVG = SVG + "<line x1=\"940\" y1=\"350\" x2=\"790\" y2=\"350\" stroke=\"black\" stroke-width=\"1\" />";

            //Add 3rd places

            SVG = SVG + "</svg>";

            _Image = SVG;
        }
    }
}
