namespace Enum;

public sealed record OrderStatus(int Key, string Value) : Enum<OrderStatus>(Key, Value)
{
    public static OrderStatus Pending => new OrderStatus(0, "Ожидание");

    public static OrderStatus Done => new OrderStatus(0, "Завершен");

    public static OrderStatus Canceled => new OrderStatus(10000, "Отменен");


}
