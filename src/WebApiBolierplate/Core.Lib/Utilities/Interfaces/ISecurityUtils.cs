namespace Core.Lib.Utilities.Interfaces;
public interface ISecurityUtils
{
    /// <summary>
    /// Encrypts the given string and return ciphertext
    /// </summary>
    public string EncryptString(string clearText, string encryptionKey);

    /// <summary>
    /// Decrypts the given string and returns plain text
    /// </summary>
    public string DecryptString(string cipherText, string encryptionKey);

    /// <summary>
    /// Hashes the plaintext password using BCrypt and returns the hash
    /// </summary>
    /// <param name="plainText"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public string HashBCrypt(string plainText);

    /// <summary>
    /// Verfies the hash and password with Brcypt
    /// </summary>
    /// <param name="plainText"></param>
    /// <param name="hash"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public bool VerifyBCrypt(string plainText, string hash);
}
