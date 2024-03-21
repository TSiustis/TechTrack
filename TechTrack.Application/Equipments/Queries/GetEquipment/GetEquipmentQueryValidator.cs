using FluentValidation;

namespace TechTrack.Application.Equipments.Queries.GetEquipment
{
    public class GetEquipmentQueryValidator : AbstractValidator<GetEquipmentQuery>
    {
        public GetEquipmentQueryValidator()
        {
            RuleFor(q => q.Id)
                .NotEmpty()
                .NotNull();
        }
    }
}
