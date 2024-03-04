using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTrack.Application.Equipment.Commands.CreateEquipment;
using TechTrack.Domain.Interfaces;

namespace TechTrack.Application.Equipment.Commands.DeleteEquipment
{
    public class DeleteEquipmentCommandHandler : IRequestHandler<DeleteEquipmentCommand>
    {
        private readonly IEquipmentRepository _equipmentRepository;

        public DeleteEquipmentCommandHandler(IEquipmentRepository equipmentRepository)
        {
            _equipmentRepository = equipmentRepository;
        }

        public Task Handle(DeleteEquipmentCommand request, CancellationToken cancellationToken)
        {
            _equipmentRepository.DeleteAsync(request.Id);

            return Task.CompletedTask;
        }
    }
}
