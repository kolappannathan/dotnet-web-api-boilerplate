using Business.Lib.Core;
using System.Text;
using static Core.Constants.Enums;

namespace Business.Lib
{
    public class HelperLib :  Base
    {
        #region [Security]

        public string HashBCrypt(string plainText) => helper.Hash.HashBCrypt(plainText);

        public bool VerifyBCrypt(string plainText, string hash) => helper.Hash.VerifyBCrypt(plainText, hash);

        public string EncryptString(string clearText) => helper.Encryption.EncryptString(clearText);

        public string DecryptString(string cipherText) => helper.Encryption.DecryptString(cipherText);

        #endregion [Security]

        #region [Utilities]

        public int GenRandomNumber(int min, int max) => helper.Rando.GenRandomNumber(min, max);

        public string GenRandomChar(int length) => helper.Rando.GenRandomChar(length, CharSet.AlphaNumeric);

        #endregion [Utilities]

        #region [Compression]

        public string CompressToGzipString(string plaintText) => helper.GZip.CompressToString(plaintText, Encoding.UTF8);

        public string DecompressGzipString(string compressedString) => helper.GZip.DecompressString(compressedString, Encoding.UTF8);

        #endregion [Compression]
    }
}
