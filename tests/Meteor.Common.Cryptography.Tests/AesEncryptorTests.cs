using System.Security.Cryptography;

namespace Meteor.Common.Cryptography.Tests;

[TestClass]
public class AesEncryptorTests
{
    private readonly AesEncryptor _encryptor;

    public AesEncryptorTests()
    {
        var options = new EncryptorOptions
        {
            AesKey = RandomNumberGenerator.GetBytes(16),
            InitializationVector = RandomNumberGenerator.GetBytes(16)
        };
        _encryptor = new(options);
    }

    [TestMethod]
    public async Task EncryptAndDecrypt_Should_MatchSourceValue()
    {
        const string sourceValue = "source123";
        var encrypted = await _encryptor.EncryptAsync(sourceValue);
        var decrypted = await _encryptor.DecryptAsync(encrypted);

        Assert.AreEqual(sourceValue, decrypted);
    }
}