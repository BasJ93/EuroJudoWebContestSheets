using EuroJudoWebContestSheets.Models;

namespace EuroJudoWebContestSheets.Extentions
{
    public static class ContestDataExtentions
    {
        public static int ScoreWhite(this ContestSheetData contest)
        {
            if (contest.IponWhite == 1 || contest.WazaariWhite == 2)
            {
                return 10;
            }
            if (contest.WazaariWhite == 1)
            {
                return 7;
            }
            return 0;
        }

        public static int ScoreBlue(this ContestSheetData contest)
        {
            if (contest.IponBlue == 1 || contest.WazaariBlue == 2)
            {
                return 10;
            }
            if (contest.WazaariBlue == 1)
            {
                return 7;
            }
            return 0;
        }

        public static bool WhiteWon(this ContestSheetData contest)
        {
            if(contest.IponWhite == 1)
            {
                return true;
            }
            if(contest.WazaariWhite == 2)
            {
                return true;
            }
            if(contest.WazaariWhite == 1 && contest.IponBlue == 0 && contest.WazaariBlue == 0)
            {
                return true;
            }
            return false;
        }

        public static string GroupName(this ContestSheetData contest)
        {
            return $"t{contest.TournamentID}c{contest.CategoryID}";
        }
    }
}