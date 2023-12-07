namespace Auth0Identity.Settings;

public record Auth0IdentitySettings
{
    public required string Domain { get; init; }

    public required string Issuer { get; init; }

    public required List<string> Audiences { get; init; }

    public required string PublicKeyUrl { get; init; }

    public required string PublicKeyStr { get; init; }
}