using PetPalBack.Pet_Care.Domain.Model.Aggregates;
using PetPalBack.Pet_Care.Domain.Model.Queries;

namespace PetPalBack.Pet_Care.Domain.Services
{
    public interface IAppointmentQueryService
    {
        Task<IEnumerable<Appointment>> Handle(GetAllAppointmentsQuery query);
        Task<Appointment?> Handle(GetAppointmentByIdQuery query);
        Task<IEnumerable<Appointment>> Handle(GetAppointmentByPetIdQuery query);
    }
}
