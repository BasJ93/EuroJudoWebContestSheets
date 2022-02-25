using System.Collections.Generic;

namespace EuroJudoWebContestSheets.Models.DTO
{
    public class CompetitorDto
    {
        public string Name { get; set; }

        public int Score { get; set; }

        public int Won { get; set; }

        public int Position { get; set; }
    }

    public class RoundRobinSheetDataDto : ContestSheetDataDto
    {
        public List<CompetitorDto> Competitors { get; set; }
    }
}
