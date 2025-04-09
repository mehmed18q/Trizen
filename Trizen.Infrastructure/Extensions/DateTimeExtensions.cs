using System.Globalization;

namespace Trizen.Infrastructure.Extensions;

public static class DateTimeExtensions
{
    private static readonly PersianCalendar PersianCalendar = new();

    public static bool IsValidDate(this DateTime? value)
    {
        return value.HasValue && value > DateTime.MinValue;
    }

    public static DateTime? ToMiladi(this DateTime? date)
    {
        return date.IsValidDate() ? date!.Value.ToMiladi() : null;
    }

    public static DateTime? ToMiladi(this DateTime date)
    {
        return new DateTime(date.Year, date.Month, date.Day, PersianCalendar);
    }

    public static string? ToShamsi(this DateTime? date)
    {
        return date.IsValidDate() ? date!.Value.ToShamsi() : null;
    }

    public static string ToShamsi(this DateTime date)
    {
        return $"{PersianCalendar.GetYear(date):0000}/{PersianCalendar.GetMonth(date):00}/{PersianCalendar.GetDayOfMonth(date):00}";
    }

    public static string? ToShamsiWithTime(this DateTime? date)
    {
        return date.IsValidDate() ? date!.Value.ToShamsiWithTime() : null;
    }

    public static string ToShamsiWithTime(this DateTime date)
    {
        return $"{date.ToShamsi()} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
    }

    public static string? ToShamsiMonthInLetters(this DateTime? date)
    {
        return date.IsValidDate() ? date!.Value.ToShamsi() : null;
    }

    public static string ToShamsiMonthInLetters(this DateTime date)
    {
        return $"{PersianCalendar.GetYear(date):0000} {PersianCalendar.ToPersianMonth(date)} {PersianCalendar.GetDayOfMonth(date):00}";
    }

    public static string? ToShamsiWithTimeMonthInLetters(this DateTime? date)
    {
        return date.IsValidDate() ? date!.Value.ToShamsiWithTime() : null;
    }

    public static string ToShamsiWithTimeMonthInLetters(this DateTime date)
    {
        return $"{date.ToShamsiMonthInLetters()} {date.Hour:00}:{date.Minute:00}:{date.Second:00}";
    }

    public static string? ToDate(this DateTime? date)
    {
        return date.IsValidDate() ? date!.Value.ToDate() : null;
    }

    public static string ToDate(this DateTime date)
    {
        return date.ToString("yyyy/MM/dd");
    }

    private static string ToPersianMonth(this PersianCalendar calendar, DateTime dateTime)
    {
        int month = calendar.GetMonth(dateTime);

        return month switch
        {
            1 => "فروردین",
            2 => "اردیببهشت",
            3 => "خرداد",
            4 => "تیر",
            5 => "مرداد",
            6 => "شهریور",
            7 => "مهر",
            8 => "ابان",
            9 => "آذر",
            10 => "دی",
            11 => "بهمن",
            12 => "اسفند",
            _ => string.Empty
        };
    }
}
