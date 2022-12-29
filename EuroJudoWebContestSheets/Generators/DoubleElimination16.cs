using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using EuroJudoWebContestSheets.Database.Models;

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
            XElement sheet = XElement.Load("SVG/DE16.svg");

            foreach(var contest in category.SheetData)
            {
                if (!string.IsNullOrEmpty(contest.CompetitorWhite))
                {
                    var sheetdescendants = sheet.Descendants();
                    var compeditor = sheet.Descendants().Where(o => (string)o.Attribute("id") == (contest.Contest.ToString() + "W" )).First();
                    compeditor.SetValue(contest.CompetitorWhite);
                }
                if (!string.IsNullOrEmpty(contest.CompetitorBlue))
                {
                    var compeditor = sheet.Descendants().Where(o => (string)o.Attribute("id") == (contest.Contest.ToString() + "B")).First();
                    compeditor.SetValue(contest.CompetitorBlue);
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