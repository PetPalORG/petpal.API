namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreatePetCommand(string Name, string Species, string Breed, DateTime BirthDate, double Weight);
}
