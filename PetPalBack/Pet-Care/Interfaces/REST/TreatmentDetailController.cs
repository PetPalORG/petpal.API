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
        public async Task<ActionResult> CreateTreatmentDetail([FromBody] CreateTreatmentDetailsResource resource)
        {
            var createTreatmentDetailCommand = CreateTreatmentDetailsCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await treatmentDetailsCommandService.Handle(createTreatmentDetailCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetTreatmentDetailById), new { id = result.id }, TreatmentDetailsResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetTreatmentDetailById(int id)
        {
            var getTreatmentDetailByIdQuery = new GetTreatmentDetailById(id);
            var result = await treatmentDetailQueryService.Handle(getTreatmentDetailByIdQuery);
            if (result is null) return NotFound();
            var resource = TreatmentDetailsResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteTreatmentDetail(int id)
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
