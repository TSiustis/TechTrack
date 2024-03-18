using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.EventHandlers
{
    public class EquipmentDeletedEventHandler :
        INotificationHandler<DomainEventNotification<EquipmentDeleted>>
    {
        private readonly IEquipmentReadRepository _equipmentReadRepository;

        public EquipmentDeletedEventHandler(IEquipmentReadRepository equipmentReadRepository)
        {
            _equipmentReadRepository = equipmentReadRepository;
        }

        public async Task Handle(DomainEventNotification<EquipmentDeleted> notification, CancellationToken cancellationToken)
        {
            _equipmentReadRepository.Delete(notification.DomainEvent.Id);
            await _equipmentReadRepository.SaveChangesAsync(cancellationToken);
        }
    }
}