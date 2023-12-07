using Application;
using Auth0Identity;
using PrimaryDbSqlServer;
using RestfulApi;
using StartUp.Configurations;

var builder = WebApplication.CreateBuilder(args);
var configuration = MyConfiguration.Build();

builder.Services
    // Drivens
    .AddPrimaryDbSqlServerServices(configuration)
    .AddAuth0Identity(configuration)
    
    // Application
    .AddApplicationServices()
    
    // Drivings
    .AddRestfulApiServices();

var app = builder.Build();

app.UseRestfulApiConfigurations();

app.MapGet("/", () => "Hello World!");

app.Run();