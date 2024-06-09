using PetPalBack.PetRegister.Domain.Model.Aggregates;
using PetPalBack.PetRegister.Domain.Model.Commands;

namespace PetPalBack.PetRegister.Domain.Services
{
    public interface IPetCommandService
    {
        Task<Pet?> Handle(CreatePetCommand command);
    }
}
