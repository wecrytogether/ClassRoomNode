using System.IdentityModel.Tokens.Jwt;
using Application.Drivens.Identity.Dtos;
using Application.Drivens.Identity.Enums;
using Application.Drivens.Identity.Exceptions;
using Application.Drivens.Identity.Services;
using Auth0Identity.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Auth0Identity.Services;

public record AuthServiceSingleton : IAuthService
{
    private readonly JwtSecurityTokenHandler _tokenHandler = new();

    private readonly TokenValidationParameters _tokenValidationParameters;

    public AuthServiceSingleton(IOptions<Auth0IdentitySettings> auth0IdentitySettingsOptions)
    {
        var auth0IdentitySettings = auth0IdentitySettingsOptions.Value;
        
        _tokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = auth0IdentitySettings.Issuer,
            ValidAudiences = auth0IdentitySettings.Audiences,
            ValidateLifetime = false, // TODO - for development only
            IssuerSigningKeys = new JsonWebKeySet(auth0IdentitySettings.PublicKeyStr).GetSigningKeys(),
            RequireSignedTokens = false
        };
    }
    
    public void ThrowIfUnauthorized(string accessToken, Role allowedRole, out AuthorInfo info)
    {
        try
        {
            var jwtToken = _tokenHandler.ReadJwtToken(accessToken);
            _tokenHandler.ValidateToken(accessToken, _tokenValidationParameters, out _);

            info = new AuthorInfo(jwtToken.Subject);
        }
        catch
        {
            throw new UnauthorizedExc();
        }
    }
}