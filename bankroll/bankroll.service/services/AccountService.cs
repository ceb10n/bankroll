using bankroll.domain.entities;
using bankroll.repository.repositories.interfaces;
using bankroll.service.services.interfaces;

namespace bankroll.service.services
{
    public class AccountService : Service<Account>, IAccountService
    {
        private readonly IAccountRepository _repository;

        public AccountService(IAccountRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public Player Login(Account account)
        {
            return _repository.Login(account);
        }

        public Player Register(Account account, Player player)
        {
            return _repository.Register(account, player);
        }
    }
}
