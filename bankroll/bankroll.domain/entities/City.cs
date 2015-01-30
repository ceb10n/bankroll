using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("City")]
    public class City
    {
        public Guid Id { get; set; }

        [Required MaxLength(200)]
        public string Name { get; set; }

        public Guid StateId { get; set; }

        [ForeignKey("StateId")]
        public virtual State State { get; set; }
    }
}
