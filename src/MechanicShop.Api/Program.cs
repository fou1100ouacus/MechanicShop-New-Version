using MechanicShop.Infrastructure.Data;
using Serilog;
using Microsoft.AspNetCore.Components;
using Scalar.AspNetCore;
var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();

    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/openapi/v1.json", "MechanicShop API V1");

        options.EnableDeepLinking();
        options.DisplayRequestDuration();
        options.EnableFilter();
    });

    app.MapScalarApiReference();

   await app.InitialiseDatabaseAsync();

    app.UseWebAssemblyDebugging();
}
else
{
    app.UseHsts();
}

app.UseCoreMiddlewares(builder.Configuration);

app.MapControllers();





app.Run();
//  dotnet ef migrations add InitialCreate --startup-project ../MechanicShop.Api            
//dotnet ef database update --startup-project ../MechanicShop.Api
