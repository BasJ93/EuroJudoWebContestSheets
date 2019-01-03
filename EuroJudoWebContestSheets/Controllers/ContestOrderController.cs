using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EuroJudoWebContestSheets.Models.ContestOrder;
using Microsoft.AspNetCore.Mvc;

namespace EuroJudoWebContestSheets.Controllers
{
    public class ContestOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ContestOrderLists()
        {
            return new JsonResult(new List<ContestOrder>() {
                new ContestOrder(){Tatami = 1, Contests = new List<string>(){"A1", "B1", "C1"}},
                new ContestOrder(){Tatami = 2, Contests = new List<string>(){"A2", "B2", "C2"}},
                new ContestOrder(){Tatami = 3, Contests = new List<string>(){"A3", "B3", "C3"}},
                new ContestOrder(){Tatami = 4, Contests = new List<string>(){"A4", "B4", "C4"}},
                new ContestOrder(){Tatami = 5, Contests = new List<string>(){"A5", "B5", "C5"}},
                new ContestOrder(){Tatami = 6, Contests = new List<string>(){"A5", "B6", "C6"}},
            });
        }
    }
}