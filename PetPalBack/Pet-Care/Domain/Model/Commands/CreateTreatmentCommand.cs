namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateTreatmentCommand(string Diagnosis, DateTime StartDate, DateTime EndDate, int AppointmentId);
}
