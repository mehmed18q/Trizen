using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Trizen.Infrastructure.Extensions;

public static class ObjectExtension
{
    public static string? TryToString(this object obj)
    {
        return obj is null ? string.Empty : obj.ToString();
    }

    public static bool TryToAny(this IQueryable<object>? obj)
    {
        return obj is not null && obj.Any();
    }

    public static bool TryToAny(this IEnumerable<object>? obj)
    {
        return obj is not null && obj.Any();
    }

    public static bool TryToAny(this List<object>? obj)
    {
        return obj is not null && obj.Count != 0;
    }

    public static int TryToInt(this object obj)
    {
        if (obj is null)
        {
            return 0;
        }

        _ = int.TryParse(obj.ToString(), out int value);
        return value;
    }

    public static string? ToJson(this object obj)
    {
        string? stringValue = obj.TryToString();
        return stringValue.IsEmpty() ? null : JsonConvert.SerializeObject(obj);
    }

    public static T? MapTo<T>(this object obj)
    {
        string? stringValue = obj.TryToString();
        return stringValue.IsEmpty() ? default : JsonConvert.DeserializeObject<T>(obj.ToJson()!);
    }

    public static string GetStringProperty(this object value, string propertyName)
    {
        return Convert.ToString(value.GetType().GetProperty(propertyName)?.GetValue(value) ?? "")!;
    }

    public static bool? GetBooleanProperty(this object value, string propertyName)
    {
        return Convert.ToBoolean(value.GetType().GetProperty(propertyName)?.GetValue(value) ?? null);
    }

    public static int? GetIntProperty(this object value, string propertyName)
    {
        object? propertyValue = value.GetType().GetProperty(propertyName)?.GetValue(value);
        return propertyValue is null ? 0 : propertyValue.TryToString()?.TryToInt();
    }

    public static string ToBase64Image(this byte[] bytes)
    {
        string base64String = Convert.ToBase64String(bytes, 0, bytes.Length);
        return $"data:image/png;base64,{base64String}";
    }

    public static string TryGetValue(this JObject obj, string propertyName)
    {
        try
        {
            return obj?[propertyName]?.ToString() ?? string.Empty;
        }
        catch
        {
            return string.Empty;
        }
    }
}