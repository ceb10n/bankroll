using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankroll.domain.entities
{
    [Table("Entry")]
    public class Entry
    {
        public Guid Id { get; set; }

        [Required]
        public decimal BuyIn { get; set; }

        public decimal? CashOut { get; set; }

        public bool? Online { get; set; }

        public DateTime Date { get; set; }

        public Guid? PlayerId { get; set; }

        public Guid? PokerClubId { get; set; }

        public Guid? PokerSiteId { get; set; }

        public Guid? ClubTournamentId { get; set; }

        public Guid? SiteTournamentId { get; set; }

        [ForeignKey("PlayerId")]
        public virtual Player Player { get; set; }

        [ForeignKey("PokerClubId")]
        public virtual PokerClub PokerClub { get; set; }

        [ForeignKey("PokerSiteId")]
        public virtual PokerSite PokerSite { get; set; }

        [ForeignKey("SiteTournamentId")]
        public virtual PokerSiteTournament SiteTournament { get; set; }

        [ForeignKey("ClubTournamentId")]
        public virtual PokerClubTournament PokerClubTournament { get; set; }
    }
}
