namespace Meteor.Common.Cryptography;

public record EncryptorOptions
{
    public byte[] AesKey { get; set; } = Array.Empty<byte>();

    public byte[] InitializationVector { get; set; } = Array.Empty<byte>();
}