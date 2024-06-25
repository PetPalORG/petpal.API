namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record CreateAppointmentResource(string reason, DateTime date, int petId);
}
