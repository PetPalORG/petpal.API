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
        public async Task<ActionResult> CreateTreatment([FromBody] CreateTreatmentResource createTreatmentResource)
        {
            var createTreatmentCommand = CreateTreatmentCommandFromResourceAssembler.ToCommandFromResource(createTreatmentResource);
            var result = await treatmentCommandService.Handle(createTreatmentCommand);
            if (result is null) return BadRequest();
            var resource = TreatmentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(GetTreatmentById), new { id = result.Id }, resource);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTreatmentById([FromRoute] int id)
        {
            var getTreatmentByIdQuery = new GetTreatmentByIdQuery(id);
            var result = await treatmentQueryService.Handle(getTreatmentByIdQuery);
            if (result is null) return NotFound();
            var resource = TreatmentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteTreatment([FromRoute] int id)
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
