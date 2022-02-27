using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Controllers
{
    /// <summary>
    /// MVC controller for the Tournaments pages
    /// </summary>
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
        public IActionResult Categories([FromQuery] int tournamentID)
        {
            ViewBag.Categories = _db.Categories.Where(o => o.TournamentID == tournamentID).ToList();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ContestSheet([FromQuery] int tID, [FromQuery] int cID)
        {
            Category category = await _db.Categories.Include(o => o.SheetData).Where(o => o.ID == cID && o.TournamentID == tID).FirstOrDefaultAsync();
            ViewBag.Title = category.CategoryName;
            ViewBag.CategoryID = category.ID;
            ViewBag.TournamentID = category.TournamentID;
            ViewBag.SVGText = Generators.SVGFactory.Get(category, out ContestType type);
            ViewBag.Type = type.ToString();
            return View();
        }

        [HttpGet]
        public IActionResult GetContestSheetData([FromQuery] int TournamentId)
        {
            List<ContestSheetData> sheetData = _db.ContestSheetData.Where(o => o.TournamentID == TournamentId).ToList();
            return new JsonResult(sheetData);
        }

        [HttpGet]
        public async Task<IActionResult> RenderSVG([FromQuery] int tID, [FromQuery] int cID)
        {
            Category category = await _db.Categories.Include(o => o.SheetData).Where(o => o.ID == cID && o.TournamentID == tID).FirstOrDefaultAsync();
            return Ok(Generators.SVGFactory.Get(category, out ContestType type));
        }
    }
}