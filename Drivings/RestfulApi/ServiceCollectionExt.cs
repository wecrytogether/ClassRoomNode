using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace RestfulApi;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddRestfulApiServices(this IServiceCollection services)
    {
        services
            .AddRouting(options => options.LowercaseUrls = true);

        services
            .AddControllers()
            .AddJsonOptions(
                options =>
                {
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
                })
            .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

        services.AddEndpointsApiExplorer();

        services.Configure<ApiBehaviorOptions>(
            options => { options.SuppressModelStateInvalidFilter = true; });
        
        return services;
    }
}