using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IMealCommandService
    {
        Task<Meal?> Handle(CreateMealCommand command);
        Task Handle(DeleteMealCommand command);
    }
}
