namespace Banking.API.DTO;

public class UserRequestDTO
{

    public string UserName { get; set; } = string.Empty; // Required username
    public string Email { get; set; } = string.Empty; //Required email
    public string Password { get; set; } = string.Empty; // Required password
    public int AccountId { get; set; }

}

public class UserResponseDTO
{
    public int UserId { get; set; }
    public string UserName { get; set; } = string.Empty; // Required username
    public string Email { get; set; } = string.Empty; //Required email
    public string Password { get; set; } = string.Empty; // Required password
}

public class LoginDTO
{
    public string? Email { get; set; }
    public string? Password { get; set; }
}

public class Token
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Token_account? account { get; set; }
}

public class Token_account
{
    public int AccountId { get; set; }
    public double Balance { get; set; }
    public string? Currency { get; set; }
    public virtual ICollection<Token_statement>? Statements { get; set; }
    public virtual ICollection<Token_activity>? Activities{ get; set; }
}

public class Token_statement
{
    public int StatementId { get; set; }
    public DateOnly StartDate { get; set; }
    public virtual ICollection<Token_activity>? Activities{ get; set; }
}

public class Token_activity
{
    public int ActivityId { get; set; }
    public string? Name { get; set; }
    public double? Amount { get; set; }
    public string? Description { get; set; }
    public bool IsRecurring { get; set; }
    public DateOnly ActivityDate { get; set; }
    public int? StatementId { get; set; }
}