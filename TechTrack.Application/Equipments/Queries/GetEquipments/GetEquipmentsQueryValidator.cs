using FluentValidation;

namespace TechTrack.Application.Equipments.Queries.GetEquipments;
public class GetEquipmentsQueryValidator : AbstractValidator<GetEquipmentsQuery>
{
	public GetEquipmentsQueryValidator()
	{
		RuleFor(query => query.Filter.PageSize)
			.InclusiveBetween(1, 100);

		RuleFor(query => query.Filter.PageNumber)
			.GreaterThan(0);
	}
}
