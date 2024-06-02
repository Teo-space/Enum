using Enum.Test.Domain;
using Enum.Test.Infrastructure;

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



Console.WriteLine($"Total: {db.Orders.Count().ToString()}", ConsoleColor.DarkMagenta);

Console.WriteLine($"Pending: {db.Orders.Count(x => x.Status > OrderStatus.Pending).ToString()}", ConsoleColor.DarkMagenta);


var first = db.Orders.OrderBy(x => x.OrderId).First();
Console.WriteLine(first);

