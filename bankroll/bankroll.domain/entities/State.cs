using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("State")]
    public class State
    {
        public Guid Id { get; set; }

        [Required MaxLength(2)]
        public string UF { get; set; }

        [Required MaxLength(200)]
        public string Name { get; set; }

        [Required]
        public string CountryIso { get; set; }

        [ForeignKey("CountryIso")]
        public virtual Country Country { get; set; }
    }
}
