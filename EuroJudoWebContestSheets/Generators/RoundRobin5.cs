using EuroJudoWebContestSheets.Extentions;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.DTO;
using System.Text;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin5 : GenerateSVG
    {
        private string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        public RoundRobin5(Category category)
        {
            bool hasFirstContest = category.TryGet(1, out ContestSheetData contest);
            RoundRobinSheetDataDto calculated = default;
            if (hasFirstContest)
            {
                calculated = contest.ToRoundRobinDto(category);
            }

            StringBuilder SVG = new StringBuilder();

            SVG.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            SVG.Append("<svg viewBox=\"0 0 1240 560\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\">");

            // Horizontal lines
            SVG.Append("<line x1=\"20\" y1=\"40\" x2=\"1220\" y2=\"40\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323\" />");
            SVG.Append("<line x1=\"20\" y1=\"120\" x2=\"1220\" y2=\"120\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6\" />");
            SVG.Append("<line x1=\"20\" y1=\"200\" x2=\"1220\" y2=\"200\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-8\" />");
            SVG.Append("<line x1=\"20\" y1=\"280\" x2=\"1220\" y2=\"280\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-8-0\" />");
            SVG.Append("<line x1=\"20\" y1=\"360\" x2=\"1220\" y2=\"360\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-8-0-4\" />");
            SVG.Append("<line x1=\"20\" y1=\"440\" x2=\"1220\" y2=\"440\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-8-0-4-5\" />");
            SVG.Append("<line x1=\"20\" y1=\"520\" x2=\"1220\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1.00844\" id=\"line323-6-8-0-4-5-7\" />");

            // Score seperators
            SVG.Append("<line x1=\"1070\" y1=\"80\" x2=\"1145\" y2=\"80\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-7\" />");
            SVG.Append("<line x1=\"1070\" y1=\"160\" x2=\"1145\" y2=\"160\" stroke=\"#000000\" stroke-width = \"1\" id = \"line323-6-7-6\" />");
            SVG.Append("<line x1=\"1070\" y1=\"240\" x2=\"1145\" y2=\"240\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-7-6-6\" />");
            SVG.Append("<line x1=\"1070\" y1=\"320\" x2=\"1145\" y2=\"320\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-7-6-6-6\" />");
            SVG.Append("<line x1=\"1070\" y1=\"400\" x2=\"1145\" y2=\"400\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-7-6-6-6-7\" />");
            SVG.Append("<line x1=\"1070\" y1=\"480\" x2=\"1145\" y2=\"480\" stroke=\"#000000\" stroke-width=\"1\" id=\"line323-6-7-6-6-6-7-5\" />");

            // Vertical lines
            SVG.Append("<line x1=\"20\" y1=\"40\" x2=\"20\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347\" />");
            SVG.Append("<line x1=\"420\" y1=\"40\" x2=\"420\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6\" />");
            SVG.Append("<line x1=\"485\" y1=\"40\" x2=\"485\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5\" />");
            SVG.Append("<line x1=\"550\" y1=\"40\" x2=\"550\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0\" />");
            SVG.Append("<line x1=\"615\" y1=\"40\" x2=\"615\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9\" />");
            SVG.Append("<line x1=\"680\" y1=\"40\" x2=\"680\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8\" />");
            SVG.Append("<line x1=\"745\" y1=\"40\" x2=\"745\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8-9\" />");
            SVG.Append("<line x1=\"810\" y1=\"40\" x2=\"810\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8-9-6\" />");
            SVG.Append("<line x1=\"875\" y1=\"40\" x2=\"875\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8-9-6-8\" />");
            SVG.Append("<line x1=\"940\" y1=\"40\" x2=\"940\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8-9-6-1\" />");
            SVG.Append("<line x1=\"1005\" y1=\"40\" x2=\"1005\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8-9-6-1-7-2\" />");
            SVG.Append("<line x1=\"1070\" y1=\"40\" x2=\"1070\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-6-5-0-9-8-9-6-1-7\" />");
            SVG.Append("<line x1=\"1145\" y1=\"40\" x2=\"1145\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3-1\" />");
            SVG.Append("<line x1=\"1220\" y1=\"40\" x2=\"1220\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1\" id=\"line347-3\" />");


            // Header text
            SVG.Append("<text x=\"447\" y=\"88\" fill=\"#000000\" id=\"text391-1\" style=\"font-size:18px;stroke-width:1\">1</text>");
            SVG.Append("<text x=\"512\" y=\"88\" fill=\"#000000\" id=\"text391\" style=\"font-size:18px;stroke-width:1\">2</text>");
            SVG.Append("<text x=\"577\" y=\"88\" fill=\"#000000\" id=\"text391-7\" style=\"font-size:18px;stroke-width:1\">3</text>");
            SVG.Append("<text x=\"642\" y=\"88\" fill=\"#000000\" id=\"text391-7-0\" style=\"font-size:18px;stroke-width:1\">4</text>");
            SVG.Append("<text x=\"708\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8\" style=\"font-size:18px;stroke-width:1\">5</text>");
            SVG.Append("<text x=\"772\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8-5\" style=\"font-size:18px;stroke-width:1\">6</text>");
            SVG.Append("<text x=\"837\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8-5-9\" style=\"font-size:18px;stroke-width:0.999997\">7</text>");
            SVG.Append("<text x=\"903\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3\" style=\"font-size:18px;stroke-width:0.999997\">8</text>");
            SVG.Append("<text x=\"967\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1\" style=\"font-size:18px;stroke-width:0.999997\">9</text>");
            SVG.Append("<text x=\"1026\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4\" style=\"font-size:18px;stroke-width:0.999997\">10</text>");
            SVG.Append("<text x=\"1082\" y=\"68\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4-1-9\" style=\"font-size:18px;stroke-width:1\">Winst</text>");
            SVG.Append("<text x=\"1078\" y=\"108\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4-1\" style=\"font-size:18px;stroke-width:1\">Punten</text>");
            SVG.Append("<text x=\"1164\" y=\"88\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4-1-7\" style=\"font-size:18px;stroke-width:1\">Res.</text>");

            // Blocks
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,480.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1679\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,400.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1718\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,320.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1757\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,160.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2073\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,240.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2112\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,480.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2588\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,400.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path2627\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,320.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path2666\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,240.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path2705\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,160.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path3341\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,160.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path3380\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,400.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path3856\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,480.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path3895\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,240.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path3934\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,320.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path3973\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,240.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path4369\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,400.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path4408\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,480.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path4447\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,160.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path4843\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,320.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path4882\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,480.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path4921\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,160.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path5557\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,240.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path5596\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,240.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path5635\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,320.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path5674\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,320.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path5713\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,400.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path5752\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,400.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path6148\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,480.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path6187\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,160.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path6226\" />");

            // Data

            if (hasFirstContest)
            {
                // Competitors
                SVG.Append("<text x=\"30\" y=\"160\" fill=\"black\" id=\"Competitor1\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");
                SVG.Append("<text x=\"30\" y=\"240\" fill=\"black\" id=\"Competitor2\" >");
                SVG.Append(contest.CompeditorBlue);
                SVG.Append("</text>");

                // Score
                SVG.Append("<text x=\"449\" y=\"160\" fill=\"black\" id=\"1W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"449\" y=\"240\" fill=\"black\" id=\"1B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                // Competitors
                SVG.Append("<text x=\"30\" y=\"160\" fill=\"black\" id=\"Competitor1\" />");
                SVG.Append("<text x=\"30\" y=\"240\" fill=\"black\" id=\"Competitor2\" />");

                // Score
                SVG.Append("<text x=\"449\" y=\"160\" fill=\"black\" id=\"1W\" />");
                SVG.Append("<text x=\"449\" y=\"240\" fill=\"black\" id=\"1B\" />");
            }

            if (category.TryGet(2, out contest))
            {
                SVG.Append("<text x=\"30\" y=\"320\" fill=\"black\" id=\"Competitor3\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");
                SVG.Append("<text x=\"30\" y=\"400\" fill=\"black\" id=\"Competitor4\" >");
                SVG.Append(contest.CompeditorBlue);
                SVG.Append("</text>");

                SVG.Append("<text x=\"514\" y=\"320\" fill=\"#000000\" id=\"2W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"514\" y=\"400\" fill=\"#000000\" id=\"2B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"30\" y=\"320\" fill=\"black\" id=\"Competitor3\" />");
                SVG.Append("<text x=\"30\" y=\"400\" fill=\"black\" id=\"Competitor4\" />");

                SVG.Append("<text x=\"514\" y=\"320\" fill=\"#000000\" id=\"2W\" />");
                SVG.Append("<text x=\"514\" y=\"400\" fill=\"#000000\" id=\"2B\" />");
            }

            if (category.TryGet(3, out contest))
            {
                SVG.Append("<text x=\"30\" y=\"480\" fill=\"black\" id=\"Competitor5\" >");
                SVG.Append(contest.CompeditorBlue);
                SVG.Append("</text>");

                SVG.Append("<text x=\"579\" y=\"160\" fill=\"black\" id=\"3W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"579\" y=\"480\" fill=\"#000000\" id=\"3B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"30\" y=\"480\" fill=\"black\" id=\"Competitor5\" />");

                SVG.Append("<text x=\"579\" y=\"160\" fill=\"black\" id=\"3W\" />");
                SVG.Append("<text x=\"579\" y=\"480\" fill=\"#000000\" id=\"3B\" />");
            }

            if (category.TryGet(4, out contest))
            {
                SVG.Append("<text x=\"644\" y=\"240\" fill=\"black\" id=\"4W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"644\" y=\"320\" fill=\"#000000\" id=\"4B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"644\" y=\"240\" fill=\"black\" id=\"4W\" />");
                SVG.Append("<text x=\"644\" y=\"320\" fill=\"#000000\" id=\"4B\" />");
            }

            if (category.TryGet(5, out contest))
            {
                SVG.Append("<text x=\"709\" y=\"400\" fill=\"black\" id=\"5W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"709\" y=\"480\" fill=\"#000000\" id=\"5B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"709\" y=\"400\" fill=\"black\" id=\"5W\" />");
                SVG.Append("<text x=\"709\" y=\"480\" fill=\"#000000\" id=\"5B\" />");
            }

            if (category.TryGet(6, out contest))
            {
                SVG.Append("<text x=\"774\" y=\"160\" fill=\"black\" id=\"6W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"774\" y=\"320\" fill=\"#000000\" id=\"6B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"774\" y=\"160\" fill=\"black\" id=\"6W\" />");
                SVG.Append("<text x=\"774\" y=\"320\" fill=\"#000000\" id=\"6B\" />");
            }

            if (category.TryGet(7, out contest))
            {
                SVG.Append("<text x=\"839\" y=\"240\" fill=\"black\" id=\"7W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"839\" y=\"400\" fill=\"#000000\" id=\"7B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"839\" y=\"240\" fill=\"black\" id=\"7W\" />");
                SVG.Append("<text x=\"839\" y=\"400\" fill=\"#000000\" id=\"7B\" />");
            }

            if (category.TryGet(8, out contest))
            {
                SVG.Append("<text x=\"904\" y=\"320\" fill=\"black\" id=\"8W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"904\" y=\"480\" fill=\"#000000\" id=\"8B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"904\" y=\"320\" fill=\"black\" id=\"8W\" />");
                SVG.Append("<text x=\"904\" y=\"480\" fill=\"#000000\" id=\"8B\" />");
            }

            if (category.TryGet(9, out contest))
            {
                SVG.Append("<text x=\"969\" y=\"160\" fill=\"black\" id=\"9W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"969\" y=\"400\" fill=\"#000000\" id=\"9B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"969\" y=\"160\" fill=\"black\" id=\"9W\" />");
                SVG.Append("<text x=\"969\" y=\"400\" fill=\"#000000\" id=\"9B\" />");
            }

            if (category.TryGet(10, out contest))
            {
                SVG.Append("<text x=\"1034\" y=\"240\" fill=\"black\" id=\"10W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"1034\" y=\"480\" fill=\"#000000\" id=\"10B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"1034\" y=\"240\" fill=\"black\" id=\"10W\" />");
                SVG.Append("<text x=\"1034\" y=\"480\" fill=\"#000000\" id=\"10B\" />");
            }

            // Additional data
            if (calculated != default && calculated.Competitors.Count >= 1)
            {
                SVG.Append("<text x=\"1099\" y=\"135\" fill=\"#000000\" id=\"WinComp1\" >");
                SVG.Append(calculated.Competitors[0].Won.ToString());
                SVG.Append("</text>");
                SVG.Append("<text x=\"1099\" y=\"175\" fill=\"#000000\" id=\"PuntComp1\" >");
                SVG.Append(calculated.Competitors[0].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[0].Position != 0)
                {
                    SVG.Append("<text x=\"1180\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" >");
                    SVG.Append(calculated.Competitors[0].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append("<text x=\"1180\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" />");
                }
            }
            else
            {
                SVG.Append("<text x=\"1099\" y=\"135\" fill=\"#000000\" id=\"WinComp1\" />");
                SVG.Append("<text x=\"1099\" y=\"175\" fill=\"#000000\" id=\"PuntComp1\" />");
                SVG.Append("<text x=\"1180\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 2)
            {
                SVG.Append("<text x=\"1099\" y=\"215\" fill=\"#000000\" id=\"WinComp2\" >");
                SVG.Append(calculated.Competitors[1].Won.ToString());
                SVG.Append("</text>");
                SVG.Append("<text x=\"1099\" y=\"255\" fill=\"#000000\" id=\"PuntComp2\" >");
                SVG.Append(calculated.Competitors[1].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[1].Position != 0)
                {
                    SVG.Append("<text x=\"1180\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" >");
                    SVG.Append(calculated.Competitors[1].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append("<text x=\"1180\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" />");
                }
            }
            else
            {
                SVG.Append("<text x=\"1099\" y=\"215\" fill=\"#000000\" id=\"WinComp2\" />");
                SVG.Append("<text x=\"1099\" y=\"255\" fill=\"#000000\" id=\"PuntComp2\" />");
                SVG.Append("<text x=\"1180\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 3)
            {
                SVG.Append("<text x=\"1099\" y=\"295\" fill=\"#000000\" id=\"WinComp3\" >");
                SVG.Append(calculated.Competitors[2].Won.ToString());
                SVG.Append("</text>");
                SVG.Append("<text x=\"1099\" y=\"335\" fill=\"#000000\" id=\"PuntComp3\" >");
                SVG.Append(calculated.Competitors[2].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[1].Position != 0)
                {
                    SVG.Append("<text x=\"1180\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" >");
                    SVG.Append(calculated.Competitors[2].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append("<text x=\"1180\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" />");
                }
            }
            else
            {
                SVG.Append("<text x=\"1099\" y=\"295\" fill=\"#000000\" id=\"WinComp3\" />");
                SVG.Append("<text x=\"1099\" y=\"335\" fill=\"#000000\" id=\"PuntComp3\" />");
                SVG.Append("<text x=\"1180\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 4)
            {
                SVG.Append("<text x=\"1099\" y=\"375\" fill=\"#000000\" id=\"WinComp4\" >");
                SVG.Append(calculated.Competitors[3].Won.ToString());
                SVG.Append("</text>");
                SVG.Append("<text x=\"1099\" y=\"415\" fill=\"#000000\" id=\"PuntComp4\" >");
                SVG.Append(calculated.Competitors[3].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[1].Position != 0)
                {
                    SVG.Append("<text x=\"1180\" y=\"400\" fill=\"#000000\" id=\"ResComp4\" >");
                    SVG.Append(calculated.Competitors[3].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append("<text x=\"1180\" y=\"400\" fill=\"#000000\" id=\"ResComp4\" />");
                }
            }
            else
            {
                SVG.Append("<text x=\"1099\" y=\"375\" fill=\"#000000\" id=\"WinComp4\" />");
                SVG.Append("<text x=\"1099\" y=\"415\" fill=\"#000000\" id=\"PuntComp4\" />");
                SVG.Append("<text x=\"1180\" y=\"400\" fill=\"#000000\" id=\"ResComp4\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 5)
            {
                SVG.Append("<text x=\"1099\" y=\"455\" fill=\"#000000\" id=\"WinComp5\" >");
                SVG.Append(calculated.Competitors[4].Won.ToString());
                SVG.Append("</text>");
                SVG.Append("<text x=\"1099\" y=\"495\" fill=\"#000000\" id=\"PuntComp5\" >");
                SVG.Append(calculated.Competitors[4].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[1].Position != 0)
                {
                    SVG.Append("<text x=\"1180\" y=\"480\" fill=\"#000000\" id=\"ResComp5\" >");
                    SVG.Append(calculated.Competitors[4].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append("<text x=\"1180\" y=\"480\" fill=\"#000000\" id=\"ResComp5\" />");
                }
            }
            else
            {
                SVG.Append("<text x=\"1099\" y=\"455\" fill=\"#000000\" id=\"WinComp5\" />");
                SVG.Append("<text x=\"1099\" y=\"495\" fill=\"#000000\" id=\"PuntComp5\" />");
                SVG.Append("<text x=\"1180\" y=\"480\" fill=\"#000000\" id=\"ResComp5\" />");
            }

            SVG.Append("</svg>");

            _Image = SVG.ToString();
        }
    }
}