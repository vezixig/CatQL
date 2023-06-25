namespace Infrastructure;

using Core.Models;
using Microsoft.EntityFrameworkCore;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions options)
        : base(options)
    {
    }

    public DbSet<Cat> Cats { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .Property(b => b.Id)
            .IsRequired();
        modelBuilder.Entity<Cat>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(150);
    }
}