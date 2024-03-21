using MediatR;
using TechTrack.Domain.Common;

namespace TechTrack.Application.Events
{
    public class DomainEventNotification<TDomainEvent> : INotification
       where TDomainEvent : DomainEvent
    {
        public DomainEventNotification(TDomainEvent domainEvent)
        {
            DomainEvent = domainEvent;
        }

        public TDomainEvent DomainEvent { get; }
    }
}
