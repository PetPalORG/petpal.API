using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class TreatmentDetailQueryService(ITreatmentDetailsRepository treatmentDetailRepository): ITreatmentDetailQueryService
    {
        public async Task<TreatmentDetail?> Handle(GetTreatmentDetailById query)
        {
            return await treatmentDetailRepository.FindByIdAsync(query.id);
        }
    }
}
