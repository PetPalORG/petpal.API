using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class CreateMealCommandFromResourceAssembler
    {
        public static CreateMealCommand ToCommandFromResource(CreateMealResource resource)
        {
            return new CreateMealCommand(resource.food, resource.description, resource.hour, resource.petId);
        }
    }
}
