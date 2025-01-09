namespace Banking.API.DTO;

public class ActivityRequestDTO
{
    public string? Name { get; set; }
    public double? Amount { get; set; }
    public string? Description { get; set; }
    public bool IsRecurring { get; set; }
    public DateOnly ActivityDate { get; set; }
    public int AccountId { get; set; }
}