using bankroll.domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.repository.repositories.interfaces
{
    public interface IEntryRepository : IRepository<Entry>
    {
        IList<Entry> EntriesFromPlayer(Player player, DateTime? since = null);
    }
}
