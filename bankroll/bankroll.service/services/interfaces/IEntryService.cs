using bankroll.domain.entities;
using System;
using System.Collections.Generic;

namespace bankroll.service.services.interfaces
{
    public interface IEntryService : IService<Entry>
    {
        IList<Entry> EntriesFromPlayer(Player player, DateTime? since = null);
    }
}
