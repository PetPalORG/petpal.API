using PetPalBack.PetRegister.Domain.Model.Commands;
using PetPalBack.PetRegister.Interfaces.REST.Resources;

namespace PetPalBack.PetRegister.Interfaces.REST.Transformers
{
    public static class CreatePetCommandFromResourceAssembler
    {
        public static CreatePetCommand ToCommandFromResource(CreatePetResource command)
        {
            return new CreatePetCommand(command.Name, command.Species, command.Breed, command.BirthDate, command.Weight, command.UserId);
        }
    }
}
