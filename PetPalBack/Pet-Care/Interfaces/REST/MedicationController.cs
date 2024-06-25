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
    public class MedicationController(
        IMedicationCommandService medicationCommandService,
        IMedicationQueryService medicationQueryService
    ) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateMedication([FromBody] CreateMedicationResource resource)
        {
            var createMedicationCommand = CreateMedicationCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await medicationCommandService.Handle(createMedicationCommand);
            if (result is null) return BadRequest();
            return CreatedAtAction(nameof(GetMedicationById), new { id = result.Id }, MedicationResourceFromEntityAssembler.ToResourceFromEntity(result));
        }
        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetMedicationById(int id)
        {
            var getMedicationByIdQuery = new GetMedicationById(id);
            var result = await medicationQueryService.Handle(getMedicationByIdQuery);
            if (result is null) return NotFound();
            var resource = MedicationResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteMedication(int id)
        {
            try
            {
                var deleteMedicationCommand = new DeleteMedicationCommand(id);
                await medicationCommandService.Handle(deleteMedicationCommand);
                return Ok("Medication deleted succesfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the medication.");
            }
        }
    }
}
