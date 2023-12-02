using Core.Lib.Utilities.Interfaces;
using System;
using System.Security.Cryptography;
using static Core.Constants.Enums;

namespace Core.Lib.Utilities;

public sealed class RandomUtils : IRandomUtils
{
    #region [Declarations]

    private readonly string _uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private readonly string _lowercase = "abcdefghijklmnopqrstuvwxyz";
    private readonly string _numbers = "0123456789";

    #endregion Declarations

    #region [Private Functions]

    /// <summary>
    /// Returns the characters as an array for the Characer set specified
    /// </summary>
    /// <param name="charSet"></param>
    /// <returns></returns>
    private char[] GetChars(CharSet charSet)
    {
        var s1 = string.Empty;
        switch (charSet)
        {
            case CharSet.Alphabets:
                s1 = _uppercase + _lowercase;
                break;
            case CharSet.Numbers:
                s1 = _numbers;
                break;
            case CharSet.AlphaNumeric:
                s1 = _uppercase + _lowercase + _numbers;
                break;
            case CharSet.UppercaseOnly:
                s1 = _uppercase;
                break;
            case CharSet.LowercaseOnly:
                s1 = _lowercase;
                break;
            case CharSet.UppercaseWithNumbers:
                s1 = _uppercase + _numbers;
                break;
            case CharSet.LowercaseWithNumbers:
                s1 = _lowercase + _numbers;
                break;
        }
        return s1.ToCharArray();
    }

    #endregion [Private Functions]

    #region [Public Functions]

    public string GenRandomChar(int length, CharSet charSet)
    {
        if (length <= 0)
        {
            throw new ArgumentException("Length of the random character must be greater than zero", nameof(length));
        }

        var chars = GetChars(charSet);
        var stringChars = RandomNumberGenerator.GetString(chars, length);
        return new string(stringChars);
    }

    #endregion [Public Functions]
}
