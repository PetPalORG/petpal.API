using Google.Protobuf;
using Microsoft.AspNetCore.Mvc;
using PetPalBack.PetRegister.Domain.Model.Queries;
using PetPalBack.PetRegister.Domain.Services;
using PetPalBack.PetRegister.Interfaces.REST.Resources;
using PetPalBack.PetRegister.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.PetRegister.Interfaces.REST
{

    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PetController(IPetCommandService petCommandService, IPetQueryService petQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreatePet([FromBody] CreatePetResource resource)
        {
            var createPetCommand = CreatePetCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await petCommandService.Handle(createPetCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetPetById), new { id = result.Id }, PetResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetPetById(int id)
        {
            var getPetByIdQuery = new GetPetByIdQuery(id);
            var result = await petQueryService.Handle(getPetByIdQuery);
            if (result is null) return NotFound();
            var resource = PetResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpGet("name/{name}")]
        public async Task<ActionResult> GetPetByName(string name)
        {
            var getPetByNameQuery = new GetPetByNameQuery(name);
            var result = await petQueryService.Handle(getPetByNameQuery);
            if (result is null) return NotFound();
            var resource = PetResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
    }
}
