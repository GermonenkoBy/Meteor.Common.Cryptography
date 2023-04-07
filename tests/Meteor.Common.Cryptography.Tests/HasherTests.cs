namespace Meteor.Common.Cryptography.Tests;

[TestClass]
public class HasherTests
{
    private readonly Pbkdf2Hasher _pbkdf2Hasher;

    public HasherTests()
    {
        var options = new HasherOptions
        {
            RequestBytesLength = 16,
            IterationsCount = 10000,
            DefaultSaltLenght = 16,
        };

        _pbkdf2Hasher = new(options);
    }

    [TestMethod]
    public void Hash_Should_MaintainConsistency()
    {
        const string sourceValue = "source123!";
        var (hash, salt) = _pbkdf2Hasher.Hash(sourceValue);
        var hash2 = _pbkdf2Hasher.Hash(sourceValue, salt);

        Assert.IsTrue(hash.SequenceEqual(hash2));
    }
}