using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class TreatmentCommandService(ITreatmentRepository treatmentRepository, IUnitOfWork unitOfWork): ITreatmentCommandService
    {
        public async Task<Treatment?> Handle(CreateTreatmentCommand command)
        {
            var treatment = new Treatment(command);
            try
            {
                await treatmentRepository.AddAsync(treatment);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return treatment;
        }

        public async Task Handle(DeleteTreatmentCommand command)
        {
            var treatment = await treatmentRepository.FindByIdAsync(command.id);
            if (treatment == null) { throw new Exception("Treatment not found"); }
            try
            {
                treatmentRepository.Remove(treatment);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting treatment");
            }
        }
    }
}
