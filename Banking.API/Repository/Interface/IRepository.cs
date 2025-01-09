using Banking.API.Model;

namespace Banking.API.Repository;

public interface IUserRepository
{
    void Add(User user);
    User GetByEmail(string email);
    Task<User?>GetUserById(int userId);
}

public interface IStatementRepository
{
    Task<Statement> GetStatementById(int statementId);
}