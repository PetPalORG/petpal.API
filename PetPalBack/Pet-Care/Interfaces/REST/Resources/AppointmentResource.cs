namespace PetPalBack.Pet_Care.Interfaces.REST.Resources
{
    public record AppointmentResource(int id, string vet, string reason, string detail, DateTime date, string hour, int petId);
}
