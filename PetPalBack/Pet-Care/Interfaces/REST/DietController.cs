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
    public class DietController(IDietCommandService dietCommandService, IDietQueryService dietQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateDiet([FromBody] CreateDietResource resource)
        {
            var createDietCommand = CreateDietCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await dietCommandService.Handle(createDietCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetDietById), new { id = result.Id }, DietResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetDietById(int id)
        {
            var getDietByIdQuery = new GetDietById(id);
            var result = await dietQueryService.Handle(getDietByIdQuery);
            if (result is null) return NotFound();
            var resource = DietResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteDiet(int id)
        {
            try
            {
                var deleteDietCommand = new DeleteDietCommand(id);
                await dietCommandService.Handle(deleteDietCommand);
                return Ok("Diet deleted succesfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the diet.");
            }
        }
    }
}
