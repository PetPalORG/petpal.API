using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class AppointmentResourceFromEntityAssembler
    {
        public static AppointmentResource ToResourceFromEntity(Appointment resource)
        {
            return new AppointmentResource(resource.id, resource.vet, resource.reason, resource.detail, resource.date, resource.hour, resource.petId);
        }
    }
}
