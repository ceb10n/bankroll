using bankroll.domain.entities;
using bankroll.Models;
using bankroll.service.services.interfaces;
using Newtonsoft.Json;
using System;
using System.Web.Mvc;

namespace bankroll.Controllers
{
    public class PlayerController : Controller
    {
        private readonly IPlayerService _service;

        public PlayerController(IPlayerService service)
        {
            _service = service;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditBankroll(EditBankrollModel model)
        {
            var player = AutoMapper.Mapper.Map<Player>(model);
            player.Id = SessionProfile.Player.Id;
            _service.EditBankroll(player);
            SessionProfile.Player.Bankroll = player.Bankroll;

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public JsonResult PlayerBankroll()
        {
            var bankroll = SessionProfile.Player.Bankroll;
            return Json(bankroll.ToString("{0:n0}"), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult OverallChartOnline()
        {
            var values = _service.OverallChartOnlineData(SessionProfile.Player.Id);
            return Json(JsonConvert.SerializeObject(values), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult OverallChartLive()
        {
            var values = _service.OverallChartLiveData(SessionProfile.Player.Id);
            return Json(JsonConvert.SerializeObject(values), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult OverallChartWinAndLose()
        {
            var values = _service.OverallChartWinAndLose(SessionProfile.Player.Id);
            return Json(JsonConvert.SerializeObject(values), JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult OverallChartWinOnlineVsLive()
        {
            var values = _service.OverallChartWinOnlineVsLive(SessionProfile.Player.Id);
            return Json(JsonConvert.SerializeObject(values), JsonRequestBehavior.AllowGet);
        }
    }
}