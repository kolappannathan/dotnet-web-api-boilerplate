using Core.Constants;
using Core.Lib.Utilities.Interfaces;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Core.Lib.Utilities;

/// <summary>
/// This class offer simple encryption and decryption
/// Ref: https://stackoverflow.com/a/27484425/5407188
/// </summary>
public sealed class SecurityUtils : ISecurityUtils
{
    #region [Private Functions]
    private Aes BuildAesEncryptor(string encryptionKey)
    {
        var aesEncryptor = Aes.Create();
        var salt = "335f0298-9eae-4285-890e-ef7243c974f0"u8.ToArray();
        aesEncryptor.Key = Rfc2898DeriveBytes.Pbkdf2(
            password: encryptionKey,
            salt: salt,
            iterations: 5033,
            hashAlgorithm: HashAlgorithmName.SHA512,
            outputLength: 32);
        aesEncryptor.IV = Rfc2898DeriveBytes.Pbkdf2(
            password: encryptionKey,
            salt: salt,
            iterations: 5033,
            hashAlgorithm: HashAlgorithmName.SHA512,
            outputLength: 16);
        return aesEncryptor;
    }

    #endregion [Private Functions]

    public string EncryptString(string clearText, string encryptionKey)
    {
        var aesEncryptor = BuildAesEncryptor(encryptionKey);
        var clearBytes = Encoding.Unicode.GetBytes(clearText);
        using (var ms = new MemoryStream())
        {
            using (var cs = new CryptoStream(ms, aesEncryptor.CreateEncryptor(), CryptoStreamMode.Write))
            {
                cs.Write(clearBytes, 0, clearBytes.Length);
            }
            var encryptedText = Convert.ToBase64String(ms.ToArray());
            return encryptedText;
        }
    }

    public string DecryptString(string cipherText, string encryptionKey)
    {
        var aesEncryptor = BuildAesEncryptor(encryptionKey);
        cipherText = cipherText.Replace(" ", "+");
        var cipherBytes = Convert.FromBase64String(cipherText);
        using (var ms = new MemoryStream())
        {
            using (var cs = new CryptoStream(ms, aesEncryptor.CreateDecryptor(), CryptoStreamMode.Write))
            {
                cs.Write(cipherBytes, 0, cipherBytes.Length);
            }
            var clearText = Encoding.Unicode.GetString(ms.ToArray());
            return clearText;
        }
    }

    public string HashBCrypt(string plainText, string salt)
    {
        ArgumentException.ThrowIfNullOrEmpty(plainText);
        ArgumentException.ThrowIfNullOrEmpty(salt);

        var hash = BCrypt.Net.BCrypt.HashPassword(plainText + salt, workFactor: 10);
        return hash;
    }

    public bool VerifyBCrypt(string plainText, string salt, string hash)
    {
        ArgumentException.ThrowIfNullOrEmpty(plainText);
        ArgumentException.ThrowIfNullOrEmpty(salt);
        ArgumentException.ThrowIfNullOrEmpty(hash);

        var isMatch = BCrypt.Net.BCrypt.Verify(plainText + salt, hash);
        return isMatch;
    }
}
