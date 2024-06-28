namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record MealResource(int id, string food, string description, string hour, PetResource pet);
}
