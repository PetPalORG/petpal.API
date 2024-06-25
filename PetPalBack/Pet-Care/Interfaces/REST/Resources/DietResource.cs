namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record DietResource(int id, string food, DateTime date, PetResource pet);
}
