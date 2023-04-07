using System.Security.Cryptography;
using Meteor.Common.Cryptography.Abstractions;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace Meteor.Common.Cryptography;

public class Pbkdf2Hasher : IHasher
{
    private readonly HasherOptions _options;

    public Pbkdf2Hasher(HasherOptions options)
    {
        _options = options;
    }

    public byte[] Hash(string source, byte[] salt)
        => KeyDerivation.Pbkdf2(
            source,
            salt,
            KeyDerivationPrf.HMACSHA256,
            _options.IterationsCount,
            _options.RequestBytesLength
        );

    public (byte[] Hash, byte[] Salt) Hash(string source)
    {
        var salt = RandomNumberGenerator.GetBytes(_options.DefaultSaltLenght);
        return (Hash(source, salt), salt);
    }
}