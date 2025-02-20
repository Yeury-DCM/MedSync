
using System.Security.Cryptography;
using System.Text;

namespace MedSync.Core.Application.Helpers
{
    public class PasswordEncryption
    {
        public static string ComputeShad256Hash(string password)
        {

            using(SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));

                //COnvert Byte array to string

                StringBuilder stringBuilder = new StringBuilder();

                for (int i = 0; i < bytes.Length; i++)
                {
                    stringBuilder.Append(bytes[i].ToString("x2"));
                }

                return stringBuilder.ToString();

            }

       
        }
    }
}
