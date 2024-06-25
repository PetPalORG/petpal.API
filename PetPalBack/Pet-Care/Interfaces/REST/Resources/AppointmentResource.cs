namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record AppointmentResource(int id, string reason, DateTime date, int petId);
}
