using Core.Lib.Compression;
using Core.Lib.Security;
using Core.Lib.Utilities;
using System;
using System.Text;
using static Core.Lib.Enums;

namespace Core.Lib
{
    /// <summary>
    /// Helpers wraps up the function in the Core.Library project into a single class
    /// </summary>
    public class Helpers
    {
        #region [Declarations]

        private Hash hashLib;
        private Rando randoLib;
        private Gzip gzipLib;

        #endregion [Declarations]

        public Helpers()
        {
        }

        #region [Security]

        /// <summary>
        /// Hashes the plaintext password using BCrypt and returns the hash
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string HashBCrypt(string plainText)
        {
            hashLib = new Hash();
            return hashLib.HashBCrypt(plainText);
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
            hashLib = new Hash();
            return hashLib.VerifyBCrypt(plainText, hash);
        }

        #endregion [Security]

        #region [Utilities]

        /// <summary>
        /// Generates a random number using cryptography within the specified range
        /// Ref: https://stackoverflow.com/a/38669162/5407188
        /// </summary>
        /// <param name="min">minimum value for the random number</param>
        /// <param name="max">maximum value for the random number</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public int GenRandomNumber(int min, int max)
        {
            randoLib = new Rando();
            return randoLib.GenRandomNumber(min, max);
        }

        /// <summary>
        /// Generates a random string using cryptography of the specified length
        /// </summary>
        /// <param name="length">Length of the random string</param>
        /// <param name="charSet">The <see cref="CharSet"/> enum variable describing which chracters to be used</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public string GenRandomChar(int length, CharSet charSet)
        {
            randoLib = new Rando();
            return randoLib.GenRandomChar(length, charSet);
        }

        #endregion [Utilities]

        #region [Compression]

        /// <summary>
        /// Compresses a given string using Gzip compression and returns the resturn as a string
        /// </summary>
        /// <param name="plaintText">string to be compressed</param>
        /// <returns></returns>
        public string CompressToGzipString(string plaintText)
        {
            gzipLib = new Gzip();
            return gzipLib.CompressToString(plaintText);
        }

        /// <summary>
        /// Decompresses a string that is compressed by Gzip compression
        /// </summary>
        /// <param name="compressedString">Compressed data</param>
        /// <param name="encoding"><see cref="Encoding"/> to be used for decoding</param>
        /// <returns></returns>
        public string DecompressGzipString(string compressedString, Encoding encoding)
        {
            gzipLib = new Gzip();
            return gzipLib.DecompressString(compressedString, encoding);
        }

        #endregion [Compression]

    }
}
