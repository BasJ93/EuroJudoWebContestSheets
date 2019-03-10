namespace EuroJudoWebContestSheets.Models.ContestOrder
{
    public class Contest
    {
        public int Number { get; set; }
        public Compeditor CompeditorWhite { get; set; }
        public Compeditor CompeditorBlue { get; set; }
        public string Weight { get; set; }
        public string Short { get; set; }
    }
}
