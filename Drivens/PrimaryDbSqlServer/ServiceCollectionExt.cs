using Application.Drivens.PrimaryDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrimaryDbSqlServer.Settings;

namespace PrimaryDbSqlServer;

public static class ServiceCollectionExt
{
    public static IServiceCollection AddPrimaryDbSqlServerServices(this IServiceCollection services, IConfiguration configuration)
    {
        var assemblyName = typeof(PrimaryDbSqlServerSettings).Assembly.GetName().Name!;
        
        var sqlServerPrimaryDbSettings = configuration.GetSection($"{assemblyName}:{nameof(PrimaryDbSqlServerSettings)}").Get<PrimaryDbSqlServerSettings>()!;
        
        services.Configure<PrimaryDbSqlServerSettings>(configuration.GetSection($"{assemblyName}:{nameof(PrimaryDbSqlServerSettings)}"));
        
        services.AddDbContext<PrimaryDbSqlServerCtx>(
            optionsAction => optionsAction.UseSqlServer(sqlServerPrimaryDbSettings.ConnectionStr));
        
        services.AddScoped<PrimaryDbCtx>(provider => provider.GetRequiredService<PrimaryDbSqlServerCtx>());
        
        return services;
    }
}