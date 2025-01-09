using Banking.API.Data;
using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly BankingContext _bankingContext;
    public UserRepository(BankingContext bankingContext) => _bankingContext = bankingContext;
    public void Add(User user)
    {
        _bankingContext.User.Add(user);
        _bankingContext.SaveChanges();
    }

    public User GetByEmail(string email)
    {
        return _bankingContext.User.FirstOrDefault(u => u.Email == email);
    }
    public async Task<User?> GetUserById(int userId)
    {
        return await _bankingContext.User
        .Include(u => u.Account)
        .FirstOrDefaultAsync(u => u.UserId == userId);
    }

}