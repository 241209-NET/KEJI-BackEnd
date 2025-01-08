using System.ComponentModel.DataAnnotations.Schema;

namespace Banking.API.Model;

public class Activity 
{
    public int ActivityId { get; set; }
    public string? Name { get; set; }
    public double? Amount { get; set; }
    public string? Description { get; set; }
    public bool IsRecurring { get; set; }
    public DateOnly ActivityDate { get; set; }
    
    [ForeignKey("Statement")]
    public int? StatementId { get; set; }
    [ForeignKey("Account")]
    public int AccountId { get; set; }
    public virtual Statement? Statement { get; set; }
}