using Auth0Identity.Settings;

namespace StartUp.Configurations.External;

public static class ExternalConfigurationExt
{
    public static IConfigurationBuilder AddExternalConfiguration(this IConfigurationBuilder builder)
    {
        var tempConfig = builder.Build();

        // Auth0
        var auth0PublicKeyUrl = 
            tempConfig.GetSection($"{nameof(Auth0Identity)}:{nameof(Auth0IdentitySettings)}:{nameof(Auth0IdentitySettings.PublicKeyUrl)}").Value!;
        
        return builder.Add(new ExternalConfigurationSource
        {
            Auth0PublicKeyUrl = auth0PublicKeyUrl
        });
    }
}