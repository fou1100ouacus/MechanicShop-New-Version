
using MechanicShop.Infrastructure.Data;
using MechanicShop.Infrastructure.Data.Interceptors;
using MechanicShop.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;//ISaveChangesInterceptor
using Microsoft.Extensions.Caching.Hybrid;
using Microsoft.Extensions.Configuration;// iConfiguration
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Infrastructure.Identity.Policies;

namespace Microsoft.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton(TimeProvider.System);

        // AppDbContext publishes domain events from SaveChangesAsync, and EF tooling
        // resolves the context from the application's service provider at design time.
        // the following line is required to ensure that the mediator is available at design time.
        // Mediator is registered in the application layer, so we need to add it here as well.
        // used for dispatching domain events from the DbContext and for the design-time DbContext factory.
        // 
        services.AddMediatR(options =>
            options.RegisterServicesFromAssembly(typeof(AppDbContext).Assembly));
        
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        ArgumentNullException.ThrowIfNull(connectionString);
        services.AddHttpContextAccessor();
        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();

        services.AddDbContext<AppDbContext>((sp, options) =>
        {
            options.AddInterceptors(sp.GetServices<ISaveChangesInterceptor>());
            options.UseSqlServer(connectionString);
        });

        services.AddScoped<IAppDbContext>(provider => provider.GetRequiredService<AppDbContext>());

       services.AddScoped<ApplicationDbContextInitialiser>();

        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>{
            var jwtSettings = configuration.GetSection("JwtSettings");

            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(
                       Encoding.UTF8.GetBytes(jwtSettings["Secret"]!)),
            };
        });

        services
        .AddIdentityCore<AppUser>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireDigit = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireLowercase = false;
            options.Password.RequiredUniqueChars = 1;
            options.SignIn.RequireConfirmedAccount = false;
        })
        .AddRoles<IdentityRole>()
        .AddEntityFrameworkStores<AppDbContext>();
// who can access a work order?  The labor assigned to it, or a manager.  This is enforced by the LaborAssignedHandler, which is registered below.  The handler checks if the user is assigned to the work order, or if they are a manager.  If neither, access is denied.  The handler is registered as a scoped service, and the requirement is added to the authorization policy.

 
      services.AddScoped<IAuthorizationHandler, LaborAssignedHandler>();

        services.AddAuthorizationBuilder()
              .AddPolicy("ManagerOnly", policy => policy.RequireRole("Manager"))
              .AddPolicy("SelfScopedWorkOrderAccess", policy =>
                policy.Requirements.Add(new LaborAssignedRequirement()));

       services.AddTransient<IIdentityService, IdentityService>();

        services.AddHybridCache(options => options.DefaultEntryOptions = new HybridCacheEntryOptions
        {
            Expiration = TimeSpan.FromMinutes(10), // L2, L3
            LocalCacheExpiration = TimeSpan.FromSeconds(30), // L1
        });
   
   
     //   services.AddScoped<IWorkOrderPolicy, WorkOrderPolicy>();

       services.AddScoped<ITokenProvider, TokenProvider>();

    //    services.AddScoped<IInvoicePdfGenerator, InvoicePdfGenerator>();
//
 //       services.AddScoped<INotificationService, NotificationService>();

   //     services.AddScoped<IWorkOrderNotifier, SignalRWorkOrderNotifier>();

  //      services.AddHostedService<OverdueBookingCleanupService>();

        return services;
    }
 


}
