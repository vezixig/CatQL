namespace CatQL.Infrastructure;

using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

internal class DataContext : DbContext
{
    public DbSet<Cat> Cats { get; set; }

    public DbSet<Breed> Breeds { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 33));
        var connectionString = "server=localhost;user=root;password=#Science21;database=catql";

        optionsBuilder.UseMySql(connectionString, serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cat>()
            .Property(b => b.Id)
            .IsRequired();
        modelBuilder.Entity<Cat>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(150);

        modelBuilder.Entity<Breed>()
            .Property(b => b.Id)
            .IsRequired();
        modelBuilder.Entity<Breed>()
            .Property(b => b.Name)
            .IsRequired()
            .HasMaxLength(150);
    }
}