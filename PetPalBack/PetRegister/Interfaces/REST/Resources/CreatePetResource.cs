namespace PetPalBack.PetRegister.Interfaces.REST.Resources
{
    public record CreatePetResource(string Name, string Species, string Breed, DateTime BirthDate, double Weight, int UserId);
}
