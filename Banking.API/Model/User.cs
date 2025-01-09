using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Model;

public class User 
{
    public int UserId { get; set; }
    public string? UserName { get; set; }
    public string? Email {get; set;}
    public string? Password { get; set; }
    
    [ForeignKey("Account")]
    public int? AccountId { get; set; }
    
    public virtual Account? Account { get; set; }
}