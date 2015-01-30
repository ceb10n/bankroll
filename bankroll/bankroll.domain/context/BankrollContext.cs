using bankroll.domain.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.context
{
    public class BankrollContext : DbContext
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<PokerClub> PokerClub { get; set; }
        public DbSet<PokerSite> PokerSite { get; set; }
        public DbSet<PokerClubTournament> PokerClubTournament { get; set; }
        public DbSet<PokerSiteTournament> PokerSiteTournament { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<TournamentType> TournamentType { get; set; }

    }
}
