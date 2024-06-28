using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class MealCommandService(IMealRepository mealRepository, IPetRepository petRepository, IUnitOfWork unitOfWork) : IMealCommandService
    {
        public async Task<Meal?> Handle(CreateMealCommand command)
        {
            var meal = new Meal(command.Food, command.description, command.hour, command.petId);
            await mealRepository.AddAsync(meal);
            await unitOfWork.CompleteAsync();
            var pet = await petRepository.FindByIdAsync(command.petId);
            meal.pet = pet;
            return meal;
        }

        public async Task Handle(DeleteMealCommand command)
        {
            var meal = await mealRepository.FindByIdAsync(command.id);
            if (meal == null) { throw new Exception("Meal not found"); }
            try
            {
                mealRepository.Remove(meal);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting meal");
            }
        }
    }
}
