using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class TreatmentDetailsCommandService(ITreatmentDetailsRepository treatmentDetailsRepository, IUnitOfWork unitOfWork): ITreatmentDetailsCommandService
    {
        public async Task<TreatmentDetail?> Handle(CreateTreatmentDetailsCommand command)
        {
            var treatmentDetails = new TreatmentDetail(command);
            try
            {
                await treatmentDetailsRepository.AddAsync(treatmentDetails);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return treatmentDetails;
        }

        public async Task Handle(DeleteTreatmentDetailCommand command)
        {
            var treatmentDetails = await treatmentDetailsRepository.FindByIdAsync(command.id);
            if (treatmentDetails == null) { throw new Exception("TreatmentDetails not found"); }
            try
            {
                treatmentDetailsRepository.Remove(treatmentDetails);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting treatmentDetails");
            }
        }
    }
}
