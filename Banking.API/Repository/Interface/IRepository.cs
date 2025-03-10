using Banking.API.Model;

namespace Banking.API.Repository;

public interface IUserRepository
{
    public void UpdateAmmount(double amount, int id);
    User Add(User user);
    User GetByEmail(string email);
    Task<User?>GetUserById(int userId);
}

public interface IStatementRepository
{
    Task<Statement> GetStatement(DateOnly date, int accountId);
    public Statement GetStatementById(int id);
}