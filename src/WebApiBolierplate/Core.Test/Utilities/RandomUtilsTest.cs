﻿using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

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

        Assert.ThrowsException<ArgumentOutOfRangeException>(() => {
            _randomUtils.GenRandomChar(0, Constants.Enums.CharSet.Alphabets);
        });
    }
}
