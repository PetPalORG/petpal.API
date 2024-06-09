namespace PetPalBack.PetRegister.Interfaces.REST.Resources
{
    public record PetResource(int Id, string Name, string Species, string Breed, DateTime BirthDate, double Weight, int UserId);

}
