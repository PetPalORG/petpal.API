using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/treatments/{treatmentId}/treatment-detail")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Treatments detail")]
    public class TreatmentDetailTreatmentController(ITreatmentDetailQueryService treatmentDetailQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetTreatmentDetailByTreatmentId([FromRoute] int treatmentId)
        {
            var getTreatmentDetailByTreatmentIdQuery = new GetTreatmentDetailByTreatmentIdQuery(treatmentId);
            var treatmentDetail = await treatmentDetailQueryService.Handle(getTreatmentDetailByTreatmentIdQuery);
            var resources = TreatmentDetailsResourceFromEntityAssembler.ToResourceFromEntity(treatmentDetail);
            return Ok(resources);
        }
    }
}
