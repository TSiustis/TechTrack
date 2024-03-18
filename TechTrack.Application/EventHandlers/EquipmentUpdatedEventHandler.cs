using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.EventHandlers
{
    public class EquipmentUpdatedEventHandler : INotificationHandler<DomainEventNotification<EquipmentUpdated>>
    {
        private readonly IEquipmentReadRepository _equipmentReadRepository;

        public EquipmentUpdatedEventHandler(IEquipmentReadRepository equipmentReadRepository)
        {
            _equipmentReadRepository = equipmentReadRepository;
        }

        public async Task Handle(DomainEventNotification<EquipmentUpdated> notification, CancellationToken cancellationToken)
        {
            _equipmentReadRepository.Update(notification.DomainEvent.Equipment);
            await _equipmentReadRepository.SaveChangesAsync(cancellationToken);
        }
    }
}
