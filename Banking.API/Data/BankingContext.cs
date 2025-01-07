using Microsoft.EntityFrameworkCore;

namespace Banking.API.Data;

public class BankingContext : DbContext
{
    public BankingContext() {}
    public BankingContext(DbContextOptions<BankingContext> options) : base(options) {}
}