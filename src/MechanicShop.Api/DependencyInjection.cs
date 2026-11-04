
using MechanicShop.Api.Services;
using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    
    public static IServiceCollection AddPresentation(this IServiceCollection services, IConfiguration configuration)
    {
      //  services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

      //  QuestPDF.Settings.License = QuestPDF.Infrastructure.LicenseType.Community;

            services.AddIdentityInfrastructure();

        // services.AddCustomProblemDetails()
        //         .AddCustomApiVersioning()
        //         .AddApiDocumentation()
        //         .AddExceptionHandling()
        //         .AddControllerWithJsonConfiguration()
        //         .AddValidation()
        //         .AddConfiguredCors(configuration)
        //         .AddIdentityInfrastructure()
        //         .AddAppRateLimiting()
        //         .AddAppOutputCaching()
        //         .AddAppOpenTelememrty()
        //         .AddSignalR();

        return services;
    }
    public static IServiceCollection AddIdentityInfrastructure(this IServiceCollection services)
    {
       services.AddScoped<IUser, CurrentUser>();
        services.AddHttpContextAccessor();
        return services;
    }
    public static IApplicationBuilder UseCoreMiddlewares(this IApplicationBuilder app, IConfiguration configuration)
    {
        // 1. Exception handling should be FIRST to catch all errors
        app.UseExceptionHandler();

        // 2. Status code pages for handling HTTP status codes
        app.UseStatusCodePages();

        // 3. HTTPS redirection (before any other middleware that might generate URLs)
        app.UseHttpsRedirection();

        // 4. Serilog request logging (early to log all requests)
  //      app.UseSerilogRequestLogging();

        // 5. CORS (before authentication/authorization)
        app.UseCors(configuration["AppSettings:CorsPolicyName"]!);

        // 6. Rate limiting (before authentication to protect auth endpoints)
        app.UseRateLimiter();

        // 7. Authentication (must come before authorization)
        app.UseAuthentication();

        // 8. Authorization (must come after authentication)
        app.UseAuthorization();

        // 9. Output caching (after auth to cache based on user context)
        app.UseOutputCache();

        return app;
    }

  
}