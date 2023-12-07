using Auth0Identity.Settings;

namespace StartUp.Configurations.External;

public class ExternalConfigurationProvider : ConfigurationProvider, IDisposable
{
    private readonly HttpClient _httpClient = new();
    
    public required string Auth0PublicKeyUrl { get; init; }

    public override void Load()
    {
        Data = LoadAuth0Configurations();
    }

    // Auth0
    private IDictionary<string, string?> LoadAuth0Configurations()
    {
        const string publicKeyStrKey = $"{nameof(Auth0Identity)}:{nameof(Auth0IdentitySettings)}:{nameof(Auth0IdentitySettings.PublicKeyStr)}";
        var publicKeyStrVal = _httpClient.GetStringAsync(Auth0PublicKeyUrl).Result;
        
        return new Dictionary<string, string?>()
        {
            [publicKeyStrKey] = publicKeyStrVal
        };
    }

    public void Dispose()
    {
        _httpClient.Dispose();
    }
}