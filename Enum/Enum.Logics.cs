using System.Collections.Concurrent;

namespace Enum;


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

    /*
    public static ImmutableDictionary<int, Enum<TEnum>> KeyValue1
        => ImmutableDictionary.CreateRange(Collection.Select(x => new KeyValuePair<int, Enum<TEnum>>(x.Key, x)));

    public static ImmutableDictionary<string, Enum<TEnum>> ValueKey1
        => ImmutableDictionary.CreateRange(Collection.Select(x => new KeyValuePair<string, Enum<TEnum>>(x.Value, x)));
    */

    public static ConcurrentDictionary<int, Enum<TEnum>> KeyValue
        => new ConcurrentDictionary<int, Enum<TEnum>>(Collection.Select(x => new KeyValuePair<int, Enum<TEnum>>(x.Key, x)));

    public static ConcurrentDictionary<string, Enum<TEnum>> ValueKey
        => new ConcurrentDictionary<string, Enum<TEnum>>(Collection.Select(x => new KeyValuePair<string, Enum<TEnum>>(x.Value, x)));

    public static Enum<TEnum>? FromKey<T>(int key) where T : Enum<T>
    {
        return KeyValue.GetValueOrDefault(key);
    }

    public static Enum<TEnum>? FromValue<T>(string value) where T : Enum<T>
    {
        return ValueKey.GetValueOrDefault(value);
    }

    public static bool TryGetValue(int key, out Enum<TEnum>? result)
    {
        var status = KeyValue.TryGetValue(key, out Enum<TEnum>? temp);
        result = temp;
        return status;
    }

    public static bool TryGetValue(string value, out Enum<TEnum>? result)
    {
        var status = ValueKey.TryGetValue(value, out Enum<TEnum>? temp);
        result = temp;
        return status;
    }

}

//ImmutableSortedSet.CreateRange(Comparer<Test>.Create((x, y) => x.Key > y.Key ? 1 : x.Key < y.Key ? - 1 : 0), Test.Collection);