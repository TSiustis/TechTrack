using AutoMapper;
using MediatR;
using TechTrack.Common.Dtos.Equipments;
using TechTrack.Application.Interfaces.Equipments;

namespace TechTrack.Application.Equipments.Queries.GetEquipment
{
    public class GetEquipmentQueryHandler : IRequestHandler<GetEquipmentQuery, EquipmentDto>
    {
        private IEquipmentReadRepository _equipmentRepository;
        private IMapper _mapper;

        public GetEquipmentQueryHandler(IEquipmentReadRepository equipmentRepository, IMapper mapper)
        {
            _equipmentRepository = equipmentRepository;
            _mapper = mapper;
        }

        public async Task<EquipmentDto> Handle(GetEquipmentQuery request, CancellationToken cancellationToken)
        {
            var equipment = await _equipmentRepository.GetByIdAsync(request.Id, cancellationToken);

            return _mapper.Map<EquipmentDto>(equipment);
        }
    }
}
