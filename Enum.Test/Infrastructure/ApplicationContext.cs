using Enum.Test.Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Enum.Test.Infrastructure;

public class ApplicationContext : DbContext
{
    public DbSet<Order> Orders { get; set; }

    public ApplicationContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("DataSource=file::memory:?cache=shared");
        optionsBuilder.LogTo(Console.WriteLine, minimumLevel: Microsoft.Extensions.Logging.LogLevel.Information);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        modelBuilder.Entity<Order>()
            .Property(x => x.Status)
            .HasConversion(x => x.Key, x => OrderStatus.FromKey<OrderStatus>(x));
    }
}