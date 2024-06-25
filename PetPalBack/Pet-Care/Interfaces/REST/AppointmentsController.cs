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
    public class AppointmentsController(IAppointmentCommandService appointmentCommandService, IAppointmentQueryService appointmentQueryService): ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult> CreateAppointment([FromBody] CreateAppointmentResource createAppointmentResource)
        {
            var createAppointmentCommand = CreateAppointmentCommandFromResourceAssembler.ToCommandFromResource(createAppointmentResource);
            var result = await appointmentCommandService.Handle(createAppointmentCommand);
            if (result is null) return BadRequest();
            var resource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = result.id }, resource);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllAppointments()
        {
            var getAllAppointmentsQuery = new GetAllAppointmentsQuery();
            var appointments = await appointmentQueryService.Handle(getAllAppointmentsQuery);
            var resources = appointments.Select(AppointmentResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult> GetAppointmentById([FromRoute] int id)
        {
            var getAppointmentByIdQuery = new GetAppointmentByIdQuery(id);
            var result = await appointmentQueryService.Handle(getAppointmentByIdQuery);
            if (result is null) return NotFound();
            var resource = AppointmentResourceFromEntityAssembler.ToResourceFromEntity(result);
            return Ok(resource);
        }
        [HttpDelete("id/{id}")]
        public async Task<ActionResult> DeleteAppointment([FromRoute] int id)
        {
            try
            {
                var deleteAppointmentCommand = new DeleteAppointmentCommand(id);
                await appointmentCommandService.Handle(deleteAppointmentCommand);
                return Ok("Appointment deleted succesfully");
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while deleting the appointment.");
            }
        }

    }
}
