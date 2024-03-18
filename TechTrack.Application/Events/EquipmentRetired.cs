using TechTrack.Domain.Common;

namespace TechTrack.Application.Events
{
    public class EquipmentRetired : DomainEvent
    {
        public EquipmentRetired(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
