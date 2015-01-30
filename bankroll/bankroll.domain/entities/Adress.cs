using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("Adress")]
    public class Adress
    {
        public Guid Id { get; set; }
        public string Street { get; set; }
        public string Complement { get; set; }
        public string Number { get; set; }
        public string District { get; set; }
        public string ZipCode { get; set; }
        
        public Guid? CityId { get; set; }

        [ForeignKey("CityId")]
        public virtual City City { get; set; }
    }
}
