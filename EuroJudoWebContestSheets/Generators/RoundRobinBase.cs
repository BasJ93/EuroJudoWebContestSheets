using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Extensions;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.DTO;

namespace EuroJudoWebContestSheets.Generators
{
    public class RoundRobinBase : GenerateSVG
    {
        internal string _Image;

        public override string Image
        {
            get
            {
                return _Image;
            }
        }

        /// <summary>
        /// Generates the filled SVG for a round robin category.
        /// </summary>
        /// <param name="category">The category to generate it for.</param>
        /// <param name="templateFileName">The filename of the template located in the SVG folder, without the extention.</param>
        public RoundRobinBase(Category category, string templateFileName)
        {
            XElement sheet = XElement.Load($"SVG/{templateFileName}.svg");

            bool hasFirstContest = category.TryGet(1, out ContestSheetData _contest);
            RoundRobinSheetDataDto calculated = default;
            if (hasFirstContest)
            {
                calculated = _contest.ToRoundRobinDto(category);
            }

            foreach (var contest in category.SheetData)
            {
                if (!string.IsNullOrEmpty(contest.CompetitorWhite))
                {
                    var sheetdescendants = sheet.Descendants();
                    var score = sheet.Descendants().Where(o => (string)o.Attribute("id") == (contest.Contest.ToString() + "W")).First();
                    score.SetValue(contest.ScoreWhite());
                }
                if (!string.IsNullOrEmpty(contest.CompetitorBlue))
                {
                    var score = sheet.Descendants().Where(o => (string)o.Attribute("id") == (contest.Contest.ToString() + "B")).First();
                    score.SetValue(contest.ScoreBlue());
                }
            }

            if (calculated != default)
            {
                for (int i = 0; i < calculated.Competitors.Count(); i++)
                {
                    var competitor = sheet.Descendants().Where(o => (string)o.Attribute("id") == ($"Competitor{i + 1}")).First();
                    competitor.SetValue(calculated.Competitors[i].Name);

                    var wins = sheet.Descendants().Where(o => (string)o.Attribute("id") == ($"WinComp{i + 1}")).First();
                    wins.SetValue(calculated.Competitors[i].Won);

                    var points = sheet.Descendants().Where(o => (string)o.Attribute("id") == ($"PuntComp{i + 1}")).First();
                    points.SetValue(calculated.Competitors[i].Score);

                    if (calculated.Competitors[i].Position != 0)
                    {
                        var position = sheet.Descendants().Where(o => (string)o.Attribute("id") == ($"ResComp{i + 1}")).First();
                        position.SetValue(calculated.Competitors[i].Position);
                    }
                }
            }

            XmlSerializer serializer = new XmlSerializer(typeof(XElement));

            using (StringWriter stringWriter = new StringWriter())
            {
                serializer.Serialize(stringWriter, sheet);
                _Image = stringWriter.ToString();
            }
        }
    }
}