using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public class CreateDietCommandFromResourceAssembler
    {
        public static CreateDietCommand ToCommandFromResource(CreateDietResource resource)
        {
            return new CreateDietCommand(resource.food, resource.date);
        }
    }
}
