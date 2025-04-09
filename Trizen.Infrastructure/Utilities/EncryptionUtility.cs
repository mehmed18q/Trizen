using System.Security.Cryptography;
using System.Text;

namespace Trizen.Infrastructure.Utilities;

public static class EncryptionUtility
{

    public static string GetSecurePassword(string password, string text)
    {
        string salt = CreateSalt(text);
        string saltAndPassword = string.Concat(password, salt);
        UTF8Encoding encoder = new();
        byte[] hashedDataBytes = SHA256.HashData(encoder.GetBytes(saltAndPassword));
        string hashedPassword = string.Concat(ByteArrayToString(hashedDataBytes), salt);
        return hashedPassword;
    }

    private static string CreateSalt(string text)
    {
        byte[] userBytes;
        string salt;
        userBytes = Encoding.ASCII.GetBytes(text);
        long XORED = 0x00;

        foreach (int x in userBytes)
        {
            XORED ^= x;
        }

        Random rand = new(Convert.ToInt32(XORED));
        salt = rand.Next().ToString();
        salt += rand.Next().ToString();
        salt += rand.Next().ToString();
        salt += rand.Next().ToString();

        return salt;
    }

    private static string ByteArrayToString(byte[] inputArray)
    {
        StringBuilder output = new("");
        for (int i = 0; i < inputArray.Length; i++)
        {
            _ = output.Append(inputArray[i].ToString("X2"));
        }
        return output.ToString();
    }
}
