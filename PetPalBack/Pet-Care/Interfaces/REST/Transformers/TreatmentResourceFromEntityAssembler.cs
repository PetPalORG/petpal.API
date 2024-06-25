using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class TreatmentResourceFromEntityAssembler
    {
        public static TreatmentResource ToResourceFromEntity(Treatment entity)
        {
            return new TreatmentResource(entity.Id, entity.Diagnosis, entity.StartDate, entity.EndDate, entity.appointmentId);
        }
    }
}
