using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class TreatmentDetailsResourceFromEntityAssembler
    {
        public static TreatmentDetailsResource ToResourceFromEntity(TreatmentDetail entity)
        {
            return new TreatmentDetailsResource(entity.id, entity.treatmentId, entity.medicationId);
        }
    }
}
