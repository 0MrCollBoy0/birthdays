using Birthdays.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Birthdays.Infrastructure;

public class PersonDbContext:DbContext
{
    public DbSet<Person> Persons { get; set; } = null!;

    private bool bl;
    
    public PersonDbContext(DbContextOptions options) : base(options)
    {
        if (Database.EnsureCreated()) bl = true;
            
    }
    public bool Valid()
    {
        return bl;
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().Property(x => x.Birthday)
            .HasConversion(d => d, d => DateTime.SpecifyKind(d, DateTimeKind.Utc));
    }
}