using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Authentication;
using EuroJudoWebContestSheets.Authorization;
using EuroJudoWebContestSheets.Database.Models;
using EuroJudoWebContestSheets.Database.Repositories.Interfaces;
using EuroJudoWebContestSheets.Extensions;
using EuroJudoWebContestSheets.Hubs;
using EuroJudoWebContestSheets.Models;
using EuroJudoWebContestSheets.Models.Tournament;
using EuroJudoWebContestSheets.Services.Tournament;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;

namespace EuroJudoWebContestSheets.Controllers.api
{
    /// <summary>
    /// API controller for the tournament related data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    [Authorize]
    public class TournamentController : ControllerBase
    {
        private readonly ILogger<TournamentController> _logger;

        private readonly ITournamentService _tournamentService;
        private readonly ICategoryService _categoryService;

        private readonly ICategoriesRepository _categories;
        private readonly IContestSheetDataRepository _sheetData;
        private readonly IHubContext<TournamentHub> _hub;

        public TournamentController(IHubContext<TournamentHub> hub, ICategoriesRepository categories,
            IContestSheetDataRepository sheetData, ILogger<TournamentController> logger,
            ITournamentService tournamentService, ICategoryService categoryService)
        {
            _categories = categories;
            _sheetData = sheetData;
            _logger = logger;
            _tournamentService = tournamentService;
            _categoryService = categoryService;
            _hub = hub;
        }

        /// <summary>
        /// Endpoint for the uploader client to create or update the result of a contest.
        /// </summary>
        /// <param name="contestData"></param>
        /// <param name="ctx">Cancellation token</param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UnauthorizedProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ForbiddenProblemDetails), StatusCodes.Status403Forbidden)]
        [Authorize(Policy = Policies.Uploader)]
        public async Task<IActionResult> PostContestSheetData([FromBody, Required] UploadContestResultDto contestData,
            CancellationToken ctx)
        {
            // TODO: Replace with a call to the correct service, and move the logic to that service. 
            
            if (ModelState.IsValid)
            {
                _logger.LogInformation(
                    $"New data for contest: {contestData.TournamentId}\t{contestData.CategoryId}\t{contestData.Contest}\t{contestData.CompetitorWhite}\t{contestData.CompetitorBlue}.");

                ContestSheetData? existingContest = await _sheetData.ByTournamentAndCategory(contestData.TournamentId,
                    contestData.CategoryId, contestData.Contest, ctx);

                Category? category =
                    await _categories.WithSheetData(contestData.CategoryId, contestData.TournamentId, ctx);

                if (existingContest == null && category != null)
                {
                    ContestSheetData newContest = new ContestSheetData()
                    {
                        TournamentId = contestData.TournamentId,
                        CategoryId = contestData.CategoryId,
                        Contest = contestData.Contest,
                    }.UpdateFromQuery(contestData);

                    try
                    {
                        await _sheetData.Insert(newContest, ctx);

                        await UpdateClients(newContest, category, ctx);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.ToString());
                    }

                    return Ok();
                }

                _logger.LogInformation("Updating existing contest [{contestId}].", existingContest.Id);
                existingContest = existingContest.UpdateFromQuery(contestData);
                if (category != null)
                {
                    try
                    {
                        await _sheetData.Update(existingContest, ctx);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.ToString());
                    }

                    await UpdateClients(existingContest, category, ctx);
                }

                return Ok();
            }

            return BadRequest();
        }

        /// <summary>
        /// Endpoint for the uploader client to create a new category in the web database.
        /// </summary>
        /// <param name="category"></param>
        /// <param name="ctx">Cancellation token</param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(CategoryDto), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UnauthorizedProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ForbiddenProblemDetails), StatusCodes.Status403Forbidden)]
        [Authorize(Policy = Policies.Uploader)]
        public async Task<IActionResult> PostCategoryData([FromBody, Required] CreateCategoryDto category,
            CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    CategoryDto? createdCategory = await _categoryService.CreateNewCategory(category, ctx);

                    return Ok(createdCategory);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest();
        }

        /// <summary>
        /// Endpoint for the uploader client to create a new tournament in the web database.
        /// </summary>
        /// <param name="tournament">Request model containing the name of the tournament to create.</param>
        /// <param name="ctx">Cancellation token</param>
        /// <returns>The data for the created tournament, both the provided name and the assigned id.</returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(TournamentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(400)]
        [ProducesResponseType(typeof(UnauthorizedProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ForbiddenProblemDetails), StatusCodes.Status403Forbidden)]
        [Authorize(Policy = Policies.Uploader)]
        public async Task<IActionResult> PostTournamentData([FromBody, Required] CreateTournamentDto tournament,
            CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    TournamentDto? response = await _tournamentService.CreateTournament(tournament, ctx);
                    return Ok(response);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }

            return BadRequest();
        }

        /// <summary>
        /// Endpoint for the uploader client to retrieve the category id for a given category.
        /// </summary>
        /// <param name="requestDto">The request DTO describing the category the client wants the Id for.</param>
        /// <param name="ctx">Cancellation token</param>
        /// <returns>The Id of the category.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(UnauthorizedProblemDetails), StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ForbiddenProblemDetails), StatusCodes.Status403Forbidden)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Authorize(Policy = Policies.Uploader)]
        public async Task<IActionResult> GetCategoryId([FromQuery] CategoryIdRequestDto requestDto,
            CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                int? category = await _categoryService.GetIdByShortAndWeight(requestDto, ctx);
                if (category != default)
                {
                    return new JsonResult(category);
                }

                return NotFound();
            }

            return BadRequest();
        }

        /// <summary>
        /// Endpoint for the uploader client to retrieve a list of all known tournaments on the webserver.
        /// </summary>
        /// <param name="ctx">Cancellation token</param>
        /// <returns>The list of known tournaments.</returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<TournamentDto>), StatusCodes.Status200OK)]
        [Authorize(Policy = Policies.Uploader)]
        public async Task<IActionResult> All(CancellationToken ctx)
        {
            IList<TournamentDto> tournaments = await _tournamentService.All(ctx);
            return new JsonResult(tournaments);
        }

        /// <summary>
        /// Endpoint fot the uploader client to retrieve a list of known categories for a given tournament on the webserver.
        /// </summary>
        /// <param name="tournamentId">The id of the tournament to load the categories for.</param>
        /// <param name="ctx">Cancellation token.</param>
        /// <returns>The list of known categories for a given tournament.</returns>
        [HttpGet, Route("~/api/Tournament/categories/all")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IList<CategoryDto>), StatusCodes.Status200OK)]
        [Authorize(Policy = Policies.Uploader)]
        public async Task<IActionResult> AllCategories([FromQuery]int tournamentId, CancellationToken ctx)
        {
            IList<CategoryDto> categories = await _tournamentService.CategoriesForTournament(tournamentId, ctx);

            return new JsonResult(categories);
        }
        
        private async Task UpdateClients(ContestSheetData contest, Category? category,
            CancellationToken ctx = default)
        {
            if (category != null)
            {
                ContestType type = category.GetContestType();

                if (type == ContestType.RoundRobin)
                {
                    var rrDto = contest.ToRoundRobinDto(category);
                    await _hub.Clients.Group($"t{contest.TournamentId}c{contest.CategoryId}")
                        .SendAsync("updateSheet", rrDto, ctx);
                }
                else
                {
                    var dto = contest.ToDTO();
                    await _hub.Clients.Group($"t{contest.TournamentId}c{contest.CategoryId}")
                        .SendAsync("updateSheet", dto, ctx);
                }
            }
        }
    }
}