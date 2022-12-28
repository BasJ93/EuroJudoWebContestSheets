using Microsoft.AspNetCore.Mvc;

namespace EuroJudoWebContestSheets.Controllers
{
    public class ContestOrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}