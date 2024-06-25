namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record TreatmentResource(int id, string Diagnosis, DateTime StartDate, DateTime EndDate, int AppointmentId);
}
