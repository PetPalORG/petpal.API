using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface ITreatmentDetailQueryService
    {
        Task<TreatmentDetail?> Handle(GetTreatmentDetailByIdQuery query);
        Task<TreatmentDetail?> Handle(GetTreatmentDetailByTreatmentIdQuery query);
    }
}
