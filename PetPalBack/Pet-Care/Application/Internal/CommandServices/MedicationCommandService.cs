using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class MedicationCommandService(IMedicationRepository medicationRepository, IUnitOfWork unitOfWork): IMedicationCommandService
    {
        public async Task<Medication?> Handle(CreateMedicationCommand command)
        {
            var medication = new Medication(command);
            try
            {
                await medicationRepository.AddAsync(medication);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return medication;
        }

        public async Task Handle(DeleteMedicationCommand command)
        {
            var medication = await medicationRepository.FindByIdAsync(command.id);
            if (medication == null) { throw new Exception("Medication not found"); }
            try
            {
                medicationRepository.Remove(medication);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting medication");
            }
        }
    }
}
