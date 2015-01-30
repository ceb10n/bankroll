using bankroll.service.services.interfaces;
using System.Web.Mvc;

namespace bankroll.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEntryService _entryService;

        public HomeController(IEntryService entryService)
        {
            _entryService = entryService;
        }
        public ActionResult Index()
        {
            ViewBag.Entries = _entryService.EntriesFromPlayer(SessionProfile.Player);

            return View();
        }
    }
}