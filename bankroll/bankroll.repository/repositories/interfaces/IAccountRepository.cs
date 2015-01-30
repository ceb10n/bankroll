using bankroll.domain.entities;

namespace bankroll.repository.repositories.interfaces
{
    public interface IAccountRepository : IRepository<Account>
    {
        Player Login(Account account);
        Player Register(Account account, Player player);
    }
}
