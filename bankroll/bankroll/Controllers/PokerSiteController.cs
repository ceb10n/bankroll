using bankroll.service.services.interfaces;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace bankroll.Controllers
{
    public class PokerSiteController : Controller
    {
        private readonly IPokerPlaceService _pokerPlaceService;

        public PokerSiteController(IPokerPlaceService pokerPlaceService)
        {
            _pokerPlaceService = pokerPlaceService;
        }

        [HttpGet]
        public JsonResult PokerSites()
        {
            var sites = _pokerPlaceService.Sites();
            return Json(JsonConvert.SerializeObject(sites), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TournamentsFromSite(Guid id)
        {
            var tournaments = _pokerPlaceService.TournamentsFromSite(id);
            return Json(JsonConvert.SerializeObject(tournaments), JsonRequestBehavior.AllowGet);
        }
    }
}