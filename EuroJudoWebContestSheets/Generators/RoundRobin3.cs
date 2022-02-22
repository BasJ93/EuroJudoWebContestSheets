using EuroJudoWebContestSheets.Extentions;
using EuroJudoWebContestSheets.Models;
using System;
using System.Linq;
using System.Text;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin3 : GenerateSVG
    {
        private string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        public RoundRobin3(Category category)
        {
            StringBuilder SVG = new StringBuilder();

            SVG.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            SVG.Append("<svg viewBox=\"0 0 800 400\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\">");

            SVG.Append("<line x1=\"20\" y1=\"40.3932\" x2=\"765\" y2=\"40.3932\" stroke=\"#000000\" stroke-width=\"0.794816\" id=\"line323\" />");
            SVG.Append("<line x1=\"20\" y1=\"120.44505\" x2=\"765\" y2=\"120.44505\" stroke=\"#000000\" stroke-width=\"0.794816\" id=\"line323-6\" />");
            SVG.Append("<line x1=\"615\" y1=\"80.117348\" x2=\"690\" y2=\"80.117348\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"line323-6-7\" />");
            SVG.Append("<line x1=\"615\" y1=\"160.12605\" x2=\"690\" y2=\"160.12605\" stroke=\"#000000\" stroke-width = \"0.25211\" id = \"line323-6-7-6\" />");
            SVG.Append("<line x1=\"615\" y1=\"240.12605\" x2=\"690\" y2=\"240.12605\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"line323-6-7-6-6\" />");
            SVG.Append("<line x1=\"615\" y1=\"320.12607\" x2=\"690\" y2=\"320.12607\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"line323-6-7-6-6-6\" />");
            SVG.Append("<line x1=\"20\" y1=\"200.48842\" x2=\"765\" y2=\"200.48842\" stroke=\"#000000\" stroke-width=\"0.794816\" id=\"line323-6-8\" />");
            SVG.Append("<line x1=\"20\" y1=\"280.53601\" x2=\"765\" y2=\"280.53601\" stroke=\"#000000\" stroke-width=\"0.794816\" id=\"line323-6-8-0\" />");
            SVG.Append("<line x1=\"20\" y1=\"360.58368\" x2=\"765\" y2=\"360.58368\" stroke=\"#000000\" stroke-width=\"0.794816\" id=\"line323-6-8-0-4\" />");


            SVG.Append("<line x1=\"19.751778\" y1=\"40\" x2=\"19.751778\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.894476\" id=\"line347\" />");
            SVG.Append("<line x1=\"420.44449\" y1=\"40\" x2=\"420.44449\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.89452\" id=\"line347-3-6\" />");
            SVG.Append("<line x1=\"485.50726\" y1=\"40\" x2=\"485.50726\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.894528\" id=\"line347-3-6-5\" />");
            SVG.Append("<line x1=\"550.52234\" y1=\"40\" x2=\"550.52234\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.894528\" id=\"line347-3-6-5-0\" />");
            SVG.Append("<line x1=\"615.53735\" y1=\"40\" x2=\"615.53735\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.894528\" id=\"line347-3-6-5-0-9\" />");
            SVG.Append("<line x1=\"690.44727\" y1=\"40\" x2=\"690.44727\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.894528\" id=\"line347-3-6-5-0-9-8\" />");
            SVG.Append("<line x1=\"765.44727\" y1=\"40\" x2=\"765.44727\" y2=\"360\" stroke=\"#000000\" stroke-width=\"0.894528\" id=\"line347-3-6-5-0-9-8-9\" />");

            // Header text
            SVG.Append("<text x=\"447.58496\" y=\"88.359375\" fill=\"#000000\" id=\"text391-1\" style=\"font-size:18px;stroke-width:0.999997\">1</text>");
            SVG.Append("<text x=\"512.58496\" y=\"88.906166\" fill=\"#000000\" id=\"text391\" style=\"font-size:18px;stroke-width:0.999997\">2</text>");
            SVG.Append("<text x=\"577.58496\" y=\"88.359375\" fill=\"#000000\" id=\"text391-7\" style=\"font-size:18px;stroke-width:0.999997\">3</text>");
            SVG.Append("<text x=\"627.19141\" y=\"68.174805\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4-1-9\" style=\"font-size:18px;stroke-width:0.999997\">Winst</text>");
            SVG.Append("<text x=\"622.24219\" y=\"108.08691\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4-1\" style=\"font-size:18px;stroke-width:0.999997\">Punten</text>");
            SVG.Append("<text x=\"710.95361\" y=\"88.086914\" fill=\"#000000\" id=\"text391-7-0-8-5-9-3-1-4-1-7\" style=\"font-size:18px;stroke-width:0.999997\">Res.</text>");

            // Blocks
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,320.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1757\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,240.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2112\" />");
            SVG.Append("<path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,160.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path5329\" />");

            // Data

            if (category.TryGet(1, out ContestSheetData contest))
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
                SVG.Append(contest.CompeditorBlue);
                SVG.Append("</text>");

                SVG.Append("<text x=\"514\" y=\"160\" fill=\"#000000\" id=\"2W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"514\" y=\"320\" fill=\"#000000\" id=\"2B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"30\" y=\"320\" fill=\"black\" id=\"Competitor3\" />");

                SVG.Append("<text x=\"514\" y=\"160\" fill=\"#000000\" id=\"2W\" />");
                SVG.Append("<text x=\"514\" y=\"320\" fill=\"#000000\" id=\"2B\" />");
            }

            if (category.TryGet(3, out contest))
            {
                SVG.Append("<text x=\"579\" y=\"240\" fill=\"black\" id=\"3W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append("<text x=\"579\" y=\"320\" fill=\"#000000\" id=\"3B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"579\" y=\"240\" fill=\"black\" id=\"3W\" />");
                SVG.Append("<text x=\"579\" y=\"320\" fill=\"#000000\" id=\"3B\" />");
            }

            // Additional data
            var competitor1 = CalculateResult(category, 1);
            var competitor2 = CalculateResult(category, 2);
            var competitor3 = CalculateResult(category, 3);

            if (competitor1 != default)
            {
                SVG.Append("<text x=\"650\" y=\"135\" fill=\"#000000\" id=\"WinComp1\" >");
                SVG.Append(competitor1.Won);
                SVG.Append("</text>");
                SVG.Append("<text x=\"650\" y=\"175\" fill=\"#000000\" id=\"PuntComp1\" >");
                SVG.Append(competitor1.Points);
                SVG.Append("</text>");
                SVG.Append("<text x=\"725\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" >");
                SVG.Append(competitor1.Position);
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"650\" y=\"135\" fill=\"#000000\" id=\"WinComp1\" />");
                SVG.Append("<text x=\"650\" y=\"175\" fill=\"#000000\" id=\"PuntComp1\" />");
                SVG.Append("<text x=\"725\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" />");
            }

            if (competitor2 != default)
            {
                SVG.Append("<text x=\"650\" y=\"215\" fill=\"#000000\" id=\"WinComp2\" >");
                SVG.Append(competitor2.Won);
                SVG.Append("</text>");
                SVG.Append("<text x=\"650\" y=\"255\" fill=\"#000000\" id=\"PuntComp2\" >");
                SVG.Append(competitor2.Points);
                SVG.Append("</text>");
                SVG.Append("<text x=\"725\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" >");
                SVG.Append(competitor2.Position);
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"650\" y=\"215\" fill=\"#000000\" id=\"WinComp2\" />");
                SVG.Append("<text x=\"650\" y=\"255\" fill=\"#000000\" id=\"PuntComp2\" />");
                SVG.Append("<text x=\"725\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" />");
            }

            if (competitor3 != default)
            {
                SVG.Append("<text x=\"650\" y=\"295\" fill=\"#000000\" id=\"WinComp3\" >");
                SVG.Append(competitor3.Won);
                SVG.Append("</text>");
                SVG.Append("<text x=\"650\" y=\"335\" fill=\"#000000\" id=\"PuntComp3\" >");
                SVG.Append(competitor3.Points);
                SVG.Append("</text>");
                SVG.Append("<text x=\"725\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" >");
                SVG.Append(competitor3.Position);
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append("<text x=\"650\" y=\"295\" fill=\"#000000\" id=\"WinComp3\" />");
                SVG.Append("<text x=\"650\" y=\"335\" fill=\"#000000\" id=\"PuntComp3\" />");
                SVG.Append("<text x=\"725\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" />");
            }
            SVG.Append("</svg>");

            _Image = SVG.ToString();
        }

        private EventResult CalculateResult(Category category, int competitor)
        {
            switch (competitor)
            {
                case 1:
                    var contests = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 2);
                    return new EventResult
                    {
                        Won = contests.Select(c => c.WhiteWon()).Count().ToString(),
                        Points = contests.Select(c => c.ScoreWhite()).Sum().ToString(),
                    };
                case 2:
                    var asWhite = category.SheetData.Where(s => s.Contest == 3).FirstOrDefault();
                    var asBlue = category.SheetData.Where(s => s.Contest == 2).FirstOrDefault();
                    int won = 0;
                    int score = 0;
                    if (asWhite != default)
                    {
                        won += asWhite.WhiteWon() ? 1 : 0;
                        score += asWhite.ScoreWhite();
                    }
                    if (asBlue != default)
                    {
                        won += asBlue.WhiteWon() ? 0 : 1;
                        score += asBlue.ScoreBlue();
                    }
                                        
                    return new EventResult
                    {
                        Won = won.ToString(),
                        Points = score.ToString(),
                    };
                case 3:
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 3);
                    return new EventResult
                    {
                        Won = contests.Select(c => c.WhiteWon() == false).Count().ToString(),
                        Points = contests.Select(c => c.ScoreBlue()).Sum().ToString(),
                    };
                default:
                    return default;
            }
        }
    }
}