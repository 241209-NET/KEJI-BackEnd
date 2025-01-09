using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;

namespace Banking.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) => _userRepository = userRepository;
    public async Task<User> CreateAccount(UserDTO newUser)
    {
        
        User fromDTO = newUser.DTOToUser();
        var user = await _userRepository.CreateAccount(fromDTO);
        return user;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _userRepository.GetUserById(userId);
    }
}