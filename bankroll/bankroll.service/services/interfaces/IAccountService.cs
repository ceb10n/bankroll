using bankroll.domain.entities;

namespace bankroll.service.services.interfaces
{
    public interface IAccountService : IService<Account>
    {
        Player Login(Account account);
        Player Register(Account account, Player player);
    }
}
