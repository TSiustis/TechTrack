using TechTrack.Domain.Common;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Events
{
    public class EquipmentUpdated : DomainEvent
    {
        public EquipmentUpdated(Equipment equipment)
        {
            Equipment = equipment;
        }

        public Equipment Equipment { get; }
    }
}
