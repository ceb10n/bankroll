using bankroll.domain.entities;
using System;
using System.Collections.Generic;

namespace bankroll.service.services.interfaces
{
    public interface IPokerPlaceService : IService<PokerClub>
    {
        IList<PokerClub> Clubs();
        IList<PokerSite> Sites();
        IList<PokerClubTournament> TournamentsFromClub(Guid id);
        IList<PokerSiteTournament> TournamentsFromSite(Guid id);
    }
}
