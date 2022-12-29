using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.Tournament;
using EuroJudoWebContestSheets.Models.ViewModels;
using EuroJudoWebContestSheets.Services.Tournament;
using Microsoft.AspNetCore.Mvc;

namespace EuroJudoWebContestSheets.Controllers
{
    /// <summary>
    /// MVC controller for the Tournaments pages
    /// </summary>
    public class TournamentsController : Controller
    {
        private readonly ITournamentService _tournaments;
        private readonly ICategoriesRepository _categories;

        //Create a partial view for the navbar, so that it can be filled based on the data.

        public TournamentsController(ITournamentService tournaments, ICategoriesRepository categories)
        {
            _tournaments = tournaments;
            _categories = categories;
        }

        [HttpGet]
        public async Task<IActionResult> Index(CancellationToken ctx)
        {
            TournamentsViewModel viewModel = new(await _tournaments.All(ctx));
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Categories([FromQuery] int tournamentId, CancellationToken ctx)
        {
            TournamentDto? tournament = await _tournaments.ById(tournamentId, ctx);

            if (tournament == null)
            {
                return new BadRequestResult();
            }
            
            CategoriesViewModel viewModel =
                new CategoriesViewModel(await _tournaments.CategoriesForTournament(tournamentId, ctx), tournament.Name);
            
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ContestSheet([FromQuery] int tId, [FromQuery] int cId, CancellationToken ctx)
        {
            ContestSheetViewModel viewModel = null!;
            
            // TODO: Move to service, somehow
            Category? category = await _categories.WithSheetData(cId, tId, ctx);
            
            if (category != null)
            {
                viewModel = new ContestSheetViewModel(category.CategoryName, category.Id, category.TournamentId, Generators.SVGFactory.Get(category, out _) ?? string.Empty);
            }

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> RenderSVG([FromQuery] int tId, [FromQuery] int cId, CancellationToken ctx)
        {
            Category? category = await _categories.WithSheetData(cId, tId, ctx);
            return Ok(Generators.SVGFactory.Get(category, out ContestType type));
        }
    }
}