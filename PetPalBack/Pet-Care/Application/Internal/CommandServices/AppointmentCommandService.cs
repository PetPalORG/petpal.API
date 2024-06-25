using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Commands;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;
using PetPalBack.Shared.Domain.Repositories;

namespace PetPalBack.Pet_Care.Application.Internal.CommandServices
{
    public class AppointmentCommandService(IAppointmentRepository appointmentRepository, IUnitOfWork unitOfWork): IAppointmentCommandService
    {
        public async Task<Appointment?> Handle(CreateAppointmentCommand command)
        {
            var appointment = new Appointment(command);
            try
            {
                await appointmentRepository.AddAsync(appointment);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                return null;
            }
            return appointment;
        }

        public async Task Handle(DeleteAppointmentCommand command)
        {
            var appointment = await appointmentRepository.FindByIdAsync(command.id);
            if (appointment == null) { throw new Exception("Appointment not found"); }
            try
            {
                appointmentRepository.Remove(appointment);
                await unitOfWork.CompleteAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Error deleting appointment");
            }
        }
    }
}
