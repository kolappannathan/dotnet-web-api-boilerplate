using Core.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Test;

[TestClass]
public class UtilitiesHelperTest
{
    private readonly Helpers helper;

    public UtilitiesHelperTest()
    {
        helper = new Helpers();
    }

    [TestMethod]
    public void TestingRandomChar()
    {
        const int length = 10;
        var randomChars = helper.Rando.GenRandomChar(length, Constants.Enums.CharSet.Alphabets);
        Assert.AreEqual(randomChars.Length, length);
    }

    [TestMethod]
    public void TestRandomNo()
    {
        const int min = 0, max = 108;
        var randomChars = helper.Rando.GenRandomNumber(min, max);
        Assert.IsTrue(randomChars <= max);
        Assert.IsTrue(randomChars >= min);
    }

    [TestMethod]
    public void TestLineEndingRemoval()
    {
        const string inputStr = "Line 1\nLine 2\r";
        const string expectedOutput = "Line 1Line 2";
        var processedStr = helper.TextUtilities.RemoveLineEndings(inputStr);
        Assert.AreEqual(expectedOutput, processedStr);
    }

    [TestMethod]
    public void TestDateTime()
    {
        var date = new DateTime(2021, 1, 1);
        var time = new DateTime(2000, 12, 12, 1, 2, 3);
        var expectedOutput = new DateTime(2021, 1, 1, 1, 2, 3);
        var combinedDate = helper.DateLib.CombaineDateAndTime(date, time);
        Assert.AreEqual(expectedOutput, combinedDate);
    }
}
