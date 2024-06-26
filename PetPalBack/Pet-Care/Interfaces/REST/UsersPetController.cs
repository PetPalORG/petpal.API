using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/users/{userId}/pet")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("User pets")]
    public class UsersPetController(IPetCommandService petCommandService, IPetQueryService petQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetPetsByUserId([FromRoute] int userId)
        {
            var getPetsByUserIdQuery = new GetPetsByUserIdQuery(userId);
            var pets = await petQueryService.Handle(getPetsByUserIdQuery);
            var resources = pets.Select(PetResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
