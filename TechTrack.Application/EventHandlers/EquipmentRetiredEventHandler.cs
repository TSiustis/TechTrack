using MediatR;
using TechTrack.Application.Events;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.EventHandlers
{
    public class EquipmentRetiredEventHandler :
        INotificationHandler<DomainEventNotification<EquipmentRetired>>
    {
        private readonly IEquipmentReadRepository _equipmentReadRepository;

        public EquipmentRetiredEventHandler(IEquipmentReadRepository equipmentReadRepository)
        {
            _equipmentReadRepository = equipmentReadRepository;
        }

        public async Task Handle(DomainEventNotification<EquipmentRetired> notification, CancellationToken cancellationToken)
        {
            _equipmentReadRepository.Retire(notification.DomainEvent.Id);
            await _equipmentReadRepository.SaveChangesAsync(cancellationToken);
        }
    }
}