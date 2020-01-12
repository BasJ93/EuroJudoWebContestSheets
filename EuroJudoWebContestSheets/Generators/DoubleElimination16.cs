using EuroJudoWebContestSheets.Models;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

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
                if (!string.IsNullOrEmpty(contest.CompeditorWhite))
                {
                    var sheetdescendants = sheet.Descendants();
                    var compeditor = sheet.Descendants().Where(o => (string)o.Attribute("id") == (contest.Contest.ToString() + "W" )).First();
                    compeditor.SetValue(contest.CompeditorWhite);
                }
                if (!string.IsNullOrEmpty(contest.CompeditorBlue))
                {
                    var compeditor = sheet.Descendants().Where(o => (string)o.Attribute("id") == (contest.Contest.ToString() + "B")).First();
                    compeditor.SetValue(contest.CompeditorBlue);
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