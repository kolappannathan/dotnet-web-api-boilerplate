﻿using Core.Lib.Utilities.Interfaces;
using System;
using System.Security.Cryptography;
using static Core.Constants.Enums;

namespace Core.Lib.Utilities;

public sealed class RandomUtils : IRandomUtils
{
    #region [Declarations]

    private string Uppercase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    private string Lowercase = "abcdefghijklmnopqrstuvwxyz";
    private string Number = "0123456789";

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
                s1 = Uppercase + Lowercase;
                break;
            case CharSet.Numbers:
                s1 = Number;
                break;
            case CharSet.AlphaNumeric:
                s1 = Uppercase + Lowercase + Number;
                break;
            case CharSet.UppercaseOnly:
                s1 = Uppercase;
                break;
            case CharSet.LowercaseOnly:
                s1 = Lowercase;
                break;
            case CharSet.UppercaseWithNumbers:
                s1 = Uppercase + Number;
                break;
            case CharSet.LowercaseWithNumbers:
                s1 = Lowercase + Number;
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
            throw new ArgumentException("length", "Length of the random character must be greater than zero");
        }

        char[] chars = GetChars(charSet);
        var stringChars = new char[length];

        for (int i = 0; i < length; i++)
        {
            stringChars[i] = chars[GenRandomNumber(0, chars.Length)];
        }

        var finalString = new String(stringChars);
        return finalString;
    }

    public int GenRandomNumber(int min, int max)
    {
        if (min >= max)
        {
            throw new ArgumentException("The value of min should be less than max");
        }

        using (var generator = RandomNumberGenerator.Create())
        {
            // Generate four random bytes
            var four_bytes = new byte[4];
            generator.GetBytes(four_bytes);

            // Convert the bytes to a UInt32
            var scale = BitConverter.ToUInt32(four_bytes, 0);

            // And use that to pick a random number >= min and < max
            return (int)(min + (max - min) * (scale / (uint.MaxValue + 1.0)));
        }
    }

    #endregion [Public Functions]
}
