using Microsoft.AspNetCore.Mvc;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Pet_Care.Interfaces.REST.Transformers;
using System.Net.Mime;

namespace PetPalBack.Pet_Care.Interfaces.REST
{
    [ApiController]
    [Route("api/v1/pets/{petId}/appointments")]
    [Produces(MediaTypeNames.Application.Json)]
    [Tags("Pets Appointments")]
    public class AppointmentPetsController(IAppointmentQueryService appointmentQueryService): ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAppointmentsByPetId([FromRoute] int petId)
        {
            var getAppointmentByPetIdQuery = new GetAppointmentByPetIdQuery(petId);
            var appointments = await appointmentQueryService.Handle(getAppointmentByPetIdQuery);
            var resources = appointments.Select(AppointmentResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
    }
}
