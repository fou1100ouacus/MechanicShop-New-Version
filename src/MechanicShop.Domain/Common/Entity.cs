using System.ComponentModel.DataAnnotations.Schema;

namespace MechanicShop.Domain.Common;

public abstract class Entity
{// abstract class is a class that cannot be instantiated and is typically used as a base class for other classes.
    public Guid Id { get; }
// A private readonly list to hold domain events associated with the entity.
    private readonly List<DomainEvent> _domainEvents = [];

    [NotMapped] //Denotes that a property or class should be excluded from database mapping.
    // A public read-only collection to expose the domain events without
    //  allowing external modification.
    public IReadOnlyCollection<DomainEvent> DomainEvents => _domainEvents.AsReadOnly();
// constructor to initialize the entity with a new or provided GUID. 
    protected Entity()
    { }

    protected Entity(Guid id)
    {
        Id = id == Guid.Empty ? Guid.NewGuid() : id;
    }

    public void AddDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }
// A method to remove a specific domain event from the entity's list of events.
    public void RemoveDomainEvent(DomainEvent domainEvent)
    {
        _domainEvents.Remove(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}