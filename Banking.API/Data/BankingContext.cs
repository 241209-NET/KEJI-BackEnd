using Banking.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Banking.API.Data;

public class BankingContext : DbContext
{
    public BankingContext() {}
    public BankingContext(DbContextOptions<BankingContext> options) : base(options) {}

    public virtual DbSet<Account> Account {get; set;}
    public virtual DbSet<Activity> Activity {get; set;}
    public virtual DbSet<Statement> Statement {get; set;}
    public virtual DbSet<User> User {get; set;}
}