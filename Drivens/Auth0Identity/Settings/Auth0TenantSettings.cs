namespace Auth0Identity.Settings;

public record Auth0TenantSettings
{
    public required string Url { get; init; }
    
    public required string ClientId { get; init; }

    public required string ClientSecret { get; init; }

    public required string Audience { get; init; }

    public required string GrantType { get; init; }
}