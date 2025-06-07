using System.Security.Cryptography;
using System.Text;

namespace Caneko.System.Util
{
    public static class NumberGenerator
    {
        public static string GetShortHashByDateNow()
        {
            var timestamp = DateTime.UtcNow.Ticks.ToString();
            using (var sha256 = SHA256.Create())
            {
                var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(timestamp));
                return BitConverter.ToString(hash).Replace("-", "").Substring(0, 8);
            }
        }
    }
}
