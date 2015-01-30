using bankroll.domain.entities;
using System;

namespace bankroll.repository.repositories.interfaces
{
    public interface IPlayerRepository : IRepository<Player>
    {
        void EditBankroll(Player player);
        object OverallChartOnlineData(Guid playerId);
        object OverallChartLiveData(Guid playerId);
        object OverallChartWinAndLose(Guid playerId);
        object OverallChartWinOnlineVsLive(Guid playerId);
    }
}
