namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateAppointmentCommand(string vet, string reason, string detail, DateTime date, string hour, int petId);
 
}
