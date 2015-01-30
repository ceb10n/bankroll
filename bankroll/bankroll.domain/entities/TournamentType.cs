using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bankroll.domain.entities
{
    [Table("TournamentType")]
    public class TournamentType
    {
        public Guid Id { get; set; }

        [Required MaxLength(100)]
        public string Name { get; set; }
    }
}
