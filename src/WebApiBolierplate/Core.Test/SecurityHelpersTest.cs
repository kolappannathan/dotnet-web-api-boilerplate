using Core.Lib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test;

[TestClass]
public class SecurityHelpersTest
{
    private readonly Helpers _helper;
    private readonly string _sampleString = "This is a sample string";
    private readonly string _key = "THk5emRHRmphMjkyWlhKbWJHOTNMbU52YlM5eGRXVnpkR2x2Ym5Ndk16azJORGs1TnpZdmFYTXRh";

    public SecurityHelpersTest()
    {
        _helper = new Helpers();
    }

    [TestMethod]
    public void TestHash()
    {
        var hashedValue = _helper.Hash.HashBCrypt(_sampleString);
        var hashComparission = _helper.Hash.VerifyBCrypt(_sampleString, hashedValue);
        Assert.IsTrue(hashComparission);
    }

    [TestMethod]
    public void TestEncryption()
    {
        var encryptedString = _helper.Encryption.EncryptString(_sampleString, _key);
        var decryptedString = _helper.Encryption.DecryptString(encryptedString, _key);
        Assert.AreEqual(_sampleString, decryptedString);
    }
}
