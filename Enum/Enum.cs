namespace Enum;

public abstract partial record Enum<TEnum> where TEnum : Enum<TEnum>
{
    public Enum(int key, string value)
    {
        Key = key;
        Value = value;
    }

    public int Key { get; set; }
    public string Value { get; set; }

    public sealed override string ToString() => Value;

    public static explicit operator int(Enum<TEnum> param) => param.Key;
    public static explicit operator string(Enum<TEnum> param) => param.Value;

    public static implicit operator Enum<TEnum>?(int key) => FromKey<TEnum>(key);
    public static implicit operator Enum<TEnum>?(string value) => FromValue<TEnum>(value);
}