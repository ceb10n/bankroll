using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("PokerSiteTournament")]
    public class PokerSiteTournament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PokerSiteId { get; set; }
        public Guid? TournamentTypeId { get; set; }

        [ForeignKey("PokerSiteId")]
        public virtual PokerSite PokerSite { get; set; }

        [ForeignKey("TournamentTypeId")]
        public virtual TournamentType TournamentType { get; set; }
    }
}
