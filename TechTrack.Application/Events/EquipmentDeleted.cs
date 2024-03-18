using TechTrack.Domain.Common;

namespace TechTrack.Application.Events
{
    public class EquipmentDeleted : DomainEvent
    {
        public EquipmentDeleted(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
