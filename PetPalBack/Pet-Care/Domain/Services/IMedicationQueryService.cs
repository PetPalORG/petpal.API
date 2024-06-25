using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IMedicationQueryService
    {
        Task<Medication?> Handle(GetMedicationByIdQuery query);
    }
}
