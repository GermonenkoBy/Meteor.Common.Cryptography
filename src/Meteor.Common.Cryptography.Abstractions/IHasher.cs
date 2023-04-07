namespace Meteor.Common.Cryptography.Abstractions;

public interface IHasher
{
    public byte[] Hash(string source, byte[] salt);

    public (byte[] Hash, byte[] Salt) Hash(string source);
}