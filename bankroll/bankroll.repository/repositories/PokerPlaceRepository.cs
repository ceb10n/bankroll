using bankroll.domain.context;
using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bankroll.repository.repositories
{
    public class PokerPlaceRepository : Repository<PokerClub>, IPokerPlaceRepository
    {
        private readonly BankrollContext _context;

        public PokerPlaceRepository(BankrollContext context) :  base(context)
        {
            _context = context;
        }

        public IList<PokerClub> Clubs()
        {
            return _context.PokerClub.OrderBy(x => x.Name).ToList();
        }
        public IList<PokerSite> Sites()
        {
            return _context.PokerSite.OrderBy(x => x.Name).ToList();
        }
        public IList<PokerClubTournament> TournamentsFromClub(Guid id)
        {
            return _context.PokerClubTournament.Where(x => x.PokerClubId == id).OrderBy(x => x.Name).ToList();
        }
        public IList<PokerSiteTournament> TournamentsFromSite(Guid id)
        {
            return _context.PokerSiteTournament.Where(x => x.PokerSiteId == id).OrderBy(x => x.Name).ToList();
        }
    }
}
