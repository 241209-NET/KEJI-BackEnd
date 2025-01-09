namespace Banking.API.DTO;

public class ActivityResponseDTO
{
    public int ActivityId { get; set; }
    public string? Name { get; set; }
    public double? Amount { get; set; }
    public string? Description { get; set; }
    public bool IsRecurring { get; set; }
    public DateOnly ActivityDate { get; set; }
}