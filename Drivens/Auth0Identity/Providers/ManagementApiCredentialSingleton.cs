using Auth0.AuthenticationApi;
using Auth0.AuthenticationApi.Models;
using Auth0Identity.Settings;
using Microsoft.Extensions.Options;

namespace Auth0Identity.Providers;

public record ManagementApiCredentialSingleton
{
    private readonly IAuthenticationApiClient _auth0AuthenticationApiClient;
    private readonly ClientCredentialsTokenRequest _auth0ClientCredentials;

    private readonly SemaphoreSlim _semaphoreSlim;

    public string AccessToken { get; private set; } = null!;
    
    public ManagementApiCredentialSingleton(IOptions<Auth0TenantSettings> auth0TenantSettingsOptions) {
        var auth0TenantSettings = auth0TenantSettingsOptions.Value;
        
        _semaphoreSlim = new SemaphoreSlim(1);
        
        _auth0AuthenticationApiClient = new AuthenticationApiClient(new Uri(auth0TenantSettings.Url));
        _auth0ClientCredentials = new ClientCredentialsTokenRequest
        {
            ClientId = auth0TenantSettings.ClientId,
            ClientSecret = auth0TenantSettings.ClientSecret,
            Audience = auth0TenantSettings.Audience
        };
    }
    
    // TODO will this work?
    public async Task RefreshAccessTokenAsync(CancellationToken cancellationToken = default)
    {
        // locking the object
        await _semaphoreSlim.WaitAsync(cancellationToken);

        try
        {
            var response = await _auth0AuthenticationApiClient.GetTokenAsync(_auth0ClientCredentials, cancellationToken);
            AccessToken = response.AccessToken;
        }
        finally
        {
            _semaphoreSlim.Release();
        }
    }
}