using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class CreateMedicationCommandFromResourceAssembler
    {
        public static CreateMedicationCommand ToCommandFromResource(CreateMedicationResource resource)
        {
            return new CreateMedicationCommand(resource.name, resource.dosage, resource.frequency, resource.duration, resource.treatmentDetailId);
        }
    }
}
