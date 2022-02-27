using System;
using System.Collections.Generic;
using System.Linq;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.DTO;

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
            if (contest.IponWhite == 1)
            {
                return true;
            }
            if (contest.WazaariWhite == 2)
            {
                return true;
            }
            if (contest.WazaariWhite == 1 && contest.IponBlue == 0 && contest.WazaariBlue == 0)
            {
                return true;
            }
            return false;
        }

        public static string GroupName(this ContestSheetData contest)
        {
            return $"t{contest.TournamentID}c{contest.CategoryID}";
        }

        public static ContestSheetDataDto ToDTO(this ContestSheetData contest)
        {
            return new ContestSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompeditorWhite,
                CompetitorBlue = contest.CompeditorBlue,
                IponWhite = contest.IponWhite,
                WazaariWhite = contest.WazaariWhite,
                IponBlue = contest.IponBlue,
                WazaariBlue = contest.WazaariBlue,
            };
        }

        public static RoundRobinSheetDataDto ToRoundRobinDto(this ContestSheetData contest, Category category)
        {
            List<CompetitorDto> competitors = new List<CompetitorDto>();
            EventResult result1;
            EventResult result2;
            EventResult result3;
            EventResult result4;
            EventResult result5;
            EventResult result6;

            ContestSheetData finalContest;

            switch (category.SheetSize)
            {
                case 3:
                    result1 = category.CalculateRR3Result(1);
                    category.TryGet(1, out ContestSheetData contest1);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorWhite,
                        Score = result1.Points,
                        Won = result1.Won,
                    });

                    result2 = category.CalculateRR3Result(2);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorBlue,
                        Score = result2.Points,
                        Won = result2.Won,
                    });

                    result3 = category.CalculateRR3Result(3);
                    category.TryGet(2, out ContestSheetData contest2);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest2.CompeditorBlue,
                        Score = result3.Points,
                        Won = result3.Won,
                    });

                    if (category.TryGet(3, out finalContest))
                    {
                        RankCompetitors();
                    }
                    break;
                case 4:
                    result1 = category.CalculateRR4Result(1);
                    category.TryGet(1, out contest1);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorWhite,
                        Score = result1.Points,
                        Won = result1.Won,
                    });

                    result2 = category.CalculateRR4Result(2);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorBlue,
                        Score = result2.Points,
                        Won = result2.Won,
                    });

                    result3 = category.CalculateRR4Result(3);
                    if (category.TryGet(2, out contest2))
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompeditorWhite,
                            Score = result3.Points,
                            Won = result3.Won,
                        });

                        result4 = category.CalculateRR4Result(4);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompeditorBlue,
                            Score = result4.Points,
                            Won = result4.Won,
                        });
                    }

                    if (category.TryGet(6, out finalContest))
                    {
                        RankCompetitors();
                    }
                    break;
                case 5:
                    result1 = category.CalculateRR5Result(1);
                    category.TryGet(1, out contest1);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorWhite,
                        Score = result1.Points,
                        Won = result1.Won,
                    });

                    result2 = category.CalculateRR5Result(2);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorBlue,
                        Score = result2.Points,
                        Won = result2.Won,
                    });

                    result3 = category.CalculateRR5Result(3);
                    if (category.TryGet(2, out contest2))
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompeditorWhite,
                            Score = result3.Points,
                            Won = result3.Won,
                        });

                        result4 = category.CalculateRR5Result(4);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompeditorBlue,
                            Score = result4.Points,
                            Won = result4.Won,
                        });
                    }

                    if (category.TryGet(3, out var contest3))
                    {
                        result5 = category.CalculateRR5Result(5);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest3.CompeditorBlue,
                            Score = result5.Points,
                            Won = result5.Won,
                        });
                    }

                    if (category.TryGet(10, out finalContest))
                    {
                        RankCompetitors();
                    }
                    else
                    {

                    }
                    break;
                case 6:
                    result1 = category.CalculateRR6Result(1);
                    category.TryGet(1, out contest1);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorWhite,
                        Score = result1.Points,
                        Won = result1.Won,
                    });

                    result2 = category.CalculateRR6Result(2);
                    competitors.Add(new CompetitorDto
                    {
                        Name = contest1.CompeditorBlue,
                        Score = result2.Points,
                        Won = result2.Won,
                    });

                    result3 = category.CalculateRR6Result(3);
                    if (category.TryGet(2, out contest2))
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompeditorWhite,
                            Score = result3.Points,
                            Won = result3.Won,
                        });

                        result4 = category.CalculateRR6Result(4);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompeditorBlue,
                            Score = result4.Points,
                            Won = result4.Won,
                        });
                    }

                    if (category.TryGet(3, out contest3))
                    {
                        result5 = category.CalculateRR6Result(5);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest3.CompeditorWhite,
                            Score = result5.Points,
                            Won = result5.Won,
                        });

                        result6 = category.CalculateRR6Result(6);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest3.CompeditorBlue,
                            Score = result6.Points,
                            Won = result6.Won,
                        });
                    }

                    if (category.TryGet(15, out finalContest))
                    {
                        RankCompetitors();
                    }
                    else
                    {

                    }
                    break;
            }

            return new RoundRobinSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompeditorWhite,
                CompetitorBlue = contest.CompeditorBlue,
                IponWhite = contest.IponWhite,
                WazaariWhite = contest.WazaariWhite,
                IponBlue = contest.IponBlue,
                WazaariBlue = contest.WazaariBlue,
                Competitors = competitors,
            };

            void RankCompetitors()
            {
                // Rank the competitors by won contests, then by points. Then assing the ranking.
                var ranked = competitors.OrderByDescending(c => c.Won).ThenByDescending(c => c.Score);

                for (int i = 1; i < ranked.Count() + 1; i++)
                {
                    competitors.Where(c => c.Name == ranked.ElementAt(i - 1).Name).First().Position = i;
                }
            }
        }

        public static ContestType GetContestType(this Category category)
        {
            switch (category.SheetSize)
            {
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                    return ContestType.RoundRobin;
                case 6:
                    return ContestType.RoundRobin;
                case 7:
                case 8:
                    return ContestType.DoubleElimination;
                case 9:
                case 10:
                case 11:
                case 12:
                case 13:
                case 14:
                case 15:
                case 16:
                    return ContestType.DoubleElimination;
                case 17:
                case 18:
                case 19:
                case 20:
                case 21:
                case 22:
                case 23:
                case 24:
                case 25:
                case 26:
                case 27:
                case 28:
                case 29:
                case 30:
                case 31:
                case 32:
                    return ContestType.DoubleElimination;
                default:
                    throw new NotImplementedException();
            }
        }

        public static EventResult CalculateRR3Result(this Category category, int competitor)
        {
            switch (competitor)
            {
                case 1:
                    var contests = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 2);
                    return new EventResult
                    {
                        Won = contests.Where(c => c.WhiteWon()).Count(),
                        Points = contests.Select(c => c.ScoreWhite()).Sum(),
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
                        Won = won,
                        Points = score,
                    };
                case 3:
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 3);
                    return new EventResult
                    {
                        Won = contests.Where(c => !c.WhiteWon()).Count(),
                        Points = contests.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return default;
            }
        }

        public static EventResult CalculateRR4Result(this Category category, int competitor)
        {
            switch (competitor)
            {
                case 1:
                    var contests = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 3 || s.Contest == 5);
                    return new EventResult
                    {
                        Won = contests.Where(c => c.WhiteWon()).Count(),
                        Points = contests.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    var asWhite = category.SheetData.Where(s => s.Contest == 3 || s.Contest == 6);
                    var asBlue = category.SheetData.Where(s => s.Contest == 1).FirstOrDefault();
                    int won = asWhite.Where(c => c.WhiteWon()).Count();
                    int score = asWhite.Select(c => c.ScoreWhite()).Sum();
                    if (asBlue != default)
                    {
                        won += asBlue.WhiteWon() ? 0 : 1;
                        score += asBlue.ScoreBlue();
                    }

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 3:
                    var asWhite2 = category.SheetData.Where(s => s.Contest == 2).FirstOrDefault();
                    var asBlue2 = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 5);
                    won = asBlue2.Where(c => !c.WhiteWon()).Count();
                    score = asBlue2.Select(c => c.ScoreBlue()).Sum();
                    if (asWhite2 != default)
                    {
                        won += asWhite2.WhiteWon() ? 1 : 0;
                        score += asWhite2.ScoreWhite();
                    }

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 4:
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 3 || s.Contest == 6);
                    return new EventResult
                    {
                        Won = contests.Where(c => !c.WhiteWon()).Count(),
                        Points = contests.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return default;
            }
        }

        public static EventResult CalculateRR5Result(this Category category, int competitor)
        {
            switch (competitor)
            {
                case 1:
                    var contests = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 3 || s.Contest == 6 || s.Contest == 9);
                    return new EventResult
                    {
                        Won = contests.Where(c => c.WhiteWon()).Count(),
                        Points = contests.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    var asWhite = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 7 || s.Contest == 10);
                    var asBlue = category.SheetData.Where(s => s.Contest == 1);
                    int won = asWhite.Where(c => c.WhiteWon()).Count();
                    int score = asWhite.Select(c => c.ScoreWhite()).Sum();
                    if (asBlue.FirstOrDefault() != default)
                    {
                        won += asBlue.FirstOrDefault().WhiteWon() ? 0 : 1;
                        score += asBlue.FirstOrDefault().ScoreBlue();
                    }

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 3:
                    asWhite = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 8);
                    asBlue = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 6);
                    won = asWhite.Where(c => c.WhiteWon()).Count() + asBlue.Where(c => !c.WhiteWon()).Count();
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 4:
                    asWhite = category.SheetData.Where(s => s.Contest == 5);
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 7 || s.Contest == 9);
                    won = contests.Where(c => !c.WhiteWon()).Count();
                    score = contests.Select(c => c.ScoreBlue()).Sum();
                    if (asWhite.FirstOrDefault() != default)
                    {
                        won += asWhite.FirstOrDefault().WhiteWon() ? 1 : 0;
                        score += asWhite.FirstOrDefault().ScoreWhite();
                    }
                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 5:
                    contests = category.SheetData.Where(s => s.Contest == 3 || s.Contest == 5 || s.Contest == 8 || s.Contest == 10);
                    return new EventResult
                    {
                        Won = contests.Where(c => !c.WhiteWon()).Count(),
                        Points = contests.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return default;
            }
        }

        public static EventResult CalculateRR6Result(this Category category, int competitor)
        {
            switch (competitor)
            {
                case 1:
                    var asWhite = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 4 || s.Contest == 7 || s.Contest == 10 || s.Contest == 13);
                    return new EventResult
                    {
                        Won = asWhite.Where(c => c.WhiteWon()).Count(),
                        Points = asWhite.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    asWhite = category.SheetData.Where(s => s.Contest == 5 || s.Contest == 8 || s.Contest == 12 || s.Contest == 14);
                    var asBlue = category.SheetData.Where(s => s.Contest == 1);
                    int won = asWhite.Where(c => c.WhiteWon()).Count() + asBlue.Where(c => !c.WhiteWon()).Count();
                    int score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 3:
                    asWhite = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 9 || s.Contest == 15);
                    asBlue = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 12);
                    won = asWhite.Where(c => c.WhiteWon()).Count() + asBlue.Where(c => !c.WhiteWon()).Count();
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 4:
                    asWhite = category.SheetData.Where(s => s.Contest == 5 || s.Contest == 11);
                    asBlue = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 7 || s.Contest == 14);
                    won = asWhite.Where(c => c.WhiteWon()).Count() + asBlue.Where(c => !c.WhiteWon()).Count();
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();
                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 5:
                    asWhite = category.SheetData.Where(s => s.Contest == 3);
                    asBlue = category.SheetData.Where(s => s.Contest == 6 || s.Contest == 9 || s.Contest == 11 || s.Contest == 13);
                    won = asWhite.Where(c => c.WhiteWon()).Count() + asBlue.Where(c => !c.WhiteWon()).Count();
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();
                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 6:
                    asBlue = category.SheetData.Where(s => s.Contest == 3 || s.Contest == 6 || s.Contest == 9 || s.Contest == 11  || s.Contest == 13);
                    return new EventResult
                    {
                        Won = asBlue.Where(c => !c.WhiteWon()).Count(),
                        Points = asBlue.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return default;
            }
        }
    }
}