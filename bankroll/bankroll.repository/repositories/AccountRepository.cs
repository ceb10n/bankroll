using bankroll.domain.context;
using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using System;
using System.Linq;

namespace bankroll.repository.repositories
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        private readonly BankrollContext _context;
        private readonly IPlayerRepository _playerRepository;
        public AccountRepository(BankrollContext context, IPlayerRepository playerRepository) : base(context)
        {
            _context = context;
            _playerRepository = playerRepository;
        }

        public Player Login(Account account)
        {
            var playerAccount = _context.Account.FirstOrDefault(x => x.Password == account.Password && x.Username == account.Username);

            if (playerAccount == null || playerAccount.Id == Guid.Empty)
                throw new Exception();

            return _context.Player.FirstOrDefault(x => x.AccountId == playerAccount.Id);
        }

        public Player Register(Account account, Player player)
        {
            account.Id = Guid.NewGuid();
            player.Id = Guid.NewGuid();

            Add(account);
            _context.SaveChanges();
            player.Account = account;

            _playerRepository.Add(player);
            _context.SaveChanges();

            return player;
        }
    }
}
