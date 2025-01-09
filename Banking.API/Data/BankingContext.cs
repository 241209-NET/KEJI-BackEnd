using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Data;

public class BankingContext : DbContext
{
    public BankingContext() {}
    public BankingContext(DbContextOptions<BankingContext> options) : base(options) {}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Activity>()
            .Property(a => a.IsRecurring)
            .HasDefaultValue(false);

        modelBuilder.Entity<Account>()
            .Property(a => a.Currency)
            .HasDefaultValue("USD");
    }

    public virtual DbSet<Account> Account {get; set;}
    public virtual DbSet<Activity> Activity {get; set;}
    public virtual DbSet<Statement> Statement {get; set;}
    public virtual DbSet<User> User {get; set;}
}