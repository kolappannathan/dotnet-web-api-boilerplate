using Business.Lib.Core;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Lib.Enums;

namespace Business.Lib
{
    public class HelperLib :  Base
    {
        #region [Security]

        public string HashBCrypt(string plainText)
        {
            return helper.HashBCrypt(plainText);
        }

        public bool VerifyBCrypt(string plainText, string hash)
        {
            return helper.VerifyBCrypt(plainText, hash);
        }

        public string EncryptString(string clearText)
        {
            return helper.EncryptString(clearText);
        }

        public string DecryptString(string cipherText)
        {
            return helper.DecryptString(cipherText);
        }

        #endregion [Security]

        #region [Utilities]

        public int GenRandomNumber(int min, int max)
        {
            return helper.GenRandomNumber(min, max);
        }

        public string GenRandomChar(int length)
        {
            return helper.GenRandomChar(length, CharSet.AlphaNumeric);
        }

        #endregion [Utilities]

        #region [Compression]

        public string CompressToGzipString(string plaintText)
        {
            return helper.CompressToGzipString(plaintText, Encoding.UTF8);
        }

        public string DecompressGzipString(string compressedString)
        {
            return helper.DecompressGzipString(compressedString, Encoding.UTF8);
        }

        #endregion [Compression]
    }
}
