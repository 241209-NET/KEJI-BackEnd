using System.Data;

namespace Banking.API.Model;

public class Account 
{
    public int AccountId { get; set; }
    public double Balance { get; set; }
    public string? Currency { get; set; }
    public ICollection<Statement>? Statements { get; set; }
}