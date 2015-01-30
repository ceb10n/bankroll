using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("PokerSite")]
    public class PokerSite
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Site { get; set; }
    }
}
