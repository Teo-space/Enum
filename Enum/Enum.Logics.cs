using System.Collections.Immutable;


public abstract partial record Enum<TEnum> where TEnum : Enum<TEnum>
{
    public static IReadOnlyCollection<TEnum> Collection => typeof(TEnum)
        .GetProperties()
        .Where(property => property.PropertyType.IsAssignableFrom(typeof(TEnum)))
        .Select(property => property.GetValue(default))
        .Where(value => value is not null)
        .OfType<TEnum>()
        .OrderBy(x => x.Key)
        .ToList() as IReadOnlyCollection<TEnum>;

    public static IEnumerable<int> Keys => Collection.Select(x => x.Key);
    public static IEnumerable<string> Values => Collection.Select(x => x.Value);


    public static ImmutableDictionary<int, TEnum> KeyValue
        => ImmutableDictionary.CreateRange(Collection.Select(x => new KeyValuePair<int, TEnum>(x.Key, x)));

    public static ImmutableDictionary<string, TEnum> ValueKey
        => ImmutableDictionary.CreateRange(Collection.Select(x => new KeyValuePair<string, TEnum>(x.Value, x)));

    public static TEnum? FromKey<T>(int key) where T : Enum<T>
    {
        return KeyValue.GetValueOrDefault(key);
    }

    public static TEnum? FromValue<T>(string value) where T : Enum<T>
    {
        return ValueKey.GetValueOrDefault(value);
    }

    public static bool TryGetValue(int key, out TEnum? result)
    {
        var status = KeyValue.TryGetValue(key, out TEnum? temp);
        result = temp;
        return status;
    }

    public static bool TryGetValue(string value, out TEnum? result)
    {
        var status = ValueKey.TryGetValue(value, out TEnum? temp);
        result = temp;
        return status;
    }

}


//ImmutableSortedSet.CreateRange(Comparer<Test>.Create((x, y) => x.Key > y.Key ? 1 : x.Key < y.Key ? - 1 : 0), Test.Collection);