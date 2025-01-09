using Banking.API.Model;

namespace Banking.API.DTO;

public class UserDTO
{
    public string UserName { get; set; } = string.Empty; // Required username
    public string Email { get; set; } = string.Empty; //Required email
    public string Password { get; set; } = string.Empty; // Required password
    public User DTOToUser()
    {
        return new User{UserName = this.UserName, Email = this.Email, Password = this.Password};
    }
}