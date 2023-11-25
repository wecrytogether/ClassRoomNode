using Application.Drivens.Identity.Services;
using Application.Drivings.Commons.Models.Requests;
using MediatR;

namespace Application.Drivings.Commons.Pipelines;

public record AuthorizationPipeline<TReq, TRes> 
    : IPipelineBehavior<TReq, TRes> where TReq : IBaseRequest
{
    private readonly IAuthService _authService;

    public AuthorizationPipeline(IAuthService authService)
    {
        _authService = authService;
    }

    public Task<TRes> Handle(TReq request, RequestHandlerDelegate<TRes> next, CancellationToken stopToken)
    {
        if (request is not IAuthorizedRequest authorizedReq) 
            return next();
        
        _authService.ThrowIfUnauthorized(
            authorizedReq.AccessToken,
            authorizedReq.GetAllowedRole(),
            out var authorInfo);
        
        authorizedReq.AuthorInfo = authorInfo;
        
        return next();
    }
}