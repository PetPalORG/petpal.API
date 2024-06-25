using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class CreateAppointmentCommandFromResourceAssembler
    {
        public static CreateAppointmentCommand ToCommandFromResource(CreateAppointmentResource resource)
        {
            return new CreateAppointmentCommand(resource.reason, resource.date, resource.petId);
        }
    }
}
