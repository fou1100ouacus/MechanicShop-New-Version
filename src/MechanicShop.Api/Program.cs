using MechanicShop.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);


builder.Services
    .AddPresentation(builder.Configuration)
    .AddApplication()
    .AddInfrastructure(builder.Configuration);

var app = builder.Build();




app.Run();
//  dotnet ef migrations add InitialCreate --startup-project ../MechanicShop.Api            
//dotnet ef database update --startup-project ../MechanicShop.Api
