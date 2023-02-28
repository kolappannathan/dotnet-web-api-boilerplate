using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test.Utilities;

[TestClass]
public sealed class TextUtilsTest
{
    private readonly ITextUtils _textUtils;

    public TextUtilsTest()
    {
        _textUtils = new TextUtils();
    }

    [TestMethod]
    public void TestLineEndingRemoval()
    {
        const string inputStr = "Line 1\nLine 2\r";
        const string expectedOutput = "Line 1Line 2";
        var processedStr = _textUtils.RemoveLineEndings(inputStr);
        Assert.AreEqual(expectedOutput, processedStr);
    }
}
