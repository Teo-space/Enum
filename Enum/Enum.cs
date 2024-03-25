
public abstract partial record Enum<TEnum> where TEnum : Enum<TEnum>
{
    protected Enum(int key, string value)
    {
        Key = key;
        Value = value;
    }

    public int Key { get; set; }
    public string Value { get; set; }

    public sealed override string ToString() => Value;

    public static implicit operator int(Enum<TEnum> param) => param.Key;
    public static implicit operator string(Enum<TEnum> param) => param.Value;
    public static implicit operator Enum<TEnum>?(int key) => FromKey<TEnum>(key);
    public static implicit operator Enum<TEnum>?(string value) => FromValue<TEnum>(value);

    public static bool operator >(Enum<TEnum> left, Enum<TEnum> right) => left.Key > right.Key;
    public static bool operator <(Enum<TEnum> left, Enum<TEnum> right) => left.Key < right.Key;
    public static bool operator >=(Enum<TEnum> left, Enum<TEnum> right) => left.Key >= right.Key;
    public static bool operator <=(Enum<TEnum> left, Enum<TEnum> right) => left.Key <= right.Key;

}