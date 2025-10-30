using System.Security.Cryptography;
using System.Text;

namespace MyPortfolio.Helpers;

public static class PasswordHasher
{
    // Şifreyi SHA256 ile hash'ler
    public static string HashPassword(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            var builder = new StringBuilder();
            foreach (var b in bytes)
            {
                builder.Append(b.ToString("x2"));
            }
            return builder.ToString();
        }
    }
    
    // Girilen şifre ile veritabanındaki hash'lenmiş şifreyi karşılaştırır.
    public static bool VerifyPassword(string enteredPassword, string storedHash)
    {
        string enteredHash = HashPassword(enteredPassword);
        return enteredHash.Equals(storedHash);
    }
}