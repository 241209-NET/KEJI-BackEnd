using Banking.API.Data;
using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly BankingContext _bankingContext;
    public UserRepository(BankingContext bankingContext) => _bankingContext = bankingContext;
    public User Add(User user)
    {
        _bankingContext.User.Add(user);
        _bankingContext.SaveChanges();
        return user;
    }

    public User GetByEmail(string email)
    {
        var user = _bankingContext.User.Single(u => u.Email == email);

        _bankingContext.Entry(user)
        .Reference(a => a.Account)
        .Query()
        .Include(a => a.Statements)
        .Include(a => a.Activities)
        .Load();

        return user;

    }
    public async Task<User?> GetUserById(int userId)
    {
        return await _bankingContext.User
        .Include(u => u.Account)
        .FirstOrDefaultAsync(u => u.UserId == userId);
    }

    public void UpdateAmmount(double amount, int id){
        var user = _bankingContext.Account.Single(a => a.AccountId == id);

        user.Balance = amount;
    }

}