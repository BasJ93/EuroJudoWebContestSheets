using System;
using System.Collections.Generic;
using System.Linq;
using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.DTO;
using EuroJudoWebContestSheets.Models.Tournament;
using ContestSheetDataDto = EuroJudoWebContestSheets.Models.DTO.ContestSheetDataDto;

namespace EuroJudoWebContestSheets.Extensions
{
    /// <summary>
    /// Extensions methods on the <see cref="ContestSheetData"/> domain object.
    /// </summary>
    public static class ContestDataExtensions
    {
        /// <summary>
        /// Update a <see cref="ContestSheetData"/> object from a <see cref="UploadContestResultDto"/>.
        /// </summary>
        /// <param name="contest">The (implicit) database object to update.</param>
        /// <param name="contestData">The result dto to use for the update.</param>
        /// <returns>The updates database object.</returns>
        public static ContestSheetData UpdateFromQuery(this ContestSheetData contest,
            UploadContestResultDto contestData)
        {
            contest.CompetitorWhite = contestData.CompetitorWhite;
            contest.CompetitorBlue = contestData.CompetitorBlue;

            switch (contestData.ScoreWhite)
            {
                case 10:
                    contest.IponWhite = 1;
                    break;
                case 7:
                    contest.WazaariWhite = 1;
                    break;
            }

            switch (contestData.ScoreBlue)
            {
                case 10:
                    contest.IponBlue = 1;
                    break;
                case 7:
                    contest.WazaariBlue = 1;
                    break;
            }

            contest.ShowSimpleScore = contestData.ShowSimpleScore;

            return contest;
        }

        /// <summary>
        /// Determine the numeric score for the competitor in white.
        /// </summary>
        /// <param name="contest">The (implicit) database object to update.</param>
        /// <returns>The numeric score.</returns>
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

        /// <summary>
        /// Determine the numeric score for the competitor in blue.
        /// </summary>
        /// <param name="contest">The (implicit) database object to update.</param>
        /// <returns>The numeric score.</returns>
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

        /// <summary>
        /// Determine whether white won. 
        /// </summary>
        /// <param name="contest">The (implicit) database object to update.</param>
        /// <returns>A bool indicating if white won.</returns>
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

        /// <summary>
        /// Return the group name used to update the frontend. 
        /// </summary>
        /// <param name="contest">The (implicit) database object to update.</param>
        /// <returns>The group name as a string.</returns>
        public static string GroupName(this ContestSheetData contest)
        {
            return $"t{contest.TournamentId}c{contest.CategoryId}";
        }

        public static ContestSheetDataDto ToDTO(this ContestSheetData contest)
        {
            return new ContestSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompetitorWhite ?? string.Empty,
                CompetitorBlue = contest.CompetitorBlue ?? string.Empty,
                IponWhite = contest.IponWhite ?? 0,
                WazaariWhite = contest.WazaariWhite ?? 0,
                IponBlue = contest.IponBlue ?? 0,
                WazaariBlue = contest.WazaariBlue ?? 0,
            };
        }

        public static RedisRoundRobinContestSheetDataDto ToRedisDTO(this ContestSheetDataDto contest, ContestType type)
        {
            return new RedisRoundRobinContestSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompetitorWhite,
                CompetitorBlue = contest.CompetitorBlue,
                IponWhite = contest.IponWhite,
                WazaariWhite = contest.WazaariWhite,
                IponBlue = contest.IponBlue,
                WazaariBlue = contest.WazaariBlue,
                ContestType = type,
            };
        }

        public static RedisRoundRobinContestSheetDataDto ToRedisDTO(this RoundRobinSheetDataDto contest,
            ContestType type)
        {
            return new RedisRoundRobinContestSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompetitorWhite,
                CompetitorBlue = contest.CompetitorBlue,
                IponWhite = contest.IponWhite,
                WazaariWhite = contest.WazaariWhite,
                IponBlue = contest.IponBlue,
                WazaariBlue = contest.WazaariBlue,
                Competitors = contest.Competitors,
                ContestType = type,
            };
        }

        public static ContestSheetDataDto ToDTO(this RedisRoundRobinContestSheetDataDto contest)
        {
            return new ContestSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompetitorWhite,
                CompetitorBlue = contest.CompetitorBlue,
                IponWhite = contest.IponWhite,
                WazaariWhite = contest.WazaariWhite,
                IponBlue = contest.IponBlue,
                WazaariBlue = contest.WazaariBlue,
            };
        }

        public static RoundRobinSheetDataDto ToRoundRobinDto(this RedisRoundRobinContestSheetDataDto contest)
        {
            return new RoundRobinSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompetitorWhite,
                CompetitorBlue = contest.CompetitorBlue,
                IponWhite = contest.IponWhite,
                WazaariWhite = contest.WazaariWhite,
                IponBlue = contest.IponBlue,
                WazaariBlue = contest.WazaariBlue,
                Competitors = contest.Competitors,
            };
        }

        /// <summary>
        /// Convert the data in the database to the dto used to render the contest sheet.
        /// </summary>
        /// <param name="contest"></param>
        /// <param name="category"></param>
        /// <returns></returns>
        public static RoundRobinSheetDataDto ToRoundRobinDto(this ContestSheetData contest, Category category)
        {
            // The contests are only extracted to retrieve the competitor names.

            List<CompetitorDto> competitors = new List<CompetitorDto>();
            EventResult result1;
            EventResult result2;
            EventResult result3;
            EventResult result4;
            EventResult result5;
            EventResult result6;

            ContestSheetData? finalContest;

            switch (category.SheetSize)
            {
                case 3:
                    result1 = category.CalculateRR3Result(1);
                    if (category.TryGet(1, out ContestSheetData? contest1) && contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorWhite ?? string.Empty,
                            Score = result1.Points,
                            Won = result1.Won,
                        });
                    }

                    result2 = category.CalculateRR3Result(2);
                    if (contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorBlue ?? string.Empty,
                            Score = result2.Points,
                            Won = result2.Won,
                        });
                    }

                    result3 = category.CalculateRR3Result(3);
                    if (category.TryGet(2, out ContestSheetData? contest2) && contest2 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorBlue ?? string.Empty,
                            Score = result3.Points,
                            Won = result3.Won,
                        });
                    }

                    if (category.TryGet(3, out finalContest))
                    {
                        RankCompetitors();
                    }

                    break;
                case 4:
                    result1 = category.CalculateRR4Result(1);
                    if (category.TryGet(1, out contest1) && contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorWhite ?? string.Empty,
                            Score = result1.Points,
                            Won = result1.Won,
                        });
                    }

                    result2 = category.CalculateRR4Result(2);
                    if (contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorBlue ?? string.Empty,
                            Score = result2.Points,
                            Won = result2.Won,
                        });
                    }

                    result3 = category.CalculateRR4Result(3);
                    if (category.TryGet(2, out contest2) && contest2 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorWhite ?? string.Empty,
                            Score = result3.Points,
                            Won = result3.Won,
                        });

                        result4 = category.CalculateRR4Result(4);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorBlue ?? string.Empty,
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
                    if (category.TryGet(1, out contest1) && contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorWhite ?? string.Empty,
                            Score = result1.Points,
                            Won = result1.Won,
                        });
                    }

                    result2 = category.CalculateRR5Result(2);
                    if (contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorBlue ?? string.Empty,
                            Score = result2.Points,
                            Won = result2.Won,
                        });
                    }

                    result3 = category.CalculateRR5Result(3);
                    if (category.TryGet(2, out contest2) && contest2 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorWhite ?? string.Empty,
                            Score = result3.Points,
                            Won = result3.Won,
                        });

                        result4 = category.CalculateRR5Result(4);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorBlue ?? string.Empty,
                            Score = result4.Points,
                            Won = result4.Won,
                        });
                    }

                    if (category.TryGet(3, out var contest3) && contest3 != null)
                    {
                        result5 = category.CalculateRR5Result(5);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest3.CompetitorBlue ?? string.Empty,
                            Score = result5.Points,
                            Won = result5.Won,
                        });
                    }

                    if (category.TryGet(10, out finalContest))
                    {
                        RankCompetitors();
                    }

                    break;
                case 6:
                    result1 = category.CalculateRR6Result(1);
                    if (category.TryGet(1, out contest1) && contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorWhite ?? string.Empty,
                            Score = result1.Points,
                            Won = result1.Won,
                        });
                    }

                    result2 = category.CalculateRR6Result(2);
                    if (contest1 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest1.CompetitorBlue ?? string.Empty,
                            Score = result2.Points,
                            Won = result2.Won,
                        });
                    }

                    result3 = category.CalculateRR6Result(3);
                    if (category.TryGet(2, out contest2) && contest2 != null)
                    {
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorWhite ?? string.Empty,
                            Score = result3.Points,
                            Won = result3.Won,
                        });

                        result4 = category.CalculateRR6Result(4);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest2.CompetitorBlue ?? string.Empty,
                            Score = result4.Points,
                            Won = result4.Won,
                        });
                    }

                    if (category.TryGet(3, out contest3) && contest3 != null)
                    {
                        result5 = category.CalculateRR6Result(5);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest3.CompetitorWhite ?? string.Empty,
                            Score = result5.Points,
                            Won = result5.Won,
                        });

                        result6 = category.CalculateRR6Result(6);
                        competitors.Add(new CompetitorDto
                        {
                            Name = contest3.CompetitorBlue ?? string.Empty,
                            Score = result6.Points,
                            Won = result6.Won,
                        });
                    }

                    if (category.TryGet(15, out finalContest))
                    {
                        RankCompetitors();
                    }

                    break;
            }

            return new RoundRobinSheetDataDto
            {
                Contest = contest.Contest,
                CompetitorWhite = contest.CompetitorWhite ?? string.Empty,
                CompetitorBlue = contest.CompetitorBlue ?? string.Empty,
                IponWhite = contest.IponWhite ?? 0,
                WazaariWhite = contest.WazaariWhite ?? 0,
                IponBlue = contest.IponBlue ?? 0,
                WazaariBlue = contest.WazaariBlue ?? 0,
                Competitors = competitors,
            };

            void RankCompetitors()
            {
                // Rank the competitors by won contests, then by points. Then assing the ranking.
                var ranked = competitors.OrderByDescending(c => c.Won).ThenByDescending(c => c.Score).ToList();

                for (int i = 1; i < ranked.Count() + 1; i++)
                {
                    competitors.First(c => c.Name == ranked.ElementAt(i - 1).Name).Position = i;
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

        private static EventResult CalculateRR3Result(this Category category, int competitor)
        {
            if (category.SheetData == null)
            {
                return new EventResult();
            }
            
            switch (competitor)
            {
                case 1:
                    List<ContestSheetData> contests = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 2).ToList();
                    return new EventResult
                    {
                        Won = contests.Count(c => c.WhiteWon()),
                        Points = contests.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    var asWhite = category.SheetData.FirstOrDefault(s => s.Contest == 3);
                    var asBlue = category.SheetData.FirstOrDefault(s => s.Contest == 2);
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
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 3).ToList();
                    return new EventResult
                    {
                        Won = contests.Count(c => !c.WhiteWon()),
                        Points = contests.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return new EventResult();
            }
        }

        private static EventResult CalculateRR4Result(this Category category, int competitor)
        {
            if (category.SheetData == null)
            {
                return new EventResult();
            }
            
            switch (competitor)
            {
                case 1:
                    List<ContestSheetData> contests = category.SheetData.Where(s => s.Contest == 1 || s.Contest == 3 || s.Contest == 5).ToList();
                    return new EventResult
                    {
                        Won = contests.Count(c => c.WhiteWon()),
                        Points = contests.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    List<ContestSheetData> asWhite = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 6).ToList();
                    var asBlue = category.SheetData.FirstOrDefault(s => s.Contest == 1);
                    int won = asWhite.Count(c => c.WhiteWon());
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
                    var asWhite2 = category.SheetData.FirstOrDefault(s => s.Contest == 2);
                    List<ContestSheetData> asBlue2 = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 5).ToList();
                    won = asBlue2.Count(c => !c.WhiteWon());
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
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 3 || s.Contest == 6).ToList();
                    return new EventResult
                    {
                        Won = contests.Count(c => !c.WhiteWon()),
                        Points = contests.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return new EventResult();
            }
        }

        private static EventResult CalculateRR5Result(this Category category, int competitor)
        {
            if (category.SheetData == null)
            {
                return new EventResult();
            }
            
            switch (competitor)
            {
                case 1:
                    List<ContestSheetData> contests = category.SheetData.Where(s =>
                        s.Contest == 1 || s.Contest == 3 || s.Contest == 6 || s.Contest == 9).ToList();
                    return new EventResult
                    {
                        Won = contests.Count(c => c.WhiteWon()),
                        Points = contests.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    List<ContestSheetData> asWhite = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 7 || s.Contest == 10).ToList();
                    List<ContestSheetData> asBlue = category.SheetData.Where(s => s.Contest == 1).ToList();
                    int won = asWhite.Count(c => c.WhiteWon());
                    int score = asWhite.Select(c => c.ScoreWhite()).Sum();
                    if (asBlue.FirstOrDefault() != default)
                    {
                        won += asBlue.First().WhiteWon() ? 0 : 1;
                        score += asBlue.First().ScoreBlue();
                    }

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 3:
                    asWhite = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 8).ToList();
                    asBlue = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 6).ToList();
                    won = asWhite.Count(c => c.WhiteWon()) + asBlue.Count(c => !c.WhiteWon());
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 4:
                    asWhite = category.SheetData.Where(s => s.Contest == 5).ToList();
                    contests = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 7 || s.Contest == 9).ToList();
                    won = contests.Count(c => !c.WhiteWon());
                    score = contests.Select(c => c.ScoreBlue()).Sum();
                    if (asWhite.FirstOrDefault() != default)
                    {
                        won += asWhite.First().WhiteWon() ? 1 : 0;
                        score += asWhite.First().ScoreWhite();
                    }

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 5:
                    contests = category.SheetData.Where(s =>
                        s.Contest == 3 || s.Contest == 5 || s.Contest == 8 || s.Contest == 10).ToList();
                    return new EventResult
                    {
                        Won = contests.Count(c => !c.WhiteWon()),
                        Points = contests.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return new EventResult();
            }
        }

        private static EventResult CalculateRR6Result(this Category category, int competitor)
        {
            if (category.SheetData == null)
            {
                return new EventResult();
            }
            
            switch (competitor)
            {
                case 1:
                    List<ContestSheetData> asWhite = category.SheetData.Where(s =>
                        s.Contest == 1 || s.Contest == 4 || s.Contest == 7 || s.Contest == 10 || s.Contest == 13).ToList();
                    return new EventResult
                    {
                        Won = asWhite.Count(c => c.WhiteWon()),
                        Points = asWhite.Select(c => c.ScoreWhite()).Sum(),
                    };
                case 2:
                    asWhite = category.SheetData.Where(s =>
                        s.Contest == 5 || s.Contest == 8 || s.Contest == 12 || s.Contest == 14).ToList();
                    List<ContestSheetData> asBlue = category.SheetData.Where(s => s.Contest == 1).ToList();
                    int won = asWhite.Count(c => c.WhiteWon()) + asBlue.Count(c => !c.WhiteWon());
                    int score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 3:
                    asWhite = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 9 || s.Contest == 15).ToList();
                    asBlue = category.SheetData.Where(s => s.Contest == 4 || s.Contest == 12).ToList();
                    won = asWhite.Count(c => c.WhiteWon()) + asBlue.Count(c => !c.WhiteWon());
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();

                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 4:
                    asWhite = category.SheetData.Where(s => s.Contest == 5 || s.Contest == 11).ToList();
                    asBlue = category.SheetData.Where(s => s.Contest == 2 || s.Contest == 7 || s.Contest == 14).ToList();
                    won = asWhite.Count(c => c.WhiteWon()) + asBlue.Count(c => !c.WhiteWon());
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();
                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 5:
                    asWhite = category.SheetData.Where(s => s.Contest == 3).ToList();
                    asBlue = category.SheetData.Where(s =>
                        s.Contest == 6 || s.Contest == 9 || s.Contest == 11 || s.Contest == 13).ToList();
                    won = asWhite.Count(c => c.WhiteWon()) + asBlue.Count(c => !c.WhiteWon());
                    score = asWhite.Select(c => c.ScoreWhite()).Sum() + asBlue.Select(c => c.ScoreBlue()).Sum();
                    return new EventResult
                    {
                        Won = won,
                        Points = score,
                    };
                case 6:
                    asBlue = category.SheetData.Where(s =>
                        s.Contest == 3 || s.Contest == 6 || s.Contest == 9 || s.Contest == 11 || s.Contest == 13).ToList();
                    return new EventResult
                    {
                        Won = asBlue.Count(c => !c.WhiteWon()),
                        Points = asBlue.Select(c => c.ScoreBlue()).Sum(),
                    };
                default:
                    return new EventResult();
            }
        }
    }
}