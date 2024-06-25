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
    public class TreatmentDetailController(ITreatmentDetailsCommandService treatmentDetailsCommandService, ITreatmentDetailQueryService treatmentDetailQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateTreatmentDetail([FromBody] CreateTreatmentDetailsResource createTreatmentDetailsResource)
        {
            var createTreatmentDetailCommand = CreateTreatmentDetailsCommandFromResourceAssembler.ToCommandFromResource(createTreatmentDetailsResource);
            var result = await treatmentDetailsCommandService.Handle(createTreatmentDetailCommand);
            if (result is null) return BadRequest();
            var resource = TreatmentDetailsResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(GetTreatmentDetailById), new { Id = result.id }, resource);
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTreatmentDetailById([FromRoute] int id)
        {
            var getTreatmentDetailByIdQuery = new GetTreatmentDetailByIdQuery(id);
            var result = await treatmentDetailQueryService.Handle(getTreatmentDetailByIdQuery);
            if (result is null) return NotFound();
            var resource = TreatmentDetailsResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteTreatmentDetail([FromRoute] int id)
        {
            try
            {
                var deleteTreatmentDetailCommand = new DeleteTreatmentDetailCommand(id);
                await treatmentDetailsCommandService.Handle(deleteTreatmentDetailCommand);
                return Ok("Treatment detail deleted succesfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the treatment detail.");
            }
        }
    }
}
