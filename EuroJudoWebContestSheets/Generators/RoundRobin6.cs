using EuroJudoWebContestSheets.Extentions;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.DTO;
using System.Text;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobin6 : GenerateSVG
    {
        private string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        public RoundRobin6(Category category)
        {
            bool hasFirstContest = category.TryGet(1, out ContestSheetData contest);
            RoundRobinSheetDataDto calculated = default;
            if (hasFirstContest)
            {
                calculated = contest.ToRoundRobinDto(category);
            }

            StringBuilder SVG = new StringBuilder();

            SVG.Append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            SVG.Append(" <svg viewBox=\"0 0 1565 620\" version=\"1.1\"  xmlns=\"http://www.w3.org/2000/svg\">");

            SVG.Append(" <line x1=\"20\" y1=\"40\" x2=\"1545\" y2=\"40\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline1\" />");
            SVG.Append(" <line x1=\"20\" y1=\"120\" x2=\"1545\" y2=\"120\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline2\" />");
            SVG.Append(" <line x1=\"20\" y1=\"200\" x2=\"1545\" y2=\"200\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline3\" />");
            SVG.Append(" <line x1=\"20\" y1=\"280\" x2=\"1545\" y2=\"280\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline4\" />");
            SVG.Append(" <line x1=\"20\" y1=\"360\" x2=\"1545\" y2=\"360\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline5\" />");
            SVG.Append(" <line x1=\"20\" y1=\"440\" x2=\"1545\" y2=\"440\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline6\" />");
            SVG.Append(" <line x1=\"20\" y1=\"520\" x2=\"1545\" y2=\"520\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline7\" />");
            SVG.Append(" <line x1=\"20\" y1=\"600\" x2=\"1545\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1.1367\" id=\"hline8\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"80\" x2=\"1470\" y2=\"80\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline1.5\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"160\" x2=\"1470\" y2=\"160\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline2.5\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"240\" x2=\"1470\" y2=\"240\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline3.5\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"320\" x2=\"1470\" y2=\"320\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline4.5\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"400\" x2=\"1470\" y2=\"400\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline5.5\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"480\" x2=\"1470\" y2=\"480\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline6.5\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"560\" x2=\"1470\" y2=\"560\" stroke=\"#000000\" stroke-width=\"0.25211\" id=\"hline7.5\" />");

            SVG.Append(" <line x1=\"20\" y1=\"40\" x2=\"20\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline1\" />");
            SVG.Append(" <line x1=\"420\" y1=\"40\" x2=\"420\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline2\" />");
            SVG.Append(" <line x1=\"485\" y1=\"40\" x2=\"485\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline3\" />");
            SVG.Append(" <line x1=\"550\" y1=\"40\" x2=\"550\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline4\" />");
            SVG.Append(" <line x1=\"615\" y1=\"40\" x2=\"615\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline5\" />");
            SVG.Append(" <line x1=\"680\" y1=\"40\" x2=\"680\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline6\" />");
            SVG.Append(" <line x1=\"745\" y1=\"40\" x2=\"745\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline7\" />");
            SVG.Append(" <line x1=\"810\" y1=\"40\" x2=\"810\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline8\" />");
            SVG.Append(" <line x1=\"875\" y1=\"40\" x2=\"875\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline9\" />");
            SVG.Append(" <line x1=\"940\" y1=\"40\" x2=\"940\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline10\" />");
            SVG.Append(" <line x1=\"1005\" y1=\"40\" x2=\"1005\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"line9571\" />");
            SVG.Append(" <line x1=\"1070\" y1=\"40\" x2=\"1070\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline11\" />");
            SVG.Append(" <line x1=\"1135\" y1=\"40\" x2=\"1135\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline12\" />");
            SVG.Append(" <line x1=\"1200\" y1=\"40\" x2=\"1200\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline13\" />");
            SVG.Append(" <line x1=\"1265\" y1=\"40\" x2=\"1265\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline14\" />");
            SVG.Append(" <line x1=\"1330\" y1=\"40\" x2=\"1330\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline15\" />");
            SVG.Append(" <line x1=\"1395\" y1=\"40\" x2=\"1395\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline16\" />");
            SVG.Append(" <line x1=\"1470\" y1=\"40\" x2=\"1470\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline17\" />");
            SVG.Append(" <line x1=\"1545\" y1=\"40\" x2=\"1545\" y2=\"600\" stroke=\"#000000\" stroke-width=\"1\" id=\"vline18\" />");

            // Header tekst
            SVG.Append(" <text x=\"448\" y=\"88\" fill=\"#000000\" id=\"match1\" style=\"font-size:18px;stroke-width:1\">1</text>");
            SVG.Append(" <text x=\"512\" y=\"88\" fill=\"#000000\" id=\"match2\" style=\"font-size:18px;stroke-width:1\">2</text>");
            SVG.Append(" <text x=\"578\" y=\"88\" fill=\"#000000\" id=\"match3\" style=\"font-size:18px;stroke-width:1\">3</text>");
            SVG.Append(" <text x=\"642\" y=\"88\" fill=\"#000000\" id=\"match4\" style=\"font-size:18px;stroke-width:1\">4</text>");
            SVG.Append(" <text x=\"718\" y=\"88\" fill=\"#000000\" id=\"match5\" style=\"font-size:18px;stroke-width:1\">5</text>");
            SVG.Append(" <text x=\"772\" y=\"88\" fill=\"#000000\" id=\"match6\" style=\"font-size:18px;stroke-width:1\">6</text>");
            SVG.Append(" <text x=\"836\" y=\"88\" fill=\"#000000\" id=\"match7\" style=\"font-size:18px;stroke-width:1\">7</text>");
            SVG.Append(" <text x=\"902\" y=\"88\" fill=\"#000000\" id=\"match8\" style=\"font-size:18px;stroke-width:1\">8</text>");
            SVG.Append(" <text x=\"966\" y=\"88\" fill=\"#000000\" id=\"match9\" style=\"font-size:18px;stroke-width:1\">9</text>");
            SVG.Append(" <text x=\"1026\" y=\"88\" fill=\"#000000\" id=\"match10\" style=\"font-size:18px;stroke-width:1\">10</text>");
            SVG.Append(" <text x=\"1091\" y=\"88\" fill=\"#000000\" id=\"match11\" style=\"font-size:18px;stroke-width:1\">11</text>");
            SVG.Append(" <text x=\"1156\" y=\"88\" fill=\"#000000\" id=\"match12\" style=\"font-size:18px;stroke-width:1\">12</text>");
            SVG.Append(" <text x=\"1221\" y=\"88\" fill=\"#000000\" id=\"match13\" style=\"font-size:18px;stroke-width:1\">13</text>");
            SVG.Append(" <text x=\"1286\" y=\"88\" fill=\"#000000\" id=\"match14\" style=\"font-size:18px;stroke-width:1\">14</text>");
            SVG.Append(" <text x=\"1351\" y=\"88\" fill=\"#000000\" id=\"match15\" style=\"font-size:18px;stroke-width:1\">15</text>");
            SVG.Append(" <text x=\"1407\" y=\"68\" fill=\"#000000\" id=\"gewonnenpartijen\" style=\"font-size:18px;stroke-width:1\">Winst</text>");
            SVG.Append(" <text x=\"1403\" y=\"108\" fill=\"#000000\" id=\"totaalpunten\" style=\"font-size:18px;stroke-width:1\">Punten</text>");
            SVG.Append(" <text x=\"1488\" y=\"88\" fill=\"#000000\" id=\"resultaat\" style=\"font-size:18px;stroke-width:1\">Res.</text>");

            // Blocks
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,480.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1679\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,400.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1718\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,320.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path1757\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,160.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2073\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,240.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2112\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,480.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path2588\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,400.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path2627\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,320.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path2666\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,240.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path2705\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,160.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path3380\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,400.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path3856\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,480.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path3895\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,240.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path3934\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,320.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path3973\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,400.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path4408\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,480.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path4447\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,320.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path4882\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,480.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path4921\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,160.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path5557\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,240.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path5635\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,320.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path5713\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,400.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path5752\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,400.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path6148\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,480.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path6187\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 421.5,560.5 v -39 h 31.5 31.5 v 39 39 H 453 421.5 Z\" id=\"path7398\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 551.5,160.5 v -39 h 31.5 31.5 v 39 39 H 583 551.5 Z\" id=\"path7437\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 486.5,560.5 v -39 h 31.5 31.5 v 39 39 H 518 486.5 Z\" id=\"path7515\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,240.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path7554\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 616.5,560.5 v -39 h 31.5 31.5 v 39 39 H 648 616.5 Z\" id=\"path7593\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 681.5,560.5 v -39 h 31.5 31.5 v 39 39 H 713 681.5 Z\" id=\"path7632\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,320.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path7671\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 746.5,160.5 v -39 h 31.5 31.5 v 39 39 H 778 746.5 Z\" id=\"path7710\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,240.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path7749\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 811.5,560.5 v -39 h 31.5 31.5 v 39 39 H 843 811.5 Z\" id=\"path7788\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,560.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path7827\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 876.5,320.5 v -39 h 31.5 31.5 v 39 39 H 908 876.5 Z\" id=\"path7866\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,160.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path7905\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 941.5,400.5 v -39 h 31.5 31.5 v 39 39 H 973 941.5 Z\" id=\"path7944\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,240.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path7983\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1006.5,560.5 v -39 h 31.5 31.5 v 39 39 h -31.5 -31.5 z\" id=\"path8022\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1071.5,480.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8061\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1071.5,320.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8100\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1071.5,240.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8139\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1071.5,160.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8178\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1136.5,160.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8217\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1136.5,400.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8256\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1136.5,480.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8295\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1136.5,560.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8334\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1201.5,240.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8373\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1201.5,320.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8412\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1201.5,400.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8451\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1201.5,480.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8490\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1266.5,160.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8529\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1266.5,320.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8568\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1266.5,560.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8646\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1266.5,480.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8685\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1331.5,160.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8724\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1331.5,240.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8763\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1331.5,400.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8802\" />");
            SVG.Append(" <path style=\"fill:#a0a0a0;stroke:none\" d=\"m 1331.5,560.5 v -39 h 31 31 v 39 39 h -31 -31 z\" id=\"path8841\" />");

            // data
            if (hasFirstContest)
            {
                SVG.Append(" <text x=\"30\" y=\"160\" fill=\"black\" id=\"Competitor1\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");
                SVG.Append(" <text x=\"30\" y=\"240\" fill=\"black\" id=\"Competitor2\" >");
                SVG.Append(contest.CompeditorBlue);
                SVG.Append("</text>");

                SVG.Append(" <text x=\"449\" y=\"160\" fill=\"black\" id=\"1W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"449\" y=\"240\" fill=\"black\" id=\"1B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"30\" y=\"160\" fill=\"black\" id=\"Competitor1\" />");
                SVG.Append(" <text x=\"30\" y=\"240\" fill=\"black\" id=\"Competitor2\" />");

                SVG.Append(" <text x=\"449\" y=\"160\" fill=\"black\" id=\"1W\" />");
                SVG.Append(" <text x=\"449\" y=\"240\" fill=\"black\" id=\"1B\" />");
            }

            if (category.TryGet(2, out contest))
            {
                SVG.Append(" <text x=\"30\" y=\"320\" fill=\"black\" id=\"Competitor3\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");
                SVG.Append(" <text x=\"30\" y=\"400\" fill=\"black\" id=\"Competitor4\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");

                SVG.Append(" <text x=\"514\" y=\"320\" fill=\"#000000\" id=\"2W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"514\" y=\"400\" fill=\"#000000\" id=\"2B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"30\" y=\"320\" fill=\"black\" id=\"Competitor3\" />");
                SVG.Append(" <text x=\"30\" y=\"400\" fill=\"black\" id=\"Competitor4\" />");

                SVG.Append(" <text x=\"514\" y=\"320\" fill=\"#000000\" id=\"2W\" />");
                SVG.Append(" <text x=\"514\" y=\"400\" fill=\"#000000\" id=\"2B\" />");
            }

            if (category.TryGet(3, out contest))
            {
                SVG.Append(" <text x=\"30\" y=\"480\" fill=\"black\" id=\"Competitor5\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");
                SVG.Append(" <text x=\"30\" y=\"560\" fill=\"black\" id=\"Competitor6\" >");
                SVG.Append(contest.CompeditorWhite);
                SVG.Append("</text>");

                SVG.Append(" <text x=\"579\" y=\"480\" fill=\"#000000\" id=\"3W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"579\" y=\"560\" fill=\"black\" id=\"3B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"30\" y=\"480\" fill=\"black\" id=\"Competitor5\" />");
                SVG.Append(" <text x=\"30\" y=\"560\" fill=\"black\" id=\"Competitor6\" />");

                SVG.Append(" <text x=\"579\" y=\"480\" fill=\"#000000\" id=\"3W\" />");
                SVG.Append(" <text x=\"579\" y=\"560\" fill=\"black\" id=\"3B\" />");
            }

            if (category.TryGet(4, out contest))
            {
                SVG.Append(" <text x=\"644\" y=\"160\" fill=\"#000000\" id=\"4W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"644\" y=\"320\" fill=\"#000000\" id=\"4B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"644\" y=\"160\" fill=\"#000000\" id=\"4W\" />");
                SVG.Append(" <text x=\"644\" y=\"320\" fill=\"#000000\" id=\"4B\" />");
            }

            if (category.TryGet(5, out contest))
            {
                SVG.Append(" <text x=\"709\" y=\"400\" fill=\"#000000\" id=\"5W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"709\" y=\"480\" fill=\"#000000\" id=\"5B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"709\" y=\"400\" fill=\"#000000\" id=\"5W\" />");
                SVG.Append(" <text x=\"709\" y=\"480\" fill=\"#000000\" id=\"5B\" />");
            }

            if (category.TryGet(6, out contest))
            {
                SVG.Append(" <text x=\"774\" y=\"240\" fill=\"black\" id=\"6W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"774\" y=\"560\" fill=\"#000000\" id=\"6B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"774\" y=\"240\" fill=\"black\" id=\"6W\" />");
                SVG.Append(" <text x=\"774\" y=\"560\" fill=\"#000000\" id=\"6B\" />");
            }

            if (category.TryGet(7, out contest))
            {
                SVG.Append(" <text x=\"839\" y=\"160\" fill=\"#000000\" id=\"7W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"839\" y=\"400\" fill=\"#000000\" id=\"7B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"839\" y=\"160\" fill=\"#000000\" id=\"7W\" />");
                SVG.Append(" <text x=\"839\" y=\"400\" fill=\"#000000\" id=\"7B\" />");
            }

            if (category.TryGet(8, out contest))
            {
                SVG.Append(" <text x=\"904\" y=\"240\" fill=\"#000000\" id=\"8W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"904\" y=\"480\" fill=\"#000000\" id=\"8B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"904\" y=\"240\" fill=\"#000000\" id=\"8W\" />");
                SVG.Append(" <text x=\"904\" y=\"480\" fill=\"#000000\" id=\"8B\" />");
            }

            if (category.TryGet(9, out contest))
            {
                SVG.Append(" <text x=\"969\" y=\"320\" fill=\"black\" id=\"9W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"969\" y=\"560\" fill=\"#000000\" id=\"9B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"969\" y=\"320\" fill=\"black\" id=\"9W\" />");
                SVG.Append(" <text x=\"969\" y=\"560\" fill=\"#000000\" id=\"9B\" />");
            }

            if (category.TryGet(10, out contest))
            {
                SVG.Append(" <text x=\"1034\" y=\"160\" fill=\"#000000\" id=\"10W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1034\" y=\"480\" fill=\"#000000\" id=\"10B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"1034\" y=\"160\" fill=\"#000000\" id=\"10W\" />");
                SVG.Append(" <text x=\"1034\" y=\"480\" fill=\"#000000\" id=\"10B\" />");
            }

            if (category.TryGet(11, out contest))
            {
                SVG.Append(" <text x=\"1099\" y=\"400\" fill=\"#000000\" id=\"11W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1099\" y=\"560\" fill=\"#000000\" id=\"11B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"1099\" y=\"400\" fill=\"#000000\" id=\"11W\" />");
                SVG.Append(" <text x=\"1099\" y=\"560\" fill=\"#000000\" id=\"11B\" />");
            }

            if (category.TryGet(12, out contest))
            {
                SVG.Append(" <text x=\"1164\" y=\"240\" fill=\"#000000\" id=\"12W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1164\" y=\"320\" fill=\"#000000\" id=\"12B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"1164\" y=\"240\" fill=\"#000000\" id=\"12W\" />");
                SVG.Append(" <text x=\"1164\" y=\"320\" fill=\"#000000\" id=\"12B\" />");
            }

            if (category.TryGet(13, out contest))
            {
                SVG.Append(" <text x=\"1229\" y=\"160\" fill=\"#000000\" id=\"13W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1229\" y=\"560\" fill=\"#000000\" id=\"13B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"1229\" y=\"160\" fill=\"#000000\" id=\"13W\" />");
                SVG.Append(" <text x=\"1229\" y=\"560\" fill=\"#000000\" id=\"13B\" />");
            }

            if (category.TryGet(14, out contest))
            {
                SVG.Append(" <text x=\"1294\" y=\"240\" fill=\"#000000\" id=\"14W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1294\" y=\"400\" fill=\"#000000\" id=\"14B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"1294\" y=\"240\" fill=\"#000000\" id=\"14W\" />");
                SVG.Append(" <text x=\"1294\" y=\"400\" fill=\"#000000\" id=\"14B\" />");
            }

            if (category.TryGet(15, out contest))
            {
                SVG.Append(" <text x=\"1359\" y=\"320\" fill=\"#000000\" id=\"15W\" >");
                SVG.Append(contest.ScoreWhite());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1359\" y=\"480\" fill=\"#000000\" id=\"15B\" >");
                SVG.Append(contest.ScoreBlue());
                SVG.Append("</text>");
            }
            else
            {
                SVG.Append(" <text x=\"1359\" y=\"320\" fill=\"#000000\" id=\"15W\" />");
                SVG.Append(" <text x=\"1359\" y=\"480\" fill=\"#000000\" id=\"15B\" />");
            }

            // Additional data
            if (calculated != default && calculated.Competitors.Count >= 1)
            {
                SVG.Append(" <text x=\"1429\" y=\"135\" fill=\"#000000\" id=\"WinComp1\" >");
                SVG.Append(calculated.Competitors[0].Won.ToString());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1429\" y=\"175\" fill=\"#000000\" id=\"PuntComp1\" >");
                SVG.Append(calculated.Competitors[0].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[0].Position != 0)
                {
                    SVG.Append(" <text x=\"1509\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" >");
                    SVG.Append(calculated.Competitors[0].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append(" <text x=\"1509\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" />");
                }
            }
            else
            {
                SVG.Append(" <text x=\"1429\" y=\"135\" fill=\"#000000\" id=\"WinComp1\" />");
                SVG.Append(" <text x=\"1429\" y=\"175\" fill=\"#000000\" id=\"PuntComp1\" />");
                SVG.Append(" <text x=\"1509\" y=\"160\" fill=\"#000000\" id=\"ResComp1\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 2)
            {
                SVG.Append(" <text x=\"1429\" y=\"215\" fill=\"#000000\" id=\"WinComp2\" >");
                SVG.Append(calculated.Competitors[1].Won.ToString());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1429\" y=\"255\" fill=\"#000000\" id=\"PuntComp2\" >");
                SVG.Append(calculated.Competitors[1].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[1].Position != 0)
                {
                    SVG.Append(" <text x=\"1509\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" >");
                    SVG.Append(calculated.Competitors[1].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append(" <text x=\"1509\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" />");
                }
            }
            else
            {
                SVG.Append(" <text x=\"1429\" y=\"215\" fill=\"#000000\" id=\"WinComp2\" />");
                SVG.Append(" <text x=\"1429\" y=\"255\" fill=\"#000000\" id=\"PuntComp2\" />");
                SVG.Append(" <text x=\"1509\" y=\"240\" fill=\"#000000\" id=\"ResComp2\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 3)
            {
                SVG.Append(" <text x=\"1429\" y=\"295\" fill=\"#000000\" id=\"WinComp3\" >");
                SVG.Append(calculated.Competitors[2].Won.ToString());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1429\" y=\"335\" fill=\"#000000\" id=\"PuntComp3\" >");
                SVG.Append(calculated.Competitors[2].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[2].Position != 0)
                {
                    SVG.Append(" <text x=\"1509\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" >");
                    SVG.Append(calculated.Competitors[2].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append(" <text x=\"1509\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" />");
                }

            }
            else
            {
                SVG.Append(" <text x=\"1429\" y=\"295\" fill=\"#000000\" id=\"WinComp3\" />");
                SVG.Append(" <text x=\"1429\" y=\"335\" fill=\"#000000\" id=\"PuntComp3\" />");
                SVG.Append(" <text x=\"1509\" y=\"320\" fill=\"#000000\" id=\"ResComp3\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 4)
            {
                SVG.Append(" <text x=\"1429\" y=\"375\" fill=\"#000000\" id=\"WinComp4\" >");
                SVG.Append(calculated.Competitors[3].Won.ToString());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1429\" y=\"415\" fill=\"#000000\" id=\"PuntComp4\" >");
                SVG.Append(calculated.Competitors[3].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[3].Position != 0)
                {
                    SVG.Append(" <text x=\"1509\" y=\"400\" fill=\"#000000\" id=\"ResComp4\" >");
                    SVG.Append(calculated.Competitors[3].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append(" <text x=\"1509\" y=\"400\" fill=\"#000000\" id=\"ResComp4\" />");
                }
            }
            else
            {
                SVG.Append(" <text x=\"1429\" y=\"375\" fill=\"#000000\" id=\"WinComp4\" />");
                SVG.Append(" <text x=\"1429\" y=\"415\" fill=\"#000000\" id=\"PuntComp4\" />");
                SVG.Append(" <text x=\"1509\" y=\"400\" fill=\"#000000\" id=\"ResComp4\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 5)
            {
                SVG.Append(" <text x=\"1429\" y=\"455\" fill=\"#000000\" id=\"WinComp5\" >");
                SVG.Append(calculated.Competitors[4].Won.ToString());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1429\" y=\"495\" fill=\"#000000\" id=\"PuntComp5\" >");
                SVG.Append(calculated.Competitors[4].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[4].Position != 0)
                {
                    SVG.Append(" <text x=\"1509\" y=\"480\" fill=\"#000000\" id=\"ResComp5\" >");
                    SVG.Append(calculated.Competitors[4].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append(" <text x=\"1509\" y=\"480\" fill=\"#000000\" id=\"ResComp5\" />");
                }
            }
            else
            {
                SVG.Append(" <text x=\"1429\" y=\"455\" fill=\"#000000\" id=\"WinComp5\" />");
                SVG.Append(" <text x=\"1429\" y=\"495\" fill=\"#000000\" id=\"PuntComp5\" />");
                SVG.Append(" <text x=\"1509\" y=\"480\" fill=\"#000000\" id=\"ResComp5\" />");
            }

            if (calculated != default && calculated.Competitors.Count >= 6)
            {
                SVG.Append(" <text x=\"1429\" y=\"535\" fill=\"#000000\" id=\"WinComp6\" >");
                SVG.Append(calculated.Competitors[5].Won.ToString());
                SVG.Append("</text>");
                SVG.Append(" <text x=\"1429\" y=\"575\" fill=\"#000000\" id=\"PuntComp6\" >");
                SVG.Append(calculated.Competitors[5].Score.ToString());
                SVG.Append("</text>");
                if (calculated.Competitors[5].Position != 0)
                {
                    SVG.Append(" <text x=\"1509\" y=\"560\" fill=\"#000000\" id=\"ResComp6\" >");
                    SVG.Append(calculated.Competitors[5].Position.ToString());
                    SVG.Append("</text>");
                }
                else
                {
                    SVG.Append(" <text x=\"1509\" y=\"560\" fill=\"#000000\" id=\"ResComp6\" />");
                }
            }
            else
            {
                SVG.Append(" <text x=\"1429\" y=\"535\" fill=\"#000000\" id=\"WinComp6\" />");
                SVG.Append(" <text x=\"1429\" y=\"575\" fill=\"#000000\" id=\"PuntComp6\" />");
                SVG.Append(" <text x=\"1509\" y=\"560\" fill=\"#000000\" id=\"ResComp6\" />");
            }

            SVG.Append(" </svg>");

            _Image = SVG.ToString();
        }
    }
}