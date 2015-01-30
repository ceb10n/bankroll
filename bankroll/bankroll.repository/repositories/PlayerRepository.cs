using bankroll.domain.context;
using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace bankroll.repository.repositories
{
    public class PlayerRepository : Repository<Player>, IPlayerRepository
    {
        private readonly BankrollContext _context;
        public PlayerRepository(BankrollContext context) : base(context)
        {
            _context = context;
        }

        public void EditBankroll(Player player)
        {
            var existingPlayer = _context.Player.Find(player.Id);

            existingPlayer.Bankroll = player.Bankroll;
            _context.Entry(existingPlayer).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public object OverallChartWinOnlineVsLive(Guid playerId)
        {
            var entries = _context.Set<Entry>().Where(x => x.PlayerId == playerId).ToList();

            return new object[]
            {
                new object[] {
                    "Online",
                    entries.Where(x => x.Online.HasValue && x.Online.Value).Sum(x => (x.CashOut - x.BuyIn))
                },
                new object[] {
                    "Live",
                    entries.Where(x => x.Online.HasValue && x.Online.Value == false).Sum(x => (x.CashOut - x.BuyIn))
                }
            };
        }

        public object OverallChartWinAndLose(Guid playerId)
        {
            var entries = _context.Set<Entry>().Where(x => x.PlayerId == playerId)
                .GroupBy(x => DbFunctions.TruncateTime(x.Date)).Select(x => new
                {
                    Date = x.Key,
                    Balance = x.Sum(y => (y.CashOut - y.BuyIn))
                }).ToDictionary(x => x.Date, x => x.Balance);

            return new object[]
            {
                new object[] {
                    "Win",
                    entries.Where(x => x.Value > 0).Count()
                },
                new object[] {
                    "Lose",
                    entries.Where(x => x.Value < 0).Count()
                },
                new object[] {
                    "Tied",
                    entries.Where(x => x.Value == 0).Count()
                }
            };
        }

        public object OverallChartOnlineData(Guid playerId)
        {
            var entries = _context.Set<Entry>().Where(x => x.PlayerId == playerId && x.Online.HasValue && x.Online.Value)
                .OrderBy(y => y.Date).ToList();

            return FormatDataToOverallChart(entries, "Online");
        }

        public object OverallChartLiveData(Guid playerId)
        {
            var entries = _context.Set<Entry>().Where(x => x.PlayerId == playerId && x.Online.HasValue && x.Online.Value == false)
                .OrderBy(y => y.Date).ToList();

            return FormatDataToOverallChart(entries, "Live");
        }

        private object FormatDataToOverallChart(List<Entry> entries, string yTitle)
        {
            var years = entries.Select(date => date.Date.Year).Distinct().ToList();
            object[] xAxis;
            object yAxis;

            if (years.Count() == 1)
            {
                xAxis = new object[] { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
                yAxis = new object[]
                {
                    new {
                        name = yTitle,
                        data = new object[] {
                            SumOfAllEntriesOfMonth(entries, 1),
                            SumOfAllEntriesOfMonth(entries, 2),
                            SumOfAllEntriesOfMonth(entries, 3),
                            SumOfAllEntriesOfMonth(entries, 4),
                            SumOfAllEntriesOfMonth(entries, 5),
                            SumOfAllEntriesOfMonth(entries, 6),
                            SumOfAllEntriesOfMonth(entries, 7),
                            SumOfAllEntriesOfMonth(entries, 8),
                            SumOfAllEntriesOfMonth(entries, 9),
                            SumOfAllEntriesOfMonth(entries, 10),
                            SumOfAllEntriesOfMonth(entries, 11),
                            SumOfAllEntriesOfMonth(entries, 12)
                        }
                    }
                };
            }
            else
            {
                xAxis = new object[years.Count()];
                var y = new object[years.Count()];

                for (int i = 0; i < years.Count(); i++)
                {
                    xAxis[i] = years[i];
                    y[i] = entries.Where(x => x.Date.Year == years[i]).Sum(x => (x.CashOut - x.BuyIn));
                }

                yAxis = new object[] {
                    new {
                        name = yTitle,
                        data = y
                    }
                };
            }

            return new
            {
                x = xAxis,
                y = yAxis
            };
        }

        private decimal SumOfAllEntriesOfMonth(List<Entry> entries, int month)
        {
            return entries.Where(x => x.Date.Month == month)
                .Sum(x => ((x.CashOut.HasValue ? x.CashOut.Value : 0) - x.BuyIn));
        }
    }
}
