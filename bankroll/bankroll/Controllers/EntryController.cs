using bankroll.domain.entities;
using bankroll.Models;
using bankroll.service.services.interfaces;
using System.Web.Mvc;
using System;

namespace bankroll.Controllers
{
    public class EntryController : Controller
    {
        private readonly IPokerPlaceService _pokerPlaceService;
        private readonly IEntryService _entryService;
        private readonly IPlayerService _playerService;

        public EntryController(IEntryService entryService, IPokerPlaceService pokerPlaceService, IPlayerService playerService)
        {
            _entryService = entryService;
            _pokerPlaceService = pokerPlaceService;
            _playerService = playerService;
        }

        public ActionResult Index()
        {
            ViewBag.Entries = _entryService.EntriesFromPlayer(SessionProfile.Player);
            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(NewEntry model)
        {
            var entry = AutoMapper.Mapper.Map<Entry>(model);
            entry.PlayerId = SessionProfile.Player.Id;
            _entryService.Add(entry);

            SessionProfile.Player = _playerService.FindById(SessionProfile.Player.Id);

            return RedirectToAction("Index", "Entry");
        }

        [HttpGet]
        public ActionResult Edit(Guid id)
        {
            var entry = _entryService.FindById(id);
            var model = AutoMapper.Mapper.Map<EditEntry>(entry);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EditEntry model)
        {
            var entry = AutoMapper.Mapper.Map<Entry>(model);
            _entryService.Edit(entry, entry.Id);

            SessionProfile.Player = _playerService.FindById(SessionProfile.Player.Id);

            return RedirectToAction("Index", "Entry");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id)
        {
            var entry = _entryService.FindById(id);
            _entryService.Remove(entry);

            return RedirectToAction("Index", "Entry");
        }
    }
}