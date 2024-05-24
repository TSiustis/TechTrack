using global::TechTrack.Common.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;
using TechTrack.Application.Users.Commands;
using TechTrack.Application.Users.Queries;
using TechTrack.Common.Dtos.Users;

namespace TechTrack.Api.Controllers
{
    public class UsersController : ApiController
    {
        /// <summary>
        /// Gets the list of users with associated equipments.
        /// </summary>
        /// <returns>List of users.</returns>
        [HttpGet("users/with-equipments")]
        [ProducesResponseType(typeof(List<UserWithEquipmentsVm>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<List<UserWithEquipmentsVm>>> GetUsersWithEquipments()
        {
            var userWithquipments = await Mediator.Send(new GetUsersWithEquipmentsQuery());

            return Ok(userWithquipments);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserForCreationDto createUserDto)
        {
            var command = new CreateUserCommand(createUserDto);

            var userId = await Mediator.Send(command);

            return Ok(userId);
        }
    }
}
