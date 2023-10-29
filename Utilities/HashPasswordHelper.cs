using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;

namespace Api.Utilities
{
    public class HashPasswordHelper
    {
        public static string HashPassword(string password, out byte[] salt)
        {
            salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
        }

        public static bool VerifyPassword(string hashedPassword, string passwordToVerify, byte[] salt)
        {
            string hashedPasswordToVerify = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: passwordToVerify,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashedPassword == hashedPasswordToVerify;
        }
    }
}
