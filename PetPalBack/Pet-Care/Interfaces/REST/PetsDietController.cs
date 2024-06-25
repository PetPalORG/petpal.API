using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/pets/{petId}/diet")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Pets Diet")]
    public class PetsDietController(IDietQueryService dietQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetDietByPetId([FromRoute] int petId)
        {
            var getDietByPetIdQuery = new GetDietByPetIdQuery(petId);
            var diet = await dietQueryService.Handle(getDietByPetIdQuery);
            var resources = diet.Select(DietResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
