namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateTreatmentDetailsCommand(int TreatmentId, int MedicationId, int DietId);
}
