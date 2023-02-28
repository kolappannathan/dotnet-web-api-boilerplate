using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test.Utilities;

[TestClass]
public sealed class RandomUtilsTest
{
    private readonly IRandomUtils _randomUtils;

    public RandomUtilsTest()
    {
        _randomUtils = new RandomUtils();
    }

    [TestMethod]
    public void TestingRandomChar()
    {
        const int length = 10;
        var randomChars = _randomUtils.GenRandomChar(length, Constants.Enums.CharSet.Alphabets);
        Assert.AreEqual(randomChars.Length, length);
    }

    [TestMethod]
    public void TestRandomNo()
    {
        const int min = 0, max = 108;
        var randomChars = _randomUtils.GenRandomNumber(min, max);
        Assert.IsTrue(randomChars <= max);
        Assert.IsTrue(randomChars >= min);
    }
}
