namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateVaccineCommand(string Type, DateTime Date, int PetId, int TreatmentId);
}
