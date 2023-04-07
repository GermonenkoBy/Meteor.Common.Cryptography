using System.Security.Cryptography;
using System.Text;
using Meteor.Common.Cryptography.Abstractions;

namespace Meteor.Common.Cryptography;

public class AesEncryptor : IEncryptor
{
    private readonly EncryptorOptions _options;

    private byte[] AesKey => _options.AesKey;

    private byte[] AesIv => _options.InitializationVector;

    public AesEncryptor(EncryptorOptions options)
    {
        _options = options;
    }

    public async Task<byte[]> EncryptAsync(string source)
    {
        using var aes = Aes.Create();
        aes.Key = AesKey;
        aes.IV = AesIv;

        using MemoryStream output = new();
        await using CryptoStream cryptoStream = new(output, aes.CreateEncryptor(), CryptoStreamMode.Write);

        await cryptoStream.WriteAsync(Encoding.Unicode.GetBytes(source));
        await cryptoStream.FlushFinalBlockAsync();

        return output.ToArray();
    }

    public async Task<string> DecryptAsync(byte[] source)
    {
        using var aes = Aes.Create();
        aes.Key = AesKey;
        aes.IV = AesIv;

        using MemoryStream input = new(source);
        await using CryptoStream cryptoStream = new(input, aes.CreateDecryptor(), CryptoStreamMode.Read);

        using MemoryStream output = new();
        await cryptoStream.CopyToAsync(output);

        return Encoding.Unicode.GetString(output.ToArray());
    }
}