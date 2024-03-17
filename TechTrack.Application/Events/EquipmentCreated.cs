using TechTrack.Domain.Common;
using TechTrack.Domain.Models;

namespace TechTrack.Application.Events
{
    public class EquipmentCreated : DomainEvent
    {
        public EquipmentCreated(Equipment equipment)
        {
            Equipment = equipment;
        }

        public Equipment Equipment { get; }
    }
}
