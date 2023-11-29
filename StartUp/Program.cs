using Application;
using PrimaryDbSqlServer;
using RestfulApi;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services
    .AddPrimaryDbSqlServerServices(configuration)
    .AddApplicationServices()
    .AddRestfulApiServices();

var app = builder.Build();

app.UseRestfulApiConfigurations();

app.MapGet("/", () => "Hello World!");

app.Run();