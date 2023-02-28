using System;
using static Core.Constants.Enums;

namespace Core.Lib.Utilities.Interfaces;
public interface IRandomUtils
{
    /// <summary>
    /// Generates a random string using cryptography of the specified length
    /// </summary>
    /// <param name="length">Length of the random string</param>
    /// <param name="charSet">The <see cref="CharSet"/> enum variable describing which chracters to be used</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public string GenRandomChar(int length, CharSet charSet);


    /// <summary>
    /// Generates a random number using cryptography within the specified range
    /// Ref: https://stackoverflow.com/a/38669162/5407188
    /// </summary>
    /// <param name="min">minimum value for the random number</param>
    /// <param name="max">maximum value for the random number</param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public int GenRandomNumber(int min, int max);
}
