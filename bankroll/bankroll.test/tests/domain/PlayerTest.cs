using bankroll.domain.entities;
using NUnit.Framework;

namespace bankroll.test.tests.domain
{
    [TestFixture]
    public class PlayerTest
    {
        [Test]
        public void must_add_the_cashout_correctly()
        {
            var player = new Player { Bankroll = 100m };

            player.AddEntryToBankroll(new Entry { BuyIn = 10m, CashOut = 20m });

            Assert.AreEqual(110m, player.Bankroll);
        }

        [Test]
        public void must_subtract_the_buy_in_correctly()
        {
            var player = new Player { Bankroll = 100m };

            player.AddEntryToBankroll(new Entry { BuyIn = 10m });

            Assert.AreEqual(90m, player.Bankroll);
        }
    }
}
