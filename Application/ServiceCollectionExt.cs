using Application.Drivings.Commons.Pipelines;
using Application.Drivings.Organization.V1.UseCases;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Application;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        #region MediatR

        // services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceCollectionExt).Assembly));
        
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationPipeline<,>));
        
        /* Each Command Use Case have to be register with ValidationPipeline here */
        
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(CommandValidationPipeline<CreateOrgCommand, CreateOrgBody, Unit>));
        
        // services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipeline<x,x,x>));

        #endregion
        
        return services;
    }
}