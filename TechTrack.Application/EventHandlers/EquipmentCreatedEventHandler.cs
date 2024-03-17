using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.EventHandlers
{
    public class EquipmentCreatedEventHandler :
            INotificationHandler<DomainEventNotification<EquipmentCreated>>
    {
        private readonly IEquipmentReadRepository _equipmentReadRepository;

        public EquipmentCreatedEventHandler(IEquipmentReadRepository equipmentReadRepository)
        {
            _equipmentReadRepository = equipmentReadRepository;
        }

        public async Task Handle(DomainEventNotification<EquipmentCreated> notification, CancellationToken cancellationToken)
        {
            await _equipmentReadRepository.Add(notification.DomainEvent.Equipment);
            await _equipmentReadRepository.SaveChangesAsync();
        }
    }
}
