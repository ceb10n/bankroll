using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using bankroll.service.services.interfaces;
using System;

namespace bankroll.service.services
{
    public class PlayerService : Service<Player>, IPlayerService
    {
        private readonly IPlayerRepository _repository;

        public PlayerService(IPlayerRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public void EditBankroll(Player player)
        {
            _repository.EditBankroll(player);
        }

        public object OverallChartOnlineData(Guid playerId)
        {
            return _repository.OverallChartOnlineData(playerId);
        }

        public object OverallChartLiveData(Guid playerId)
        {
            return _repository.OverallChartLiveData(playerId);
        }

        public object OverallChartWinAndLose(Guid playerId)
        {
            return _repository.OverallChartWinAndLose(playerId);
        }

        public object OverallChartWinOnlineVsLive(Guid playerId)
        {
            return _repository.OverallChartWinOnlineVsLive(playerId);
        }
    }
}
