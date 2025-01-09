using Banking.API.Model;

namespace Banking.API.Repository;

public interface IUserRepository
{
    Task<User>CreateAccount(User newUser);
    Task<User?>GetUserById(int userId);
}

public interface IStatementRepository
{
    Task<Statement> GetStatementById(int statementId);
}