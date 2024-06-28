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
    public class MealController(IMealCommandService mealCommandService, IMealQueryService mealQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateMeal([FromBody] CreateMealResource createDietResource)
        {
            var createMealCommand = CreateMealCommandFromResourceAssembler.ToCommandFromResource(createDietResource);
            var result = await mealCommandService.Handle(createMealCommand);
            if (result is null) return BadRequest();
            var resource = MealResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(GetMealById), new { id = result.Id }, resource);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetMealById([FromRoute] int id)
        {
            var getMealByIdQuery = new GetMealByIdQuery(id);
            var result = await mealQueryService.Handle(getMealByIdQuery);
            if (result is null) return NotFound();
            var resource = MealResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteMeal([FromRoute] int id)
        {
            try
            {
                var deleteMealCommand = new DeleteMealCommand(id);
                await mealCommandService.Handle(deleteMealCommand);
                return Ok("Diet deleted succesfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the meal.");
            }
        }
    }
}
