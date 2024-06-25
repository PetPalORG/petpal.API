using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class PetCommandService(IPetRepository petRepository, IUnitOfWork unitOfWork) : IPetCommandService
    {
        public async Task<Pet?> Handle(CreatePetCommand command)
        {
            var pet = await petRepository.FindByNameAsync(command.Name);
            if (pet != null) { throw new Exception("Pet already exists"); }
            pet = new Pet(command);
            try
            {
                await petRepository.AddAsync(pet);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return pet;
        }

        public async Task Handle(DeletePetCommand command)
        {
            var pet = await petRepository.FindByIdAsync(command.id);
            if (pet == null) { throw new Exception("Pet not found"); }
            try
            {
                petRepository.Remove(pet);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting pet");
            }
        }
    }
}
