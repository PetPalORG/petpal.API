using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class MedicationResourceFromEntityAssembler
    {
        public static MedicationResource ToResourceFromEntity(Medication entity)
        {
            return new MedicationResource(entity.Id, entity.Name, entity.Dosage, entity.Frequency, entity.Duration, entity.treatmentDetailId);
        }
    }
}
