using System;
using System.Collections.Generic;

namespace EuroJudoWebContestSheets.Models.DTO
{
    public class CompetitorDto
    {
        public string Name { get; set; } = String.Empty;

        public int Score { get; set; }

        public int Won { get; set; }

        public int Position { get; set; }
    }

    public class RoundRobinSheetDataDto : ContestSheetDataDto
    {
        public IList<CompetitorDto> Competitors { get; set; } = new List<CompetitorDto>();
    }
}
