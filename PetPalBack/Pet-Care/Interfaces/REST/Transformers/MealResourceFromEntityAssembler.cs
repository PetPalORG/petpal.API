using PetPalBack.Pet_Care.Domain.Model.Entities;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class MealResourceFromEntityAssembler
    {
        public static MealResource ToResourceFromEntity(Meal entity)
        {
            return new MealResource(entity.Id, entity.Food, entity.description, entity.hour, PetResourceFromEntityAssembler.ToResourceFromEntity(entity.pet));
        }
    }
}
