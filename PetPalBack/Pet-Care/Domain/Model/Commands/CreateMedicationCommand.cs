namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateMedicationCommand(string Name, string Dosage, string Frequency, string Duration);
}
