using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc5;
using bankroll.service.services.interfaces;
using bankroll.service.services;
using bankroll.repository.repositories;
using bankroll.repository.repositories.interfaces;
using bankroll.domain.context;

namespace bankroll
{
    public static class UnityConfig

    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IAccountService, AccountService>();
            container.RegisterType<IAccountRepository, AccountRepository>();

            container.RegisterType<IEntryService, EntryService>();
            container.RegisterType<IEntryRepository, EntryRepository>();

            container.RegisterType<IPokerPlaceService, PokerPlaceService>();
            container.RegisterType<IPokerPlaceRepository, PokerPlaceRepository>();

            container.RegisterType<IPlayerService, PlayerService>();
            container.RegisterType<IPlayerRepository, PlayerRepository>();

            container.RegisterType<BankrollContext>(new InjectionFactory(c => { return MvcApplication.CurrentContext; }));

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}