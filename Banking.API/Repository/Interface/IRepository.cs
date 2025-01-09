using Banking.API.Model;

namespace Banking.API.Repository;

public interface IUserRepository
{
    User CreateUser(User newUserDTO);
    Task<User?>GetUserById(int userId);
}

public interface IStatementRepository
{
    Task<Statement> GetStatementById(int statementId);
}