using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Model;

public class Statement
{
    public int StatementId { get; set; }
    public double Amount { get; set; }
    public double Difference { get; set; }
    public DateOnly StartDate { get; set; }

    [ForeignKey("Account")]
    public int AccountId { get; set; }

    public virtual Account? Account { get; set; }
    public virtual ICollection<Activity>? Activities { get; set; }
}