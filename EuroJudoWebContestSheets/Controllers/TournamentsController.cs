using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models;
using Microsoft.AspNetCore.Mvc;

namespace EuroJudoWebContestSheets.Controllers
{
    public class TournamentsController : Controller
    {

        dbContext _db;

        //Create a partial view for the navbar, so that it can be filled based on the data.

        public TournamentsController(dbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Tournaments = _db.Tournaments.ToList();
            return View();
        }

        [HttpGet]
        public IActionResult ShowSVG()
        {
            Category test = new Category
            {
                SheetSize = 8,
                SheetData = new List<ContestSheetData>
                {
                    new ContestSheetData
                    {
                        Contest = 1,
                        CompeditorWhite = "MARTIN, Mauro",
                        CompeditorBlue = "VOLLEMAN, Tibo"
                    },
                    new ContestSheetData
                    {
                        Contest = 2,
                        CompeditorWhite = "LICHTENBERG, Bram",
                        CompeditorBlue = "SCHREURS, Vincent"
                    },
                    new ContestSheetData
                    {
                        Contest = 3,
                        CompeditorWhite = "JANSSEN, Bas",
                        CompeditorBlue = "PIETERS, Jan"
                    },
                    new ContestSheetData
                    {
                        Contest = 4,
                        CompeditorWhite = "KLAASSEN, Rob",
                        CompeditorBlue = "VAN DIJK, Nico"
                    },
                    new ContestSheetData
                    {
                        Contest = 5,
                        CompeditorWhite = "MARTIN, Mauro",
                        CompeditorBlue = "SCHREURS, Vincent"
                    },
                    new ContestSheetData
                    {
                        Contest = 6,
                        CompeditorWhite = "PIETERS, Jan",
                        CompeditorBlue = "KLAASSEN, Rob"
                    },
                    new ContestSheetData
                    {
                        Contest = 7,
                        CompeditorWhite = "VOLLEMAN, Tibo",
                        CompeditorBlue = "LICHTENBERG, Bram"
                    },
                    new ContestSheetData
                    {
                        Contest = 8,
                        CompeditorWhite = "JANSSEN, Bas",
                        CompeditorBlue = "VAN DIJK, Nico"
                    }
                }
            };
            ViewBag.SVGText = Generators.SVGFactory.Get(test);
            return View();//Ok();//(Generators.SVGGenerator(1), "image/svg+xml");
        }

        [HttpGet]
        public IActionResult GetContestSheetData([FromQuery] int TournamentId)
        {
            List<ContestSheetData> sheetData = _db.ContestSheetData.Where(o => o.TournamentID == TournamentId).ToList();
            return new JsonResult(sheetData);
        }

        [HttpPost]
        public IActionResult PostContestSheetData([FromBody] ContestSheetData contestData)
        {
            //List<ContestSheetData> sheetData = _db.ContestSheetData.Where(o => o.TournamentID == TournamentId).ToList();
            //return new JsonResult(sheetData);
            return Ok();
        }
    }
}