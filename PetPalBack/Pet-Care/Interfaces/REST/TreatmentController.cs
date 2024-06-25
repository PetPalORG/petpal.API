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
    public class TreatmentController(ITreatmentCommandService treatmentCommandService, ITreatmentQueryService treatmentQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateTreatment([FromBody] CreateTreatmentResource resource)
        {
            var createTreatmentCommand = CreateTreatmentCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await treatmentCommandService.Handle(createTreatmentCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetTreatmentById), new { id = result.Id }, TreatmentResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTreatmentById(int id)
        {
            var getTreatmentByIdQuery = new GetTreatmentById(id);
            var result = await treatmentQueryService.Handle(getTreatmentByIdQuery);
            if (result is null) return NotFound();
            var resource = TreatmentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteTreatment(int id)
        {
            try
            {
                var deleteTreatmentCommand = new DeleteTreatmentCommand(id);
                await treatmentCommandService.Handle(deleteTreatmentCommand);
                return Ok("Treatment deleted succesfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the treatment.");
            }
        }
    }
}
