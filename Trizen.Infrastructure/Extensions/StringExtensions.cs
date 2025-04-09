using Newtonsoft.Json;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Trizen.Infrastructure.Extensions;

public static class StringExtensions
{
    public static bool IsEmpty(this string? value)
    {
        return string.IsNullOrEmpty(value) || string.IsNullOrWhiteSpace(value);
    }

    public static bool IsNotEmpty(this string? value)
    {
        return !value.IsEmpty();
    }

    public static string? RemoveHtmlTags(this string? input)
    {
        return input.IsEmpty() ? string.Empty : Regex.Replace(input!, "<.*?>", string.Empty).UnEscape().HtmlDecode();
    }

    public static string HtmlDecode(this string input)
    {
        return input.IsEmpty() ? string.Empty : WebUtility.HtmlDecode(input);
    }

    public static string UnEscape(this string input)
    {
        return input.IsEmpty() ? string.Empty : Regex.Replace(input, @"\\[^\w]", string.Empty);
    }

    public static string? Right(this string? value, int length)
    {
        return value.IsEmpty() ? string.Empty : value!.Length <= length ? value : value[^length..];
    }

    public static string Coalesce(string? input1 = null, string? input2 = null, string? input3 = null, string? input4 = null, string? input5 = null)
    {
        if (input1.IsEmpty())
        {
            input1 = null;
        }

        if (input2.IsEmpty())
        {
            input2 = null;
        }

        if (input3.IsEmpty())
        {
            input3 = null;
        }

        if (input4.IsEmpty())
        {
            input4 = null;
        }

        if (input5.IsEmpty())
        {
            input5 = null;
        }

        return input1 ?? input2 ?? input3 ?? input4 ?? input5 ?? string.Empty;
    }

    public static string RemoveBase64(this string input)
    {
        string pattern = @"^data:image\/[a-zA-Z]+;base64,";

        return Regex.Replace(input, pattern, string.Empty);
    }

    public static T? MapTo<T>(this string val)
    {
        return val.IsEmpty() ? default : JsonConvert.DeserializeObject<T>(val);
    }

    public static string CodeGenerator(int size)
    {
        Random generator = new();

        int max = (int)Math.Pow(10, size);
        return generator.Next(1, max).ToString($"D{size}");
    }

    public static string HashPassword(this string password)
    {
        using SHA256 sha256 = SHA256.Create();
        byte[] bytes = Encoding.UTF8.GetBytes(password);
        byte[] hash = sha256.ComputeHash(bytes);
        return Convert.ToBase64String(hash);
    }
}