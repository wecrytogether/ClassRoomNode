using Application.Drivens.Identity.Services;
using Auth0Identity.Services;
using Auth0Identity.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth0Identity;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddAuth0Identity(this IServiceCollection services, IConfiguration configuration)
    {
        const string rootNamespace = nameof(Auth0Identity);
        
        services.Configure<Auth0IdentitySettings>(configuration.GetSection($"{rootNamespace}:{nameof(Auth0IdentitySettings)}"));
        services.Configure<Auth0TenantSettings>(configuration.GetSection($"{rootNamespace}:{nameof(Auth0TenantSettings)}"));

        services.AddSingleton<IAuthService, AuthServiceSingleton>();
        
        return services;
    }
}