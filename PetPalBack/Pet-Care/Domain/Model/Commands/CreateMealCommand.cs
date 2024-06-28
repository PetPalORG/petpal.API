namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateMealCommand(string Food, string description, string hour, int petId);
}
