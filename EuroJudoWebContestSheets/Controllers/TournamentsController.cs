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
                        Contest = 9,
                        CompeditorWhite = "MARTIN, Mauro",
                        CompeditorBlue = "VOLLEMAN, Tibo"
                    },
                    new ContestSheetData
                    {
                        Contest = 10,
                        CompeditorWhite = "LICHTENBERG, Bram",
                        CompeditorBlue = "SCHREURS, Vincent"
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
    }
}