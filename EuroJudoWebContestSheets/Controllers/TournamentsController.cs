using System.Collections.Generic;
using System.Linq;
using System.Threading;
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
        private readonly dbContext _db;

        //Create a partial view for the navbar, so that it can be filled based on the data.

        public TournamentsController(dbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken ctx)
        {
            ViewBag.Tournaments = await _db.Tournaments.ToListAsync(ctx);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Categories([FromQuery] int tournamentID, CancellationToken ctx)
        {
            ViewBag.Categories = await _db.Categories.Where(o => o.TournamentID == tournamentID).ToListAsync(ctx);
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ContestSheet([FromQuery] int tID, [FromQuery] int cID, CancellationToken ctx)
        {
            Category category = await _db.Categories.Include(o => o.SheetData).Where(o => o.ID == cID && o.TournamentID == tID).FirstOrDefaultAsync(ctx);
            ViewBag.Title = category.CategoryName;
            ViewBag.CategoryID = category.ID;
            ViewBag.TournamentID = category.TournamentID;
            ViewBag.SVGText = Generators.SVGFactory.Get(category, out ContestType type);
            ViewBag.Type = type.ToString();
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetContestSheetData([FromQuery] int TournamentId, CancellationToken ctx)
        {
            List<ContestSheetData> sheetData = await _db.ContestSheetData.Where(o => o.TournamentID == TournamentId).ToListAsync(ctx);
            return new JsonResult(sheetData);
        }

        [HttpGet]
        public async Task<IActionResult> RenderSVG([FromQuery] int tID, [FromQuery] int cID, CancellationToken ctx)
        {
            Category category = await _db.Categories.Include(o => o.SheetData).Where(o => o.ID == cID && o.TournamentID == tID).FirstOrDefaultAsync(ctx);
            return Ok(Generators.SVGFactory.Get(category, out ContestType type));
        }
    }
}