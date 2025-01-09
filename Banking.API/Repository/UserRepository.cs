using Banking.API.Data;
using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Repository;

public class UserRepository : IUserRepository
{
    private readonly BankingContext _bankingContext;
    public UserRepository(BankingContext bankingContext) => _bankingContext = bankingContext;
    public User CreateUser(User newUserDTO)
    {
        _bankingContext.User.Add(newUserDTO);
        _bankingContext.SaveChanges();
        return newUserDTO;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _bankingContext.User
        .Include(u => u.Account)
        .FirstOrDefaultAsync(u => u.UserId == userId);
    }

}