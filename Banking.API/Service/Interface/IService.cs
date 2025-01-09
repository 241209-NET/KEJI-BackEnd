using Banking.API.DTO;
using Banking.API.Model;

namespace Banking.API.Service;

public interface IUserService
{
    Task<User>CreateAccount(UserDTO newUser);
    Task<User?>GetUserById(int userId);
}

public interface IStatementService
{
    Task<Statement> GetStatementById(int statementId);
}