using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace bankroll.domain.entities
{
    [Table("Player")]
    public class Player
    {
        
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }

        [MaxLength(100)]
        public string Name { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        [EmailAddress MinLength(10) MaxLength(100) Index(IsUnique = true)]
        public string Email { get; set; }

        public decimal Bankroll { get; set; }

        [ForeignKey("AccountId")]
        public Account Account { get; set; }

        public IQueryable<Entry> Entries { get; set; }

        public void AddEntryToBankroll(Entry entry)
        {
            var buyin = entry.BuyIn;
            var cashout = entry.CashOut.HasValue ? entry.CashOut.Value : 0m;

            Bankroll += (cashout - buyin);
        }
    }
}
