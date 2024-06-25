using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IDietCommandService
    {
        Task<Diet?> Handle(CreateDietCommand command);
        Task Handle(DeleteDietCommand command);
    }
}
