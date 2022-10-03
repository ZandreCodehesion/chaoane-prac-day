using Microsoft.EntityFrameworkCore;


namespace PracticalDay.Model;


public class AccountContext : DbContext
{

    public AccountContext(DbContextOptions<AccountContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<AccountModel> AccountModel {get; set;}
    
}