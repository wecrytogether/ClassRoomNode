namespace StartUp.Configurations.External;

public class ExternalConfigurationSource : IConfigurationSource
{
    public required string Auth0PublicKeyUrl { get; init; }
    
    public IConfigurationProvider Build(IConfigurationBuilder builder)
        => new ExternalConfigurationProvider
        {
            Auth0PublicKeyUrl = Auth0PublicKeyUrl
        };
}