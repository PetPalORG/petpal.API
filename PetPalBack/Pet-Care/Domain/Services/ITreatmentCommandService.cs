using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface ITreatmentCommandService
    {
        Task<Treatment?> Handle(CreateTreatmentCommand command);
        Task Handle(DeleteTreatmentCommand command);
    }
}
