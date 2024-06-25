using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class CreateTreatmentDetailsCommandFromResourceAssembler
    {
        public static CreateTreatmentDetailsCommand ToCommandFromResource(CreateTreatmentDetailsResource resource)
        {
            return new CreateTreatmentDetailsCommand(resource.treatmentId);
        }
    }
}
