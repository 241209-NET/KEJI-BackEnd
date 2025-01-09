using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Utils;

namespace Banking.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) => _userRepository = userRepository;
    
    public UserDTO Register(UserDTO userDTO)
    {
        var user = new User
        {
            UserName = userDTO.UserName,
            Email = userDTO.Email,
            Password = userDTO.Password,
            AccountId = (int)userDTO.AccountId
        };
        _userRepository.Add(user);
        return MapToDto(user);
    }
    private UserDTO MapToDto(User user)
    {
        return new UserDTO
        {
            UserId = user.UserId,
            UserName = user.UserName,
            Email = user.Email,
            AccountId = user.AccountId
        };
    }


    public string Login(LoginDTO loginDTO)
    {
        var user = _userRepository.GetByEmail(loginDTO.Email);
        if (user == null || !VerifyPassword(loginDTO.Password, user.Password)) return null;

        // Simulate generating a JWT or session token
        return "SampleToken";
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