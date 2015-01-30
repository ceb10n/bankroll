using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("Country")]
    public class Country
    {
        [Key]
        [MaxLength(2)]
        public string Iso { get; set; }

        [Required MaxLength(3)]
        public string Iso3 { get; set; }

        [Required MaxLength(300)]
        public string Name { get; set; }
    }
}
