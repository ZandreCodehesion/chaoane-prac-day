using Microsoft.EntityFrameworkCore;

namespace PracticalDay.Model;

public class ContextDb : DbContext
{
    public ContextDb(DbContextOptions<ContextDb> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    public DbSet<BooksModel> BooksModel {get; set;}
    
    public DbSet<AuthorsModel> AuthorsModel {get; set;}
    
    public DbSet<AccountModel> AccountModel {get; set;}
}