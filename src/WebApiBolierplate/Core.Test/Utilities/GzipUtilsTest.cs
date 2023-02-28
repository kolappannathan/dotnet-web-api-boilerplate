using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Core.Test.Utilities;

[TestClass]
public sealed class GzipUtilsTest
{
    private readonly IGzipUtils _gzipUtils;
    private const string _sampleString = "This is a sample string";

    public GzipUtilsTest()
    {
        _gzipUtils = new GzipUtils();
    }

    [TestMethod]
    public void TestGZip()
    {
        var compressedString = _gzipUtils.CompressToString(_sampleString, Encoding.UTF8);
        var decompressedString = _gzipUtils.DecompressString(compressedString, Encoding.UTF8);
        Assert.AreEqual(_sampleString, decompressedString);
    }
}
