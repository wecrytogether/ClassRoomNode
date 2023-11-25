using Application.Drivens.Identity.Dtos;
using Application.Drivens.Identity.Enums;

namespace Application.Drivens.Identity.Services;

public interface IAuthService
{
    void ThrowIfUnauthorized(string accessToken, Role allowedRole, out AuthorInfo info);
}