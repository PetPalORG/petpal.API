namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record CreateMedicationResource(string name, string dosage, string frequency, string duration, int treatmentDetailId);
    
}
