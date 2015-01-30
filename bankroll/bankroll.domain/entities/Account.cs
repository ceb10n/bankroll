using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankroll.domain.entities
{
    [Table("Account")]
    public class Account
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(100)]
        [Index(IsUnique = true)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        [MaxLength(20)]
        public string Password { get; set; }
    }
}
