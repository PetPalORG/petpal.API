using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class TreatmentQueryService(ITreatmentRepository treatmentRepository): ITreatmentQueryService
    {
        public async Task<Treatment?> Handle(GetTreatmentById query)
        {
            return await treatmentRepository.FindByIdAsync(query.id);
        }
    }
}
