using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Model;

public class Account 
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int AccountId { get; set; }
    public double Balance { get; set; }
    public string? Currency { get; set; }
    public virtual ICollection<Statement>? Statements { get; set; }
    public virtual ICollection<Activity>? Activities{ get; set; }
}