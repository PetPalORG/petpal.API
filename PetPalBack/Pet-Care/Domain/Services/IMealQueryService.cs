using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IMealQueryService
    {
        Task<Meal?> Handle(GetMealByIdQuery query);
        Task<IEnumerable<Meal>> Handle(GetMealByPetIdQuery query);
    }
}
