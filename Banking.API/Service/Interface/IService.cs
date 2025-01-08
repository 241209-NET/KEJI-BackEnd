using Banking.API.DTO;
using Banking.API.Model;

namespace Banking.API.Service;

public interface IUserService
{
    Task<User>CreateAccount(UserDTO newUser);
}