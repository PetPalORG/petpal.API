using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface ITreatmentDetailsCommandService
    {
        Task<TreatmentDetail?> Handle(CreateTreatmentDetailsCommand command);
        Task Handle(DeleteTreatmentDetailCommand command);
    }
}
