using Core.Lib.Utilities;
using Core.Lib.Utilities.Interfaces;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Core.Test.Utilities;

[TestClass]
public sealed class SecurityUtilsTest
{
    private readonly ISecurityUtils _securityUtils;
    private const string _sampleString = "This is a sample string";
    private const string _key = "THk5emRHRmphMjkyWlhKbWJHOTNMbU52YlM5eGRXVnpkR2x2Ym5Ndk16azJORGs1TnpZdmFYTXRh";

    public SecurityUtilsTest()
    {
        _securityUtils = new SecurityUtils();
    }

    [TestMethod]
    public void TestHash()
    {

        var hashedValue = _securityUtils.HashBCrypt(_sampleString);
        var hashComparission = _securityUtils.VerifyBCrypt(_sampleString, hashedValue);
        Assert.IsTrue(hashComparission);
    }

    [TestMethod]
    public void TestEncryption()
    {
        var encryptedString = _securityUtils.EncryptString(_sampleString, _key);
        var decryptedString = _securityUtils.DecryptString(encryptedString, _key);
        Assert.AreEqual(_sampleString, decryptedString);
    }
}
