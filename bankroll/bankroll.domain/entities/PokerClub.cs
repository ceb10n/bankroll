using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("PokerClub")]
    public class PokerClub
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public Guid? AdressId { get; set; }

        [ForeignKey("AdressId")]
        public virtual Adress Adress { get; set; }
    }
}
