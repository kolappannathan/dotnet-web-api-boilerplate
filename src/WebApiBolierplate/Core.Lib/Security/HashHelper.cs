using System;

namespace Core.Lib.Security
{
    public class HashHelper
    {
        private const string AllPrametersMandatory = "All the parameters are mandatory";

        public HashHelper()
        {

        }

        /// <summary>
        /// Hashes the plaintext password using BCrypt and returns the hash
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string HashBCrypt(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
            {
                throw new ArgumentNullException("plainText", AllPrametersMandatory);
            }

            var hash = BCrypt.Net.BCrypt.HashPassword(plainText, workFactor: 10);
            return hash;
        }

        /// <summary>
        /// Verfies the hash and password with Brcypt
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool VerifyBCrypt(string plainText, string hash)
        {
            if (string.IsNullOrEmpty(plainText) || string.IsNullOrEmpty(hash))
            {
                throw new ArgumentNullException("plainText", AllPrametersMandatory);
            }

            var isMatch = BCrypt.Net.BCrypt.Verify(plainText, hash);
            return isMatch;
        }
    }
}
