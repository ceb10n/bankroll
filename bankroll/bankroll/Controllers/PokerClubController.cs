using bankroll.service.services.interfaces;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace bankroll.Controllers
{
    public class PokerClubController : Controller
    {
        private readonly IPokerPlaceService _pokerPlaceService;

        public PokerClubController(IPokerPlaceService pokerPlaceService)
        {
            _pokerPlaceService = pokerPlaceService;
        }

        [HttpGet]
        public JsonResult PokerClubs()
        {
            var clubs = _pokerPlaceService.Clubs();
            return Json(JsonConvert.SerializeObject(clubs), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult TournamentsFromClub(Guid id)
        {
            var tournaments = _pokerPlaceService.TournamentsFromClub(id);
            return Json(JsonConvert.SerializeObject(tournaments), JsonRequestBehavior.AllowGet);
        }
    }
}