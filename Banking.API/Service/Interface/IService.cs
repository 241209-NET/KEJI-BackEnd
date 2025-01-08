using Banking.API.DTO;
using Banking.API.Model;

namespace Banking.API.Service;

public interface IUserService
{
    Task<User>CreateAccount(UserDTO newUser);
}

public interface IStatementService
{
    Task<Statement> GetStatementById(int statementId);
}