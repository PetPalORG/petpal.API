using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.PetRegister.Domain.Model.Commands;
using PetPalBack.PetRegister.Domain.Repositories;
using PetPalBack.PetRegister.Domain.Services;
using PetPalBack.shared.Domain.Repositories;

namespace PetPalBack.PetRegister.Application.Internal.CommandServices
{
    public class PetCommandService(IPetRepository petRepository, IUnitOfWork unitOfWork) : IPetCommandService
    {
        public async Task<Pet?> Handle(CreatePetCommand command)
        {
            var pet = await petRepository.FindByNameAsync(command.Name);
            if(pet != null) { throw new Exception("Pet already exists"); }
            pet = new Pet(command);
            try
            {
                await petRepository.AddAsync(pet);
                await unitOfWork.CompleteAsync();
            }
            catch(Exception ex)
            {
                return null;
            }
            return pet;
        }
    }
}
