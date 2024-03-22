using global::TechTrack.Application.Users.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TechTrack.Application.Common.Pagination;
using TechTrack.Application.Equipments.Queries.GetEquipments;
using TechTrack.Application.Equipments.ViewModels;
using TechTrack.Application.Users.Queries;

namespace TechTrack.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ApiController
    {
        /// <summary>
        /// Gets the list of users with associated equipments.
        /// </summary>
        /// <returns>List of users.</returns>
        [HttpGet("with-equipments")]
        [ProducesResponseType(typeof(List<UserWithEquipmentsVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UserWithEquipmentsVm>>> GetUsersWithEquipments()
        {
            var userWithquipments = await Mediator.Send(new GetUsersWithEquipmentsQuery());

            return Ok(userWithquipments);
        }
    }
}
