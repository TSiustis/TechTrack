using MediatR;
using TechTrack.Common.Dtos.Equipments;

namespace TechTrack.Application.Equipments.Queries.GetEquipment
{
    public class GetEquipmentQuery : IRequest<EquipmentDto>
    {
        public GetEquipmentQuery(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
