using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;
using PetPalBack.Pet_Care.Domain.Repositories;
using PetPalBack.Pet_Care.Domain.Services;

namespace PetPalBack.Pet_Care.Application.Internal.QueryServices
{
    public class AppointmentQueryService(IAppointmentRepository appointmentRepository): IAppointmentQueryService
    {
        public async Task<Appointment?> Handle(GetAppointmentByIdQuery query)
        {
            return await appointmentRepository.FindByIdAsync(query.id);
        }

        public async Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery query)
        {
            return await appointmentRepository.ListAsync();
        }

        public async Task<IEnumerable<Appointment>> Handle(GetAppointmentByPetIdQuery query)
        {
            return await appointmentRepository.FindByPetIdAsync(query.petId);
        }
    }
}
