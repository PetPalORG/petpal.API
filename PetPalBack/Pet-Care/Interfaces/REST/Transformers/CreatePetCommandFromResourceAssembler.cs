using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Interfaces.REST.Resources;

namespace PetPalBack.Pet_Care.Interfaces.REST.Transformers
{
    public static class CreatePetCommandFromResourceAssembler
    {
        public static CreatePetCommand ToCommandFromResource(CreatePetResource command)
        {
            return new CreatePetCommand(command.Name, command.Species, command.Breed, command.BirthDate, command.Weight);
        }
    }
}
