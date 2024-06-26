namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record CreatePetResource(string Name, string Species, string Breed, int age, double Weight, string imagePath, string description, int userId);
}
