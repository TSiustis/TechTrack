using MediatR;
using TechTrack.Application.Common.Interfaces;
using TechTrack.Domain.Common;

namespace TechTrack.Application.Events;
public class DomainEventService : IDomainEventService
{
    private readonly IMediator _mediator;

    public DomainEventService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task Raise(DomainEvent domainEvent, CancellationToken cancellationToken)
    {
        await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent), cancellationToken);
    }

    private INotification GetNotificationCorrespondingToDomainEvent(DomainEvent domainEvent)
    {
        return (INotification)Activator.CreateInstance(
            typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
    }
}   