using Banking.API.DTO;
using Banking.API.Model;
using Banking.API.Repository;
using Banking.API.Utils;

namespace Banking.API.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository) => _userRepository = userRepository;
    
    public User CreateUser(UserDTO newUserDTO)
    {
        User fromDTO = newUserDTO.DTOToUser();
        User fromDTO2 = Utilities.DTOToObject(newUserDTO);
        var user = _userRepository.CreateUser(fromDTO);
        return user;
    }

    public async Task<User?> GetUserById(int userId)
    {
        return await _userRepository.GetUserById(userId);
    }
}