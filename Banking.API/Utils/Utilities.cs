using Banking.API.DTO;
using Banking.API.Model;

namespace Banking.API.Utils;

public static class Utilities
{
    public static User DTOToObject(UserDTO userDTO)
    {
         return new User{UserName = userDTO.UserName, Email = userDTO.Email, Password = userDTO.Password};
    }
}