using Core.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace Core.Test
{
    [TestClass]
    public class CompressionHelperTest
    {
        private readonly Helpers helper;
        private readonly string sampleString = "This is a sample string";

        public CompressionHelperTest()
        {
            helper = new Helpers();
        }

        [TestMethod]
        public void TestGZip()
        {
            var compressedString = helper.GZip.CompressToString(sampleString, Encoding.UTF8);
            var decompressedString = helper.GZip.DecompressString(compressedString, Encoding.UTF8);
            Assert.AreEqual(sampleString, decompressedString);
        }
    }
}
