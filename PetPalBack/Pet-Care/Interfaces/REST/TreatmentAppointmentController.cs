using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/appointments/{appointmentId}/treatment")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Appointments treatment")]
    public class TreatmentAppointmentController(ITreatmentQueryService treatmentQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetTreatmentByAppointmentId([FromRoute] int appointmentId)
        {
            var getTreatmentByAppointmentIdQuery = new GetTreatmentByAppointmentIdQuery(appointmentId);
            var treatment = await treatmentQueryService.Handle(getTreatmentByAppointmentIdQuery);
            var resources = treatment.Select(TreatmentResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
