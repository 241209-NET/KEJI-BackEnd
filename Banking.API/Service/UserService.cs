using System.Text.Json;
using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Utils;

namespace Banking.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) => _userRepository = userRepository;

    public UserResponseDTO Register(UserRequestDTO userDTO)
    {

        User user = new();
        DTOToEntityRequest<UserRequestDTO, User>.ToEntity(userDTO, user);

        var repoRes = _userRepository.Add(user);
        UserResponseDTO res = new();
        EntityToDTORequest<User, UserResponseDTO>.ToDTO(repoRes, res);

        return res;
    }



    public Token? Login(LoginDTO loginDTO)
    {
        var user = _userRepository.GetByEmail(loginDTO.Email!);
        if (user == null || !VerifyPassword(loginDTO.Password!, user.Password!)) return null;

        Token token = new()
        {
            account = new()
            {
                Statements = [],
                Activities = []
            }
        };

        EntityToDTORequest<User, Token>.ToDTO(user, token);

        EntityToDTORequest<Account, Token_account>.ToDTO(user.Account!, token.account);

        foreach (Statement s in user.Account!.Statements!)
        {
            Token_statement Ts = new();
            EntityToDTORequest<Statement, Token_statement>.ToDTO(s, Ts);
            token.account.Statements.Add(Ts);
        }

        foreach (Activity a in user.Account.Activities!)
        {
            Token_activity Ta = new();
            EntityToDTORequest<Activity, Token_activity>.ToDTO(a, Ta);
            token.account.Activities.Add(Ta);
        }


        return token;
    }
    private bool VerifyPassword(string password, string hashedPassword)
    {
        // Simulate password verification
        return password == hashedPassword;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _userRepository.GetUserById(userId);
    }



}