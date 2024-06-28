using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/treatments/{treatmentId}/medication")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Treatments medication")]
    public class TreatmentsMedicationController(IMedicationQueryService medicationQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetMedicationByTreatmentId([FromRoute] int treatmentId)
        {
            var getMedicationByTreatmentIdQuery = new GetMedicationByTreatmentId(treatmentId);
            var medication = await medicationQueryService.Handle(getMedicationByTreatmentIdQuery);
            var resources = medication.Select(MedicationResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
