namespace Meteor.Common.Cryptography.Abstractions;

public interface IEncryptor
{
    Task<byte[]> EncryptAsync(string source);

    Task<string> DecryptAsync(byte[] source);
}