namespace Banking.API.DTO;

public class UserRequestDTO
{

    public string UserName { get; set; } = string.Empty; // Required username
    public string Email { get; set; } = string.Empty; //Required email
    public string Password { get; set; } = string.Empty; // Required password

}

public class UserResponseDTO
{
    public int UserId { get; set;}
    public string UserName { get; set; } = string.Empty; // Required username
    public string Email { get; set; } = string.Empty; //Required email
    public string Password { get; set; } = string.Empty; // Required password
}

public class LoginDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}