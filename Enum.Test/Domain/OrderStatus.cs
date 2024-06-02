namespace Enum.Test.Domain;


public sealed record OrderStatus : Enum<OrderStatus>
{
    protected OrderStatus(int Key, string Value) : base(Key, Value) { }

    public static OrderStatus Pending => new OrderStatus(0, "Ожидание");

    public static OrderStatus Done => new OrderStatus(1, "Завершен");

    public static OrderStatus Canceled => new OrderStatus(10000, "Отменен");


}
