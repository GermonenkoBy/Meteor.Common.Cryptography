namespace Meteor.Common.Cryptography;

public record HasherOptions
{
    public int RequestBytesLength { get; set; }

    public int DefaultSaltLenght { get; set; }

    public int IterationsCount { get; set; }
}