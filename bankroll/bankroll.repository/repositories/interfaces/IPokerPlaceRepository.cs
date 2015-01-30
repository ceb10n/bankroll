using bankroll.domain.entities;
using System;
using System.Collections.Generic;

namespace bankroll.repository.repositories.interfaces
{
    public interface IPokerPlaceRepository : IRepository<PokerClub>
    {
        IList<PokerClub> Clubs();
        IList<PokerSite> Sites();
        IList<PokerClubTournament> TournamentsFromClub(Guid id);
        IList<PokerSiteTournament> TournamentsFromSite(Guid id);
    }
}
