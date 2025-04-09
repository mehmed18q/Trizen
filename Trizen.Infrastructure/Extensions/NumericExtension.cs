namespace Trizen.Infrastructure.Extensions;

public static class NumericExtension
{
    public static bool IsZeroOrNull<T>(this T? value)
    {
        return !value.IsNotZeroOrNull();
    }

    public static bool IsZeroOrNull(this decimal? value)
    {
        return !value.IsNotZeroOrNull();
    }

    public static bool IsNotZeroOrNull<T>(this T? value)
    {
        return value is not (null or <= 0);
    }

    public static bool IsNotZeroOrNull(this decimal? value)
    {
        return value is not (null or <= 0);
    }

    public static string To3Digit(this decimal d)
    {
        return d.ToString("#,0");
    }

    public static string To3Digit(this double d)
    {
        return d.ToString("#,0");
    }

    public static string To3Digit(this int? d)
    {
        return d.IsZeroOrNull() ? "0" : d!.Value.To3Digit();
    }

    public static string To3Digit(this int d)
    {
        return d.ToString("#,0");
    }

    public static decimal Percent(this decimal? value, decimal? percent)
    {
        return value.IsZeroOrNull() || percent.IsZeroOrNull() ? 0 : value!.Value * percent!.Value / 100;
    }

    public static decimal PlusPercent(this decimal? value, decimal? percent)
    {
        return value.IsZeroOrNull() || percent.IsZeroOrNull() ? 0 : value!.Value + value.Percent(percent);
    }

    public static decimal MinesPercent(this decimal? value, decimal? percent)
    {
        return value.IsZeroOrNull() || percent.IsZeroOrNull() ? 0 : value!.Value - value.Percent(percent);
    }

    public static int Coalesce(int? input1 = null, int? input2 = null, int? input3 = null, int? input4 = null, int? input5 = null)
    {
        if (input1.IsZeroOrNull())
        {
            input1 = null;
        }

        if (input2.IsZeroOrNull())
        {
            input2 = null;
        }

        if (input3.IsZeroOrNull())
        {
            input3 = null;
        }

        if (input4.IsZeroOrNull())
        {
            input4 = null;
        }

        if (input5.IsZeroOrNull())
        {
            input5 = null;
        }

        return input1 ?? input2 ?? input3 ?? input4 ?? input5 ?? 0;
    }

    public static int ToRial(this decimal toman)
    {
        return (int)(toman * 10);
    }

    public static int ToToman(this int rial)
    {
        return rial / 10;
    }
}
