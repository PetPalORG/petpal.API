using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class MedicationQueryService(IMedicationRepository medicationRepository): IMedicationQueryService
    {
        public async Task<Medication?> Handle(GetMedicationByIdQuery query)
        {
            return await medicationRepository.FindByIdAsync(query.id);
        }

    }
}
