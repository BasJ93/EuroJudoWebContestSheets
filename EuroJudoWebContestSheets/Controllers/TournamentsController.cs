using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using EuroJudoWebContestSheets.Hubs;

namespace EuroJudoWebContestSheets.Controllers
{
    public class TournamentsController : Controller
    {

        dbContext _db;
        private readonly IHubContext<TournamentHub> _hub;

        //Create a partial view for the navbar, so that it can be filled based on the data.

        public TournamentsController(dbContext db, IHubContext<TournamentHub> hub)
        {
            _db = db;
            _hub = hub;
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
            ViewBag.SVGText = Generators.SVGFactory.Get(category);
            return View();
        }

        [HttpGet]
        public IActionResult GetContestSheetData([FromQuery] int TournamentId)
        {
            List<ContestSheetData> sheetData = _db.ContestSheetData.Where(o => o.TournamentID == TournamentId).ToList();
            return new JsonResult(sheetData);
        }

        [HttpPost]
        public async Task<IActionResult> PostContestSheetData([FromBody, Required] ContestSheetData contestData)
        {
            if(ModelState.IsValid)
            {
                Console.WriteLine($"{contestData.TournamentID}\t{contestData.CategoryID}\t{contestData.Contest}\t{contestData.CompeditorWhite}");
                ContestSheetData existingContest = await _db.ContestSheetData.Where(o => o.CategoryID == contestData.CategoryID && o.Contest == contestData.Contest).FirstOrDefaultAsync();
                if (existingContest == null)
                {
                    try
                    {
                        await _db.ContestSheetData.AddAsync(contestData);
                        await _db.SaveChangesAsync();
                        await _hub.Clients.Group($"t{contestData.TournamentID}c{contestData.CategoryID}").SendAsync("updateSheet", contestData);
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
                        await _db.SaveChangesAsync();
                    }
                    catch(Exception e)
                    {
                        return BadRequest(e.ToString());
                    }
                    await _hub.Clients.Group($"t{contestData.TournamentID}c{contestData.CategoryID}").SendAsync("updateSheet", existingContest);
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostCategoryData([FromBody, Required] Category category)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _db.Categories.AddAsync(category);
                    await _db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> PostTournamentData([FromBody, Required] Tournament tournament)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _db.Tournaments.AddAsync(tournament);
                    await _db.SaveChangesAsync();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}

/*
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
        */