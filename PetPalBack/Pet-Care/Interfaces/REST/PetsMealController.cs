using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/pets/{petId}/meal")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Pet meals")]
    public class PetsMealController(IMealQueryService dietQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetMealByPetId([FromRoute] int petId)
        {
            var getMealByPetIdQuery = new GetMealByPetIdQuery(petId);
            var meal = await dietQueryService.Handle(getMealByPetIdQuery);
            var resources = meal.Select(MealResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
