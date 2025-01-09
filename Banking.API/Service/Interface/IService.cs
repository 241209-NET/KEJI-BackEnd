using Banking.API.DTO;
using Banking.API.Model;

namespace Banking.API.Service;

public interface IUserService
{
    UserDTO Register(UserDTO userDTO);
    string Login(LoginDTO loginDTO);
    Task<User?>GetUserById(int userId);
}

public interface IStatementService
{
    Task<Statement> GetStatementById(int statementId);
}