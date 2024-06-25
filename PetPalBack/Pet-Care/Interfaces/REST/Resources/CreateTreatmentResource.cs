namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record CreateTreatmentResource(string Diagnosis, DateTime StartDate, DateTime EndDate, int appointmentId);
}
