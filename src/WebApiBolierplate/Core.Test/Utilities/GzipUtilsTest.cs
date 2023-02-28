using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Core.Test.Utilities;

[TestClass]
public sealed class GzipUtilsTest
{
    private readonly IGzipUtils gzipUtils;
    private const string sampleString = "This is a sample string";

    public GzipUtilsTest()
    {
        gzipUtils = new GzipUtils();
    }

    [TestMethod]
    public void TestGZip()
    {
        var compressedString = gzipUtils.CompressToString(sampleString, Encoding.UTF8);
        var decompressedString = gzipUtils.DecompressString(compressedString, Encoding.UTF8);
        Assert.AreEqual(sampleString, decompressedString);
    }
}
