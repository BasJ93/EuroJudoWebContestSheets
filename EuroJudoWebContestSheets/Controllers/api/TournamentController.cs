using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Extentions;
using EuroJudoWebContestSheets.Hubs;
using EuroJudoWebContestSheets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace EuroJudoWebContestSheets.Controllers.api
{
    /// <summary>
    /// API controller for the tournament related data.
    /// </summary>
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TournamentController : ControllerBase
    {
        private readonly dbContext _db;
        private readonly IHubContext<TournamentHub> _hub;

        public TournamentController(dbContext db, IHubContext<TournamentHub> hub)
        {
            _db = db;
            _hub = hub;
        }

        /// <summary>
        /// Endpoint for the uploader client to create or update the result of a contest.
        /// </summary>
        /// <param name="contestData"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostContestSheetData([FromBody, Required] ContestSheetData contestData, CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine($"{contestData.TournamentID}\t{contestData.CategoryID}\t{contestData.Contest}\t{contestData.CompeditorWhite}");
                ContestSheetData existingContest = await _db.ContestSheetData.Where(o => o.TournamentID == contestData.TournamentID && o.CategoryID == contestData.CategoryID && o.Contest == contestData.Contest).FirstOrDefaultAsync(cancellationToken: ctx);
                Category category = await _db.Categories.Include(o => o.SheetData).Where(c => c.ID == contestData.CategoryID && c.TournamentID == contestData.TournamentID).FirstOrDefaultAsync(cancellationToken: ctx);
                if (existingContest == null)
                {
                    try
                    {
                        await _db.ContestSheetData.AddAsync(contestData, ctx);
                        await _db.SaveChangesAsync(ctx);

                        await UpdateClients(category.GetContestType(), contestData, category, ctx);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.ToString());
                    }
                    return Ok();
                }
                else
                {
                    Console.WriteLine($"{existingContest.ID}");
                    existingContest.UpdateFromQuery(contestData);
                    try
                    {
                        await _db.SaveChangesAsync(ctx);
                    }
                    catch (Exception e)
                    {
                        return BadRequest(e.ToString());
                    }

                    await UpdateClients(category.GetContestType(), contestData, category, ctx);
                }
                return Ok();
            }
            return BadRequest();
        }

        private async Task UpdateClients(ContestType type, ContestSheetData contest, Category category, CancellationToken ctx = default)
        {
            if (type == ContestType.RoundRobin)
            {
                var rrDto = contest.ToRoundRobinDto(category);
                await _hub.Clients.Group($"t{contest.TournamentID}c{contest.CategoryID}").SendAsync("updateSheet", rrDto, ctx);
            }
            else
            {
                var dto = contest.ToDTO();
                await _hub.Clients.Group($"t{contest.TournamentID}c{contest.CategoryID}").SendAsync("updateSheet", dto, ctx);
            }
        }

        /// <summary>
        /// Endpoint for the uploader client to create a new category in the web database.
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostCategoryData([FromBody, Required] Category category, CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _db.Categories.AddAsync(category, ctx);
                    await _db.SaveChangesAsync(ctx);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Endpoint for the uploader client to create a new tournament in the web database.
        /// </summary>
        /// <param name="tournament"></param>
        /// <returns></returns>
        [HttpPost]
        [Consumes("application/json")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostTournamentData([FromBody, Required] Tournament tournament, CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _db.Tournaments.AddAsync(tournament, ctx);
                    await _db.SaveChangesAsync(ctx);
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
            return BadRequest();
        }

        /// <summary>
        /// Endpoint for the uploader client to retreive the category id for a given category.
        /// </summary>
        /// <param name="tournamentID"></param>
        /// <param name="categoryShort"></param>
        /// <param name="weight"></param>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(int), 200)]
        public async Task<IActionResult> GetCategoryId([FromQuery, Required] int tournamentID, [FromQuery, Required] string categoryShort, [FromQuery, Required] string weight, CancellationToken ctx)
        {
            if (ModelState.IsValid)
            {
                var category = await _db.Categories.Where(c => c.TournamentID == tournamentID && c.Short == categoryShort && c.Weight == weight).FirstOrDefaultAsync(cancellationToken: ctx);
                if (category != default)
                {
                    return new JsonResult(category.ID);
                }
                return NotFound();
            }
            return BadRequest();
        }
    }
}