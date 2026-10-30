// using MediatR;

// <summary>
// Base class for domain events.
// used for events that are raised by entities or aggregates within the domain model.
// MediatR is a popular library for implementing the mediator pattern in .NET applications
// , and it provides a way to handle domain events in a decoupled manner.
// The INotification interface is part of MediatR and is used to mark a class as a notification 
// or event that can be published and handled by multiple handlers.
// </summary>
namespace MechanicShop.Domain.Common;

public abstract class DomainEvent : INotification;