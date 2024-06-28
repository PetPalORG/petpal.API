using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class CreateTreatmentCommandFromResourceAssembler
    {
        public static CreateTreatmentCommand ToCommandFromResource(CreateTreatmentResource resource)
        {
            return new CreateTreatmentCommand(resource.Diagnosis, resource.StartDate, resource.EndDate, resource.appointmentId);
        }
    }
}
