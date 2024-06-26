namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record CreateMealResource(string food, string description, string hour, int petId);
    
}
