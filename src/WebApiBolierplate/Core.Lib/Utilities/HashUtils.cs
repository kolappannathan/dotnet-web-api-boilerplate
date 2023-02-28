using System;

namespace Core.Lib.Utilities;

public class BcryptUtils
{
    private const string AllPrametersMandatory = "All the parameters are mandatory";

    public BcryptUtils()
    {

    }

    /// <summary>
    /// Hashes the plaintext password using BCrypt and returns the hash
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public string HashBCrypt(string plainText)
    {
        ArgumentException.ThrowIfNullOrEmpty(plainText);

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
    /// <exception cref="ArgumentException"></exception>
    public bool VerifyBCrypt(string plainText, string hash)
    {
        ArgumentException.ThrowIfNullOrEmpty(plainText);
        ArgumentException.ThrowIfNullOrEmpty(hash);

        var isMatch = BCrypt.Net.BCrypt.Verify(plainText, hash);
        return isMatch;
    }
}
