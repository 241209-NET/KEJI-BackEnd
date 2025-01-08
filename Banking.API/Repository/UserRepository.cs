using Banking.API.Data;
using Banking.API.Model;

namespace Banking.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly BankingContext _bankingContext;
    public UserRepository(BankingContext bankingContext) => _bankingContext = bankingContext;
    public async Task<User> CreateAccount(User newUser)
    {
        await _bankingContext.User.AddAsync(newUser);
        await _bankingContext.SaveChangesAsync();
        return newUser;
    }
}