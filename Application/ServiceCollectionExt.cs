using Application.Drivings.Commons.Pipelines;
using Application.Drivings.EndUser.Organization.V1.Dtos;
using Application.Drivings.EndUser.Organization.V1.UseCases;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region MediatR

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExt).Assembly));
        
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationPipeline<,>));
        
        /* Each Command Use Case have to be register with ValidationPipeline here */
        
        services.AddTransient(typeof(IPipelineBehavior<CreateOrgCommand, OrgResponse>), typeof(CommandValidationPipeline<CreateOrgCommand, CreateOrgBody, OrgResponse>));
        
        // services.AddTransient(typeof(IPipelineBehavior<x,z>), typeof(ValidationPipeline<x,y,z>));

        #endregion
        
        return services;
    }
}