using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IAppointmentCommandService
    {
        Task<Appointment?> Handle(CreateAppointmentCommand command);
        Task Handle(DeleteAppointmentCommand command);
    }
}
