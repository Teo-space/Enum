using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

List<Order> orders = [];

orders.Add(new Order
{
    OrderId = 1,
    Date = DateTime.Now,
    Status = OrderStatus.Pending,
});
orders.Add(new Order
{
    OrderId = 2,
    Date = DateTime.Now,
    Status = OrderStatus.Done,
});

using var db = new ApplicationContext();

db.Orders.AddRange(orders);
db.SaveChanges();

Console.WriteLine(db.Orders.Count().ToString(), ConsoleColor.DarkMagenta);
Console.WriteLine(db.Orders.Count(x => x.Status > OrderStatus.Pending).ToString(), ConsoleColor.DarkMagenta);

var first = db.Orders.OrderBy(x => x.OrderId).First();
Console.WriteLine(first);


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


public sealed record Order
{
    [Key]
    public int OrderId { get; set; }

    public DateTime Date { get; set; }

    public OrderStatus Status { get; set; } = OrderStatus.Pending;
}



public sealed record OrderStatus : Enum<OrderStatus>
{
    protected OrderStatus(int Key, string Value) : base(Key, Value) { }

    public static OrderStatus Pending => new OrderStatus(0, "Ожидание");

    public static OrderStatus Done => new OrderStatus(1, "Завершен");

    public static OrderStatus Canceled => new OrderStatus(10000, "Отменен");


}
