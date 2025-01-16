using Banking.API.DTO;
using Banking.API.Model;

namespace Banking.API.Service;

public interface IUserService
{
    UserResponseDTO Register(UserRequestDTO userDTO);
    Token? Login(LoginDTO loginDTO);
    Task<User?>GetUserById(int userId);
    User? GetByEmail(string email);
}

public interface IStatementService
{
    Task<Statement> GetStatement(DateOnly date, int accountId);
}