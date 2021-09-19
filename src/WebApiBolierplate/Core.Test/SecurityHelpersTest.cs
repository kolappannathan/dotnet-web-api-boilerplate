using Core.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test
{
    [TestClass]
    public class SecurityHelpersTest
    {
        private readonly Helpers helper;
        private readonly string sampleString = "This is a sample string";

        public SecurityHelpersTest()
        {
            helper = new Helpers();
        }

        [TestMethod]
        public void TestHash()
        {
            var hashedValue = helper.Hash.HashBCrypt(sampleString);
            var hashComparission = helper.Hash.VerifyBCrypt(sampleString, hashedValue);
            Assert.IsTrue(hashComparission);
        }

        [TestMethod]
        public void TestEncryption()
        {
            var encryptedString = helper.Encryption.EncryptString(sampleString);
            var decryptedString = helper.Encryption.DecryptString(encryptedString);
            Assert.AreEqual(sampleString, decryptedString);
        }
    }
}
