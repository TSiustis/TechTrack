using TechTrack.Domain.Common;

namespace TechTrack.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Raise(DomainEvent domainEvent, CancellationToken cancellationToken);
    }
}
