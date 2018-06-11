using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text.RegularExpressions;

namespace Common.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string Hash(this string input, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: input,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        public static string Hash(this string input, string salt)
        {
            var saltByteArray = Convert.FromBase64String(salt);
            return input.Hash(saltByteArray);
        }

        public static bool IsValidEmailAddress(this string input)
        {
            Regex pattern = new Regex(@"^\w+([-+.']*\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", RegexOptions.IgnoreCase);
            return pattern.IsMatch(input);

        }
        public static bool IsValidPassword(this string password)
        {
            Regex pattern = new Regex("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z]).{8,}$");
            return pattern.IsMatch(password);
        }
    }
}
