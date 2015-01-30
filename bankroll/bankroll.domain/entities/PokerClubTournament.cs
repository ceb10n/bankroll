using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("PokerClubTournament")]
    public class PokerClubTournament
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid PokerClubId { get; set; }

        [ForeignKey("PokerClubId")]
        public virtual PokerClub PokerClub { get; set; }
    }
}
