using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IMedicationCommandService
    {
        Task<Medication?> Handle(CreateMedicationCommand command);
        Task Handle(DeleteMedicationCommand command);
    }
}
