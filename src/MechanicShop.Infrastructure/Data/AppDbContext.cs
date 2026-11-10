using MechanicShop.Application.Common.Interfaces;
using MechanicShop.Domain.Common;
using MechanicShop.Domain.Identity;
using MechanicShop.Domain.Customers;
using MechanicShop.Domain.Customers.Vehicles;

using MechanicShop.Infrastructure.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MechanicShop.Domain.Employees;
namespace MechanicShop.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options, IMediator mediator) : IdentityDbContext<AppUser>(options), IAppDbContext
{
      public DbSet<RefreshToken> RefreshTokens => Set<RefreshToken>();
      public DbSet<Employee> Employees => Set<Employee>();
      public DbSet<Customer> Customers => Set<Customer>();
      public DbSet<Vehicle> Vehicles => Set<Vehicle>();


        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        await DispatchDomainEventsAsync(cancellationToken);
        return await base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

// Dispatch domain events before saving changes to the database
// This ensures that any side effects or additional actions triggered by domain events are handled appropriately
// The method retrieves all entities that have domain events, publishes those events using the mediator, 
// and then clears the domain events from the entities
// This pattern helps maintain a clean separation of concerns and ensures that domain events are processed in a consistent manner
// The method is asynchronous to allow for non-blocking operations, especially when dealing with I/O-bound tasks such as publishing events
// The cancellationToken parameter allows for cooperative cancellation of the operation, which is useful in scenarios where the operation may need to be aborted, such as during application shutdown or when a user cancels an action
// while the method is designed to be called before saving changes to the database, it can also be invoked independently if needed, providing flexibility in how domain events are handled within the application
// quickly and efficiently, ensuring that the application remains responsive and can handle multiple operations concurrently without unnecessary delays or blocking
 private async Task DispatchDomainEventsAsync(CancellationToken cancellationToken)
    {
        var domainEntities = ChangeTracker.Entries()
            .Where(e => e.Entity is Entity baseEntity && baseEntity.DomainEvents.Count != 0)
            .Select(e => (Entity)e.Entity)
            .ToList();

        var domainEvents = domainEntities
            .SelectMany(e => e.DomainEvents)
            .ToList();

        foreach (var domainEvent in domainEvents)
        {
            await mediator.Publish(domainEvent, cancellationToken);
        }

        foreach (var entity in domainEntities)
        {
            entity.ClearDomainEvents();
        }
    }

}