using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    public class PetController(IPetCommandService petCommandService, IPetQueryService petQueryService) : ControllerBase
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
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeletePet(int id)
        {
            try
            {
                var deletePetCommand = new DeletePetCommand(id);
                await petCommandService.Handle(deletePetCommand);
                return Ok("Pet deleted succesfully");
            }
            catch (KeyNotFoundException) 
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the pet.");
            }
        }
    }
}
