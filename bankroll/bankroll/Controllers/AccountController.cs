using bankroll.domain.entities;
using bankroll.Models;
using bankroll.service.services.interfaces;
using System.Web.Mvc;

namespace bankroll.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            var account = AutoMapper.Mapper.Map<Account>(model);
            var player = _accountService.Login(account);

            if (player == null)
                return RedirectToAction("Login");

            SessionProfile.Player = player;

            if (string.IsNullOrEmpty(returnUrl))
                return RedirectToAction("Index", "Home");

            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterModel model)
        {
            var player = AutoMapper.Mapper.Map<Player>(model);
            var account = AutoMapper.Mapper.Map<Account>(model);

            SessionProfile.Player = _accountService.Register(account, player);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            SessionProfile.Player = null;
            return RedirectToAction("Index", "Home");
        }
    }
}