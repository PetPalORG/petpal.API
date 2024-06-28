using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class MealQueryService(IMealRepository mealRepository): IMealQueryService
    {
        public async Task<Meal?> Handle(GetMealByIdQuery query)
        {
            return await mealRepository.FindByIdAsync(query.id);
        }

        public async Task<IEnumerable<Meal>> Handle(GetMealByPetIdQuery query)
        {
            return await mealRepository.FindByPetIdAsync(query.petId);
        }
    }
}
