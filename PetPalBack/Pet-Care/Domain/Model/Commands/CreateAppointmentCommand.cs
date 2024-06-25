namespace PetPalBack.Pet_Care.Domain.Model.Commands
{
    public record CreateAppointmentCommand(string reason, DateTime date, int petId);
 
}
