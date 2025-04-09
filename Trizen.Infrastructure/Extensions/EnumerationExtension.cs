using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Trizen.Infrastructure.Extensions;

public static class EnumerationExtension
{
    public static Enum GetAsEnum<E>(this int val)
    {
        return (Enum)Enum.Parse(typeof(E), val.ToString());
    }

    public static string GetDisplayName(this Enum enumeration)
    {
        MemberInfo? enumerationsName = enumeration.GetType().GetMember(enumeration.ToString())
            .FirstOrDefault();

        return enumerationsName?.GetCustomAttribute<DisplayAttribute>()?.GetName() ?? string.Empty;
    }

    public static string GetEnumDisplayName<E>(this int? val)
    {
        return val == null ? string.Empty : val.Value.GetEnumDisplayName<E>();
    }

    public static string GetEnumDisplayName<E>(this int val)
    {
        Enum _enum = val.GetAsEnum<E>();

        return _enum.GetDisplayName();
    }

    public static IEnumerable<E> GetEnumList<E>()
    {
        return Enum.GetValues(typeof(E)).Cast<E>();
    }

    public static int ToInt<E>(this E val) where E : Enum
    {
        return Convert.ToInt32(val);
    }

    public static T ToEnum<T>(this int val) where T : struct, IConvertible
    {
        return (T)(object)val;
    }
}
