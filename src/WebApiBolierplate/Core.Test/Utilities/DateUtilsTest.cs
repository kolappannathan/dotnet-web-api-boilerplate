using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Core.Test.Utilities;

[TestClass]
public sealed class DateUtilsTest
{

    private readonly IDateUtils _dateUtils;

    public DateUtilsTest()
    {
        _dateUtils = new DateUtils();
    }

    [TestMethod]
    public void TestDateTimeCombining()
    {
        var date = new DateTime(2021, 1, 1);
        var time = new DateTime(2000, 12, 12, 1, 2, 3);
        var expectedOutput = new DateTime(2021, 1, 1, 1, 2, 3);
        var combinedDate = _dateUtils.CombaineDateAndTime(date, time);
        Assert.AreEqual(expectedOutput, combinedDate);
    }
}
