namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreatePetCommand(string Name, string Species, string Breed, int age, double Weight, string imagePath, string description, int userId);
}
