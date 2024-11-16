using Microsoft.EntityFrameworkCore;

namespace PhoneBook.Core;

public class AppContext : DbContext
{
    public DbSet<Abonent> Abonents { get; set; }

    public AppContext()
    {
        Database.EnsureCreated();
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=phonebook.db");
    }
}