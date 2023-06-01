using System.Security.Cryptography;
using System.Text;

namespace demo_post_api.Helpers
{
    public class EncryptHelper
    {
        public static string SHA256Encrypt(string value)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(value);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string hashedString = Convert.ToHexString(hashBytes);

                return hashedString;
            }
        }
    }
}
