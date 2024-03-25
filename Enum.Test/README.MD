SQL

```
info: 25.03.2024 20:07:46.490 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (10ms) [Parameters=[], CommandType='Text', CommandTimeout='30']

      SELECT COUNT(*) FROM "sqlite_master" WHERE "type" = 'table' AND "rootpage" IS NOT NULL;

info: 25.03.2024 20:07:46.553 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']

      CREATE TABLE "Orders" (
          "OrderId" INTEGER NOT NULL CONSTRAINT "PK_Orders" PRIMARY KEY AUTOINCREMENT,
          "Date" TEXT NOT NULL,
          "Status" INTEGER NOT NULL
      );

info: 25.03.2024 20:07:46.647 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (5ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = DateTime), @p2='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      
      INSERT INTO "Orders" ("OrderId", "Date", "Status")
      VALUES (@p0, @p1, @p2);

info: 25.03.2024 20:07:46.653 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[@p0='?' (DbType = Int32), @p1='?' (DbType = DateTime), @p2='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      
      INSERT INTO "Orders" ("OrderId", "Date", "Status")
      VALUES (@p0, @p1, @p2);

      db.Orders.Count()

info: 25.03.2024 20:07:46.826 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      
      SELECT COUNT(*)
      FROM "Orders" AS "o"
2

      db.Orders.Count(x => x.Status > OrderStatus.Pending)

info: 25.03.2024 20:07:46.852 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[@__Pending_0='?' (DbType = Int32)], CommandType='Text', CommandTimeout='30']
      
      SELECT COUNT(*)
      FROM "Orders" AS "o"
      WHERE "o"."Status" > @__Pending_0
1

      var first = db.Orders.OrderBy(x => x.OrderId).First();

info: 25.03.2024 20:07:46.892 RelationalEventId.CommandExecuted[20101] (Microsoft.EntityFrameworkCore.Database.Command)
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      
      SELECT "o"."OrderId", "o"."Date", "o"."Status"
      FROM "Orders" AS "o"
      ORDER BY "o"."OrderId"
      LIMIT 1

      Console.WriteLine(first);

Order { OrderId = 1, Date = 25.03.2024 20:07:45, Status = ќжидание }
```
