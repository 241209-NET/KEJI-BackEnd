namespace Banking.API.DTO;

public class AccountResponseDTO
{
    public int AccountId { get; set; }
    public double Balance { get; set; }
    public string? Currency { get; set; }
}