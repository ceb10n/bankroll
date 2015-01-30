using bankroll.domain.context;
using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace bankroll.repository.repositories
{
    public class EntryRepository : Repository<Entry>, IEntryRepository
    {
        private readonly BankrollContext _context;

        public EntryRepository(BankrollContext context) : base(context)
        {
            _context = context;
        }

        public IList<Entry> EntriesFromPlayer(Player player, DateTime? since = null)
        {
            var entries = _context.Entries.Where(x => x.PlayerId == player.Id);

            if (since.HasValue)
                entries = entries.Where(x => x.Date.Date > since.Value.Date);

            return entries.OrderBy(x => x.Date).ToList();
        }
    }
}
