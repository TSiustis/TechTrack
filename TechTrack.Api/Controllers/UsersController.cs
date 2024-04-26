using global::TechTrack.Common.ViewModel.Users;
using Microsoft.AspNetCore.Mvc;
using TechTrack.Application.Users.Queries;

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
    }
}
