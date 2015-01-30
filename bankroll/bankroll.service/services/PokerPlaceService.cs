using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using bankroll.service.services.interfaces;
using System;
using System.Collections.Generic;

namespace bankroll.service.services
{
    public class PokerPlaceService : Service<PokerClub>, IPokerPlaceService
    {
        private readonly IPokerPlaceRepository _repository;

        public PokerPlaceService(IPokerPlaceRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public IList<PokerClub> Clubs()
        {
            return _repository.Clubs();
        }
        public IList<PokerSite> Sites()
        {
            return _repository.Sites();
        }
        public IList<PokerClubTournament> TournamentsFromClub(Guid id)
        {
            return _repository.TournamentsFromClub(id);
        }
        public IList<PokerSiteTournament> TournamentsFromSite(Guid id)
        {
            return _repository.TournamentsFromSite(id);
        }
    }
}
