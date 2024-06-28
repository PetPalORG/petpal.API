namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record MedicationResource(int id, string name, string dosage, string indications, int treatmentId);
}
