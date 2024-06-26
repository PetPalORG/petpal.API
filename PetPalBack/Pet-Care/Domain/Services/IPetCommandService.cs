using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IPetCommandService
    {
        Task<Pet?> Handle(CreatePetCommand command);
        Task Handle(DeletePetCommand command);
    }
}
