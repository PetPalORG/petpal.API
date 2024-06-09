namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateDietCommand(string Food, DateTime Date, int PetId);
}
