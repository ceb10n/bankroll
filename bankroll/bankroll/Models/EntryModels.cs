using System;
using System.ComponentModel.DataAnnotations;

namespace bankroll.Models
{
    public class NewEntry
    {
        [Required]
        public decimal BuyIn { get; set; }
        public decimal CashOut { get; set; }
        public bool Online { get; set; }
        public DateTime Date { get; set; }
        public Guid? PokerPlaceId { get; set; }
        public Guid? TournamentId { get; set; }
    }

    public class EditEntry
    {
        public Guid Id { get; set; }
        [Required]
        public decimal BuyIn { get; set; }
        public decimal CashOut { get; set; }
        public bool Online { get; set; }
        public DateTime Date { get; set; }
        public Guid? PokerPlaceId { get; set; }
        public Guid? TournamentId { get; set; }
        public Guid PlayerId { get; set; }
    }
}