using Meteor.Common.Cryptography.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace Meteor.Common.Cryptography.DependencyInjection.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddHasher(
        this IServiceCollection services,
        Action<HasherOptions> configureOptions,
        ServiceLifetime hasherLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
    )
    {
        services.AddScoped<HasherOptions>(_ =>
        {
            var options = new HasherOptions();
            configureOptions.Invoke(options);
            return options;
        });
        services.AddScoped<IHasher, Pbkdf2Hasher>();
    }

    public static void AddEncryptor(
        this IServiceCollection services,
        Action<EncryptorOptions> configureOptions,
        ServiceLifetime hasherLifetime = ServiceLifetime.Scoped,
        ServiceLifetime optionsLifetime = ServiceLifetime.Scoped
    )
    {
        services.AddScoped<EncryptorOptions>(_ =>
        {
            var options = new EncryptorOptions();
            configureOptions.Invoke(options);
            return options;
        });
        services.AddScoped<IEncryptor, AesEncryptor>();
    }
}