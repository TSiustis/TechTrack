using Microsoft.AspNetCore.Mvc;
using TechTrack.Application.Common.Pagination;
using TechTrack.Application.Equipments.Commands.CreateEquipment;
using TechTrack.Application.Equipments.Commands.DeleteEquipment;
using TechTrack.Application.Equipments.Commands.UpdateEquipment;
using TechTrack.Application.Equipments.Dtos;
using TechTrack.Application.Equipments.Queries.GetEquipment;
using TechTrack.Application.Equipments.Queries.GetEquipments;
using TechTrack.Application.Equipments.ViewModels;

namespace TechTrack.Api.Controllers
{
    public class EquipmentController : ApiController
    {
        /// <summary>
        /// Gets the list of equipments for specified filters.
        /// </summary>
        /// <param name="equipmentsFilter">Additional search filters to be applied.</param>
        /// <returns>Paginated list of tenders.</returns>
        [HttpGet("equipments")]
        [ProducesResponseType(typeof(PaginatedResult<EquipmentOutputVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PaginatedResult<EquipmentOutputVm>>> TendersSummary( 
            [FromQuery] EquipmentInputVm equipmentsFilter)
        {
            var equipments = await Mediator.Send(new GetEquipmentsQuery(equipmentsFilter));

            return Ok(equipments);
        }

        /// <summary>
        /// Gets the equipment for a specified guid.
        /// </summary>
        /// <param name="id">The guid.</param>
        /// <returns>Equipment.</returns>
        [HttpGet("equipment/{id:Guid}")]
        [ProducesResponseType(typeof(EquipmentDto), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EquipmentDto>> GetEquipmentAsync(Guid id)
        {
            var equipment = await Mediator.Send(new GetEquipmentQuery(id));

            return Ok(equipment);
        }

        /// <summary>
        /// Creates an equipment.
        /// </summary>
        /// <param name="equipmentDto">The created equipment.</param>
        /// <returns>201 Created.</returns>
        [HttpPost("equipments")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateEquipmentAsync(
            [FromBody] EquipmentForCreationDto equipmentDto)
        {
            await Mediator.Send(new CreateEquipmentCommand(equipmentDto));

            return Created();
        }

        /// <summary>
        /// Updates equipment for specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <param name="equipmentDto">The updated equipment.</param>
        /// <returns>200 OK.</returns>
        [HttpPut("equipments/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateEquipmentAsync(
            Guid id,
            [FromBody] EquipmentForUpdateDto equipmentDto)
        {
            await Mediator.Send(new UpdateEquipmentCommand(id, equipmentDto));

            return Ok();
        }

        /// <summary>
        /// Deletes an equipment for a specified id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>204 No content.</returns>
        [HttpDelete("equipments/{id:Guid}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteEquipmentAsync(Guid id)
        {
            await Mediator.Send(new DeleteEquipmentCommand(id));

            return NoContent();
        }
    }
}
