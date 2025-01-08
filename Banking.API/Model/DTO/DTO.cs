using Banking.API.Model;

namespace Banking.API.DTO;

public class UserDTO
{
    public string UserName { get; set; } = string.Empty; // Required username
    public string Password { get; set; } = string.Empty; // Required password
    public User DTOToUser()
    {
        return new User{UserName = this.UserName, Password = this.Password};
    }
}