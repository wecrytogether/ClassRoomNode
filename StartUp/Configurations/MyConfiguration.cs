using StartUp.Configurations.External;

namespace StartUp.Configurations;

public class MyConfiguration
{
    public static IConfiguration Build()
    {
        #region DecideEnvironment
        
        var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        
        var configFilePath = $"appsettings.{environment}.json";
        
        #endregion

        var configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile(configFilePath, optional: true, reloadOnChange: true)
            .AddExternalConfiguration()
            .Build();

        return configuration;
    }
}